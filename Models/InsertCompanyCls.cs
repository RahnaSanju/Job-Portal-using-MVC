using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectMVC.Models
{
    public class InsertCompanyCls
    {
        public int cRegId { set; get; }

        [Required(ErrorMessage = "Enter name")]
        public string cName { set; get; }

        [EmailAddress(ErrorMessage = "Enter email")]
        public string cEmail { set; get; }

        [Required(ErrorMessage = "Enter website")]
        [RegularExpression(@"^(https?:\/\/)?([a-zA-Z0-9.-]+\.[a-zA-Z]{2,})(:[0-9]+)?(\/[a-zA-Z0-9._~:/?#\[\]@!$&'()*+,;=-]*)?$")]
        public string cWbste { set; get; }

        [Required(ErrorMessage = "Enter address")]
        public string cPhone { set; get; }

        [Required(ErrorMessage = "Enter username")]
        public string cUsrnm { set; get; }

        [Required(ErrorMessage = "Enter password")]
        public string cPwd { set; get; }

        [Compare("cPwd", ErrorMessage = "Password mismatch")]
        public string cCnfpwd { set; get; }
        public string cLogType { set; get; }

        public string msg { set; get; }
    }
}