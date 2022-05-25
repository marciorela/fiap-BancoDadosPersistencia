using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBotCore.Data;
using SimpleBotCore.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBotCore.Repositories
{
    public class UserProfileSqlRepository : IUserProfileRepository
    {
        private Context _context;

        public UserProfileSqlRepository(Context context)
        {
            _context = context;
        }

        public SimpleUser TryLoadUser(string userId)
        {
            if (Exists(userId))
            {
                return GetUser(userId);
            }

            return null;
        }

        public SimpleUser Create(SimpleUser user)
        {
            if (Exists(user.Id))
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

            UpdateUser(user);
        }

        public void AtualizaIdade(string userId, int idade)
        {
            if (idade <= 0)
                throw new ArgumentOutOfRangeException(nameof(idade));

            if (!Exists(userId))
                throw new InvalidOperationException("Usuário não existe");

            var user = GetUser(userId);

            user.Idade = idade;

            UpdateUser(user);
        }

        public void AtualizaCor(string userId, string cor)
        {
            if (cor == null)
                throw new ArgumentNullException(nameof(cor));

            if (!Exists(userId))
                throw new InvalidOperationException("Usuário não existe");

            var user = GetUser(userId);

            user.Cor = cor;

            UpdateUser(user);
        }

        private bool Exists(string userId)
        {
            return _context.SimpleUsers.Any(x => x.Id == userId);
        }

        private SimpleUser GetUser(string userId)
        {
            return _context.SimpleUsers.Find(userId);
        }

        private void SaveUser(SimpleUser user)
        {
            _context.SimpleUsers.Add(user);
            _context.SaveChanges();
        }

        private void UpdateUser(SimpleUser user)
        {
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

