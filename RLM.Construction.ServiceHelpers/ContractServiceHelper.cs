using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Construction.Services;

namespace RLM.Construction.ServiceHelpers
{
    public class ContractServiceHelper
    {
        public RLM.Construction.Entities.Contract Get(int contractId)
        {
            return ServiceRepository.ContractService.GetByContractId(contractId);
        }
    }
}
