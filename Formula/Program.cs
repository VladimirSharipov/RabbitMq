// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Hello, World!");

var factory = new ConnectionFactory()
{
	HostName = "localhost",
	UserName = "User",
	Password = "1234",
	VirtualHost = "/"

};
var conn = factory.CreateConnection();
using var channel = conn.CreateModel();
channel.QueueDeclare("Booking", durable: true, exclusive: true);


var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, args) =>
{
	//получить байт []
	var body = args.Body.ToArray();
	var message = Encoding.UTF8.GetString(body);
	Console.WriteLine(message);
};
channel.BasicConsume("Booking",true,consumer);
Console.ReadKey();