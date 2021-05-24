using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SpecflowAPIAutomation.Data;
using SpecflowAPIAutomation.Enums;
using SpecflowAPIAutomation.Extensions;

namespace SpecflowAPIAutomation.Mapper
{
    public abstract class BaseResponseMapper<TResponse>
    {
        protected User MapUser(JToken data)
        {
            User user = new User();
            user.Id = data.GetStringValue("id");
            user.Name = data.GetStringValue("name");
            user.Email = data.GetStringValue("email");
            user.Gender = (Gender)Enum.Parse(typeof(Gender), data.GetStringValue("gender"), true);
            user.Status = (Status)Enum.Parse(typeof(Status), data.GetStringValue("status"), true);
            return user;
        }
    }
}
