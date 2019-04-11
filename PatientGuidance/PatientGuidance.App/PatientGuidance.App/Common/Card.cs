using System.Collections.Generic;

namespace PatientGuidance.App.Common
{
    public class Card
    {
        public CardType Type { get; set; }
        public string Title { get; set; }

        public Dictionary<string,List<string>> Questions { get; set; }

        public string Content { get; set; }
        public string SubContent { get; set; }
    }

    public enum CardType
    {
        Default,
        GastroQuestions,
        GastroYesNo,
        ComplexGastro,
        GastroTimeLine
    }
}
