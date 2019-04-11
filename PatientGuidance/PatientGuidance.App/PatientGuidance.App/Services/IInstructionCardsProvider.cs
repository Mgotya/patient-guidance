using System.Collections.Generic;
using System.Linq;
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
            => Task.Run(() =>
            {
                if (Settings.IsGastro)
                {
                    return Settings.IsSpecial ? GetGastroSpecialState() : GetGastroDefaultTemplate();
                }

                return GetBurnCards();
            });

        private IEnumerable<Card> GetBurnCards()
        {
            return Enumerable.Empty<Card>();
        }

        private IEnumerable<Card> GetGastroDefaultTemplate()
        {
            yield return FirstGastroCards();
            yield return LastGastroCards();
        }

        private IEnumerable<Card> GetGastroSpecialState()
        {
            yield return FirstGastroCards();
            yield return LastGastroCards();
        }

        private Card FirstGastroCards()
        {
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

            return firstCard;
        }

        private Card LastGastroCards()
        {
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

            return last;
        }
    }
}
