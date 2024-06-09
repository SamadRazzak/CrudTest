using CrudTest.API.Entities;
using CrudTest.API.Models.DTOs;

namespace CrudTest.API.Interfaces
{
    public interface IUserService
    {
        Task<IQueryable<User>> GetAllUsers(UserParams userParams); 
        void DeleteUser(string userId);
    }
}
