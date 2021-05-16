using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.IO;

namespace Research_GRPC_Client
{
    public class ConfigManager
    {
        private string hostURL;
        private string maxBodySize;
        public IConfiguration GetConfiguration()
        {
            IConfiguration GetConfigurationBuilder()
            {
                try
                {
                    return new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .AddEnvironmentVariables()
                                .Build();
                }
                catch
                {
                    return null;
                }
            }

            var config = GetConfigurationBuilder();

            // if config doesn't exists or value invalid
            if (config == null || !CheckHostURL(config["HostURL"]) || !IsUserAgreeConfig(config))
            {
                inputConfig();
                config = GetConfigurationBuilder();
            }

            return config;
        }

        private bool IsUserAgreeConfig(IConfiguration config)
        {
            Console.WriteLine("Greetings");
            Console.WriteLine("Config file was found with data:");
            Console.WriteLine($"HostURL: {config["HostURL"]}");
            Console.WriteLine("Use this configuration? y/n");
            return (Console.ReadLine().ToLower() == "y");
        }
        private void inputConfig()
        {
            void inputHostURL()
            {
                while (true)
                {
                    Console.Write("Input HostURL: ");
                    hostURL = Console.ReadLine();
                    if (CheckHostURL(hostURL))
                        break;
                    else
                        Console.WriteLine("Wrong Host address. Try again");
                }
            }
            
            inputHostURL();

            File.Create("appsettings.json").Close();
            File.AppendAllText("appsettings.json", JsonSerializer.Serialize(new 
            {  
                HostURL = hostURL, 
            }));
        }
        private bool CheckHostURL(string field)
        {
            if (field == null || field.Trim() == "") return false;

            return Uri.IsWellFormedUriString(field, UriKind.Absolute);
        }
    }
}