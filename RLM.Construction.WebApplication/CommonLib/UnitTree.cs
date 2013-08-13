using System;
using System.Collections.Generic;
using System.Text;
using RLM.Construction.Entities;
using RLM.Construction.ServiceHelpers;
using RLM.Core.Framework.Utility;
using RLM.Core.Framework.Log;

namespace RLM.Construction.WebApplication.CommonLib
{
    public class UnitTree:AlphaBetaTree<Unit>
    {
        #region Construction
        public UnitTree() : base() { }
        public UnitTree(Unit unit, double weight, UnitTree parent) : base(unit, weight, parent) { }
        #endregion

        #region Properties
        public static double Translate(int fromUnitId, int toUnitId)
        {
            try
            {
                Unit fromUnit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(fromUnitId);
                Unit toUnit = ServiceRepositoryHelper.UnitServiceHelper.GetByUnitId(toUnitId);
                UnitTree tree = new UnitTree(fromUnit,1,null);
                AlphaBetaTree<Unit> result = tree.Translate(toUnit);
                return result != null ? result.Weight : 0;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return 0;
            }
        }
        #endregion

        #region Override
        protected override AlphaBetaTree<Unit> CreateNode(Unit item, double childWeight)
        {
            return new UnitTree(item, childWeight, this);
        }
        protected override bool IsEqual(Unit first, Unit second)
        {
            return first.UnitId==second.UnitId;
        }

        protected override double GetWeight(Unit item)
        {
            try
            {
                if(this.Node==null){ return 0;}
                UnitConvertor convertor = ServiceRepositoryHelper.UnitConvertorServiceHelper.GetCurrentByUnit(this.Node.UnitId, item.UnitId);
                if (convertor == null) { return 0; }
                return NumberHelper.GetValue<double>(convertor.Quantity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected override TList<Unit> GetChildItems(Unit item)
        {
            if (this.Node == null) { return null; }
            TList<Unit> childs = ServiceRepositoryHelper.UnitServiceHelper.GetByParentUnitId(this.Node.UnitId, true);
            return childs;
        }
        #endregion
    }
}
