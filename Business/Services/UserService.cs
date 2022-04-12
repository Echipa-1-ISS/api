using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

using Data;
using Data.models;
using Infrastructure.Services;
using Business;


namespace Business.Services;
public class UserService {
    private UMSDatabaseContext _context;
    private JWTService _jWTService;

    public UserService(UMSDatabaseContext context, JWTService jWTService) {
        _context = context;
        _jWTService = jWTService;
    }

    public string Login(string username, string password) {
        User user = _context.Users.Where(u => u.Username == username).FirstOrDefault();

        if (user == null) {
            throw new Exception("Username doesn't exist!");
        }

        if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            throw new Exception("Incorrect password!");


        return _jWTService.GenerateJWT(user);
    }
}
