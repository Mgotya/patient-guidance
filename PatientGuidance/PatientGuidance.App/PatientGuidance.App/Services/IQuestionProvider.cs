using System.Collections.Generic;
using System.Threading.Tasks;
using PatientGuidance.App.Models;

namespace PatientGuidance.App.Services
{
    public interface IQuestionProvider
    {
        Task<IEnumerable<Question>> GetGastroPrerequisiteQuestionsAsync();
    }

    public class TempQuestionProvider : IQuestionProvider
    {
        public Task<IEnumerable<Question>> GetGastroPrerequisiteQuestionsAsync()
            => Task.Run(() => new List<Question>
            {
                new Question("האם יש לך סכרת?"),
                new Question("האם יש לך עצירות כרונית?"),
                new Question("האם אתה נוטל תרופות נגד כאבים?")
            } as IEnumerable<Question>);
    }
}
