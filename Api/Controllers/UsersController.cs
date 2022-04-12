using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Api.Attributes;
using Api.Requests;
using Data;
using Data.models;
using Data.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UMSDatabaseContext _context;
        private JWTService _jwtService;

        public UsersController(UMSDatabaseContext context, JWTService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }
        
        [HttpGet()]
        [AuthorizeRoles(Roles.Admin)]
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        [AuthorizeRoles(Roles.Admin)]
        [HttpPost()]
        public int AddUser(AddUserRequest request)
        {
            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                Password = request.Password,
                Role = request.Role
            };
            
            _context.Users.Add(user);
            _context.SaveChanges();

            return user.Id;
        }

        [AllowAnonymous]
        [HttpPost("/login")]
        public string Authenticate()
        {
            return _jwtService.GenerateJWT(new User
            {
                Role = Roles.Admin,
                Email = "test@test.com",
                Username = "test"
            });
        }
    }
}