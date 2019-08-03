using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;

namespace ConsoleMongoDB.domain
{
    [BsonIgnoreExtraElements]
    public class Client : Entity
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string SocialNumber { get; set; }
    }
}