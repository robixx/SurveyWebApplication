using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SurveyWebApplication.Models;
using SurveyWebApplication.ModelViewInfo;
using SurveyWebApplication.DAL;
using Newtonsoft.Json;
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
            //List<Question> data = databaseConnection.GetAllQuestionList();
            List<QuestionViewModel> view = databaseConnection.GetAllQuestionView();
            ViewBag.JsonData = view;



            List<SetManage> oldSet = databaseConnection.GetAllSetManage();
            List<SetManageInfo> newSet = new List<SetManageInfo>();
            var data = oldSet.Select(x => x.SetId).Distinct();
            foreach (var item in data)
            {
                var sdata = oldSet.Where(e => e.SetId == item).ToList();
                SetManageInfo info = new SetManageInfo
                {
                    SetManageId=sdata[0].SetManageId,
                    SetId = sdata[0].SetId,
                    SetName = sdata[0].SetName,
                    SetManageList = new List<SetManage>()

                };

                foreach (var iitem in sdata)
                {
                    SetManage SetManageItem = new SetManage
                    {
                        SetId = iitem.SetId,
                        SetName = iitem.SetName,
                        QuestionId = iitem.QuestionId,
                        QuestionTitle = iitem.QuestionTitle,
                    };
                    info.SetManageList.Add(SetManageItem);
                }
                newSet.Add(info);
            }


            
            return View(newSet);
        }

        [HttpGet]
        public JsonResult SetList()
        {
            var databaseConnection = new DatabaseConnection();
            var data = databaseConnection.GetAllQuestionSet();

            return Json(data, JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public ActionResult SetAdd(QuestionViewInfo model)
        {
            var databaseConnection = new DatabaseConnection();
            string SetId = (model.SetId).ToString();
            model.list = JsonConvert.DeserializeObject<List<QuestionIdList>>(model.Connectinglist);
            foreach (var item in model.list)
            {
                string QuestionId = (item.QuestionId).ToString();
                var result = databaseConnection.SetManageAdd(SetId, QuestionId);
            }

            return RedirectToAction("SetManageList", "SetManage");

        }



    }
}