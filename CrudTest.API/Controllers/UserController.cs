using AutoMapper;
using CrudTest.API.Entities;
using CrudTest.API.Helpers;
using CrudTest.API.Interfaces;
using CrudTest.API.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudTest.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, RoleManager<IdentityRole> roleManager, IMapper mapper, ILogger<UserController> logger)
        {
            _userService = userService;
            _roleManager = roleManager;
            _mapper = mapper;
            _logger = logger;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]       
        public async Task<ActionResult<PaginatedResponse<UsersDto>>> GetUsers(
            [FromQuery] UserParams userParams)
        {
            var data = await _userService.GetAllUsers(userParams);
            
            var count = await data.CountAsync();
            
            var result = data.Skip(userParams.PageSize * (userParams.PageIndex - 1)).Take(userParams.PageSize).ToList();

            var users = _mapper.Map<List<UsersDto>>(result);

            _logger.LogInformation("Users retreived");

            return Ok(new PaginatedResponse<UsersDto>(userParams.PageIndex, userParams.PageSize, count, users));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            _userService.DeleteUser(id);

            _logger.LogInformation("User deleted");

            return Ok();
        }
    }
}
