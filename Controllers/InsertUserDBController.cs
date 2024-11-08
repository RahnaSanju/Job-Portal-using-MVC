using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectMVC.Models;

namespace ProjectMVC.Controllers
{
    public class InsertUserDBController : Controller
    {
        // GET: InsertUserDB

        Job_Portal_ProjectEntities dbObj = new Job_Portal_ProjectEntities();
        public ActionResult Insert_User_PageLoad()
        {
            InsertUserCls clsObj = new InsertUserCls();
            clsObj.uDOB = DateTime.Now;
            clsObj.Qlfcn = getQlfcnData();
            clsObj.Skills = getSkillData();
            return View(clsObj);
        }

        public List<uCBListQlftHelper> getQlfcnData()
        {
            List<uCBListQlftHelper> qlfs = new List<uCBListQlftHelper>()
            {
                new uCBListQlftHelper{Value="SSLC",Text="SSLC",IsChecked=true},
                new uCBListQlftHelper{Value="PLUS TWO",Text="PLUS TWO",IsChecked=false},
                new uCBListQlftHelper{Value="BCA",Text="BCA",IsChecked=false},
                new uCBListQlftHelper{Value="MCA",Text="MCA",IsChecked=false},
                new uCBListQlftHelper{Value="BTECH",Text="BTECH",IsChecked=false},
            };
            return qlfs;
        }

        public List<uCBListSkilltHelper> getSkillData()
        {
            List<uCBListSkilltHelper> skls = new List<uCBListSkilltHelper>()
            {
                new uCBListSkilltHelper{Value="C#",Text="C#",IsChecked=true},
                new uCBListSkilltHelper{Value="ASP.NET",Text="ASP.NET",IsChecked=false},
                new uCBListSkilltHelper{Value="HTML",Text="HTML",IsChecked=false},
                new uCBListSkilltHelper{Value="CSS",Text="CSS",IsChecked=false},
                new uCBListSkilltHelper{Value="JAVA SCRIPT",Text="JAVA SCRIPT",IsChecked=false},
            };
            return skls;
        }

        public ActionResult Insert_User_Click(InsertUserCls clsObj, HttpPostedFileBase file, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                //to set Photo to property
                if (file.ContentLength > 0)
                {
                    //string path="~\PHS\" + fileUpload1.filename
                    //fileUpload1.SaveAs(MapPath(path))

                    string fname = System.IO.Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/PHS");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);

                    var fullpath = Path.Combine("~\\PHS", fname);
                    clsObj.uPhoto = fullpath;//set
                }

                //to set qualication to property
                clsObj.Qlfcn = getQlfcnData();
                var qlf = string.Join(",", clsObj.selectedQlfcn); //joins the selected qualifications using , //selectedQlfcn name of control in View
                clsObj.uQlf = qlf;

                //to set skills to property
                clsObj.Skills = getSkillData();
                var skl = string.Join(",", clsObj.selectedSkills); //joins the selected qualifications using ,
                clsObj.uSkill = skl;

                int maxid = Convert.ToInt32(dbObj.sp_GetMaxID_Login().FirstOrDefault());
                int regid = 0;
                if (maxid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = maxid + 1;
                }


                dbObj.sp_Insert_User(regid, clsObj.uName, clsObj.uDOB, clsObj.uAddr, clsObj.uEmail, clsObj.uGen, clsObj.uPhone, clsObj.uPhoto, clsObj.uQlf, clsObj.uSkill, clsObj.uExp);
                dbObj.sp_Insert_Login(regid, clsObj.uUsrnm, clsObj.uPwd, "user");
                clsObj.msg = "Inserted";
                return View("Insert_User_PageLoad", clsObj);
            }
            else
            {
                clsObj.Qlfcn = getQlfcnData();
                clsObj.Skills = getSkillData();
                return View("Insert_User_PageLoad", clsObj);
            }
        }

    }
}