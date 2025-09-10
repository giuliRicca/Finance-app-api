
using Finance_Api.Core.DTOs;
using Finance_Api.Core.Entities;
using Finance_Api.Core.Interfaces;
using Finance_Api.Infrastructure.Data;
using Finance_Api.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Finance_Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly FinanceTrackerDbContext _dbContext;
        private readonly IPasswordHasher<User> _hasher;
        private readonly ITokenService _tokenService;

        public AuthController(FinanceTrackerDbContext dbContext, IPasswordHasher<User> hasher, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _hasher = hasher;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto dto, CancellationToken cancellationToken)
        {
            if(await _dbContext.Users.AnyAsync(u => u.Email == dto.Email, cancellationToken))
            {
                return Conflict("Email already registered.");
            }

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                CreatedDate = DateTime.UtcNow
            };
            user.HashPassword = _hasher.HashPassword(user, dto.Password);

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var token = _tokenService.Create(user);
            return Ok(new {access_token = token});
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null) return Unauthorized("Invalid Credentials.");

            var passwordCheckResult = _hasher.VerifyHashedPassword(user, user.HashPassword, dto.Password);
            if (passwordCheckResult == PasswordVerificationResult.Failed) return Unauthorized("Invalid Credentials.");

            var token = _tokenService.Create(user);
            return Ok(new { access_token = token });
        }


        [HttpGet("me")]
        public async Task<IActionResult> Me(CancellationToken cancellationToken)
        {
            var sub = User.FindFirstValue(JwtRegisteredClaimNames.Sub) ?? User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (sub == null) return Unauthorized();

            var userId = int.Parse(sub);
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null) return NotFound();

            return Ok(new { user.Id, user.Name, user.Email, user.CreatedDate });

        }
    }
}
