using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.TestLessonAnswer
{
    public interface ITestLessonAnswerRepository
    {
        List<Sys_TestLessonAnswer> getAllTestLessonAnswer();
        string addTestLessonAnswer(Sys_TestLessonAnswer testlessonanswer);
        bool editTestLessonAnswer(Sys_TestLessonAnswer testlessonanswer);
        bool deleteTestLessonAnswer(string id);
        Sys_TestLessonAnswer viewDetail(string id);
    }
}
