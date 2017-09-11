using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;

using Newtonsoft.Json;

using cosmosdotnetcore.Models;
using cosmosdotnetcore.Mongo;

namespace cosmosdotnetcore
{
    class Program
    {
        static void Main(string[] args)
        {

            /* 
                Fetch the settings off disk, and put them in our settings instance (see: Readme.md)
            */
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("settings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();

            var settings = new Settings();
            configuration.Bind(settings);
            Console.WriteLine(settings.ToString());

            /*
                Use the repository
            */
            var id = string.Empty;
            var repos = new MongoRespository(settings);

            /*
                Find all as BSON
             */
            Console.Write("\nBSON Find All");
            var list3 = repos.FindAllAsBson();
            foreach (var item in list3)
            {
                Console.WriteLine("{0}", item.ToJson());
            }

            /*
                Find with a regular expression (Fluent)
             */
            Console.WriteLine("\nStrongly Typed RegEx Find");
            var list2 = repos.FindRegEx("NameLast", "/^Mc/");
            Console.WriteLine("{0}", JsonConvert.SerializeObject(list2));

            /*
                Find with a simple filter (Fluent)
             */
            Console.WriteLine("\nStrongly Typed Fluent Simple Find");
            FilterDefinition<Person> filter = Builders<Person>.Filter.Where(x => x.NameLast == "Cinkan");
            var list = repos.Find(filter);
            id = list[0]._id;
            Console.WriteLine("{0}", JsonConvert.SerializeObject(list));

            /*
                Find by ID (Fluent)
             */
            Console.WriteLine("\nStrongly Typed Fluent Find By Id: {0}", id);
            var person = repos.GetById(id);
            Console.WriteLine("{0}", JsonConvert.SerializeObject(person));
        }
    }
}
