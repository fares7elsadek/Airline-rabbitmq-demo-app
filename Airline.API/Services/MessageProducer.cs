using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Airline.API.Services;

public class MessageProducer : IMessageProducer
{
    private readonly ConnectionFactory _connectionFactory;
    public MessageProducer()
    {
        var username = Environment.GetEnvironmentVariable("RABBITMQ_DEFAULT_USER");
        var password = Environment.GetEnvironmentVariable("RABBITMQ_DEFAULT_PASS");
        _connectionFactory = new ConnectionFactory
        {
            HostName = "rabbitmq",
            UserName = username!,
            Password = password!,
            VirtualHost = "/"
        };

    }
    public async Task SendMessage<T>(string routingKey,T message)
    {
        string exchange_name = "booking.exchange";
        var jsonMessage = JsonConvert.SerializeObject(message);
        var bytes = Encoding.UTF8.GetBytes(jsonMessage);

        var conn = await _connectionFactory.CreateConnectionAsync();
        using var channel = await conn.CreateChannelAsync();
        await channel.ExchangeDeclareAsync(exchange: exchange_name,type: ExchangeType.Direct
            ,durable:true);
        await channel.BasicPublishAsync(exchange_name,routingKey,bytes);
    }
}
