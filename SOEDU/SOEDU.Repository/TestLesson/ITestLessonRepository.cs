using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.TestLesson
{
    public interface ITestLessonRepository
    {
        List<Sys_TestLesson> getAllTestLesson();
        string addTestLesson(Sys_TestLesson testlesson);
        bool editTestLesson(Sys_TestLesson testlesson);
        bool deleteTestLesson(string id);
        Sys_TestLesson viewDetail(string id);
    }
}
