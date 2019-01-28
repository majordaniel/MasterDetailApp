using MasterDetailApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterDetailApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

     //Post Action for save Applicants

        [HttpPost]
        public JsonResult SaveApplicant(JobPortalViewModel ApplicantData)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (JobApplicationDBEntities AppDetails = new JobApplicationDBEntities())
                {
                    Tb_Applicants RefInfo = new Tb_Applicants
                    {
                        App_First_Name = ApplicantData.App_First_Name,
                        App_Last_Name = ApplicantData.App_Last_Name,
                        App_Email = ApplicantData.App_Email,
                        App_Phone = ApplicantData.App_Phone,
                        App_Postion = ApplicantData.App_Postion,
                    };
                    foreach (var IndRef in ApplicantData.ReferenceDetails)
                    {
                        RefInfo.Tb_Ref.Add(IndRef);
                    }
                    AppDetails.Tb_Applicants.Add(RefInfo);

                    AppDetails.SaveChanges();
                    status = true;
                } 
            }
            else
            {
                status = false;
            }

            return new JsonResult { Data = new { status = status } };
        }
    }
}