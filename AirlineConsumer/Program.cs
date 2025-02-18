using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var username = "user";
var password = "password";
var _connectionFactory = new ConnectionFactory
{
    HostName = "localhost",
    UserName = username!,
    Password = password!,
    VirtualHost = "/",
    Port = 5672,
};

string exchange_name = "booking.exchange";
string routing_key = "booking.create";
string queue_name = "booking.queue";

var conn = await _connectionFactory.CreateConnectionAsync();
using var channel = await conn.CreateChannelAsync();
await channel.ExchangeDeclareAsync(exchange: exchange_name, type: ExchangeType.Direct
    , durable: true);

await channel.QueueDeclareAsync(queue:queue_name,durable: true,exclusive: false,
    autoDelete: false,arguments: null);
await channel.QueueBindAsync(queue: queue_name, exchange: exchange_name,
    routingKey: routing_key);

AsyncEventingBasicConsumer consumer = new(channel);

consumer.ReceivedAsync += Hanlder;

await channel.BasicConsumeAsync(queue:queue_name, consumer:consumer,autoAck:true);

async Task Hanlder(Object sender, BasicDeliverEventArgs args)
{
    byte[] body = args.Body.ToArray();
    string message = Encoding.UTF8.GetString(body);
    Console.WriteLine(message);
}

Console.ReadKey();