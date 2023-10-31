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
    public class QuestionController : Controller
    {
       
        // GET: /Questionnaire/
        [HttpGet]
        public ActionResult QuestionTitleList()
        {
            var databaseConnection = new DatabaseConnection();
            List<QuestionManage> data = databaseConnection.GetAllQuestion();
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
        public JsonResult SetList()
        {
            var databaseConnection = new DatabaseConnection();
            var data = databaseConnection.GetAllQuestionSet();

            return Json(data, JsonRequestBehavior.AllowGet);


        }



        [HttpGet]
        public ActionResult QuestionCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult QuestionCreate(Question model)
        {
            
            string Title = model.QuestionTitle;
           
           
            string createby = "";
            string updateby = "";
            DateTime CreateDate = DateTime.Now;
            DateTime UpdateDate = Convert.ToDateTime("1900-01-01");
            string Status = "";
            if (Title == null  )
            {

            }
            else
            {
                var databaseConnection = new DatabaseConnection();
                var valueadd = databaseConnection.CreateQuestion(Title, createby, updateby, CreateDate, UpdateDate, Status);
                TempData["massage"] = valueadd;
                return RedirectToAction("QuestionTitleList");
            }

            return View(model);
        }
	}
}