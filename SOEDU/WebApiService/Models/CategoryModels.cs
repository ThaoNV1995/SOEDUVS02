using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiService.Models
{
    public class CategoryModels
    {
        public string Category_ID { get; set; }
        public string Course_ID { get; set; }
        public string Category_Name { get; set; }
        public string Title_Name { get; set; }
        public string IsIcon { get; set; }
        public string Parent_ID { get; set; }
        public int lv{get;set;}

        public CategoryModels(string Category_ID, string Course_ID, string Category_Name, string Title_Name, string IsIcon, string Parent_ID,int lv)
        {
            this.Category_ID = Category_ID;
            this.Course_ID = Course_ID;
            this.Category_Name = Category_Name;
            this.Title_Name = Title_Name;
            this.IsIcon = IsIcon;
            this.Parent_ID = Parent_ID;
            this.lv = lv;
        }
    }
}