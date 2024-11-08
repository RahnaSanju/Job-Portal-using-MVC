using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectMVC.Models;

namespace ProjectMVC.Controllers
{
    public class InsertCompanyDBController : Controller
    {
        // GET: InsertCompanyDB
        Job_Portal_ProjectEntities dbObj = new Job_Portal_ProjectEntities();
        public ActionResult Insert_Company_PageLoad()
        {
            return View();
        }

        public ActionResult Insert_Company_Click(InsertCompanyCls clsObj)
        {
            if(ModelState.IsValid)
            {
                int maxid = Convert.ToInt32(dbObj.sp_GetMaxID_Login().FirstOrDefault());
                int regid = 0;
                if(maxid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = maxid + 1;
                }
                dbObj.sp_Insert_Company(regid, clsObj.cName, clsObj.cEmail, clsObj.cWbste, clsObj.cPhone);
                dbObj.sp_Insert_Login(regid,clsObj.cUsrnm, clsObj.cPwd,"company");
                clsObj.msg = "Inserted";
                return View("Insert_Company_PageLoad",clsObj);
            }
            else
            {
                return View("Insert_Company_PageLoad", clsObj);
            }
        }
    }
}