using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOEDU.Entities.Models;
using SOEDU.Repository.Assess;

namespace SOEDU.Service.Assess
{
    public class AssessService : IAssessService
    {
        AssessRepository assessRepository = new AssessRepository();
        public string addAssess(Sys_Assess assess)
        {
            return assessRepository.addAssess(assess);
        }

        public bool deleteAssess(string id)
        {
            return assessRepository.deleteAssess(id);
        }

        public bool editAssess(Sys_Assess assess)
        {
            return assessRepository.editAssess(assess);
        }

        public List<Sys_Assess> getAllAssess()
        {
            return assessRepository.getAllAssess();
        }

        public Sys_Assess viewDetail(string id)
        {
            return assessRepository.viewDetail(id);
        }


        public List<Sys_Assess> getAssessByCourse(string id)
        {
            return assessRepository.getAssessByCourse(id);
        }
    }
}
