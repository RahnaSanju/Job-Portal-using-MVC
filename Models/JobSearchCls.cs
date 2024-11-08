using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMVC.Models
{
    public class JobSearchCls
    {
        public jsearch obj_jsearch { set; get; }
        public List<jsearch> selectjob { set; get; }
        public JobSearchCls()
        {
            selectjob = new List<jsearch>();
            obj_jsearch = new jsearch();
        }
    }
    public class jsearch
    {
        public int jId { set; get; }

        public int jCompRegId { set; get; }

        public string jCompName { set; get; }

        public string jStatename { set; get; }

        public string jDistname { set; get; }

        public string jTitle { set; get; }

        public string jDesc { set; get; }

        public string jStatus { set; get; }

        public string jQual { set; get; }

        public string jSkills { set; get; }

        public DateTime jDOP { set; get; }

        public string jLocation { set; get; }

        public string jSalary { set; get; }

        public string jExp { set; get; }
    }
}