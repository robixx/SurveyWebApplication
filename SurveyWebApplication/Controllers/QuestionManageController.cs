using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SurveyWebApplication.DAL;
using SurveyWebApplication.ModelViewInfo;
using SurveyWebApplication.Models;
using Newtonsoft.Json;

namespace SurveyWebApplication.Controllers
{
    public class QuestionManageController : Controller
    {
        
         //GET: /QuestionManage/
        //[HttpGet]
        //public ActionResult QuestionManageList()
        //{
        //    var databaseConnection = new DatabaseConnection();
        //    List<Option> result = databaseConnection.GetQuestionAnswerss();
        //    //ViewBag.result = Newtonsoft.Json.JsonConvert.SerializeObject(result);
        //    return View(result);
            
        //}

        [HttpGet]
        public ActionResult QuestionManages()
        {


            return View();
        }

        [HttpGet]
        public JsonResult GetQuestionList()
        {
            var databaseConnection = new DatabaseConnection();
            var data = databaseConnection.GetAllQuestionList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult OptionList()
        {
            var databaseConnection = new DatabaseConnection();
            var data = databaseConnection.GetAllOptionType();

            return Json(data, JsonRequestBehavior.AllowGet);


        }


        [HttpGet]
        public ActionResult QuestionCreate()
        {
            return View();
        }


        [HttpPost]
        public JsonResult QuestionCreate(Question model)
        {
            model.OptionList = JsonConvert.DeserializeObject<List<Options>>(model.OptionListstring);

            return Json(model, JsonRequestBehavior.AllowGet);
           // return RedirectToAction("QuestionSet", "QuestionSets");
        }
        
	}
}
