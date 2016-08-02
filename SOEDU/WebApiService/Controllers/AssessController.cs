using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SOEDU.Entities.Models;
using SOEDU.Service.Assess;
using System.Web.Http.Description;

namespace WebApiService.Controllers
{
    public class AssessController : ApiController
    {
        private readonly IAssessService assService = new AssessService();

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(string id, Sys_Assess assess)
        {
            assService.addAssess(assess);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet, ActionName("getlistassess")]
        public IEnumerable<Sys_Assess> Get(string id)
        {
            return assService.getAssessByCourse(id);
        }
    }
}
