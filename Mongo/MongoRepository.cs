using System.Collections.Generic;

using MongoDB.Bson;
using MongoDB.Driver;

using cosmosdotnetcore.Models;

namespace cosmosdotnetcore.Mongo
{
    public class MongoRespository
    {
        private Settings _settings;

        private MongoRespository() { }

        public MongoRespository(Settings settings)
        {
            _settings = settings;
        }

        private void ValidateSettings()
        {
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(_settings.ConnectionString)) errors.Add("Connection String Missing");
            if (string.IsNullOrWhiteSpace(_settings.Database)) errors.Add("Database Missing");
            if (string.IsNullOrWhiteSpace(_settings.Collection)) errors.Add("Collection Missing");

            if (errors.Count > 0) throw new ValidationException("MongoRespository", "Settings", errors);
        }

        private MongoClient _client = null;
        public MongoClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new MongoClient(_settings.ConnectionString);
                }
                return _client;
            }
        }

        private IMongoDatabase _database = null;
        public IMongoDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    _database = Client.GetDatabase(_settings.Database);
                }
                return _database;
            }
        }

        private IMongoCollection<Person> _people = null;
        private IMongoCollection<Person> People
        {
            get
            {
                if (_people == null)
                {
                    var collectionSettings = new MongoCollectionSettings();
                    _people = Database.GetCollection<Person>(_settings.Collection, collectionSettings);
                }
                return _people;
            }
        }

        public List<BsonDocument> FindAllAsBson()
        {
            ValidateSettings();
            var collection = Database.GetCollection<BsonDocument>(_settings.Collection);
            var list = collection.Find(new BsonDocument()).ToList();
            return list;
        }

        public List<Person> FindRegEx(string fieldName, string regEx)
        {
            FilterDefinition<Person> filter = Builders<Person>.Filter.Regex(fieldName, new BsonRegularExpression(regEx));
            return Find(filter);
        }

        public List<Person> Find(FilterDefinition<Person> filter)
        {
            ValidateSettings();
            var list = People.Find(filter).ToList();
            return list;
        }

        public Person GetById(string id)
        {
            ValidateSettings();
            Person model = _people.Find(x => x._id == id).FirstOrDefault();
            return model;
        }

    }
}