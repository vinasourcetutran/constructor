using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Construction.Services;
using RLM.Construction.Entities;

namespace RLM.Construction.ServiceHelpers
{
    public class AppConfigServiceHelper
    {
        public RLM.Construction.Entities.TList<RLM.Construction.Entities.AppConfig> GetPaged(string whereClause, string orderBy, int pageSize, int pageIndex, out int totalRecords)
        {
            return ServiceRepository.AppConfigService.GetPaged(whereClause,orderBy,pageSize, pageIndex, out totalRecords);
        }

        public void Delete(int appconfigId)
        {
            ServiceRepository.AppConfigService.Delete(appconfigId);
        }

        public RLM.Construction.Entities.AppConfig Get(int appconfigId)
        {
            return ServiceRepository.AppConfigService.GetByAppConfigId(appconfigId);
        }

        public void Update(RLM.Construction.Entities.AppConfig item)
        {
            ServiceRepository.AppConfigService.Update(item);
        }

        public void Insert(RLM.Construction.Entities.AppConfig item)
        {
            ServiceRepository.AppConfigService.Insert(item);
        }

        public RLM.Construction.Entities.AppConfig GetByAppConfigName(string appconfigName)
        {
            string whereClause = string.Format("[AppConfigName]='{0}'", appconfigName);
            int total;
            TList<AppConfig> items = this.GetPaged(whereClause, AppConfigColumn.AppConfigName.ToString(), 0, 0, out total);
            return items != null && items.Count > 0 ? items[0] : null;
        }
    }
}
