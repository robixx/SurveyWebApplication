using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SurveyWebApplication.ModelViewInfo;
namespace SurveyWebApplication.Models
{
    public class SurveyModel
    {
        [Key]
        public int CustomerId { get; set; }
        public List<Question> QuestionTitleList { get; set; }
        public string QuestionTitleString { get; set; }

    }

   
}