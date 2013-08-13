using System;
using System.Collections.Generic;
using System.Text;

namespace RLM.Construction.Entities
{
    public class GraphGrantChartDataItem
    {
        #region Properties
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Member { get; set; }
        public double PercentComplete { get; set; }
        public string Name { get; set; }

        public IList<GraphGrantChartDataItem> ChildItems { get; set; }
        #endregion
    }
}
