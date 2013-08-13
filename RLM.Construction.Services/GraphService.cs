using System;
using System.Collections.Generic;
using System.Text;
using RLM.Construction.Entities;
using RLM.Configuration;
using RLM.Core.Framework.Utility;

namespace RLM.Construction.Services
{
    public class GraphService
    {
        #region Pie
        public IList<GraphDataItem> GetGraphDataItems(TList<RLM.Construction.Entities.ItemInProject> items, GraphDataItemType type)
        {
            IList<GraphDataItem> result = new List<GraphDataItem>();
            if (items == null || items.Count == 0) { return result; }
            foreach (ItemInProject item in items)
            {
                GraphDataItem graphItem = GetGraphDataItems(item,type);
                result.Add(graphItem);
            }
            return result;
        }

        private GraphDataItem GetGraphDataItems(ItemInProject item, GraphDataItemType type)
        {
            GraphDataItem result = new GraphDataItem();
            Item iItem = ServiceRepository.ItemService.GetByItemId(item.ItemId);
            result.Label = iItem.Name;
            if (type == GraphDataItemType.Quantity)
            {
                result.Value = (decimal)item.Quantity;
            }
            if (type == GraphDataItemType.Price)
            {
                result.Value = item.UnitPrice*(decimal)item.ExchangeRate*(decimal)item.Quantity;
            }
            return result;
        }
        #endregion

        #region GrantChart
        public IList<GraphGrantChartDataItem> ToGrantChartDataItem(TList<Task> items)
        {
            IList<GraphGrantChartDataItem> result = new List<GraphGrantChartDataItem>();
            if (items == null || items.Count == 0) { return result; }
            foreach (Task item in items)
            {
                GraphGrantChartDataItem graphItem = GetGraphDataItems(item);
                result.Add(graphItem);
            }
            return result;
        }

        private GraphGrantChartDataItem GetGraphDataItems(Task item)
        {
            GraphGrantChartDataItem result = new GraphGrantChartDataItem();
            result.FromDate = NumberHelper.GetValue<DateTime>(item.EstimationFromDate);
            result.ToDate = NumberHelper.GetValue<DateTime>(item.EstimationToDate);
            result.Name = item.Name;
            result.PercentComplete = NumberHelper.GetValue<double>(item.PercentComplete);
            result.Member = string.Empty;
            return result;
        }
        #endregion
    }
}
