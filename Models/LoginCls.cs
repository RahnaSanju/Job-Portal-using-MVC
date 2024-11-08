using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectMVC.Models
{
    public class LoginCls
    {
        public int regid { set; get; }

        [Required(ErrorMessage = "Enter username")]
        public string usrnm { set; get; }

        [Required(ErrorMessage = "Enter password")]
        public string pwd { set; get; }
        public string logtype { set; get; }
        public string msg { set; get; }
        

    }
}