using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.Section
{
    public class SectionRepository : ISectionRepository
    {
        /// <summary>
        /// Lấy ra tất cả các phần học
        /// </summary>
        /// <returns>List danh sách phần học</returns>
        public List<Sys_Section> getAllSection()
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                List<Sys_Section> lst = new List<Sys_Section>();
                lst = _db.Sys_Section.ToList();
                return lst;
            }
        }
        /// <summary>
        /// Xem Chi tiết phần học qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> section</returns>
        public Sys_Section viewDetail(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                return _db.Sys_Section.Find(id);
            }
        }
        /// <summary>
        /// Thêm phần học
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public string addSection(Sys_Section section)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    _db.Sys_Section.Add(section);
                    _db.SaveChanges();
                    return section.Section_ID;
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// Sửa phần học
        /// </summary>
        /// <param name="section">phần học cần sửa</param>
        /// <returns></returns>
        public bool editSection(Sys_Section section)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var c = _db.Sys_Section.Find(section.Section_ID);
                    c.Section_Name = section.Section_Name;
                    c.Title = section.Title;
                    c.Description = section.Description;
                    c.CreateDate = section.CreateDate;
                    c.IsOrder = section.IsOrder;
                    c.IsStatus = section.IsStatus;
                    c.Course_ID = c.Course_ID;
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
        public bool deleteSection(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var result = _db.Sys_Section.Find(id);
                    _db.Sys_Section.Remove(result);
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
