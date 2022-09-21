using ApiProject.DTO;
using ApiProject.Wrappers;

namespace ApiProject.Services.Interfaces
{
    public interface ILoginService
    {
        Task<ServiceResponse<LoginDTO>> Login(LoginDTO loginDto);
    }
}
