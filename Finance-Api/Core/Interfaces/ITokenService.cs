using Finance_Api.Core.Entities;

namespace Finance_Api.Core.Interfaces
{
    public interface ITokenService
    {
        string Create(User user, IEnumerable<string>? roles = null);
    }
}
