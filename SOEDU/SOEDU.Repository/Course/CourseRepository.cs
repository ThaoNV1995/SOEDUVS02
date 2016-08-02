using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.Course
{
    public class CourseRepository : ICourseRepository
    {
        /// <summary>
        /// Lấy danh sách khóa học
        /// </summary>
        /// <returns>List</returns>
        public List<Sys_Course> getAllCourse()
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                List<Sys_Course> lst = new List<Sys_Course>();
                lst = _db.Sys_Course.ToList();
                return lst;
            }
        }

        /// <summary>
        /// Xem chi tiết 1 khóa học
        /// </summary>
        /// <param name="id">ID khóa học</param>
        /// <returns>Course</returns>
        public Sys_Course viewDetail(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {

                return _db.Sys_Course.Find(id);
            }
        }

        /// <summary>
        /// Tạo 1 khóa học
        /// </summary>
        /// <param name="course">Course</param>
        /// <returns>long</returns>
        public string addCourse(Sys_Course course)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    course.Course_ID = Guid.NewGuid().ToString("D").ToUpper();
                    _db.Sys_Course.Add(course);
                    _db.SaveChanges();
                    return course.Course_ID;
                }
                catch (Exception)
                {
                    return "Lỗi";
                }
            }
        }

        //Cập nhật khóa học
        /// <summary>
        /// Cập Nhật Khóa Học
        /// </summary>
        /// <param name="course">Course</param>
        /// <returns>bool</returns>
        public bool editCourse(Sys_Course course)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var c = _db.Sys_Course.Find(course.Course_ID);
                    if (course.Course_Name != null)
                    {
                        c.Course_Name = course.Course_Name;
                    }
                    else
                    {
                        c.Course_Name = c.Course_Name;
                    }
                    if (course.Category_ID != null)
                    {
                        c.Category_ID = course.Category_ID;
                    }
                    else
                    {
                        c.Category_ID =c.Category_ID;
                    }
                    if (course.Avatar != null)
                    {
                        c.Avatar = course.Avatar;
                    }
                    else
                    {
                        c.Avatar = c.Avatar;
                    }
                    if (course.Video != null)
                    {
                        c.Video = course.Video;
                    }
                    else
                    {
                        c.Video = c.Video;
                    }
                    if (course.VideoImg != null)
                    {
                        c.VideoImg = course.VideoImg;
                    }
                    else
                    {
                        c.VideoImg = c.VideoImg;
                    }
                    if (course.Description != null)
                    {
                        c.Description = course.Description;
                    }
                    else
                    {
                        c.Description = c.Description;
                    }
                    if (course.IsValue)
                    {
                        c.IsPrice = course.IsPrice;
                        c.IsPriceSale = course.IsPriceSale;
                    }
                    if (course.Status != null)
                    {
                        c.Status = course.Status;
                    }
                    else
                    {
                        c.Status = c.Status;
                    }
                    if (course.IsOrder != null)
                    {
                        c.IsOrder = course.IsOrder;
                    }
                    else
                    {
                        c.IsOrder = c.IsOrder;
                    }
                    if (course.IsValue != null)
                    {
                        c.IsValue = course.IsValue;
                    }
                    else
                    {
                        c.IsValue = c.IsValue;
                    }
                    _db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Xóa 1 khóa học
        /// </summary>
        /// <param name="id">ID khóa học</param>
        /// <returns>bool</returns>
        public bool deleteCourse(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var result = _db.Sys_Course.Find(id);
                    _db.Sys_Course.Remove(result);
                    _db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public List<Common.Models.CategoryModels> GetCourseCategory()
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                List<Common.Models.CategoryModels> list = new List<Common.Models.CategoryModels>();
                var model = _db.Sys_CourseCategory.Where(x => x.Parent_ID == null).Select(t => new { t.Category_ID, t.Category_Name, t.Title_Name, t.IsIcon,t.IsOrder, t.Parent_ID, lv = 0 }).OrderBy(x=>x.IsOrder);
                foreach(var t in model)
                {
                    Common.Models.CategoryModels cat = new Common.Models.CategoryModels(t.Category_ID, t.Category_Name, t.Title_Name, t.IsIcon,t.IsOrder, t.Parent_ID, t.lv);
                    list.Add(cat);
                    SetCourseCategory(list, t.Category_ID, 1);
                }
                return list;
            }
        }

        public void SetCourseCategory(List<SOEDU.Common.Models.CategoryModels> list, string ParentID, int lv)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                var strc = "";
                for (int i = 0; i < lv; i++)
                {
                    strc += "------";
                }
                string tn = _db.Sys_CourseCategory.Where(x => x.Category_ID == ParentID).FirstOrDefault().Category_Name;
                var Cate = _db.Sys_CourseCategory.Where(x => x.Parent_ID == ParentID).Select(t => new { t.Category_ID, NameCategory = strc + t.Category_Name, t.IsIcon, t.IsOrder, t.Parent_ID, t.Title_Name, lv }).OrderBy(x=>x.IsOrder);
                if (Cate.Count() > 0)
                {
                    foreach (var t in Cate)
                    {
                        SOEDU.Common.Models.CategoryModels obj = new Common.Models.CategoryModels(t.Category_ID,  t.NameCategory,t.Title_Name, t.IsIcon,t.IsOrder, t.Parent_ID, t.lv);
                        list.Add(obj);
                        SetCourseCategory(list, t.Category_ID, lv + 1);
                    }
                }
            }
        }



    }
}
