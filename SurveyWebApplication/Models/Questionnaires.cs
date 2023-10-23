using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SurveyWebApplication.Models
{
    public class Questionnaires
    {
        [Key]
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public int OptionId { get; set; }
        
    }
}