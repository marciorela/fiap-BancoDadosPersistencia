using StackExchange.Redis;

string connecitonString = "localhost";
var redis = ConnectionMultiplexer.Connect(connecitonString);
var db = redis.GetDatabase();

db.StringSet("A", 1);
var a = db.StringGet("A");

db.StringSet("B", 2);
db.StringIncrement("B");

var b = db.StringGet("B");
Console.WriteLine(a);
Console.WriteLine(b);
