using System.Text.Json.Serialization;

namespace ApiProject.Models
{
    public class QuestionAnswer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        [JsonIgnore]
        public Question Question { get; set; }
    }
}
