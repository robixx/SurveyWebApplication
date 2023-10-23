using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using SurveyWebApplication.Models;
using System.Data;
using System.Data.SqlClient;
using SurveyWebApplication.DAL;


namespace SurveyWebApplication.Controllers
{
    public class OptionTypeController : Controller
    {
        
        //
        // GET: /OptionType/
        [HttpGet]
        public ActionResult OptionTypeList()
        {

            return View();
        }

        [HttpGet]
        public JsonResult OptionList()
        {
            var databaseConnection = new DatabaseConnection();
            var data = databaseConnection.GetAllOptionType();

            return Json(data,JsonRequestBehavior.AllowGet);
           
           
        }
        [HttpPost]
        public ActionResult CreateOptionType(string QuestionTitle, string OptionId)
        {
            string Title = QuestionTitle.ToString();
            string id = OptionId.ToString(); 
            if (Title == "" && id == "")
            {

            }
            else
            {
                var databaseConnection = new DatabaseConnection();
                var valueadd = databaseConnection.CreateOptionType(Title, id);
            }
           
            return View();
        }
    }
}