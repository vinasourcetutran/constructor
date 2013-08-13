using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Construction.Services;

namespace RLM.Construction.ServiceHelpers
{
    public class ProjectPhaseServiceHelper
    {
        public RLM.Construction.Entities.ProjectPhase GetCurrentPhaseByProjectId(int projectId)
        {
            return ServiceRepository.ProjectPhaseService.GetCurrentPhaseByProjectId(projectId);
        }

        public RLM.Construction.Entities.TList<RLM.Construction.Entities.ProjectPhase> GetByProjectId(int projectId)
        {
            return ServiceRepository.ProjectPhaseService.GetByProjectId(projectId);
        }

        public RLM.Construction.Entities.TList<RLM.Construction.Entities.ProjectPhase> GetByContractId(int contractId)
        {
            return ServiceRepository.ProjectPhaseService.GetByContractId(contractId);
        }

        public RLM.Construction.Entities.TList<RLM.Construction.Entities.ProjectPhase> GetByContractId(int contractId, string ignoreId)
        {
            return ServiceRepository.ProjectPhaseService.GetByContractId(contractId, ignoreId); 
        }

        public RLM.Construction.Entities.TList<RLM.Construction.Entities.ProjectPhase> GetByProjectId(int projectId, string ignoreId)
        {
            return ServiceRepository.ProjectPhaseService.GetByProjectId(projectId, ignoreId); 
        }

        public RLM.Construction.Entities.ProjectPhase GetByProjectPhaseId(int projectPhaseId)
        {
            return ServiceRepository.ProjectPhaseService.GetByProjectPhaseId(projectPhaseId);
        }
    }
}
