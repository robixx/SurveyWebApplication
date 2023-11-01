using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyWebApplication.ModelViewInfo
{
    public class QuestionViewInfo
    {
        public int SetId { get; set; }
        public List<QuestionIdList> list { get; set; }
        public string Connectinglist { get; set; }
    }

    public class QuestionIdList
    {
        public int QuestionId { get; set; }
    }
}