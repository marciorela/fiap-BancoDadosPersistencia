using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBotCore.Logic;

namespace SimpleBotCore.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        IMongoDatabase _dbMongo;

        public MessageRepository(string conString)
        {
            _dbMongo = new MongoClient(conString).GetDatabase("dbLogMessages");
        }

        public void InsereMensagem(Message message)
        {
            var col = _dbMongo.GetCollection<Message>("message");
            col.InsertOne(message);
        }
    }
}
