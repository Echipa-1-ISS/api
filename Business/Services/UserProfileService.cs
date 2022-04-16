using Business.DTOs;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services {
    public class UserProfileService {
        private UMSDatabaseContext _context;

        public UserProfileService(UMSDatabaseContext context) {
            _context = context;
        }

        public UserProfileDetails GetUserDetails(int UserId) {

            if (_context.Users.FirstOrDefault(u => u.Id == UserId) is null)
                throw new Exception("User doesn't exist!");

            var userProfile = _context.UserProfiles.FirstOrDefault(p => p.UserId == UserId);

            if (userProfile == null)
                throw new Exception("UserProfile doesn't exist!");

            return new UserProfileDetails {
                Age = userProfile.Age,
                Email = userProfile.Email,
                ProfileImageUrl = userProfile.ProfileImageUrl,
                Fullname = userProfile.Fullname
            };
        }
    }
}
