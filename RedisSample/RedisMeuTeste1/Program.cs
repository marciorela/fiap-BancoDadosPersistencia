using RedisMeuTeste1;
using StackExchange.Redis;

string connectionString = "192.168.1.55";
var redis = ConnectionMultiplexer.Connect(connectionString);
var db = redis.GetDatabase();

var cliente1 = new Cliente() { Id = 1, Nome = "Nome1" };
cliente1.Enderecos.Add(new Endereco("Rua Primeira", "40", "São Paulo", "SP"));
cliente1.Enderecos.Add(new Endereco("Rua Segunda", "200", "Longe Pacas", "SP"));

var cliente2 = new Cliente() { Id = 2, Nome = "Nome2" };

db.SetData<Cliente>(cliente1.Id.ToString(), cliente1, null);
db.SetData<Cliente>(cliente2.Id.ToString(), cliente2);

var c2 = db.GetData<Cliente>("1");

if (c2 != null)
{
    Console.WriteLine(c2.Nome);
    foreach (var e in c2.Enderecos)
    {
        Console.WriteLine(e.Logradouro, e.Numero);
    }
}
