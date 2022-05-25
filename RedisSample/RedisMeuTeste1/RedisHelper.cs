using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RedisMeuTeste1
{
    public static class RedisHelper
    {
        public static void SetData<T>(this IDatabase db, string key, T data)
        {
            SetData<T>(db, key, data, TimeSpan.FromSeconds(5));
        }

        public static void SetData<T>(this IDatabase db, string key, T data, TimeSpan? ttl)
        {
            db.StringSet(key, JsonSerializer.Serialize(data), ttl);
        }

        public static T? GetData<T>(this IDatabase db, string key)
        {
            var res = db.StringGet(key);
            if (res.IsNull) return default;

            return JsonSerializer.Deserialize<T>(res);
        }
    }
}
