using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace cosmosdotnetcore.Models
{
    [BsonIgnoreExtraElements]
    public class Address
    {
        [BsonElement(elementName: "NameLast")]
        public string Address1 { get; set; }
        [BsonElement(elementName: "NameLast")]
        public string Address2 { get; set; }
        [BsonElement(elementName: "NameLast")]
        public string City { get; set; }
        [BsonElement(elementName: "NameLast")]
        public string State { get; set; }
        [BsonElement(elementName: "NameLast")]
        public string Zip { get; set; }
        [BsonElement(elementName: "Kind")]
        public AddressKind Kind { get; set; }

        [JsonIgnore]
        public bool IsEmpty
        {
            get
            {
                return
                    string.IsNullOrWhiteSpace(this.Address1) &&
                    string.IsNullOrWhiteSpace(this.City) &&
                    string.IsNullOrWhiteSpace(this.State) &&
                    string.IsNullOrWhiteSpace(this.Zip);
            }
        }
    }
}
