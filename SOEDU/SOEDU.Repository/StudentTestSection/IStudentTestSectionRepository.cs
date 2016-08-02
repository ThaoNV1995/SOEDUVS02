using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.StudentTestSection
{
    public interface IStudentTestSectionRepository
    {
        List<Sys_StudentTestSection> getAllStudentTestSection();
        string addStudentTestSection(Sys_StudentTestSection studenttestsection);
        bool editStudentTestSection(Sys_StudentTestSection studenttestsection);
        bool deleteStudentTestSection(string id);
        Sys_StudentTestSection viewDetail(string id);
    }
}
