using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SurveyWebApplication.DAL;
using SurveyWebApplication.Models;
namespace SurveyWebApplication.Controllers
{
    public class QuestionSetsController : Controller
    {
        //
        // GET: /QuestionSets/
        [HttpGet]
        public ActionResult QuestionSet()
        {
               var databaseConnection = new DatabaseConnection();
               List<QuestionSet> data = databaseConnection.GetAllQuestionSet();
              ViewBag.JsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data); 
             return View();

            
        }

        [HttpGet]
        public ActionResult QuestionSetCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult QuestionSetCreate(String SetName, string Name)
        {
            string setName = SetName.ToString();
            string createby = "";
            string updateby = "";
            DateTime CreateDate =DateTime.Now;
            DateTime UpdateDate = Convert.ToDateTime("1900-01-01");
            string Status = "";
            string OrgId = Name.ToString();

            if (setName == "" || OrgId=="")
            {

            }
            else
            {
                var databaseConnection = new DatabaseConnection();
                var valueadd = databaseConnection.QuestionSetCreate(setName, createby, updateby, CreateDate, UpdateDate, Status, OrgId);
            }

            return RedirectToAction("QuestionSet");
        }





        [HttpGet]
        public JsonResult OrganizationList()
        {
            var databaseConnection = new DatabaseConnection();
            var list = databaseConnection.GetOrganizationList01(); 

            return Json(list, JsonRequestBehavior.AllowGet);


        }
	}
}