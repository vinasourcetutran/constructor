using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Construction.Services;

namespace RLM.Construction.ServiceHelpers
{
    public class CommentServiceHelper
    {
        public void Insert(RLM.Construction.Entities.Comment comment)
        {
            ServiceRepository.CommentService.Insert(comment);
        }

        public RLM.Construction.Entities.TList<RLM.Construction.Entities.Comment> GetByResource(RLM.Construction.Entities.ResourceType resourceType, int resourceId, string orderBy, int pageIndex, int pageSize, out int totalRecords)
        {
            return ServiceRepository.CommentService.GetByResource(resourceType, resourceId,orderBy, pageIndex, pageSize, out totalRecords);
        }
    }
}
