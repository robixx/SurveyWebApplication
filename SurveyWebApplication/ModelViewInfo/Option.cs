using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyWebApplication.ModelViewInfo
{
    public class Option
    {
        public int SetId { get; set; }
        public string SetName { get; set; }      

       public string TypeofQuestion { get; set; }
        public int OptionId { get; set; }
        public string OptionTypeName { get; set; }
        public DateTime CreateDate { get; set; }
        public Boolean InActive { get; set; }
        public List<OptionList> OptionList { get; set; }
    }
    public class OptionList
    {
        public int OptionId { get; set; }
        public string Options { get; set; }
        public string Options1 { get; set; }
        public string Options2 { get; set; }
        public string Options3 { get; set; }

    }
}

