using MongoDB.Driver;
using MongoDB.Bson;
using ConsoleMongo;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


string connectionString = "mongodb://localhost:27017";
var cliente = new MongoClient(connectionString);

var db = cliente.GetDatabase("db02");
var col = db.GetCollection<BsonDocument>("col02");
var colMeuDoc = db.GetCollection<MeuDocumento>("col02");

//var doc = BsonDocument.Parse("{Nome: 'visual studio 2022'}");

var doc = new MeuDocumento() { Nome = "VS Novo" };

//var doc = new BsonDocument()
//{
//    {"Nome", "Marcio Rela" },
//    {"Aula",
//        new BsonArray()
//        {
//            "C#", "SQL"
//        }
//    }
//};

var updateSe = new BsonDocument()
{
    {"$set", new BsonDocument() { { "Nome", "Fernando"} } }
};

var updateSet2 = Builders<BsonDocument>.Update.Set("Nome", "Joaquim");

colMeuDoc.InsertOne(doc);
//col.InsertOne(doc);

var filtroTudo = BsonDocument.Parse("{}");
//var resultado = col.Find(filtroTudo).ToList();
var resultado = colMeuDoc.Find(filtroTudo).ToList();

resultado.ForEach(x => Console.WriteLine(x.Nome));
