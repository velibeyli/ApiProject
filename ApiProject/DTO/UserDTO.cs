using ApiProject.Models;

namespace ApiProject.DTO
{
    public class UserDTO
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserDTO(User user)
        {
            Firstname = user.Firstname;
            Lastname = user.Lastname;
            Username = user.Username;
            Password = user.Password;
        }
        public UserDTO()
        {

        }
    }
}
