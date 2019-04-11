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

        public string TypeName { get; set; }
        public bool IsHidden { get; set; }
        public List<Card> SubCards { get; set; }
        public string PageKey { get; set; }
        public string MovieLink { get; set; }
        public List<string> ImagesLink { get; set; }
        public string PdfFileLink { get; set; }
        public string WebPageLink { get; set; }
    }

    public enum CardType
    {
        Default,
        GastroDefault,
        GastroQuestions,
        GastroYesNo,
        GastroTimeLine,
    }
}
