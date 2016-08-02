using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.Section
{
    public interface ISectionRepository
    {
        List<Sys_Section> getAllSection();
        string addSection(Sys_Section section);
        bool editSection(Sys_Section section);
        bool deleteSection(string id);
        Sys_Section viewDetail(string id);
    }
}
