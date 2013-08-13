using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Construction.Services;

namespace RLM.Construction.ServiceHelpers
{
    public class ItemInProjectServiceHelper
    {
        public RLM.Construction.Entities.TList<RLM.Construction.Entities.ItemInProject> GetByProjectPhaseId(int projectPhaseId, string orderBy)
        {
            return ServiceRepository.ItemInProjectService.GetByProjectPhaseId(projectPhaseId, orderBy);
        }

        public RLM.Construction.Entities.TList<RLM.Construction.Entities.ItemInProject> GetByProjectId(int projectId)
        {
            return ServiceRepository.ItemInProjectService.GetByProjectId(projectId);
        }

        public RLM.Construction.Entities.TList<RLM.Construction.Entities.ItemInProject> GetByContractId(int contractId)
        {
            return ServiceRepository.ItemInProjectService.GetByContractId(contractId);
        }

        public RLM.Construction.Entities.TList<RLM.Construction.Entities.ItemInProject> GetByResource(RLM.Construction.Entities.ResourceType resourceType, int resourceId, bool isDetailItem)
        {
            return ServiceRepository.ItemInProjectService.GetByResource(resourceType, resourceId, isDetailItem);
        }

        public RLM.Construction.Entities.TList<RLM.Construction.Entities.ItemInProject> GetItemInProjectPhase(string projectPhaseIds)
        {
            return ServiceRepository.ItemInProjectService.GetItemInProjectPhase(projectPhaseIds);
        }

        public RLM.Construction.Entities.ItemInProject GetByItemIdAndProjectPhaseId(long itemId, int projectPhaseId)
        {
            return ServiceRepository.ItemInProjectService.GetByItemIdAndProjectPhaseId(itemId, projectPhaseId);
        }
    }
}
