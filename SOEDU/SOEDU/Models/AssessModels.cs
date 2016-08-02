using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOEDU.Models
{
    public class AssessModels
    {
        public string Assess_ID { get; set; }
        public string Course_ID { get; set; }
        public Nullable<int> IsStar { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}