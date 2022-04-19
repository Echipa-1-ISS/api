using Api.Requests;
using Business.DTOs;
using Business.Services;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase {

        private UMSDatabaseContext _context;
        private UserProfileService _service;

        public UserProfileController(UserProfileService service, UMSDatabaseContext context) {
            _service = service;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost()]
        public int AddUserProfile(AddUserProfileRequest request) {
            var userProfile = new UserProfile {
                Age = request.Age,
                Email = request.Email,
                Fullname = request.Fullname,
                UserId = request.UserId,
                ProfileImageUrl = request.ProfileImageUrl
            };

            _context.UserProfiles.Add(userProfile);
            _context.SaveChanges();

            return userProfile.Id;
        }

        [HttpGet()]
        [AllowAnonymous]
        public UserProfileDetails GetUserDetails(int UserId) {
            return _service.GetUserDetails(UserId);
        }
    }
}
