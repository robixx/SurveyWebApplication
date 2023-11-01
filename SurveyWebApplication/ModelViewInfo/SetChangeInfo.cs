using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyWebApplication.ModelViewInfo
{
    public  class SetChangeInfo
    {
        public int SetId { get; set; }
        public List<RemoveList> datalist { get; set; }
        public string Connectingstringlist { get; set; }
    }


   
}