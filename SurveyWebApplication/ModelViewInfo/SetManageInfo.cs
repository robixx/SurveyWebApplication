using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SurveyWebApplication.Models;
namespace SurveyWebApplication.ModelViewInfo
{
    public class SetManageInfo
    {
        [Key]
        public int SetManageId { get; set; }
        public int SetId { get; set; }      
        public string SetName { get; set; }
        public List<SetManage> SetManageList { get; set; }



    }
}