using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZohoCRMWebApp.Models
{
    public class ZohoCrmConfig
    {
       
            public Dictionary<string, string> _config { get; set; }

            public ZohoCrmConfig(Dictionary<string, string> config)
            {
                _config = config;
            }        

    }
}