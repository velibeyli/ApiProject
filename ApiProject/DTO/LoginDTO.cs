using ApiProject.Models;

namespace ApiProject.DTO
{
    public class LoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public LoginDTO(User user)
        {
            Username = user.Username;
            Password = user.Password;
        }
        public LoginDTO()
        {

        }
    }
}
