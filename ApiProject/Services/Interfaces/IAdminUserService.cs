using ApiProject.DTO;
using ApiProject.Wrappers;

namespace ApiProject.Services.Interfaces
{
    public interface IAdminUserService
    {
        Task<ServiceResponse<IEnumerable<AdminUserDTO>>> GetAll();
        Task<ServiceResponse<AdminUserDTO>> GetById(int id);
        Task<ServiceResponse<AdminUserDTO>> Create(AdminUserDTO adminUserDto);
        Task<ServiceResponse<AdminUserDTO>> Update(int id,AdminUserDTO adminUserDto);
        Task<ServiceResponse<AdminUserDTO>> Delete(AdminUserDTO adminUserDto);
    }
}
