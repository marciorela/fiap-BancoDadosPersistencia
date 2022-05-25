using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBotCore.Data;
using SimpleBotCore.Logic;

namespace SimpleBotCore.Repositories
{
    public class MessageSqlRepository : IMessageRepository
    {
        private Context _context;

        public MessageSqlRepository(Context context)
        {
            _context = context;
        }

        public void InsereMensagem(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
        }
    }
}
