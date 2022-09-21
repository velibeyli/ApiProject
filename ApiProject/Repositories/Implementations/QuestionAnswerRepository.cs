using ApiProject.Db;
using ApiProject.Models;
using ApiProject.Repositories.Interfaces;

namespace ApiProject.Repositories.Implementations
{
    public class QuestionAnswerRepository : GenericRepository<QuestionAnswer>, IQuestionAnswerRepository
    {
        public QuestionAnswerRepository(ProjectContext context) : base(context)
        {
        }
    }
}
