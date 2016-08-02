using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.StudentTest
{
    public interface IStudentTestRepository
    {
        List<Sys_StudentTest> getAllStudentTest();
        string addStudentTest(Sys_StudentTest studentTest);
        bool editStudentTest(Sys_StudentTest studentTest);
        bool deleteStudentTest(string id);
        Sys_StudentTest viewDetail(string id);
    }
}
