using ApiProject.DTO;
using ApiProject.Services.Interfaces;
using ApiProject.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<LoginDTO>>> Login([FromQuery]LoginDTO loginDto) =>
            Ok(await _loginService.Login(loginDto));
    }
}
