using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectMVC.Models;

namespace ProjectMVC.Controllers
{
    public class InsertCVController : Controller
    {
        Job_Portal_ProjectEntities dbObj = new Job_Portal_ProjectEntities();
        // GET: InsertCV
        public ActionResult InsertCV_Load(int jid)
        {
            //TempData["cid"] = cid;
            TempData["jid"] = jid;
            return View();
        }

        public ActionResult ApplyCV_Click(InsertApplicationCls clsObj, HttpPostedFileBase file, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fname = System.IO.Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/CV");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);

                    var fullpath = Path.Combine("~\\CV", fname);
                    clsObj.aResume = fullpath;//set
                }

                clsObj.aUserRegId = Convert.ToInt32(Session["regid"]);
                clsObj.aJobId = Convert.ToInt32(TempData["jid"]);
                clsObj.aDate = System.DateTime.Today.Date;
                clsObj.aStatus = "active";

                dbObj.sp_Insert_Application(clsObj.aUserRegId, clsObj.aJobId, clsObj.aDate, clsObj.aResume, clsObj.aResume);
                clsObj.msg = "Your Application is submitted";
                return View("InsertCV_Load", clsObj);
            }
            return View("InsertCV_Load", clsObj);
        }
        
    }
}