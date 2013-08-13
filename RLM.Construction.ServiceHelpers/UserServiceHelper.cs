using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RLM.Construction.Services;

namespace RLM.Construction.ServiceHelpers
{
    public class UserServiceHelper
    {
        public RLM.Construction.Entities.User GetByUserId(int userId)
        {
            return ServiceRepository.UserService.GetByUserId(userId);
        }
    }
}
