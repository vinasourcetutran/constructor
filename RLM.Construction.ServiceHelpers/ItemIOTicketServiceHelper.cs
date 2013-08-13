using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Construction.Services;

namespace RLM.Construction.ServiceHelpers
{
    public class ItemIOTicketServiceHelper
    {
        public RLM.Construction.Entities.TList<RLM.Construction.Entities.ItemIOTicket> GetAll()
        {
            return ServiceRepository.ItemIOTicketService.GetAll();
        }

        public RLM.Construction.Entities.ItemIOTicket GetByIOTicketId(int itemIOTicketId)
        {
            return ServiceRepository.ItemIOTicketService.GetByIOTicketId(itemIOTicketId);
        }

        public void Update(RLM.Construction.Entities.ItemIOTicket item)
        {
            ServiceRepository.ItemIOTicketService.Update(item);
        }

        public void Insert(RLM.Construction.Entities.ItemIOTicket item)
        {
            ServiceRepository.ItemIOTicketService.Insert(item);
        }
    }
}
