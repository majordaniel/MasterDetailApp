using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterDetailApp.Models
{
    public class JobPortalViewModel
    {
    
        public string App_Postion { get; set; }
        public string App_First_Name { get; set; }
        public string App_Last_Name { get; set; }
        public string App_Email { get; set; }
        public string App_Phone { get; set; }
        public List<Tb_Ref> ReferenceDetails { get; set; }
    }
}