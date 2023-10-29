using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SurveyWebApplication.ModelViewInfo
{
    public class QuestionInfo
    {
           [Key]
        public int QuestionId { get; set; }
        //public string QuestionTitle { get; set; }
        //public int SetId { get; set; }
        public int OptionTypeId { get; set; }
     
        public int OptionId { get; set; }
        public string OptionName { get; set; }
       // public bool IsActive { get; set; }
        public bool IsCorrect { get; set; }
      

    }
}