using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.Attach
{
    public interface IAttachRepository
    {
        List<Sys_Attach> getAllAttach();
        string addAttach(Sys_Attach attach);
        bool editAttach(Sys_Attach attach);
        bool deleteAttach(string id);
        Sys_Attach viewDetail(string id);
    }
}
