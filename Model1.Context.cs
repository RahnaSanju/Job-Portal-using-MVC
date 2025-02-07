﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectMVC
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Job_Portal_ProjectEntities : DbContext
    {
        public Job_Portal_ProjectEntities()
            : base("name=Job_Portal_ProjectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Application_Tab> Application_Tab { get; set; }
        public virtual DbSet<Company_Reg_Tab> Company_Reg_Tab { get; set; }
        public virtual DbSet<District_Tab> District_Tab { get; set; }
        public virtual DbSet<Job_Tab> Job_Tab { get; set; }
        public virtual DbSet<Login_Tab> Login_Tab { get; set; }
        public virtual DbSet<State_Tab> State_Tab { get; set; }
        public virtual DbSet<User_Reg_Tab> User_Reg_Tab { get; set; }
    
        public virtual ObjectResult<sp_DisplayAllJobs_Result> sp_DisplayAllJobs()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_DisplayAllJobs_Result>("sp_DisplayAllJobs");
        }
    
        public virtual ObjectResult<sp_GetDistricts_Result> sp_GetDistricts(Nullable<int> stId)
        {
            var stIdParameter = stId.HasValue ?
                new ObjectParameter("stId", stId) :
                new ObjectParameter("stId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetDistricts_Result>("sp_GetDistricts", stIdParameter);
        }
    
        public virtual ObjectResult<string> sp_GetLogType(string usrnm, string pwd)
        {
            var usrnmParameter = usrnm != null ?
                new ObjectParameter("usrnm", usrnm) :
                new ObjectParameter("usrnm", typeof(string));
    
            var pwdParameter = pwd != null ?
                new ObjectParameter("pwd", pwd) :
                new ObjectParameter("pwd", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("sp_GetLogType", usrnmParameter, pwdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_GetMaxID_Login()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_GetMaxID_Login");
        }
    
        public virtual ObjectResult<Nullable<int>> sp_GetRegId(string usrnm, string pwd)
        {
            var usrnmParameter = usrnm != null ?
                new ObjectParameter("usrnm", usrnm) :
                new ObjectParameter("usrnm", typeof(string));
    
            var pwdParameter = pwd != null ?
                new ObjectParameter("pwd", pwd) :
                new ObjectParameter("pwd", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_GetRegId", usrnmParameter, pwdParameter);
        }
    
        public virtual ObjectResult<sp_GetStates_Result> sp_GetStates()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetStates_Result>("sp_GetStates");
        }
    
        public virtual int sp_Insert_Company(Nullable<int> regid, string nm, string eml, string wbste, string phn)
        {
            var regidParameter = regid.HasValue ?
                new ObjectParameter("regid", regid) :
                new ObjectParameter("regid", typeof(int));
    
            var nmParameter = nm != null ?
                new ObjectParameter("nm", nm) :
                new ObjectParameter("nm", typeof(string));
    
            var emlParameter = eml != null ?
                new ObjectParameter("eml", eml) :
                new ObjectParameter("eml", typeof(string));
    
            var wbsteParameter = wbste != null ?
                new ObjectParameter("wbste", wbste) :
                new ObjectParameter("wbste", typeof(string));
    
            var phnParameter = phn != null ?
                new ObjectParameter("phn", phn) :
                new ObjectParameter("phn", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Insert_Company", regidParameter, nmParameter, emlParameter, wbsteParameter, phnParameter);
        }
    
        public virtual int sp_Insert_Job(Nullable<int> com_reg_id, Nullable<int> st_id, Nullable<int> dis_id, string title, string desc, string st, string qlf, string skls, Nullable<System.DateTime> dop, string loc, string sal, Nullable<int> exp)
        {
            var com_reg_idParameter = com_reg_id.HasValue ?
                new ObjectParameter("com_reg_id", com_reg_id) :
                new ObjectParameter("com_reg_id", typeof(int));
    
            var st_idParameter = st_id.HasValue ?
                new ObjectParameter("st_id", st_id) :
                new ObjectParameter("st_id", typeof(int));
    
            var dis_idParameter = dis_id.HasValue ?
                new ObjectParameter("dis_id", dis_id) :
                new ObjectParameter("dis_id", typeof(int));
    
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            var descParameter = desc != null ?
                new ObjectParameter("desc", desc) :
                new ObjectParameter("desc", typeof(string));
    
            var stParameter = st != null ?
                new ObjectParameter("st", st) :
                new ObjectParameter("st", typeof(string));
    
            var qlfParameter = qlf != null ?
                new ObjectParameter("qlf", qlf) :
                new ObjectParameter("qlf", typeof(string));
    
            var sklsParameter = skls != null ?
                new ObjectParameter("skls", skls) :
                new ObjectParameter("skls", typeof(string));
    
            var dopParameter = dop.HasValue ?
                new ObjectParameter("dop", dop) :
                new ObjectParameter("dop", typeof(System.DateTime));
    
            var locParameter = loc != null ?
                new ObjectParameter("loc", loc) :
                new ObjectParameter("loc", typeof(string));
    
            var salParameter = sal != null ?
                new ObjectParameter("sal", sal) :
                new ObjectParameter("sal", typeof(string));
    
            var expParameter = exp.HasValue ?
                new ObjectParameter("exp", exp) :
                new ObjectParameter("exp", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Insert_Job", com_reg_idParameter, st_idParameter, dis_idParameter, titleParameter, descParameter, stParameter, qlfParameter, sklsParameter, dopParameter, locParameter, salParameter, expParameter);
        }
    
        public virtual int sp_Insert_Login(Nullable<int> regid, string usrnm, string pwd, string logtype)
        {
            var regidParameter = regid.HasValue ?
                new ObjectParameter("regid", regid) :
                new ObjectParameter("regid", typeof(int));
    
            var usrnmParameter = usrnm != null ?
                new ObjectParameter("usrnm", usrnm) :
                new ObjectParameter("usrnm", typeof(string));
    
            var pwdParameter = pwd != null ?
                new ObjectParameter("pwd", pwd) :
                new ObjectParameter("pwd", typeof(string));
    
            var logtypeParameter = logtype != null ?
                new ObjectParameter("logtype", logtype) :
                new ObjectParameter("logtype", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Insert_Login", regidParameter, usrnmParameter, pwdParameter, logtypeParameter);
        }
    
        public virtual int sp_Insert_User(Nullable<int> regid, string nm, Nullable<System.DateTime> dob, string addr, string eml, string gnd, string phn, string pht, string qlf, string skl, Nullable<int> exp)
        {
            var regidParameter = regid.HasValue ?
                new ObjectParameter("regid", regid) :
                new ObjectParameter("regid", typeof(int));
    
            var nmParameter = nm != null ?
                new ObjectParameter("nm", nm) :
                new ObjectParameter("nm", typeof(string));
    
            var dobParameter = dob.HasValue ?
                new ObjectParameter("dob", dob) :
                new ObjectParameter("dob", typeof(System.DateTime));
    
            var addrParameter = addr != null ?
                new ObjectParameter("addr", addr) :
                new ObjectParameter("addr", typeof(string));
    
            var emlParameter = eml != null ?
                new ObjectParameter("eml", eml) :
                new ObjectParameter("eml", typeof(string));
    
            var gndParameter = gnd != null ?
                new ObjectParameter("gnd", gnd) :
                new ObjectParameter("gnd", typeof(string));
    
            var phnParameter = phn != null ?
                new ObjectParameter("phn", phn) :
                new ObjectParameter("phn", typeof(string));
    
            var phtParameter = pht != null ?
                new ObjectParameter("pht", pht) :
                new ObjectParameter("pht", typeof(string));
    
            var qlfParameter = qlf != null ?
                new ObjectParameter("qlf", qlf) :
                new ObjectParameter("qlf", typeof(string));
    
            var sklParameter = skl != null ?
                new ObjectParameter("skl", skl) :
                new ObjectParameter("skl", typeof(string));
    
            var expParameter = exp.HasValue ?
                new ObjectParameter("exp", exp) :
                new ObjectParameter("exp", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Insert_User", regidParameter, nmParameter, dobParameter, addrParameter, emlParameter, gndParameter, phnParameter, phtParameter, qlfParameter, sklParameter, expParameter);
        }
    
        public virtual int sp_JobSearches(string qry)
        {
            var qryParameter = qry != null ?
                new ObjectParameter("qry", qry) :
                new ObjectParameter("qry", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_JobSearches", qryParameter);
        }
    
        public virtual int sp_Login(string usrnm, string pwd, ObjectParameter status)
        {
            var usrnmParameter = usrnm != null ?
                new ObjectParameter("usrnm", usrnm) :
                new ObjectParameter("usrnm", typeof(string));
    
            var pwdParameter = pwd != null ?
                new ObjectParameter("pwd", pwd) :
                new ObjectParameter("pwd", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Login", usrnmParameter, pwdParameter, status);
        }
    
        public virtual int sp_Insert_Application(Nullable<int> usrid, Nullable<int> jobid, Nullable<System.DateTime> dt, string rsme, string st)
        {
            var usridParameter = usrid.HasValue ?
                new ObjectParameter("usrid", usrid) :
                new ObjectParameter("usrid", typeof(int));
    
            var jobidParameter = jobid.HasValue ?
                new ObjectParameter("jobid", jobid) :
                new ObjectParameter("jobid", typeof(int));
    
            var dtParameter = dt.HasValue ?
                new ObjectParameter("dt", dt) :
                new ObjectParameter("dt", typeof(System.DateTime));
    
            var rsmeParameter = rsme != null ?
                new ObjectParameter("rsme", rsme) :
                new ObjectParameter("rsme", typeof(string));
    
            var stParameter = st != null ?
                new ObjectParameter("st", st) :
                new ObjectParameter("st", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Insert_Application", usridParameter, jobidParameter, dtParameter, rsmeParameter, stParameter);
        }
    
        public virtual ObjectResult<sp_ViewAppliedUsers_Result> sp_ViewAppliedUsers(Nullable<int> comp_Id)
        {
            var comp_IdParameter = comp_Id.HasValue ?
                new ObjectParameter("comp_Id", comp_Id) :
                new ObjectParameter("comp_Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ViewAppliedUsers_Result>("sp_ViewAppliedUsers", comp_IdParameter);
        }
    
        public virtual ObjectResult<sp_ViewAppUsrCount_Result> sp_ViewAppUsrCount(Nullable<int> comp_Id)
        {
            var comp_IdParameter = comp_Id.HasValue ?
                new ObjectParameter("comp_Id", comp_Id) :
                new ObjectParameter("comp_Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ViewAppUsrCount_Result>("sp_ViewAppUsrCount", comp_IdParameter);
        }
    }
}
