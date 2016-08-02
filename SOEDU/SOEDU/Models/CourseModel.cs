using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOEDU.Models
{
    public class CourseModel
    {
        public string Course_ID { get; set; }
        public string Category_ID { get; set; }
        public string Course_Name { get; set; }
        public string Avatar { get; set; }
        public string Video { get; set; }
        public string VideoImg { get; set; }
        public bool IsYoutube { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public bool IsValue { get; set; }
        public double? IsPrice { get; set; }
        public double? IsPriceSale { get; set; }
        public int? ViewCount { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool Status { get; set; }
        public int? IsOrder { get; set; }
    }
}