using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Construction.Services;

namespace RLM.Construction.ServiceHelpers
{
    public class TaskServiceHelper
    {
        public RLM.Construction.Entities.TList<RLM.Construction.Entities.Task> GetByResource(RLM.Construction.Entities.ResourceType resourceType, int resourceId, bool isActiveOnly)
        {
            return ServiceRepository.TaskService.GetByResource(resourceType, resourceId, isActiveOnly);
        }

        public RLM.Construction.Entities.Task GetByTaskId(int taskId)
        {
            return ServiceRepository.TaskService.GetByTaskId(taskId);
        }

        public void Update(RLM.Construction.Entities.Task task)
        {
            ServiceRepository.TaskService.Update(task);
        }

        public void Insert(RLM.Construction.Entities.Task task)
        {
            ServiceRepository.TaskService.Insert(task);
        }
    }
}
