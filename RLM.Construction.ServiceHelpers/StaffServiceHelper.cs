using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Construction.Services;

namespace RLM.Construction.ServiceHelpers
{
    public class StaffServiceHelper
    {
        public RLM.Construction.Entities.Staff GetByStaffId(int staffId)
        {
            return ServiceRepository.StaffService.GetByStaffId(staffId);
        }

        public RLM.Construction.Entities.TList<RLM.Construction.Entities.Staff> GetAll()
        {
            return ServiceRepository.StaffService.GetAll();
        }


        public void Update(RLM.Construction.Entities.Staff staff)
        {
            ServiceRepository.StaffService.Update(staff);
        }

        public void Insert(RLM.Construction.Entities.Staff staff)
        {
            ServiceRepository.StaffService.Insert(staff);
        }
    }
}
