using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.TestSectionAnswer
{
    public interface ITestSectionAnswerRepository
    {
        List<Sys_TestSectionAnswer> getAllTestSectionAnswer();
        string addTestSectionAnswer(Sys_TestSectionAnswer testsectionanswer);
        bool editTestSectionAnswer(Sys_TestSectionAnswer testsectionanswer);
        bool deleteTestSectionAnswer(string id);
        Sys_TestSectionAnswer viewDetail(string id);
    }
}
