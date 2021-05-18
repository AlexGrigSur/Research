using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research_GRPC_Client
{
    class AppSettingsJson
    {
        public string HostURL { get; set; }

        public AppSettingsJson(string hostUrl)
        {
            HostURL = hostUrl;
        }
    }
}
