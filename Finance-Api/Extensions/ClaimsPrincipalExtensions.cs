using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Finance_Api.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string? Sub(this ClaimsPrincipal user) => user.FindFirstValue("sub");
        public static string? Email(this ClaimsPrincipal user) => user.FindFirstValue("emails");
        public static string? Name(this ClaimsPrincipal user) => user.FindFirstValue("name");

    }
}