using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMVC.Models
{
    public class InsertApplicationCls
    {
        public int aAppId { set; get; }
        public int aUserRegId { set; get; }
        public int aJobId { set; get; }
        public DateTime aDate { set; get; }
        public string aResume { set; get; }
        public string aStatus { set; get; }

        public string msg { set; get; }
    }
}