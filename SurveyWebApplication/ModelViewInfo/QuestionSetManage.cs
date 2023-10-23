using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SurveyWebApplication.ModelViewInfo
{
    public class QuestionSetManage
    {

        [Key]
        public int SetId { get; set; }
        public string SetName { get; set; }
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
       
         public string Options { get; set; }
        public string Options1 { get; set; }
        public string Options2 { get; set; }
        public string Options3 { get; set; }
    
        public int OptionId { get; set; }
        public string OptionTypeName { get; set; }
        public DateTime CreateDate { get; set; }
        public Boolean InActive { get; set; }
    }

    
}