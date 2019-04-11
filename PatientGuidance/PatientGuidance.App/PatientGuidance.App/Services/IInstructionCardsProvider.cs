using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientGuidance.App.Common;
using Xamarin.Forms;

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
            yield return SecondGastroCard();
            yield return DayBeforGastroCard();
            yield return LastGastroCards();
        }

        private IEnumerable<Card> GetGastroSpecialState()
        {
            yield return FirstGastroCards();
            yield return SecondGastroCard();
            yield return DayBeforGastroCard();
            yield return LastGastroCards();
        }

        private Card FirstGastroCards()
        {
            var firstCard = new Card
            {
                Title = Settings.SelectedDate.AddDays(-7).ToString("dd-MM"),
                Type = CardType.GastroQuestions,
                Questions = new Dictionary<string, List<string>>
                {
                    {"האם נוטל תרופות לקרישת דם?", new List<string>{"לא","כן-נא להתייעץ עם הרופא המטפל לגבי מועד הפסקת התרופה."}},
                    {"האם נוטל תכשירי ברזל?",new List<string>{ "לא" , "כן-יש להפסיק לקחת שבוע לפני הבדיקה"} }
                },
                SubContent = "יש לקבוע פגישה עם רופא המשפחה למרשם תרופת הכנה"
            };

            return firstCard;
        }

        private Card SecondGastroCard()
        {
            return new Card
            {
                Title = Settings.SelectedDate.AddDays(-3).ToString("dd-MM"),
                Type = CardType.GastroYesNo,
                Questions = new Dictionary<string, List<string>>
                {
                    {"מותר", new List<string>{"לחם לבן","מוצרי חלב","ביצים","דגים","עוף","פסטה","מים","תה","קפה"} },
                    {"אסור", new List<string>{"לחם מלא","פירות וירקות","דגנים מלאים","בשר","מיצי פירות וירקות"} },
                }
            };
        }

        private Card DayBeforGastroCard()
        {
            if (Settings.SelectedHour < 11)
                return new Card
                {
                    Title = Settings.SelectedDate.AddDays(-1).ToString("dd-MM"),
                    Type = CardType.GastroTimeLine,
                    Questions = new Dictionary<string, List<string>>
                    {
                        {"13:00", new List<string>{"הפסק אכילה"} },
                        {"14:00", new List<string>{"שתיה פיקולקס 1","שתייה 8 כוסות נוזלים במשך 6 שעות"} },
                        {"20:00", new List<string>{"שתיית פיקולוקס 2","שתייה 8 כוסות נוזלים במשך 6 שעות"} }
                    }
                };
            return new Card
            {
                Title = Settings.SelectedDate.AddDays(-1).ToShortDateString(),
                Type = CardType.GastroTimeLine,
                Questions = new Dictionary<string, List<string>>
                {
                    {"15:00", new List<string>{"הפסק אכילה"} },
                    {"16:00", new List<string>{"שתיה פיקולקס 1","שתייה 8 כוסות נוזלים במשך 6 שעות"} },
                    {"22:00", new List<string>{"שתיית פיקולוקס 2","שתייה 8 כוסות נוזלים במשך 6 שעות"} }
                }
            };
        }

        private Card LastGastroCards()
        {
            return new Card
            {
                Title = Settings.SelectedDate.ToString("dd-MM"),
                Type = CardType.Default,
                Content = "אין לאכול עד לבדיקה, ניתן לשתות מים או כל נוזל צלול אחר כמו מרק צח, מיץ צלול, תה עם סוכר עד שלוש שעות לפני הבדיקה",
                Questions = new Dictionary<string, List<string>>
                {
                    {"יש להביא לבדיקה:",new List<string>
                    {
                        "מלווה (אין לנהוג 12 שעות לאחר הבדיקה)", "הפנייה","התחייבות מקופת החולים",
                        "בעלי CPAP – יש להביא CPAP לסובלים מעצירת נשימה בזמן השינה", "בעלי קוצב לב – יש להביא הערכת קוצב והזמנה למרפאת קוצבים",
                        "באם הנבדק אינו בר חתימה להסכמה לבדיקה, יש להגיע עם אפוטרופוס ואישור בית משפט המסמיך אותו לאפוטרופסות"
                    } }
                }
            }; 
        }
    }
}
