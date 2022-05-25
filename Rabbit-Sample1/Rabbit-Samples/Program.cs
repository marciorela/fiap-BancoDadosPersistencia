// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Hello, World!");

var factory = new ConnectionFactory();
//factory.Uri = new Uri("amqp://user:fiap@ip:port/");

factory.UserName = "user";
factory.Password = "fiap";
factory.HostName = "20.225.241.127";
factory.Port = 5672;
factory.VirtualHost = "/";
factory.ConsumerDispatchConcurrency = 50;

var connection = factory.CreateConnection();
var i = 0;

using (var channel = connection.CreateModel())
{
    var consumidor = new EventingBasicConsumer(channel);

    consumidor.Received += Consumidor_Received;

    channel.BasicConsume("fiap", false, consumidor);

    Console.ReadKey();
}

void Consumidor_Received(object? sender, BasicDeliverEventArgs e)
{
    try
    {
        var message = Encoding.UTF8.GetString(e.Body.Span);

        i++;
        Console.WriteLine($"Mensagem recebida: {message} - {i}");

        var channel = ((EventingBasicConsumer)sender).Model;

        channel.BasicAck(e.DeliveryTag, false);
    }
    catch (Exception)
    {

    }
}

//using (var channel = connection.CreateModel())
//{

//    for (int i = 0; i < 1000; i++)
//    {
//        string msg = $"Olá NET 21 ({i})";

//        var body = Encoding.UTF8.GetBytes(msg);

//        channel.BasicPublish("e-rela", routingKey: "", body: body);
//    }
//}

//Console.ReadKey();
