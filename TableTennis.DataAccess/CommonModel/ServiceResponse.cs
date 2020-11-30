using System;
using System.Collections.Generic;
using System.Text;

namespace TableTennis.DataAccess.CommonModel
{
    public class ServiceResponse
    {
        public dynamic data { get; set; }
        public List<string> message { get; set; }
        public bool success { get; set; }
    }
}
