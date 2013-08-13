using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Construction.Services;

namespace RLM.Construction.ServiceHelpers
{
    public class TaskMemberServiceHelper
    {
        public RLM.Construction.Entities.TList<RLM.Construction.Entities.TaskMember> GetByResource(RLM.Construction.Entities.ResourceType resourceType, int resourceId)
        {
            
            return ServiceRepository.TaskMemberService.GetByResource(resourceType, resourceId);
        }

        public void Update(RLM.Construction.Entities.TaskMember taskMember)
        {
            ServiceRepository.TaskMemberService.Update(taskMember);
        }

        public void Insert(RLM.Construction.Entities.TaskMember taskMember)
        {
            ServiceRepository.TaskMemberService.Insert(taskMember);
        }

        public RLM.Construction.Entities.TaskMember GetByTaskMemberId(int taskMemberId)
        {
            return ServiceRepository.TaskMemberService.GetByTaskMemberId(taskMemberId);
        }

        public void Delete(int p)
        {
            throw new NotImplementedException();
        }
    }
}
