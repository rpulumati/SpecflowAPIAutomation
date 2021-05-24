using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SpecflowAPIAutomation.Data;

namespace SpecflowAPIAutomation.Response
{
    public class CreateUserResponse
    {
        public String Code;
        public String MetaData;
        public User User;
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
    }
}
