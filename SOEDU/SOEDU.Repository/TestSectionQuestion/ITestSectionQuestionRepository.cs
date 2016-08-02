using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.TestSectionQuestion
{
    public interface ITestSectionQuestionRepository
    {
        List<Sys_TestSectionQuestion> getAllTestSectionQuestion();
        string addTestSectionQuestion(Sys_TestSectionQuestion testsectionquestion);
        bool editTestSectionQuestion(Sys_TestSectionQuestion testsectionquestion);
        bool deleteTestSectionQuestion(string id);
        Sys_TestSectionQuestion viewDetail(string id);
    }
}
