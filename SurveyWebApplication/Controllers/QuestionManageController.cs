using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SurveyWebApplication.DAL;
using SurveyWebApplication.ModelViewInfo;
using SurveyWebApplication.Models;

namespace SurveyWebApplication.Controllers
{
    public class QuestionManageController : Controller
    {
        //
        // GET: /QuestionManage/
        [HttpGet]
        public ActionResult QuestionManageList()
        {
            var databaseConnection = new DatabaseConnection();
            List<Option> result = databaseConnection.GetQuestionAnswerss();
            //ViewBag.result = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            return View(result);
            
        }

        [HttpPost]
        public ActionResult SaveAnswer(QuestionAnswer model)
        {


            string QuestionTitle = model.QuestionTitle;

            return View();
        }

	}
}
