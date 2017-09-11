using System;
using System.Collections.Generic;

namespace cosmosdotnetcore.Models
{
    public class Settings
    {
        public Settings() {}

        public string ConnectionString { get; set; }

        public string Database { get; set; }

        public string Collection { get; set; }

        public override string ToString()
        {
            return string.Format("Settings\n______________\nConnection: {0}\nDatabase: {1}\nCollection: {2}", this.ConnectionString, this.Database, this.Collection);
        }
    }
}