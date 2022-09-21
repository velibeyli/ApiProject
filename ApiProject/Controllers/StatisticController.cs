using ApiProject.DTO;
using ApiProject.Repositories.Interfaces;
using ApiProject.Services.Interfaces;
using ApiProject.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticService _statisticService;
        public StatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<StatisticDTO>>>> GetAll() =>
            Ok(await _statisticService.GetAll());

        [HttpGet("getById")]
        public async Task<ActionResult<ServiceResponse<StatisticDTO>>> GetById(int id) =>
            Ok(await _statisticService.GetById(id));

        [HttpPost("create")]
        public async Task<ActionResult<ServiceResponse<StatisticDTO>>> Create(StatisticDTO statisticDto) =>
            Ok(await _statisticService.Create(statisticDto));

        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<StatisticDTO>>> Update(int id, StatisticDTO statisticDto) =>
            Ok(await _statisticService.Update(id,statisticDto));

        [HttpDelete("delete")]
        public async Task<ActionResult<ServiceResponse<StatisticDTO>>> Delete(int id) =>
            Ok(await _statisticService.Delete(id));
    }
}
