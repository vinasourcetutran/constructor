using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Construction.Services;

namespace RLM.Construction.ServiceHelpers
{
    public class AdvanceRequestServiceHelper
    {
        public RLM.Construction.Entities.TList<RLM.Construction.Entities.AdvanceRequest> GetPaged(string whereClause, string orderBy, int pageIndex, int pageSize, out int totalRecords)
        {
            return ServiceRepository.AdvanceRequestService.GetPaged(whereClause, orderBy, pageIndex, pageSize, out totalRecords);
        }

        public void Delete(int advanceRequestId)
        {
            ServiceRepository.AdvanceRequestService.Delete(advanceRequestId);
        }

        public void Insert(RLM.Construction.Entities.AdvanceRequest advanceRequest)
        {
            ServiceRepository.AdvanceRequestService.Insert(advanceRequest);
        }

        public void Update(RLM.Construction.Entities.AdvanceRequest advanceRequest)
        {
            ServiceRepository.AdvanceRequestService.Update(advanceRequest);
        }

        public RLM.Construction.Entities.TList<RLM.Construction.Entities.AdvanceRequest> GetPaged(int resourceId, RLM.Construction.Entities.AdvanceRequestType resourceType)
        {
            return ServiceRepository.AdvanceRequestService.GetPaged(resourceId, resourceType);
        }
    }
}
