using ApiProject.Models;

namespace ApiProject.DTO
{
    public class CategoryDTO
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public CategoryDTO(Category category)
        {
            Name = category.Name;
            Score = category.Score;
        }
        public CategoryDTO()
        {

        }
    }
}
