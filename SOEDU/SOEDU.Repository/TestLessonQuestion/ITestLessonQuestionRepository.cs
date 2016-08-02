using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.TestLessonQuestion
{
    public interface ITestLessonQuestionRepository
    {
        List<Sys_TestLessonQuestion> getAllTestLessonQuestion();
        string addTestLessonQuestion(Sys_TestLessonQuestion testslessonquestion);
        bool editTestLessonQuestion(Sys_TestLessonQuestion testslessonquestion);
        bool deleteTestLessonQuestion(string id);
        Sys_TestLessonQuestion viewDetail(string id);
    }
}
