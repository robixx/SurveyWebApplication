using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyWebApplication.ModelViewInfo
{
    public class SurveyViewInfo
    {
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public int OptionTypeId { get; set; }
        public string OptionTypeName { get; set; }
        public int OptionId { get; set; }
        public string OptionName { get; set; }
        public int SetId { get; set; }
        public bool IsCorrect { get; set; }
    }
}