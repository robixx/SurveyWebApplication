using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyWebApplication.Models
{
    public class QuestionAnswer
    {

        public int AnswerId { get; set; }
        public string CustomerId { get; set; }
        public string QuestionId { get; set; }
        public string QuestionTypeId { get; set; }
        public string OptionId { get; set; }
        public string OptionName { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
       
      
 

    }
}