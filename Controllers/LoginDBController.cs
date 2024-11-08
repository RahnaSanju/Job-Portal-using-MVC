using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectMVC.Models;

namespace ProjectMVC.Controllers
{
    public class LoginDBController : Controller
    {
        Job_Portal_ProjectEntities dbObj = new Job_Portal_ProjectEntities();
        // GET: LoginDB
        public ActionResult Login_Pageload()
        {
            return View();
        }

        public ActionResult Login_Click(LoginCls objCls)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int)); //output parameter
                dbObj.sp_Login(objCls.usrnm, objCls.pwd, op);
                int val = Convert.ToInt32(op.Value);
                if (val == 1)
                {
                    var getid = (dbObj.sp_GetRegId(objCls.usrnm, objCls.pwd).FirstOrDefault());
                    Session["regid"] = Convert.ToInt32(getid);

                    var gettype = (dbObj.sp_GetLogType(objCls.usrnm, objCls.pwd).FirstOrDefault());
                    if(gettype=="company")
                    {
                        TempData["appCount"]= dbObj.sp_ViewAppUsrCount(Convert.ToInt32(getid)).FirstOrDefault().appCount;
                        return RedirectToAction("AdminHome");
                    }
                    else if(gettype=="user")
                    {
                        return RedirectToAction("UserHome");
                    }
                }
                else
                {
                    ModelState.Clear();
                    objCls.msg = "Invalid Login";
                    return View("Login_Pageload", objCls);
                }
            }
            return View("Login_Pageload", objCls);
        }

        public ActionResult AdminHome()
        {

            return View();
        }

        public ActionResult UserHome()
        {
            return View();
        }

    }
}