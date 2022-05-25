using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBotCore.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBotCore.Repositories
{
    public class UserProfileMongoRepository : IUserProfileRepository
    {
        IMongoDatabase _dbMongo;
        IMongoCollection<SimpleUser> _userCollection;

        public UserProfileMongoRepository(string conString)
        {
            _dbMongo = new MongoClient(conString).GetDatabase("dbLogMessages");
            _userCollection = _dbMongo.GetCollection<SimpleUser>("user");
        }

        public SimpleUser TryLoadUser(string userId)
        {
            if( Exists(userId) )
            {
                return GetUser(userId);
            }

            return null;
        }

        public SimpleUser Create(SimpleUser user)
        {
            if ( Exists(user.Id) )
                throw new InvalidOperationException("Usuário ja existente");

            SaveUser(user);

            return user;
        }

        public void AtualizaNome(string userId, string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (!Exists(userId))
                throw new InvalidOperationException("Usuário não existe");

            var user = GetUser(userId);

            user.Nome = name;

            var update = Builders<SimpleUser>.Update.Set(s => s.Nome, name);

            UpdateUser(userId, update);
        }

        public void AtualizaIdade(string userId, int idade)
        {
            if (idade <= 0)
                throw new ArgumentOutOfRangeException(nameof(idade));

            if (!Exists(userId))
                throw new InvalidOperationException("Usuário não existe");

            var user = GetUser(userId);

            user.Idade = idade;

            var update = Builders<SimpleUser>.Update.Set(s => s.Idade, idade);

            UpdateUser(userId, update);
        }

        public void AtualizaCor(string userId, string cor)
        {
            if (cor == null)
                throw new ArgumentNullException(nameof(cor));

            if (!Exists(userId))
                throw new InvalidOperationException("Usuário não existe");

            var user = GetUser(userId);

            var update = Builders<SimpleUser>.Update.Set(s => s.Cor, cor);

            UpdateUser(userId, update);
        }

        private bool Exists(string userId)
        {
            return _userCollection.Find(_ => _.Id == userId).Any();
        }

        private SimpleUser GetUser(string userId)
        {
            var user =  _userCollection.Find(x => x.Id == userId).FirstOrDefault();
            return user;
        }

        private void SaveUser(SimpleUser user)
        {
            _userCollection.InsertOne(user);
        }

        private void UpdateUser(string userId, UpdateDefinition<SimpleUser> update)
        {
            var result = _userCollection.UpdateOne(e => e.Id == userId, update);
            var a = result.ModifiedCount;
        }
    }
}

