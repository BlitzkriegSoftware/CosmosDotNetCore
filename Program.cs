using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;

namespace cosmosdotnetcore
{

    public class Settings
    {

        public string ConnectionString { get; set; }

        public string Database { get; set; }

        public string Collection { get; set; }

        public override string ToString()
        {
            return string.Format("Settings\n______________\nConnection: {0}\nDatabase: {1}\nCollection: {2}", this.ConnectionString, this.Database, this.Collection);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            // fetch the settings off disk, and put them in our settings instance (see: Readme.md)
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("settings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();

            var settings = new Settings();
            configuration.Bind(settings);
            Console.WriteLine(settings.ToString());








        }
    }
}
