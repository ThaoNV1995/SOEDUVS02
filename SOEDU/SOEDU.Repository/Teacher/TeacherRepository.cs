using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOEDU.Entities.Models;

namespace SOEDU.Repository.Teacher
{
    public class TeacherRepository : ITeacherRepository
    {
        public List<Sys_GetListCourse_Result> GetListCourse()
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                _db.Database.Connection.Open();
                var result = _db.Database.SqlQuery<Sys_GetListCourse_Result>("EXEC Sys_GetListCourse").ToList();
                return result;
            }
        }
    }
}
