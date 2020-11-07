using TeamSearch.Models;

namespace TeamSearch.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}