using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZCRMSDK.CRM.Library.Api.Response;
using ZCRMSDK.CRM.Library.Common;
using ZCRMSDK.CRM.Library.CRUD;
using ZohoCRMWebApp.Models;

namespace ZohoCRMWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<string> fieldsLeads = new List<string> { "id", "First_Name", "Last_Name", "E_mail" };
            ViewData["Leads"] = ZohoCRMRequests.GetRecords("Leads", 2187808000000087509, fieldsLeads);

            List<string> fieldsContacts = new List<string> { "id", "First_Name", "Last_Name", "Email" };
            ViewData["Contacts"] = ZohoCRMRequests.GetRecords("Contacts", 2187808000000087529, fieldsContacts);

            List<string> fieldsAccounts = new List<string> { "id", "Account_Name"};
            ViewData["Accounts"] = ZohoCRMRequests.GetRecords("Accounts", 2187808000000087515, fieldsAccounts);

            ViewData["GetLeadById"] = ZohoCRMRequests.GetRecordById("Leads", 2187808000003418001);

            var createMap = new Dictionary<string, string>();
            createMap.Add("Last_Name", "test1");
            //!!! ViewData["CreateRecord"] = ZohoCRMRequests.CreateRecord("Accounts", "test", createMap);

            var updateMap = new Dictionary<string, string>();
            updateMap.Add("Last_Name", "test1");
            updateMap.Add("First_Name", "test1");
           //!!! ViewData["UpdateRecord"] = ZohoCRMRequests.UpdateRecord("Leads", 2187808000003622004, updateMap);
            return View();
        }
    }
}
