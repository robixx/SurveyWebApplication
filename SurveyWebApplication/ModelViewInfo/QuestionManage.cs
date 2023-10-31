using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SurveyWebApplication.ModelViewInfo
{
    public class QuestionManage
    {

        [Key]
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }     
 
        public int OptionTypeId { get; set; }
        public string OptionTypeName { get; set; }
    }
}