using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBotCore.Data;
using SimpleBotCore.Logic;
using System;
using System.Collections.Generic;

namespace SimpleBotCore.Repositories
{
    public class MessageMockRepository : IMessageRepository
    {
        Dictionary<string, Message> _messages = new Dictionary<string, Message>();

        public void InsereMensagem(Message message)
        {
            _messages[message.Id] = message;
        }
    }
}
