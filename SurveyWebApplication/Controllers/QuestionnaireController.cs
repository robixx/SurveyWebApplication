using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using SurveyWebApplication.Models;
using SurveyWebApplication.ModelViewInfo;
using System.Data;
using System.Data.SqlClient;
using SurveyWebApplication.DAL;
namespace SurveyWebApplication.Controllers
{
    public class QuestionnaireController : Controller
    {
        //
        // GET: /Questionnaire/
        [HttpGet]
        public ActionResult QuestionTitleList()
        {
            var databaseConnection = new DatabaseConnection();
            List<Question> data = databaseConnection.GetAllQuestion();
            ViewBag.JsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data); 
            return View();
        }

        [HttpGet]
        public JsonResult OptionList()
        {
            var databaseConnection = new DatabaseConnection();
            var data = databaseConnection.GetAllOptionType();

            return Json(data, JsonRequestBehavior.AllowGet);


        }



        [HttpGet]
        public ActionResult CreateOptionType()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateOptionType(Questionnaires model)
        {
            Questionnaires q = new Questionnaires
            {
                QuestionTitle=model.QuestionTitle,
                QuestionId=model.QuestionId,
                OptionId=model.OptionId,
            };


            string Title = model.QuestionTitle;
            string id = model.OptionId.ToString();
            if (Title == null && id =="0")
            {

            }
            else
            {
                var databaseConnection = new DatabaseConnection();
                var valueadd = databaseConnection.CreateOptionType(Title, id);
                TempData["massage"] = valueadd;
                return RedirectToAction("QuestionTitleList");
            }

            return View(model);
        }
	}
}