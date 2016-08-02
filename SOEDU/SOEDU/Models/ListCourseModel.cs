using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOEDU.Models
{
    public class ListCourseModel
    {
        public string Course_ID { get; set; }
        public string Avatar { get; set; }
        public string Course_Name { get; set; }
        public Nullable<double> IsPrice { get; set; }
        public Nullable<double> IsPriceSale { get; set; }
        public string IsName { get; set; }
        public string User_ID { get; set; }
        public string IsFoto { get; set; }
        public string IsLevel { get; set; }
        public Nullable<int> CountTarget { get; set; }
        public Nullable<int> CountStudent { get; set; }
        public Nullable<int> IsStar5 { get; set; }
        public Nullable<int> IsStar4 { get; set; }
        public Nullable<int> IsStar3 { get; set; }
        public Nullable<int> IsStar2 { get; set; }
        public Nullable<int> IsStar1 { get; set; }
    }
}