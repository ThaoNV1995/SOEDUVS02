using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOEDU.Entities.Models;
using SOEDU.Repository.Attach;

namespace SOEDU.Service.Attach
{
    public class AttachService : IAttachService
    {
        AttachRepository attachRepository = new AttachRepository();
        public string addAttach(Sys_Attach attach)
        {
            return attachRepository.addAttach(attach);
        }

        public bool deleteAttach(string id)
        {
            return attachRepository.deleteAttach(id);
        }

        public bool editAttach(Sys_Attach attach)
        {
            return attachRepository.editAttach(attach);
        }

        public List<Sys_Attach> getAllAttach()
        {
            return attachRepository.getAllAttach();
        }

        public Sys_Attach viewDetail(string id)
        {
            return attachRepository.viewDetail(id);
        }
    }
}
