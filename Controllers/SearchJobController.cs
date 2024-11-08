using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectMVC.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjectMVC.Controllers
{
    public class SearchJobController : Controller
    {
        Job_Portal_ProjectEntities dbObj = new Job_Portal_ProjectEntities();
        // GET: SearchJob
        public ActionResult SearchJob_PageLoad()
        {
            return View(GetData());
        }

        private JobSearchCls GetData()
        {
            var jobList = new JobSearchCls();
            var data = dbObj.sp_DisplayAllJobs().ToList();
            foreach (var e in data)
            {
                var jobcls = new jsearch();
                jobcls.jId = e.Job_Id;
                jobcls.jCompRegId = e.Comp_Reg_Id;
                jobcls.jCompName = e.Name;
                jobcls.jStatename = e.State_Name;
                jobcls.jDistname = e.Dist_Name;
                jobcls.jTitle = e.Title;
                jobcls.jDesc = e.Description;
                jobcls.jStatus = e.Status;
                jobcls.jQual = e.Qualification;
                jobcls.jSkills = e.Skills;
                jobcls.jDOP = e.DOP;
                jobcls.jLocation = e.Location;
                jobcls.jSalary = e.Salary;
                jobcls.jExp = e.Experience.ToString();

                jobList.selectjob.Add(jobcls);
            }

            return jobList;

        }

        public ActionResult SearchJob_Click(JobSearchCls clsObj)
        {
            string qry = "";
            if(!string.IsNullOrWhiteSpace(clsObj.obj_jsearch.jExp))
            {
                qry += " and jt.Experience <= " + clsObj.obj_jsearch.jExp;
            }
            if(!string.IsNullOrWhiteSpace(clsObj.obj_jsearch.jSkills))
            {
                List<string> skl = new List<string>(clsObj.obj_jsearch.jSkills.Split(','));
                foreach (string s in skl)
                {
                    qry += " and jt.Skills like '%" + s + "%'";
                }
                //qry += " and jt.Skills like '" + clsObj.obj_jsearch.jSkills + "'";
            }
            if (!string.IsNullOrWhiteSpace(clsObj.obj_jsearch.jLocation))
            {
                qry += " and jt.Location like '%" + clsObj.obj_jsearch.jLocation + "%'";
            }
            return View("SearchJob_PageLoad", getData(clsObj, qry));
        }

        public JobSearchCls getData(JobSearchCls clsObj, string qry)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["JobCon"].ConnectionString;
            SqlConnection con;
            using (con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_JobSearches", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new JobSearchCls();
                while (dr.Read())
                {
                    var jobcls = new jsearch();
                    jobcls.jId = Convert.ToInt32(dr["Job_Id"]);
                    jobcls.jCompRegId = Convert.ToInt32(dr["Comp_Reg_Id"]);
                    jobcls.jCompName = dr["Name"].ToString();
                    jobcls.jStatename = dr["State_Name"].ToString();
                    jobcls.jDistname = dr["Dist_Name"].ToString();
                    jobcls.jTitle = dr["Title"].ToString();
                    jobcls.jDesc = dr["Description"].ToString();
                    jobcls.jStatus = dr["Status"].ToString();
                    jobcls.jQual = dr["Qualification"].ToString();
                    jobcls.jSkills = dr["Skills"].ToString();
                    jobcls.jDOP = Convert.ToDateTime(dr["DOP"]);
                    jobcls.jLocation = dr["Location"].ToString();
                    jobcls.jSalary = dr["Salary"].ToString();
                    jobcls.jExp = dr["Experience"].ToString();

                    joblist.selectjob.Add(jobcls);
                }
                con.Close();
                return joblist;
            }
        }


        public ActionResult ViewJobDetails_PageLoad(JobSearchCls clsObj, int jid)
        {
            TempData["jid"] = jid;

            string qry = " and jt.job_id = " + jid;

            return View(getData(clsObj, qry));
        }

    }

   
}