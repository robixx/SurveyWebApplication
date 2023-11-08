using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SurveyWebApplication.ModelViewInfo;
namespace SurveyWebApplication.Models
{
    public class Options :BaseModel
    {
      //  [Key]
        public int OptionId { get; set; }
        public string OptionName { get; set; }
        public bool IsActive { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public int OptionTypeId { get; set; }
        public string AnsCount { get; set; }
        
    }
}