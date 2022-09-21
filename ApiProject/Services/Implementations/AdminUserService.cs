using ApiProject.DTO;
using ApiProject.Models.Admin;
using ApiProject.Repositories.Interfaces;
using ApiProject.Services.Interfaces;
using ApiProject.Wrappers;

namespace ApiProject.Services.Implementations
{
    public class AdminUserService : IAdminUserService
    {
        private readonly IAdminUserRepository _adminRepo;
        public AdminUserService(IAdminUserRepository adminRepo)
        {
            _adminRepo = adminRepo;
        }

        public async Task<ServiceResponse<AdminUserDTO>> Create(AdminUserDTO adminUserDto)
        {
            var result = await _adminRepo.GetByFilter(x => x.Username == adminUserDto.Username);
            if(result is not null)
            {
                return new ServiceResponse<AdminUserDTO>(null)
                { Message = "There is already such username with this name in database!",StatusCode = 4000 };
            }

            AdminUser adminUser = new AdminUser()
            {
                Username = adminUserDto.Username,
                Password = adminUserDto.Password
            };

            var createdAdminUser = await _adminRepo.Create(adminUser);
            var createdAdminDto = new AdminUserDTO(createdAdminUser);

            return new ServiceResponse<AdminUserDTO>(createdAdminDto)
            { Message = "Admin was successfully created!", StatusCode = 2001 };
        }

        public async Task<ServiceResponse<AdminUserDTO>> Delete(AdminUserDTO adminUserDto)
        {
            var result = await _adminRepo.GetByFilter(x => x.Username == adminUserDto.Username);
            if(result is null)
            {
                return new ServiceResponse<AdminUserDTO>(null)
                { Message = "There is not any username with this name in database!", StatusCode = 4000 };
            }

            var deletedAdmin = await _adminRepo.Delete(result);
            var deletedAdminDto = new AdminUserDTO(deletedAdmin);

            return new ServiceResponse<AdminUserDTO>(deletedAdminDto)
            { Message = "Admin was successfully deleted from database", StatusCode = 2000 };
        }

        public async Task<ServiceResponse<IEnumerable<AdminUserDTO>>> GetAll()
        {
            List<AdminUser> adminUsers = await _adminRepo.GetAll();
            List<AdminUserDTO> adminUserDto = adminUsers.Select(x => new AdminUserDTO(x)).ToList();

            return new ServiceResponse<IEnumerable<AdminUserDTO>>(adminUserDto)
            { Message = "Successfull operation!", StatusCode = 2000 };
        }

        public async Task<ServiceResponse<AdminUserDTO>> GetById(int id)
        {
            var result = await _adminRepo.GetByFilter(x => x.Id == id);
            if(result is null)
            {
                return new ServiceResponse<AdminUserDTO>(null)
                { Message = "There is not any username with this id in database", StatusCode = 4000 };
            }

            var adminDto = new AdminUserDTO(result);

            return new ServiceResponse<AdminUserDTO>(adminDto)
            { Message = "Successfull operation!", StatusCode = 2000 };
        }

        public async Task<ServiceResponse<AdminUserDTO>> Update(int id,AdminUserDTO adminUserDto)
        {
            var result = await _adminRepo.GetByFilter(x => x.Username == adminUserDto.Username);
            if (result is null)
            {
                return new ServiceResponse<AdminUserDTO>(null)
                { Message = "There is not any username with this name in database", StatusCode = 4000 };
            }

            AdminUser adminUser = new AdminUser()
            {
                Id = id,
                Username = adminUserDto.Username,
                Password = adminUserDto.Password
            };

            var updatedAdmin = await _adminRepo.Update(adminUser);
            var updatedAdminDto = new AdminUserDTO(updatedAdmin);

            return new ServiceResponse<AdminUserDTO>(updatedAdminDto)
            { Message = "Admin was successfully updated", StatusCode = 2000 };
        }
    }
}
