using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PatientGuidance.App.Common;

namespace PatientGuidance.App.Services
{
    public interface IInstructionCardsProvider
    {
        Task<IEnumerable<Card>> GetRelevantCardsAsync();
    }

    internal class StaticCardsProvider : IInstructionCardsProvider
    {
        public Task<IEnumerable<Card>> GetRelevantCardsAsync()
            => Task.Run(() => GetGastroDefaultTemplate());

        private IEnumerable<Card> GetGastroDefaultTemplate()
        {
            var cards = new List<Card>();

            var firstContent = new StringBuilder("האם נוטל תרופות לקרישת דם?");
            firstContent.AppendLine("לא");
            firstContent.AppendLine("כן-נא להתייעץ עם הרופא המטפל לגבי מועד הפסקת התרופה.");
            firstContent.AppendLine("האם נוטל תכשירי ברזל?");
            firstContent.AppendLine("לא");
            firstContent.AppendLine("כן-יש להפסיק לקחת שבוע לפני הבדיקה");

            var firstCard = new Card
            {
                Title = Settings.SelectedDate.AddDays(-7).ToShortDateString(),
                Type = CardType.Default,
                Content = firstContent.ToString(),
                SubContent = "יש לקבוע פגישה עם רופא המשפחה למרשם תרופות הכנה (פיקולוקס)"
            };


            var lastContent = new StringBuilder("אין לאכול עד הבדיקה עצמה");
            lastContent.AppendLine("מותר לשתות: מים, נוזלים צלולים (מרק, מיץ דליל, תה)");

            var sub = new StringBuilder("מה להביא:");
            sub.AppendLine("להביא מלווה (אין לנהוג 12 שעות לאחר הבדיקה)");
            sub.AppendLine("תעודה מזהה");
            sub.AppendLine("מכתב הפניה");
            
            var last = new Card
            {
                Title = Settings.SelectedDate.ToShortDateString(),
                Type = CardType.Default,
                Content = lastContent.ToString(),
                SubContent = sub.ToString()
            };

            cards.Add(firstCard);
            cards.Add(last);


            return cards;
        }
    }
}
