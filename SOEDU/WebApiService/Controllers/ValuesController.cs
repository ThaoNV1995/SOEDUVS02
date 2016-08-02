namespace WebApiService.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using SOEDU.Entities.Models;
    using SOEDU.Service.Course;
using System.Web.Http.Description;

    //[Authorize]
    public class ValuesController : ApiController
    {
        private readonly ICourseService courseService = new CourseService();

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", "value3" };
        }

        // GET api/values/5
        [ResponseType(typeof(Sys_Course))]
        public IHttpActionResult Get(string id)
        {
            Sys_Course couse = courseService.viewDetail(id);
            return Ok(couse);
            //if (couse != null)
            //{
            //    return new string[] { 
            //    couse.Course_ID, 
            //    couse.Course_Name,
            //    couse.Avatar,
            //    couse.Video,  
            //    couse.Description,
            //    couse.IsPrice.ToString(),
            //    couse.IsPriceSale.ToString(),
            //    couse.ViewCount.ToString(),
            //    couse.CreateDate.ToString(),
            //    couse.Status.ToString(),
            //    couse.IsOrder.ToString()
            //};
            //}
            //else
            //{
            //    return new string[] { "fail" };
            //}
            //return new string[] { "mycourse" };

        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
