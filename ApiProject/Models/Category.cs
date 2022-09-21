using System.Text.Json.Serialization;

namespace ApiProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        [JsonIgnore]
        public IEnumerable<Question>? Questions { get; set; }
    }
}
