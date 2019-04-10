using System;
using System.Collections.Generic;
using System.Text;

namespace PatientGuidance.App.Common
{
    public class Card
    {
        public CardType Type { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string SubContent { get; set; }
    }

    public enum CardType
    {
        Default,
        ComplexGastro
    }
}
