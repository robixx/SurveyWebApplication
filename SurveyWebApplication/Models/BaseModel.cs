using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyWebApplication.Models
{
    public class BaseModel
    {
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Status { get; set; }
    }
}