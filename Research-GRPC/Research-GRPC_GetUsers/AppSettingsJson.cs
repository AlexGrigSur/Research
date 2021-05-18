using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Research_GRPC_Client
{
    public class AppSettingsJson
    {
        [JsonPropertyName("hosturl")]
        public string HostURL { get; set; }

        public AppSettingsJson(string hostUrl)
        {
            HostURL = hostUrl;
        }
    }
}
