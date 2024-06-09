using CrudTest.API.Data;
using CrudTest.API.Entities;
using CrudTest.API.Interfaces;
using CrudTest.API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudTest.API.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void DeleteUser(string userId)
        {
           var user = _context.Users.Find(userId);
            if (user == null) {
                throw new Exception("User not found.");
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public async Task<IQueryable<User>> GetAllUsers(UserParams userParams)
        {            
            var users = _context.Users.Where(x => userParams.Search != null && userParams.Search != "" ?
                (x.FirstName.Contains(userParams.Search) || x.LastName.Contains(userParams.Search) || x.Email.Contains(userParams.Search)) : true);

            if (!string.IsNullOrEmpty(userParams.Sort))
            {
                switch (userParams.Sort)
                {
                    case "email":
                        users = userParams.SortType == "asc" ? users.OrderBy(x => x.Email) : users.OrderByDescending(x => x.Email);
                        break;
                    case "firstName":
                        users = userParams.SortType == "asc" ? users.OrderBy(x => x.FirstName) : users.OrderByDescending(x => x.FirstName);
                        break;
                    case "lastName":
                        users = userParams.SortType == "asc" ? users.OrderBy(x => x.LastName) : users.OrderByDescending(x => x.LastName);
                        break;
                }
            }

            return users;
        }
    }
}
