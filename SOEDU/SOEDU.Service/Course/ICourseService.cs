using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Service.Course
{
    public interface ICourseService
    {
        List<Sys_Course> getAllCourse();
        string addCourse(Sys_Course course);
        bool editCourse(Sys_Course course);
        bool deleteCourse(string courseID);
        Sys_Course viewDetail(string id);
        List<SOEDU.Common.Models.CategoryModels> GetCourseCategory();
    }
}
