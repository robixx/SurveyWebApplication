using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SurveyWebApplication.Models;
using SurveyWebApplication.DAL;
namespace SurveyWebApplication.Controllers
{
    public class OrganizationController : Controller
    {
        //
        // GET: /Organization/
        [HttpGet]
        public ActionResult OrganizationList()
        {

            var dataConnection = new DatabaseConnection();

            List<Organization> list = dataConnection.GetOrganizationList01();
            ViewBag.list = list;
              return View();
        }

       [HttpPost]

        public ActionResult Create(Organization model)
        {
            var dataConnection = new DatabaseConnection();

            string Name = model.Name.ToString();
            string Address = model.Address.ToString();
            string ContactNo = model.ContactNo.ToString();
            string CreateBy = "";
            DateTime CreateDate = DateTime.Now;

            var result = dataConnection.OrganizationInsert(Name, Address, ContactNo, CreateBy, CreateDate);
            return Redirect(Request.UrlReferrer.ToString()); 
        }
	}
}