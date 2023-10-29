using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SurveyWebApplication.Models
{
    public class Question : BaseModel
    {
        [Key]
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public int SetId { get; set; }
        public int OptionTypeId { get; set; }
        public List<Options> OptionList { get; set; }
        public string OptionListstring { get; set; }


    }
    
}