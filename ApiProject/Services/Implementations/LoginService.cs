using ApiProject.DTO;
using ApiProject.Repositories.Interfaces;
using ApiProject.Services.Interfaces;
using ApiProject.Validation;
using ApiProject.Wrappers;
using FluentValidation;

namespace ApiProject.Services.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepo;
        public LoginService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<ServiceResponse<LoginDTO>> Login(LoginDTO loginDto)
        {
            LoginValidator validator = new LoginValidator();
            await validator.ValidateAndThrowAsync(loginDto);

            var result = await _userRepo.GetByFilter(x => x.Username == loginDto.Username && x.Password == loginDto.Password);
            if(result is null)
            {
                return new ServiceResponse<LoginDTO>(null)
                { Message = "Username and Password is not valid", StatusCode = 4000 };
            }

            var resultDto = new LoginDTO(result);
            return new ServiceResponse<LoginDTO>(resultDto)
            { Message = "Successfully login", StatusCode = 2000 };
        }
    }
}
