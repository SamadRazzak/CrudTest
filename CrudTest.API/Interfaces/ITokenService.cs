using CrudTest.API.Entities;

namespace CrudTest.API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
