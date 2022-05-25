using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBotCore.Logic
{
    
    public class SimpleUser
    {
        [BsonElement("_id")]
        public string Id { get; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cor { get; set; }

        public SimpleUser(string userId)
        {
            this.Id = userId ?? throw new ArgumentNullException(nameof(userId));
        }

        public SimpleUser()
        {
        }
    }
}
