using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.Assess
{
    public class AssessRepository : IAssessRepository
    {
        /// <summary>
        /// Lấy ra tất cả các đánh giá
        /// </summary>
        /// <returns>List danh sách phần học</returns>
        public List<Sys_Assess> getAllAssess()
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                List<Sys_Assess> lst = new List<Sys_Assess>();
                lst = _db.Sys_Assess.ToList();
                return lst;
            }
        }
        /// <summary>
        /// Xem Chi tiết đánh giá qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> section</returns>
        public Sys_Assess viewDetail(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                return _db.Sys_Assess.Find(id);
            }
        }
        /// <summary>
        /// Thêm đánh giá
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public string addAssess(Sys_Assess assess)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    assess.Assess_ID = Guid.NewGuid().ToString("D").ToUpper();
                    _db.Sys_Assess.Add(assess);
                    _db.SaveChanges();
                    return assess.Assess_ID;
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// Sửa đánh giá
        /// </summary>
        /// <param name="section">phần học cần sửa</param>
        /// <returns></returns>
        public bool editAssess(Sys_Assess assess)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var c = _db.Sys_Assess.Find(assess.Assess_ID);
                    c.IsStar = assess.IsStar;
                    c.Description = assess.Description;
                    c.CreateDate = assess.CreateDate;
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
        public bool deleteAssess(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var result = _db.Sys_Assess.Find(id);
                    _db.Sys_Assess.Remove(result);
                    _db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }


        public List<Sys_Assess> getAssessByCourse(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                return _db.Sys_Assess.Where(x => x.Course_ID == id).ToList();
            }
        }
    }
}
