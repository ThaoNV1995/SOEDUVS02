using SOEDU.Repository.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Service.Teacher
{
    public class TeacherService:ITeacherService
    {
        ITeacherRepository teacher = new TeacherRepository();
        public List<Entities.Models.Sys_GetListCourse_Result> GetListCourse()
        {
            return teacher.GetListCourse();
        }
    }
}
