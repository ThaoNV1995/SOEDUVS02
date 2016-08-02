using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SOEDU.Entities.Models;
using SOEDU.Service.Teacher;

namespace WebApiService.Controllers
{
    public class TeacherController : ApiController
    {
        private readonly ITeacherService teacher = new TeacherService();

        // GET api/teacher
         [HttpGet, ActionName("getlistcourse")]
        public IEnumerable<Sys_GetListCourse_Result> Get()
       {
            return teacher.GetListCourse();
        }
    }
}
