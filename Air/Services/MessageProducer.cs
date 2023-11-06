using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace FormulaAir.API.Services
{
	public class MessageProducer:IMessageProducer
	{
		public void SendingMessage<T>(T message)
		{
			var factory = new ConnectionFactory()
			{
				HostName = "localhost",
				UserName = "User",
				Password = "1234",
				VirtualHost = "/"

			};
			var conn  = factory.CreateConnection();
			using var channel = conn.CreateModel();
			channel.QueueDeclare("Booking",durable:true,exclusive:true);
			var jsonString = JsonSerializer.Serialize(message);
			var body = Encoding.UTF8.GetBytes(jsonString);
			channel.BasicPublish("", "Bookings", body: body);
		}
	}
}
