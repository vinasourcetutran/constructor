using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Core.Framework.Log;
using RLM.Construction.Services;
using RLM.Construction.Entities;

namespace RLM.Construction.ServiceHelpers
{
    public class ProjectServiceHelper
    {
        public RLM.Construction.Entities.Project GetItemByContractId(int contractId)
        {
            return ServiceRepository.ProjectService.GetItemByContractId(contractId);
        }

        public TList<Project> GetByPartnerId(int partnerId, string orderBy)
        {
            return ServiceRepository.ProjectService.GetByPartnerId(partnerId, orderBy);
        }

        public Project GetByProjectId(int projectId)
        {
            return ServiceRepository.ProjectService.GetByProjectId(projectId);
        }
    }
}
