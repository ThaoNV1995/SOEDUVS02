using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.Lesson
{
    public class LessonRepository:ILessonRepository
    {
        /// <summary>
        /// Lấy ra tất cả các chương học
        /// </summary>
        /// <returns>List danh sách chương học</returns>
        public List<Sys_Lesson> getAllLesson()
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                List<Sys_Lesson> lst = new List<Sys_Lesson>();
                lst = _db.Sys_Lesson.ToList();
                return lst;
            }
        }
        /// <summary>
        /// Xem Chi tiết chương học qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> section</returns>
        public Sys_Lesson viewDetail(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                return _db.Sys_Lesson.Find(id);
            }
        }
        /// <summary>
        /// Thêm chương học
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public string addLesson(Sys_Lesson lesson)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    lesson.Lesson_ID = Guid.NewGuid().ToString("D").ToUpper();
                    _db.Sys_Lesson.Add(lesson);
                    _db.SaveChanges();
                    return lesson.Lesson_ID;
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// Sửa chương học
        /// </summary>
        /// <param name="section">chương học cần sửa</param>
        /// <returns></returns>
        public bool editLesson(Sys_Lesson lesson)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var c = _db.Sys_Lesson.Find(lesson.Section_ID);
                    if (lesson.Lesson_Name != null)
                    {
                        c.Lesson_Name = lesson.Lesson_Name;
                    }
                    else
                    {
                        c.Lesson_Name = c.Lesson_Name;
                    }
                    c.Title = lesson.Title;
                    c.Description = lesson.Description;
                    c.Video = lesson.Video;
                    c.ParentID = lesson.ParentID;
                    c.CreateDate = lesson.CreateDate;
                    c.IsOrder = lesson.IsOrder;
                    c.IsStatus = lesson.IsStatus;
                    c.Section_ID = c.Section_ID;
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
        public bool deleteLesson(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var result = _db.Sys_Lesson.Find(id);
                    _db.Sys_Lesson.Remove(result);
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
