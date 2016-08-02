using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.Target
{
    public interface ITargetRepository
    {
        List<Sys_Target> getAllTarget();
        string addTarget(Sys_Target target);
        bool editTarget(Sys_Target target);
        bool deleteTarget(string id);
        Sys_Target viewDetail(string id);
    }
}
