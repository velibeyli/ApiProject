using ApiProject.DTO;
using ApiProject.Wrappers;

namespace ApiProject.Services.Interfaces
{
    public interface IStatisticService
    {
        Task<ServiceResponse<IEnumerable<StatisticDTO>>> GetAll();
        Task<ServiceResponse<StatisticDTO>> GetById(int id);
        Task<ServiceResponse<StatisticDTO>> Create(StatisticDTO statisticDto);
        Task<ServiceResponse<StatisticDTO>> Delete(int id);
        Task<ServiceResponse<StatisticDTO>> Update(int id, StatisticDTO statisticDto);
    }
}
