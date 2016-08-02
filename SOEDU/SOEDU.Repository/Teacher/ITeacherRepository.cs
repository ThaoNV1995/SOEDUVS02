using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOEDU.Entities.Models;

namespace SOEDU.Repository.Teacher
{
    public interface ITeacherRepository
    {
        List<Sys_GetListCourse_Result> GetListCourse();
    }
}
