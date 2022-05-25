using StackExchange.Redis;

string connectionString = "localhost";
var redis = ConnectionMultiplexer.Connect(connectionString);
var db = redis.GetDatabase();

db.StringSet("A", 1);
Console.WriteLine(db.StringGet("A"));

db.StringIncrement("A");
Console.WriteLine(db.StringGet("A"));

db.SetAdd("tech", "SQL");
db.HashSet("tamanho", "P", 1);
db.ListLeftPush("L1", "A");
db.ListLeftPush("L1", "B");
