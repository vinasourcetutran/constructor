using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Construction.Services;

namespace RLM.Construction.ServiceHelpers
{
    public class ContactorServiceHelper
    {
        public RLM.Construction.Entities.Contactor Get(int contactorId)
        {
            return ServiceRepository.ContactorService.GetByContactorId(contactorId);
        }
    }
}
