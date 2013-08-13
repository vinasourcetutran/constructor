using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Construction.Services;

namespace RLM.Construction.ServiceHelpers
{
    public class GraphServiceHelper
    {
        public static IList<RLM.Construction.Entities.GraphDataItem> GetGraphDataItems(RLM.Construction.Entities.TList<RLM.Construction.Entities.ItemInProject> items, RLM.Construction.Entities.GraphDataItemType graphDataItemType)
        {
            return ServiceRepository.GraphService.GetGraphDataItems(items,graphDataItemType);
        }

        public IList<RLM.Construction.Entities.GraphGrantChartDataItem> ToGrantChartDataItem(RLM.Construction.Entities.TList<RLM.Construction.Entities.Task> items)
        {
            return ServiceRepository.GraphService.ToGrantChartDataItem(items);
        }
    }
}
