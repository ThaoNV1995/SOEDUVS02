using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.Lesson
{
    public interface ILessonRepository
    {
        List<Sys_Lesson> getAllLesson();
        string addLesson(Sys_Lesson lesson);
        bool editLesson(Sys_Lesson lesson);
        bool deleteLesson(string id);
        Sys_Lesson viewDetail(string id);
    }
}
