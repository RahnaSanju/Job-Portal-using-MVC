using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectMVC.Models;

namespace ProjectMVC.Controllers
{
    public class InsertJobDBController : Controller
    {

        Job_Portal_ProjectEntities dbObj = new Job_Portal_ProjectEntities();
        StateDistrictCls objSD_Cls = new StateDistrictCls();
        // GET: InsertJobDB
        public ActionResult Insert_Job_Pageload()
        {
            InsertJobCls clsObj = new InsertJobCls();
            clsObj.jDOP = DateTime.Now;
            clsObj.Qlfcn = getQlfcnData();
            clsObj.Skills = getSkillData();

            List<jStateClass> stList = objSD_Cls.selectStates();
            ViewBag.selStates = new SelectList(stList, "StId", "StName");

            return View(clsObj);
        }

        public JsonResult GetDistricts(int stateID)
        {
            var districts = getDistrictByStateID(stateID);
            return Json(districts, JsonRequestBehavior.AllowGet);
        }

        private List<SelectListItem> getDistrictByStateID(int stateID)
        {
            var getDistricts = objSD_Cls.selectDistricts(stateID);
            var districtsByState = getDistricts.Select(a => new SelectListItem() { Value = a.DistId.ToString(), Text = a.DistName }).ToList();
            return districtsByState;
        }

        public List<jCBListQlftHelper> getQlfcnData()
        {
            List<jCBListQlftHelper> qlfs = new List<jCBListQlftHelper>()
            {
                new jCBListQlftHelper{Value="SSLC",Text="SSLC",IsChecked=true},
                new jCBListQlftHelper{Value="PLUS TWO",Text="PLUS TWO",IsChecked=false},
                new jCBListQlftHelper{Value="BCA",Text="BCA",IsChecked=false},
                new jCBListQlftHelper{Value="MCA",Text="MCA",IsChecked=false},
                new jCBListQlftHelper{Value="BTECH",Text="BTECH",IsChecked=false},
            };
            return qlfs;
        }

        public List<jCBListSkilltHelper> getSkillData()
        {
            List<jCBListSkilltHelper> skls = new List<jCBListSkilltHelper>()
            {
                new jCBListSkilltHelper{Value="C#",Text="C#",IsChecked=true},
                new jCBListSkilltHelper{Value="ASP.NET",Text="ASP.NET",IsChecked=false},
                new jCBListSkilltHelper{Value="HTML",Text="HTML",IsChecked=false},
                new jCBListSkilltHelper{Value="CSS",Text="CSS",IsChecked=false},
                new jCBListSkilltHelper{Value="JAVA SCRIPT",Text="JAVA SCRIPT",IsChecked=false},
            };
            return skls;
        }


        public ActionResult Insert_Job_Click(InsertJobCls clsObj, HttpPostedFileBase file, FormCollection form)
        {
            if (ModelState.IsValid)
            {

                List<jStateClass> stList = objSD_Cls.selectStates();
                int selectedID = Convert.ToInt32(form["ddlStateID"]);//name of form control in form
                jStateClass selelectedItem = stList.FirstOrDefault(c => c.StId == selectedID);
                clsObj.jStId = selelectedItem.StId;
                clsObj.jStName = selelectedItem.StName;
                ViewBag.selStates = new SelectList(stList, "StId", "StName");

                int distID = Convert.ToInt32(form["ddlDistrictID"]);//name of form control in form
                clsObj.jDistId = distID;

                //to set qualication to property
                clsObj.Qlfcn = getQlfcnData();
                var qlf = string.Join(",", clsObj.jselectedQlfcn); //joins the selected qualifications using , //selectedQlfcn name of control in View
                clsObj.jQlf = qlf;

                //to set skills to property
                clsObj.Skills = getSkillData();
                var skl = string.Join(",", clsObj.jselectedSkills); //joins the selected qualifications using , //selectedSkills is the name of the control in view
                clsObj.jSkills = skl;

                int cRegid = Convert.ToInt32(Session["regid"]);
                clsObj.jDOP = System.DateTime.Today.Date;
                dbObj.sp_Insert_Job(cRegid,clsObj.jStId, clsObj.jDistId, clsObj.jTitle, clsObj.jDesc, "active" , clsObj.jQlf, clsObj.jSkills, clsObj.jDOP , clsObj.jLoc, clsObj.jSal, clsObj.jExp);
                //dbObj.sp_Insert_Login(regid, clsObj.uUsrnm, clsObj.uPwd, "user");
                clsObj.msg = "Inserted";
                return View("Insert_Job_PageLoad", clsObj);
            }
            else
            {

                clsObj.Qlfcn = getQlfcnData();
                clsObj.Skills = getSkillData();
                List<jStateClass> stList = objSD_Cls.selectStates();
                ViewBag.selStates = new SelectList(stList, "StId", "StName");
                return View("Insert_Job_PageLoad", clsObj);
            }
        }

    }




}