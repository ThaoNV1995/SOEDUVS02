using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOEDU.Entities.Models;
using SOEDU.Repository.CourseCategory;

namespace SOEDU.Service.CourseCategory
{
    public class CourseCategoryService : ICourseCategoryService
    {
        SOEDU.Repository.CourseCategory.ICourseCategory courseCategoryRepository = new SOEDU.Repository.CourseCategory.CourseCategory();
        public string addCourseCategory(Sys_CourseCategory coursecategory)
        {
            return courseCategoryRepository.addCourseCategory(coursecategory);
        }

        public bool deleteCourseCategory(string id)
        {
            return courseCategoryRepository.deleteCourseCategory(id);
        }

        public bool editCourseCategory(Sys_CourseCategory coursecategory)
        {
            return courseCategoryRepository.editCourseCategory(coursecategory);
        }

        public List<Sys_CourseCategory> getAllCourseCategory()
        {
            return courseCategoryRepository.getAllCourseCategory();
        }

        public Sys_CourseCategory viewDetail(string id)
        {
            return courseCategoryRepository.viewDetail(id);
        }
    }
}
