using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SurveyWebApplication.Models;
using SurveyWebApplication.DAL;
namespace SurveyWebApplication.Controllers
{
    public class QuestionSetController : Controller
    {
        //
        // GET: /QuestionSet/
        //[HttpGet]
        //public ActionResult QuestionList()
        //{
        //    var databaseConnection = new DatabaseConnection();
        //    List<QuestionSet> result = databaseConnection.GetQuestionSet();
        //    ViewBag.QSet = Newtonsoft.Json.JsonConvert.SerializeObject(result);
        //    return View();
        //}



        //[HttpGet]
        //public JsonResult GetQuestionList()
        //{
        //    var databaseConnection = new DatabaseConnection();
        //    var data = databaseConnection.GetAllQuestionTitle();

        //    return Json(data, JsonRequestBehavior.AllowGet);


        //}




        //[HttpGet]
        //public ActionResult QuestionCreate()
        //{
        //    return View();
        //}


        //[HttpPost]
        //public ActionResult QuestionCreate(QuestionSet model)
        //{

           
        //    string SetName = model.SetName == null ? "" : model.SetName.ToString();
        //    string TypeofQuestion = model.TypeofQuestion == null ? "" : model.TypeofQuestion.ToString();
        //    string Options = model.Options == null ? "" : model.Options.ToString();
        //    string Options1 = model.Options1 == null ? "" : model.Options1.ToString();
        //    string Options2 = model.Options2 == null ? "" : model.Options2.ToString();
        //    string Options3 = model.Options3 == null ? "" : model.Options3.ToString();
        //    string CreateDate= (DateTime.Now).ToString();
        //    bool InActive= true;
        //    if (TypeofQuestion == "" && SetName == "" )
        //    {
        //         TempData["message"]= "Please Insert Text Box";

        //    }
        //    else
        //    {
        //        var DataConnection = new DatabaseConnection();
        //        var result = DataConnection.InsertQuestionSet(SetName, TypeofQuestion, Options, Options1, Options2, Options3, CreateDate, InActive);
        //        TempData["message"] = result;
        //        return RedirectToAction("QuestionList");
        //    }
        //    return View(model);
        //}
	}
}