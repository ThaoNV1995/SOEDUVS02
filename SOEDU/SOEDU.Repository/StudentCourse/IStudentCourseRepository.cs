using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.StudentCourse
{
    public interface IStudentCourseRepository
    {
        List<Sys_StudentCourse> getAllStudentCourse();
        string addStudentCourse(Sys_StudentCourse studentcourse);
        bool editStudentCourse(Sys_StudentCourse studentcourse);
        bool deleteStudentCourse(string id);
        Sys_StudentCourse viewDetail(string id);
    }
}
