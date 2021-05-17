using System;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace Research_GRPC
{
    public class ConfigManager
    {
        private string _hostURL;
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
                    _hostURL = Console.ReadLine();
                    if (CheckHostURL(_hostURL))
                        break;
                    Console.WriteLine("Wrong Host address. Try again");
                }
            }

            inputHostURL();
            if (File.Exists("appsettings.json"))
            {
                File.Delete("appsettings.json");
            }

            try
            {
                File.AppendAllTextAsync("appsettings.json", JsonSerializer.Serialize(("{\"HostURL\":\"{0}\"}", _hostURL)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        private bool CheckHostURL(string field)
        {
            if (field == null || field.Trim() == "") return false;

            return Uri.IsWellFormedUriString(field, UriKind.Absolute);
        }
    }
}
