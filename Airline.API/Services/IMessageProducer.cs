namespace Airline.API.Services;

public interface IMessageProducer
{
    public Task SendMessage<T>(string routingKey,T message);
}
