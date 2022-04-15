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
using Business.Services;
using BCrypt.Net;
namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UMSDatabaseContext _context;
        private JWTService _jwtService;
        private UserService _userService;

        public UsersController(UMSDatabaseContext context, JWTService jwtService, UserService userService)
        {
            _context = context;
            _jwtService = jwtService;
            _userService = userService;
        }
        
        [HttpGet()]
        [AllowAnonymous]
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        [AllowAnonymous]
        [HttpPost()]
        public int AddUser(AddUserRequest request)
        {
            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = request.Role
            };
            
            _context.Users.Add(user);
            _context.SaveChanges();

            return user.Id;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public string Authenticate(LoginRequest request)
        {
            return _userService.Login(request.Username,request.Password);
        }
    }
}