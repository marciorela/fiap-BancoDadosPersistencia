using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ConsoleMongo
{

    //[BsonIgnoreExtraElements]
    public class MeuDocumento
    {
        public string Nome { get; set; }

        [BsonExtraElements]
        public BsonDocument Outros { get; set; }
    }
}
