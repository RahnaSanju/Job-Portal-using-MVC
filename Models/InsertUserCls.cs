using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectMVC.Models
{
    public class uCBListQlftHelper
    {
        public string Value { set; get; }
        public string Text { set; get; }
        public bool IsChecked { set; get; }

    }

    public class uCBListSkilltHelper
    {
        public string Value { set; get; }
        public string Text { set; get; }
        public bool IsChecked { set; get; }

    }

    public class InsertUserCls
    {
        //Qualification
        public List<uCBListQlftHelper> Qlfcn { set; get; }
        public string[] selectedQlfcn { set; get; }

        //Skill set
        public List<uCBListSkilltHelper> Skills { set; get; }
        public string[] selectedSkills { set; get; }

        public int uRegId { set; get; }


        //[Required(ErrorMessage = "Enter name")]
        public string uName { set; get; }

        //[DataType(DataType.Date)]
        public DateTime uDOB { set; get; }

        //[Required(ErrorMessage = "Enter address")]
        public string uAddr { set; get; }

        //[EmailAddress(ErrorMessage = "Enter email")]
        public string uEmail { set; get; }

        //[Required(ErrorMessage = "Enter gender")]
        public string uGen { set; get; }

        //[Phone(ErrorMessage = "Enter phone no.")]
        public string uPhone { set; get; }

        //[Required(ErrorMessage = "Upload Photo")]
        public string uPhoto { set; get; }

        //[Required(ErrorMessage = "Choose Qualification")]
        public string uQlf { set; get; }

        //[Required(ErrorMessage = "Choose skills")]
        public string uSkill { set; get; }

        //[Required(ErrorMessage = "Enter Experience")]
        public int uExp { set; get; }

        //[Required(ErrorMessage = "Enter username")]
        public string uUsrnm { set; get; }

        //[Required(ErrorMessage = "Enter password")]
        public string uPwd { set; get; }

        //[Compare("uPwd", ErrorMessage = "Password mismatch")]
        public string uCnfpwd { set; get; }
        public string uLogType { set; get; }

        public string msg { set; get; }


    }
}