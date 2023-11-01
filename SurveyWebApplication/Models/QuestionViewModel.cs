using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyWebApplication.Models
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public int SetId { get; set; }
        public int SetManageQuestionId { get; set; }
    }
}