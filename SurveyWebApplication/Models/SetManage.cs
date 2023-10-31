using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SurveyWebApplication.Models
{
    public class SetManage
    {
        [Key]
        public int SetManageId { get; set; }
        public int SetId{get;set;}
        public string SetName { get; set; }

        public int QuestionId { get; set; }

        public string QuestionTitle { get; set; }

    }
}