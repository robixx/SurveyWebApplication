using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SurveyWebApplication.ModelViewInfo;
namespace SurveyWebApplication.Models
{
    public class QuestionSet : BaseModel
    {
        [Key]
        public int SetId { get; set; }
        public string SetName { get; set; }
        public List<Question> QuestionList { get; set; }

    }
}