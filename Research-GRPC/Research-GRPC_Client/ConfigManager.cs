using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research_GRPC_Client
{
    public static class ConfigManager
    {
        public static string GetField(string fieldName)
        {
            // TODO: Get fields from appsettings.json

            return "https://localhost:5001";
        }
    }
}
