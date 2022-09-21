using ApiProject.DTO;
using ApiProject.Services.Interfaces;
using ApiProject.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
        private readonly IAdminUserService _adminService;
        public AdminUserController(IAdminUserService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<AdminUserDTO>>>> GetAll() =>
            Ok(await _adminService.GetAll());

        [HttpGet("getById")]
        public async Task<ActionResult<ServiceResponse<AdminUserDTO>>> GetByName(int id) =>
            Ok(await _adminService.GetById(id));

        [HttpPost("create")]
        public async Task<ActionResult<ServiceResponse<AdminUserDTO>>> Create(AdminUserDTO adminUserDto) =>
            Ok(await _adminService.Create(adminUserDto));

        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<AdminUserDTO>>> Update(int id, AdminUserDTO adminUserDto) =>
            Ok(await _adminService.Update(id,adminUserDto));

        [HttpDelete("delete")]
        public async Task<ActionResult<ServiceResponse<AdminUserDTO>>> Delete(AdminUserDTO adminUserDto) =>
            Ok(await _adminService.Delete(adminUserDto));
    }
}
