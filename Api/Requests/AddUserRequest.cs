using Data.Models;

namespace Api.Requests;

public class AddUserRequest
{
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Roles Role { get; set; } 
}