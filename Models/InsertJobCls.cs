using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectMVC.Models
{
        public class jCBListQlftHelper
        {
            public string Value { set; get; }
            public string Text { set; get; }
            public bool IsChecked { set; get; }

        }

        public class jCBListSkilltHelper
        {
            public string Value { set; get; }
            public string Text { set; get; }
            public bool IsChecked { set; get; }

        }
        public class jStateClass
        {
            public int StId { set; get; }
            public string StName { set; get; }
        }

        public class jDistClass
        {
            public int DistId { set; get; }
            public string DistName { set; get; }
        }
    public class InsertJobCls
    {
        //Qualification
        public List<jCBListQlftHelper> Qlfcn { set; get; }
        public string[] jselectedQlfcn { set; get; }

        //Skill set
        public List<jCBListSkilltHelper> Skills { set; get; }
        public string[] jselectedSkills { set; get; }
        public int jStId { set; get; }
        public string jStName { set; get; }

        public int jDistId { set; get; }
        public string jDistName { set; get; }

        public int jRegid { set; get; }

        [Required (ErrorMessage ="Enter the Job Title")]
        public string jTitle { set; get; }

        [Required(ErrorMessage = "Enter the Job Description")]
        public string jDesc { set; get; }

        public string jStatus { set; get; }

        public string jQlf { set; get; }

        public string jSkills { set; get; }

        public DateTime jDOP { set; get; }

        [Required(ErrorMessage = "Enter the Job Location")]
        public string jLoc { set; get; }

        [Required(ErrorMessage = "Enter the Salary")]
        public string jSal{ set; get; }

        [Required(ErrorMessage = "Enter Experience required")]
        public int jExp { set; get; }

        public string msg { set; get; }

    }
}