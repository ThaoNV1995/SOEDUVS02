using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.Test
{
    public interface ITestRepository
    {
        List<Sys_Test> getAllTest();
        string addTest(Sys_Test test);
        bool editTest(Sys_Test test);
        bool deleteTest(string id);
        Sys_Test viewDetail(string id);
    }
}
