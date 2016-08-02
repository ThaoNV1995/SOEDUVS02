using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOEDU.Entities.Models;
using SOEDU.Repository.Course;

namespace SOEDU.Service.Course
{
    public class CourseService : ICourseService
    {
        CourseRepository courseRepository = new CourseRepository();
        public string addCourse(Sys_Course course)
        {
            return courseRepository.addCourse(course);
        }

        public bool deleteCourse(string courseID)
        {
            return courseRepository.deleteCourse(courseID);
        }

        public bool editCourse(Sys_Course course)
        {
            return courseRepository.editCourse(course);
        }

        public List<Sys_Course> getAllCourse()
        {
            return courseRepository.getAllCourse();
        }

        public Sys_Course viewDetail(string id)
        {
            return courseRepository.viewDetail(id);
        }


        public List<Common.Models.CategoryModels> GetCourseCategory()
        {
            return courseRepository.GetCourseCategory();
        }
    }
}
