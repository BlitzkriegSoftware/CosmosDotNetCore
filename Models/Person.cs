using System;
using System.Collections.Generic;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace cosmosdotnetcore.Models
{
    [BsonIgnoreExtraElements]
    public class Person
    {
        /// <summary>
        /// Mongo DB is super fussy about this, make sure the generator is used
        /// <para>No luck with GUID</para>
        /// </summary>
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string _id { get; set; }
        [BsonElement(elementName: "NameLast")]
        public string NameLast { get; set; }
        [BsonElement(elementName: "NameFirst")]
        public string NameFirst { get; set; }
        [BsonElement(elementName: "EMail")]
        public string EMail { get; set; }
        [BsonElement(elementName: "Company")]
        public string Company { get; set; }
        [BsonElement(elementName: "MemberSince")]
        public DateTime MemberSince { get; set; }
        [BsonElement(elementName: "Birthday")]
        public DateTime Birthday { get; set; }

        private List<Address> _addresses = null;

        [BsonElement(elementName: "Addresses")]
        public List<Address> Addresses
        {
            get
            {
                if (_addresses == null) _addresses = new List<Address>();
                return _addresses;
            }
        }

        private Dictionary<string, string> _preference = null;

        [BsonElement(elementName: "Preference")]
        public Dictionary<string,string> Preference
        {
            get
            {
                if (_preference == null) _preference = new Dictionary<string, string>();
                return _preference;
            }
        }
    }
}

