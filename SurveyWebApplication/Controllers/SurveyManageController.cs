﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SurveyWebApplication.DAL;
using SurveyWebApplication.Models;
using SurveyWebApplication.ModelViewInfo;
using Newtonsoft.Json;
namespace SurveyWebApplication.Controllers
{
    public class SurveyManageController : Controller
    {
        //
        // GET: /SurveyManage/
        [HttpGet]
        public ActionResult SurveyQuestion()
        {
            var databaseConnection = new DatabaseConnection();
            string setId =Request.QueryString["SetId"]==null?"": Request.QueryString["SetId"].ToString();
            List<SurveyViewInfo> questionlist = databaseConnection.GetAllSurveyList(setId);

            List<Question> newQuestionList = new List<Question>();
            var data = questionlist.Select(x => x.QuestionId).Distinct();
            foreach (var item in data)
            {
                var sdata = questionlist.Where(e => e.QuestionId == item).ToList();
                Question info = new Question
                {
                    QuestionId = sdata[0].QuestionId,
                    OptionTypeId=sdata[0].OptionTypeId,
                    QuestionTitle = sdata[0].QuestionTitle,
                    OptionList = new List<Options>()

                };

                foreach (var iitem in sdata)
                {
                    Options SetManageItem = new Options
                    {
                        OptionId = iitem.OptionId,
                        OptionName = iitem.OptionName,
                        OptionTypeId = iitem.OptionTypeId,
                        IsCorrect = iitem.IsCorrect,
                    };
                    info.OptionList.Add(SetManageItem);
                }
                newQuestionList.Add(info);
            }

            return View(newQuestionList);
        }


        [HttpGet]
        public ActionResult SetList()
        {
            var databaseConnection = new DatabaseConnection();
            string orgid = Request.QueryString["OrgId"].ToString();
            List<QuestionSet> questionlist = databaseConnection.GetAllQuestionSet01(orgid);
            return View(questionlist);
        }



        [HttpPost]
        public ActionResult AnswerSubmit(SurveyModel model)
        {
            var databaseConnection = new DatabaseConnection();

            string CustomerId = model.CustomerId.ToString();
            string createby = "";           
            DateTime CreateDate = DateTime.Now;
           
            model.QuestionTitleList = JsonConvert.DeserializeObject<List<Question>>(model.QuestionTitleString);
            foreach (var item in model.QuestionTitleList)
            {
                string QuestionId = item.QuestionId.ToString();               
                var option = item.OptionList;

                foreach (var iitem in option)
                {
                    string OptionId = iitem.OptionId.ToString();
                    string OptionName = iitem.OptionName.ToString();
                    string QuestionTypeId = iitem.OptionTypeId.ToString();
                    var result = databaseConnection.AnswerSubmit(CustomerId, QuestionId, OptionId, OptionName, QuestionTypeId, createby, CreateDate);
                }
            }
            return View();
        }


        [HttpGet]
        public ActionResult Test()
        {
            var databaseConnection = new DatabaseConnection();
            string setId = Request.QueryString["SetId"] == null ? "" : Request.QueryString["SetId"].ToString();
            List<SurveyViewInfo> questionlist = new List<SurveyViewInfo>();
            if (setId == "")
            {
                questionlist = databaseConnection.GetAllSurveyList01();
            }
            else
            {
                questionlist = databaseConnection.GetAllSurveyList(setId);
            }
            

            List<Question> newQuestionList = new List<Question>();
            var idata = questionlist.Select(x => x.QuestionId).Distinct();
            foreach (var item in idata)
            {
                var sdata = questionlist.Where(e => e.QuestionId == item).ToList();
                Question info = new Question
                {
                    QuestionId = sdata[0].QuestionId,
                    OptionTypeId = sdata[0].OptionTypeId,
                    QuestionTitle = sdata[0].QuestionTitle,
                    OptionList = new List<Options>()

                };

                foreach (var iitem in sdata)
                {
                    Options SetManageItem = new Options
                    {
                        OptionId = iitem.OptionId,
                        OptionName = iitem.OptionName,
                        OptionTypeId = iitem.OptionTypeId,
                        IsCorrect = iitem.IsCorrect,
                        AnsCount=iitem.AnsCount
                    };
                    info.OptionList.Add(SetManageItem);
                }
                newQuestionList.Add(info);
            }
            return View(newQuestionList);
        }


        [HttpGet]
        //[Route("SurveyManage/ModalData/{id}")]
        public JsonResult ModalData(int id)
        {
            var databaseConnection = new DatabaseConnection();
            List<CustomerInformation> result = databaseConnection.GetCustomer(id);
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public JsonResult SetNameList()
        {
            var databaseConnection = new DatabaseConnection();
            var data = databaseConnection.GetAllQuestionSet();

            return Json(data, JsonRequestBehavior.AllowGet);


        }


        [HttpGet]
        public JsonResult CustListList()
        {
            var databaseConnection = new DatabaseConnection();
            var data = databaseConnection.GetAllCustomer();

            return Json(data, JsonRequestBehavior.AllowGet);


        }





        [HttpGet]

        public ActionResult OrganizationSurvey(string fromDate, string toDate)
        {
            var dataConnection = new DatabaseConnection();
            string frmdate = fromDate == null ? "" : fromDate.ToString();
            string todate = fromDate == null ? "" : toDate.ToString();
            List<Organization> list = dataConnection.GetOrganizationList(frmdate, todate);
            //ViewBag.list = list;
            ViewBag.Datad = list;

            return View();
        }


        


	}
}