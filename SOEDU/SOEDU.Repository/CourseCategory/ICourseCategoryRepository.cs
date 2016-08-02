using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.CourseCategory
{
    public interface ICourseCategoryRepository
    {
        List<Sys_CourseCategory> getAllCourseCategory();
        string addCourseCategory(Sys_CourseCategory coursecategory);
        bool editCourseCategory(Sys_CourseCategory coursecategory);
        bool deleteCourseCategory(string id);
        Sys_CourseCategory viewDetail(string id);
    }
}
