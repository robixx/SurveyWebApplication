using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SurveyWebApplication.Models
{
    public class QuestionSet
    {
        [Key]
        public int SetId { get; set; }
        public string SetName { get; set; }      
    
        public string Options { get; set; }

       public string TypeofQuestion { get; set; }
        public string Options1 { get; set; }
        public string Options2 { get; set; }
        public string Options3 { get; set; }
        public DateTime CreateDate { get; set; }
        public Boolean InActive { get; set; }

    }
}