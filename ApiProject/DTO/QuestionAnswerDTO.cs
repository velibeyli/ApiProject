using ApiProject.Models;

namespace ApiProject.DTO
{
    public class QuestionAnswerDTO
    {
        public string Content { get; set; }
        public QuestionAnswerDTO(QuestionAnswer answer)
        {
            Content = answer.Content;
        }
        public QuestionAnswerDTO()
        {

        }
    }
}
