using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Service.Assess
{
    public interface IAssessService
    {
        List<Sys_Assess> getAllAssess();
        string addAssess(Sys_Assess assess);
        bool editAssess(Sys_Assess assess);
        bool deleteAssess(string id);
        Sys_Assess viewDetail(string id);
        List<Sys_Assess> getAssessByCourse(string id);
    }
}
