using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Construction.Services;
using RLM.Construction.Entities;

namespace RLM.Construction.ServiceHelpers
{
    public class ItemIOItemServiceHelper
    {
        public RLM.Construction.Entities.TList<RLM.Construction.Entities.ItemIOItem> GetByItemIOTicketId(int itemIOTicketId)
        {
            return ServiceRepository.ItemIOItemService.GetByItemIOTicketId(itemIOTicketId);
        }

        public void Insert(RLM.Construction.Entities.ItemIOItem item)
        {
            ServiceRepository.ItemIOItemService.Insert(item);
        }

        public void Update(RLM.Construction.Entities.ItemIOItem item)
        {
            ServiceRepository.ItemIOItemService.Update(item);
        }

        public RLM.Construction.Entities.ItemIOItem ItemIOItemId(int itemId)
        {
            return ServiceRepository.ItemIOItemService.GetByItemIOItemId(itemId);
        }

        public RLM.Construction.Entities.ItemIOItem GetByTicketIdAndItemId(int ticketId, int itemId)
        {
            return ServiceRepository.ItemIOItemService.GetByTicketIdAndItemId(ticketId, itemId);
        }

        public TList<ItemIOItem> GetByItemIdAndType(int itemId, ItemIOTicketType ioType, int pageSize, int pageIndex, out int totalRecords)
        {
            return ServiceRepository.ItemIOItemService.GetByItemIdAndType(itemId, ioType, pageSize, pageIndex, out totalRecords);
        }
    }
}
