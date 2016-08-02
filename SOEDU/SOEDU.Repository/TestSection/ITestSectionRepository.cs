using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.TestSection
{
    public interface ITestSectionRepository
    {
        List<Sys_TestSection> getAllTestSection();
        string addTestSection(Sys_TestSection testSection);
        bool editTestSection(Sys_TestSection testSection);
        bool deleteTestSection(string id);
        Sys_TestSection viewDetail(string id);
    }
}
