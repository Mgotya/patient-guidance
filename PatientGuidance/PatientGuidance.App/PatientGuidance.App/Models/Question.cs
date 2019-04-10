using System;
using System.Collections.Generic;
using System.Text;

namespace PatientGuidance.App.Models
{
    public class Question
    {
        public string Content { get;}
        public bool IsCorrect { get; set; }

        public Question(string content)
        {
            Content = content;
        }

    }
}
