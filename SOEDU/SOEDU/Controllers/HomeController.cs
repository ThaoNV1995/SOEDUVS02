using Newtonsoft.Json;
using SOEDU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SOEDU.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using(var client=new HttpClient())
            {
                string url = "http://localhost:49401";
                client.BaseAddress = new Uri("http://localhost:49401");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(url+"/api/teacher").Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    var course = JsonConvert.DeserializeObject<List<ListCourseModel>>(responseString);
                    return View(course);
                }
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}