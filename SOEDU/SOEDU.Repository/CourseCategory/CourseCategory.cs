using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.CourseCategory
{
    public class CourseCategory : ICourseCategory
    {
        /// <summary>
        /// Lấy ra tất cả các loại khóa học
        /// </summary>
        /// <returns>List danh sách loại khóa học</returns>
        public List<Sys_CourseCategory> getAllCourseCategory()
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                List<Sys_CourseCategory> lst = new List<Sys_CourseCategory>();
                lst = _db.Sys_CourseCategory.ToList();
                return lst;
            }
        }
        /// <summary>
        /// Xem Chi tiết loại khóa học qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> section</returns>
        public Sys_CourseCategory viewDetail(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                return _db.Sys_CourseCategory.Find(id);
            }
        }
        /// <summary>
        /// Thêm loại khóa học
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public string addCourseCategory(Sys_CourseCategory coursecategory)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    coursecategory.Category_ID = Guid.NewGuid().ToString("D").ToUpper();
                    _db.Sys_CourseCategory.Add(coursecategory);
                    _db.SaveChanges();
                    return coursecategory.Category_ID;
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// Sửa loại khóa học
        /// </summary>
        /// <param name="section">loại khóa học cần sửa</param>
        /// <returns></returns>
        public bool editCourseCategory(Sys_CourseCategory coursecategory)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var c = _db.Sys_CourseCategory.Find(coursecategory.Category_ID);
                    c.Category_Name = coursecategory.Category_Name;
                    c.Title_Name = coursecategory.Title_Name;
                    c.IsIcon = coursecategory.IsIcon;
                    c.Parent_ID = coursecategory.Parent_ID;
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
        /// xóa 1 bản ghi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool deleteCourseCategory(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var result = _db.Sys_CourseCategory.Find(id);
                    _db.Sys_CourseCategory.Remove(result);
                    _db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
