using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyWebApplication.Models
{
    public class QuestionAnswer
    {

        public int AnswerId { get; set; }
        public string QuestionTitle { get; set; }
        public string TypeofQuestion { get; set; }
        public string Option1 { get; set; }
        public string option2 { get; set; }
        public string option3 { get; set; }
        public string option4 { get; set; }
        public string TextOption { get; set; }
        public string CustomerId { get; set; }

    }
}