using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.TeacherCourse
{
    public interface ITeacherCourseRepository
    {
        List<Sys_TeacherCourse> getAllTeacherCourse();
        string addTeacherCourse(Sys_TeacherCourse teachercourse);
        bool editTeacherCourse(Sys_TeacherCourse teachercourse);
        bool deleteTeacherCourse(string id);
        Sys_TeacherCourse viewDetail(string id);
    }
}
