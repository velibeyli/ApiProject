using ApiProject.Models.Admin;

namespace ApiProject.DTO
{
    public class WinnerDTO
    {
        public DateTime WinningDate { get; set; }
        public int Score { get; set; }
        public int CorrectAnswer { get; set; }
        public int UserId { get; set; }
        public WinnerDTO(Winner winner)
        {
            WinningDate = winner.WinningDate;
            Score = winner.Score;
            CorrectAnswer = winner.CorrectAnswer;
            UserId = winner.UserId;
        }
        public WinnerDTO()
        {

        }
    }
}
