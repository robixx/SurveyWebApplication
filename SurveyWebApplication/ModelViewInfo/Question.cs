using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SurveyWebApplication.ModelViewInfo
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public int OptionId { get; set; }
        public string OptionTypeName { get; set; }
    }
}