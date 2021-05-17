using System;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.IO;

namespace Research_GRPC_Client
{
    public class ConfigManager
    {
        public IConfiguration GetConfiguration()
        {
            var config = GetConfigurationBuilder();

            // if config doesn't exists or value invalid
            if (config == null || !CheckHostURL(config["HostURL"]) || !IsUserAgreeConfig(config["HostURL"]))
            {
                string hostURL;
                do
                {
                    Console.Write("Input HostURL: ");
                    hostURL = Console.ReadLine();
                    if (CheckHostURL(hostURL))
                        break;
                    Console.WriteLine("Wrong Host address. Try again");
                } while (true);

                try
                {
                    File.AppendAllText("appsettings.json",
                        JsonSerializer.Serialize(("{\"HostURL\":\"{0}\"}", hostURL)));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    // ???
                }

                config = GetConfigurationBuilder();
            }

            return config;
        }

        private IConfiguration GetConfigurationBuilder()
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
        private bool IsUserAgreeConfig(string hostURL)
        {
            Console.WriteLine("Greetings");
            Console.WriteLine("Config file was found with data:");
            Console.WriteLine($"HostURL: {hostURL}");
            Console.WriteLine("Use this configuration? y/n");
            return (Console.ReadLine().ToLower() == "y");
        }
        private bool CheckHostURL(string field)
        {
            if (field == null || field.Trim() == "")
            {
                return false;
            }

            return Uri.IsWellFormedUriString(field, UriKind.Absolute);
        }
    }
}