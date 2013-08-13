using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Construction.Services;
using RLM.Construction.Entities;

namespace RLM.Construction.ServiceHelpers
{
    public class ResourceDataServiceHelper
    {
        public ResourceData GetByResourceDataId(int itemId)
        {
            return ServiceRepository.ResourceDataService.GetByResourceDataId(itemId);
        }

        public RLM.Construction.Entities.TList<RLM.Construction.Entities.ResourceData> GetByResource(int resourceId, RLM.Construction.Entities.ResourceType resourceType, RLM.Construction.Entities.ResourceDataContentType contentType)
        {
            return ServiceRepository.ResourceDataService.GetByResource(resourceId, resourceType, contentType);
        }

        public void Update(ResourceData item)
        {
            ServiceRepository.ResourceDataService.Update(item);
        }

        public void Insert(ResourceData item)
        {
            ServiceRepository.ResourceDataService.Insert(item);
        }

        public void Delete(int itemId)
        {
            ServiceRepository.ResourceDataService.Delete(itemId);
        }
    }
}
