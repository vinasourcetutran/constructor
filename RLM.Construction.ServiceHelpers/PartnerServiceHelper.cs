using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Construction.Services;

namespace RLM.Construction.ServiceHelpers
{
    public class PartnerServiceHelper
    {
        public RLM.Construction.Entities.Partner GetByPartnerId(int partnerId)
        {
            return ServiceRepository.PartnerService.GetByPartnerId(partnerId);
        }

        public Entities.Partner GetPartnerByTaxtCode(string taxCode)
        {
            int totalRecords;
            string whereClause = string.Format("[TaxCode]='{0}'", taxCode);
            IList<Entities.Partner> items = ServiceRepository.PartnerService.GetPaged(whereClause, "PartnerID", 0, 0, out totalRecords);
            return totalRecords > 0 ? items[0] : null;
        }
    }
}
