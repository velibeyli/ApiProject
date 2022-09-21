using ApiProject.Models.Admin;

namespace ApiProject.DTO
{
    public class AdminUserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public AdminUserDTO(AdminUser adminUser)
        {
            Username = adminUser.Username;
            Password = adminUser.Password;
        }
        public AdminUserDTO()
        {

        }
    }
}
