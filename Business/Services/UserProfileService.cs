using Business.DTOs;
using Data;
using Data.models;
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
            var userProfile = _context.UserProfiles.FirstOrDefault(p => p.UserId == UserId);

            if (userProfile == null)
                throw new Exception("User doesn't exist!");

            return new UserProfileDetails {
                Age = userProfile.Age,
                Email = userProfile.Email,
                ProfileImageUrl = userProfile.ProfileImageUrl,
                Fullname = userProfile.Fullname
            };
        }

        public bool UpdateUserProfile(int UserId, string Fullname, int Age, string ImageURL) {
            var userProfile = _context.UserProfiles.FirstOrDefault(u => u.UserId == UserId);

            if (Fullname == "" || Age < 14)
                throw new Exception("Invalid input!");

            userProfile.Fullname = Fullname;
            userProfile.Age = Age;
            userProfile.ProfileImageUrl = ImageURL;
            _context.UserProfiles.Update(userProfile);
            _context.SaveChanges();
          
            return true;
        }
    }
}
