using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SurveyWebApplication.Models;
using SurveyWebApplication.ModelViewInfo;
using SurveyWebApplication.DAL;
namespace SurveyWebApplication.Controllers
{
    public class SetManageController : Controller
    {
        //
        // GET: /QuestionSet/
       [HttpGet]
        public ActionResult SetManageList()
        {

            var databaseConnection = new DatabaseConnection();
            List<Question> data = databaseConnection.GetAllQuestionList();
            ViewBag.JsonData = data;

            List<SetManage> set = databaseConnection.GetAllSetManage();
           List<SetManageInfo> setName= new List<SetManageInfo>();
           foreach(var team in set)
           {
               SetManageInfo info = new SetManageInfo{
                   SetId=team.SetId,
                   SetName=team.SetName,
                 SetManageList=new List<SetManage>()
                   
               };
               info.SetManageList.Add(team);
               
               setName.Add(info);
           }
           
            ViewBag.Data = setName; 
            return View();
        }
	}
}