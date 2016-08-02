using Newtonsoft.Json;
using SOEDU.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SOEDU.Controllers
{
    public class CourseController : Controller
    {
        HttpClient client;
        string url = "http://localhost:49401/api";
        public CourseController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(string id)
        {
           
            HttpResponseMessage responseMessage = client.GetAsync(url + "/Course/" + id).Result;
            if(responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Course = JsonConvert.DeserializeObject<CourseModel>(responseData);
                HttpResponseMessage responseAssess = client.GetAsync(url + "/Assess/" + Course.Course_ID).Result;
                if (responseAssess.IsSuccessStatusCode)
                {
                    var responseDataAssess = responseAssess.Content.ReadAsStringAsync().Result;

                    var Assess = JsonConvert.DeserializeObject<List<AssessModels>>(responseDataAssess);

                    ViewBag.Assess = Assess;
                    LoadDropCategory();
                    return View(Course);
                }
                
            }
           
            return View("Error");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(string id, CourseModel course, HttpPostedFileBase courseCover, string[] courseTarget)
        {
            string ass = string.Join(",", courseTarget);
            if (courseCover != null && courseCover.ContentLength > 0)
            {
                string filename = course.Course_ID + "-" + courseCover.FileName;
                courseCover.SaveAs(Server.MapPath("~/Content/Img/" + filename));
                course.Avatar = "/Content/Img/"+filename;
            }
            var json = new JavaScriptSerializer().Serialize(course);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PutAsync(url + "/Course/" + course.Course_ID + "?ass=" + ass, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                
                LoadDropCategory();
                return RedirectToAction("Edit", new { id=course.Course_ID});
            }
            return RedirectToAction("Error");
        }

        [HttpPost]
        public async Task<ActionResult> UpdateVideo(CourseModel course, HttpPostedFileBase FileUpload, string thumb)
        {
            string sourcePath = System.Web.HttpContext.Current.Server.MapPath("~/video");
            string destinationPath = System.Web.HttpContext.Current.Server.MapPath("~/Content/Img");
            string sourceFileName = thumb.Remove(0, 7);
            string sourceFile = System.IO.Path.Combine(sourcePath, sourceFileName);
            string destinationFile = System.IO.Path.Combine(destinationPath, sourceFileName);

            //if (!System.IO.Directory.Exists(destinationPath))
            //{
            //    System.IO.Directory.CreateDirectory(destinationPath);
            //}
            System.IO.File.Copy(sourceFile, destinationFile, true);
            if(!course.IsYoutube)
            {
                if (FileUpload != null && FileUpload.ContentLength > 0)
                {
                    string filename = course.Course_ID + "-" + FileUpload.FileName;
                    FileUpload.SaveAs(Server.MapPath("~/Content/Img/" + filename));
                    course.Video = filename;
                }

            }
            course.VideoImg = "/Content/Img/" + thumb.Remove(0, 7).ToString();
            var json = new JavaScriptSerializer().Serialize(course);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PutAsync(url + "/Course/" + course.Course_ID + "?ass=", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                LoadDropCategory();
                return RedirectToAction("Edit", new { id = course.Course_ID });
            }
            return RedirectToAction("Error");

        }

        public ActionResult UpVideoThumb(string Course_ID, HttpPostedFileBase FileUpload)
        {
            if (FileUpload != null && FileUpload.ContentLength > 0)
            {
                string filename = Course_ID + "-" + FileUpload.FileName;
                FileUpload.SaveAs(Server.MapPath("~/video/" + filename));
            }
            List<string> thumb = new List<string>() { null, null, null, null };
            for (int i = 0; i < 4; i++)
            {
                thumb[i] = generateThumb("~/video/"+Course_ID + "-" + FileUpload.FileName);
            }
            
            return Json(thumb, JsonRequestBehavior.AllowGet);
        }
        

        public ActionResult Content(string id)
        {
            return View();
        }

       [ChildActionOnly]
        public PartialViewResult _MenuLeft(string id)
        {
            HttpResponseMessage responseMessage = client.GetAsync(url + "/Course/" + id).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Course = JsonConvert.DeserializeObject<CourseModel>(responseData);

                return PartialView("~/Views/Shared/Local/_MenuLeft.cshtml", Course);
            }
            return PartialView("Error");
        }

        public void LoadDropCategory()
       {
           var drop = new List<SelectListItem>();
           HttpResponseMessage responseMessage = client.GetAsync(url+"/Course").Result;
           if (responseMessage.IsSuccessStatusCode)
           {
               var responseData = responseMessage.Content.ReadAsStringAsync().Result;

               var CourseCategory = JsonConvert.DeserializeObject<List<SOEDU.Common.Models.CategoryModels>>(responseData);
               foreach(var t in CourseCategory)
               {
                   drop.Add(new SelectListItem { Value = t.Category_ID.ToString(), Text = t.Category_Name });
               }
               ViewData["Category"] = drop;
           }
       }
        
        public static string generateThumb(string file)
        {
            string thumb = "";
           
            try
            {
                FileInfo fi = new FileInfo(System.Web.HttpContext.Current.Server.MapPath(file));
                string filename = Path.GetFileNameWithoutExtension(fi.Name);
                Random random = new Random();
                int rand = random.Next(1, 9999999);
                string newfilename = "/video/" + filename + "_(" + rand.ToString() + ").jpg";
                var processInfo = new ProcessStartInfo();
                processInfo.FileName = "\"" + System.Web.HttpContext.Current.Server.MapPath("/video/ffmpeg/bin/ffmpeg.exe") + "\"";
                int rd= random.Next(1, 100);
                processInfo.Arguments = string.Format("-ss {0} -i {1} -f image2 -vframes 1 -y {2}", rd, "\"" + System.Web.HttpContext.Current.Server.MapPath(file) + "\"", "\"" + System.Web.HttpContext.Current.Server.MapPath(newfilename) + "\"");
                processInfo.CreateNoWindow = true;
                processInfo.UseShellExecute = false;
                using (var process = new Process())
                {
                    process.StartInfo = processInfo;
                    process.Start();
                    process.WaitForExit();
                    thumb = newfilename;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

            return thumb;
        }

        
	}
}