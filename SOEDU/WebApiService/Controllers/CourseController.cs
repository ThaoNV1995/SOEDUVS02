using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SOEDU.Entities.Models;
using SOEDU.Service.Course;
using System.Web.Http.Description;
using WebApiService.Models;
using SOEDU.Service.Assess;

namespace WebApiService.Controllers
{
    public class CourseController : ApiController
    {
        private readonly ICourseService courseService = new CourseService();
        private readonly IAssessService assService = new AssessService();

        [HttpPost, ActionName("CreateCourse")]
        public string CreateCourse(Sys_Course course)
        {
            courseService.addCourse(course);
            return course.Course_ID;
        }

        [HttpPost, ActionName("getcoursebyid")]
        public string GetCourseById(string courseId)
        {
            courseService.viewDetail(courseId);
            return "";

        }

        [ActionName("getcourse")]
        [ResponseType(typeof(Sys_Course))]
        public IHttpActionResult Get(string id)
        {
            Sys_Course couse = courseService.viewDetail(id);
            return Ok(couse);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(string id, Sys_Course course, string ass)
        {
            if (ass != null)
            {
                string[] assess = ass.Split(',');
                if (assess.Length > 0)
                {
                    if (assService.getAssessByCourse(course.Course_ID).Count > 0)
                    {
                        foreach (var item in assService.getAssessByCourse(course.Course_ID))
                        {
                            assService.deleteAssess(item.Assess_ID);
                        }
                    }

                    for (int i = 0; i < assess.Length; i++)
                    {
                        Sys_Assess sysAss = new Sys_Assess();
                        sysAss.Course_ID = course.Course_ID;
                        sysAss.CreateDate = DateTime.Now;
                        sysAss.Description = assess[i].ToString();
                        sysAss.IsStar = i;
                        assService.addAssess(sysAss);
                    }
                }
            }
            courseService.editCourse(course);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet, ActionName("getcoursecategory")]
        public IEnumerable<SOEDU.Common.Models.CategoryModels> GetCourseCategory()
        {
            return courseService.GetCourseCategory();
        }



    }
}
