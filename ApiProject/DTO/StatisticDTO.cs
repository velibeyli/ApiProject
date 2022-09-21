using ApiProject.Models.Admin;

namespace ApiProject.DTO
{
    public class StatisticDTO
    {
        public DateTime GameDate { get; set; }
        public int Score { get; set; }
        public StatisticDTO(Statistic statistic)
        {
            GameDate = statistic.GameDate;
            Score = statistic.Score;
        }
        public StatisticDTO()
        {

        }
    }
}
