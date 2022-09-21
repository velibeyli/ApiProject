using ApiProject.DTO;
using ApiProject.Models.Admin;
using ApiProject.Repositories.Interfaces;
using ApiProject.Services.Interfaces;
using ApiProject.Wrappers;

namespace ApiProject.Services.Implementations
{
    public class StatisticService : IStatisticService
    {
        private readonly IStatisticRepository _statisticRepo;
        public StatisticService(IStatisticRepository statisticRepo)
        {
            _statisticRepo = statisticRepo;
        }

        public async Task<ServiceResponse<StatisticDTO>> Create(StatisticDTO statisticDto)
        {
            var result = await _statisticRepo.GetAll(x => x.GameDate == statisticDto.GameDate);
            if(result is not null)
            {
                return new ServiceResponse<StatisticDTO>(null)
                { Message = "There is already such statistic in this date in database!", StatusCode = 4000 };
            }

            Statistic statistic = new Statistic()
            {
                GameDate = statisticDto.GameDate,
                Score = statisticDto.Score
            };

            var createdStatistic = await _statisticRepo.Create(statistic);
            var createdStatisticDto = new StatisticDTO(createdStatistic);

            return new ServiceResponse<StatisticDTO>(createdStatisticDto)
            { Message = "Statistics was successfully created", StatusCode = 2001 };
        }

        public async Task<ServiceResponse<StatisticDTO>> Delete(int id)
        {
            var result = await _statisticRepo.GetByFilter(x => x.Id == id);
            if(result is null)
            {
                return new ServiceResponse<StatisticDTO>(null)
                { Message = "There is not any Statistics with this id in database!", StatusCode = 4000 };
            }

            var deletedStatistic = await _statisticRepo.Delete(result);
            var deletedStatisticDto = new StatisticDTO(deletedStatistic);

            return new ServiceResponse<StatisticDTO>(deletedStatisticDto)
            { Message = "Statistics was successfully deleted from database!", StatusCode = 2000 };
        }

        public async Task<ServiceResponse<IEnumerable<StatisticDTO>>> GetAll()
        {
            List<Statistic> statistics = await _statisticRepo.GetAll();
            List<StatisticDTO> statisticDtos = statistics.Select(x => new StatisticDTO(x)).ToList();

            return new ServiceResponse<IEnumerable<StatisticDTO>>(statisticDtos)
            { Message = "Successfull operation!", StatusCode = 2000 };
        }

        public async Task<ServiceResponse<StatisticDTO>> GetById(int id)
        {
            var result = await _statisticRepo.GetByFilter(x => x.Id == id);
            if(result is null)
            {
                return new ServiceResponse<StatisticDTO>(null)
                { Message = "There is not any Statistics with this id in database!", StatusCode = 4000 };
            }

            var statisticDto = new StatisticDTO(result);

            return new ServiceResponse<StatisticDTO>(statisticDto)
            { Message = "Successfull operation!", StatusCode = 2000 };
        }

        public async Task<ServiceResponse<StatisticDTO>> Update(int id, StatisticDTO statisticDto)
        {
            var result = await _statisticRepo.GetByFilter(x => x.Id == id);
            if (result is null)
            {
                return new ServiceResponse<StatisticDTO>(null)
                { Message = "There is not any Statistics with this id in database!", StatusCode = 4000 };
            }

            Statistic statistic = new Statistic()
            {
                Id = id,
                GameDate = statisticDto.GameDate,
                Score = statisticDto.Score
            };

            var updatedStatistic = await _statisticRepo.Update(statistic);
            var updatedStatisticDto = new StatisticDTO(updatedStatistic);

            return new ServiceResponse<StatisticDTO>(updatedStatisticDto)
            { Message = "Statistic was susccessfully updated", StatusCode = 2000 };
        }
    }
}
