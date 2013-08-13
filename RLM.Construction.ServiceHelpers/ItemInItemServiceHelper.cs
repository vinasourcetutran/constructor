using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Construction.Services;
using RLM.Construction.Entities;
using RLM.Core.Framework.Log;

namespace RLM.Construction.ServiceHelpers
{
    public class ItemInItemServiceHelper
    {
        public TList<ItemInItem> GetListByFromItemId(long fromItemId)
        {
            string whereClause = string.Format("[FromItemId]={0}", fromItemId);
            int total;
            return ServiceRepository.ItemInItemService.GetPaged(whereClause, "[LastModificationDate]",0,0, out total);
        }

        public ErrorPair IsValidate(ItemInItem itemInItem)
        {
            ErrorPair pair = new ErrorPair();
            try
            {
                if (itemInItem.FromItemId <= 0 || itemInItem.ToItemId <= 0)
                {
                    pair.ErrorType = ErrorType.Error;
                    pair.ErrorMessage = Resources.ValidationError.InvalidItem;
                    return pair;
                }

                if (itemInItem.Quantity <= 0)
                {
                    pair.ErrorType = ErrorType.Error;
                    pair.ErrorMessage = Resources.ValidationError.InvalidQuantity;
                    return pair;
                }

                if (itemInItem.UnitId <= 0)
                {
                    pair.ErrorType = ErrorType.Error;
                    pair.ErrorMessage = Resources.ValidationError.InvalidUnit;
                    return pair;
                }
                return pair;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return pair;
            }
        }

        public ErrorPair InsertOrUpdate(ItemInItem itemInItem)
        {
            ErrorPair errorPair = new ErrorPair();
            try
            {
                ItemInItem availabelItem = ServiceRepository.ItemInItemService.GetItemByFromItemAndToItem(itemInItem.FromItemId, itemInItem.ToItemId);
                if (availabelItem == null)
                {
                    ServiceRepository.ItemInItemService.Insert(itemInItem);
                    errorPair.ErrorType = ErrorType.Info;
                    errorPair.ErrorMessage = Resources.ValidationError.MessageInsertSuccessful;
                    return errorPair;
                }
                if (availabelItem != null && availabelItem.ItemInItemId == itemInItem.ItemInItemId)
                {
                    ServiceRepository.ItemInItemService.Update(itemInItem);
                    errorPair.ErrorType = ErrorType.Info;
                    errorPair.ErrorMessage = Resources.ValidationError.MessageUpdateSuccessful;
                    return errorPair;
                }

                availabelItem.Quantity += itemInItem.Quantity;
                availabelItem.LastModificationUserId = itemInItem.LastModificationUserId;
                availabelItem.LastModificationDate = itemInItem.LastModificationDate;

                ServiceRepository.ItemInItemService.Update(availabelItem);
                errorPair.ErrorType = ErrorType.Info;
                errorPair.ErrorMessage = Resources.ValidationError.MessageUpdateExistItemSuccessful;
                return errorPair;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                errorPair.ErrorType = ErrorType.Error;
                errorPair.ErrorMessage = Resources.ValidationError.ExceptionOnSaveItem;
                return errorPair;
            }
            
        }

        public void DeleteItemInItem(int itemInItemId)
        {
            ServiceRepository.ItemInItemService.Delete(itemInItemId);
        }
    }
}
