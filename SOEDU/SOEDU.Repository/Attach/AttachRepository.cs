using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.Attach
{
    public class AttachRepository : IAttachRepository
    {
        /// <summary>
        /// Lấy ra tất cả các file đính kèm
        /// </summary>
        /// <returns>List danh sách phần học</returns>
        public List<Sys_Attach> getAllAttach()
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                List<Sys_Attach> lst = new List<Sys_Attach>();
                lst = _db.Sys_Attach.ToList();
                return lst;
            }
        }
        /// <summary>
        /// Xem Chi tiết file đính kèm qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> section</returns>
        public Sys_Attach viewDetail(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                return _db.Sys_Attach.Find(id);
            }
        }
        /// <summary>
        /// Thêm file đính kèm
        /// </summary>
        /// <param name="attach"></param>
        /// <returns></returns>
        public string addAttach(Sys_Attach attach)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    _db.Sys_Attach.Add(attach);
                    _db.SaveChanges();
                    return attach.Attach_ID;
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// Sửa file đính kèm
        /// </summary>
        /// <param name="attach">file đính kèm cần sửa</param>
        /// <returns></returns>
        public bool editAttach(Sys_Attach attach)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var c = _db.Sys_Attach.Find(attach.Attach_ID);
                    c.File_Name = attach.File_Name;
                    c.Des = attach.Des;
                    c.FileSource = attach.FileSource;
                    c.FileSize = attach.FileSize;
                    c.IsOrder = attach.IsOrder;
                    c.Lesson_ID = attach.Lesson_ID;
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
        public bool deleteAttach(string id)
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
