using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SimpleBotCore.Logic
{
    public class Message
    {
        [BsonElement("_id")]
        public string Id { get; set; }
        public string Mensagem { get; set; }

        public Message()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
