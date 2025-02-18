# Airline RabbitMQ Demo App

This is a demonstration application showcasing the integration of RabbitMQ with an Airline API for booking management. The application consists of a producer service and a RabbitMQ instance for handling message queues.

## Features

- **RabbitMQ Integration:** Uses RabbitMQ to send and receive messages.
- **API Producer:** An ASP.NET Core API producer to handle booking creation and send messages to RabbitMQ.
- **Message Consumer:** A console-based RabbitMQ consumer that processes booking messages.

## Prerequisites

- Docker and Docker Compose installed on your machine.
- .NET 6.0 SDK (if you want to build and run the app locally).

## Running the Application

1. **Clone the repository:**

   ```bash
   git clone https://github.com/fares7elsadek/Airline-rabbitmq-demo-app
   cd airline-rabbitmq-demo
   ```

2. **Start the application with Docker Compose:**

   ```bash
   docker-compose up
   ```

   This will start:

   - **Airline Producer:** Accessible on `http://localhost:8080`.
   - **RabbitMQ:** Accessible via the management interface at `http://localhost:15672` (default username/password: `user/password`).

3. **Access RabbitMQ Management:**
   Open `http://localhost:15672` in your browser and log in with the credentials:

   ```
   Username: user
   Password: password
   ```

4. **Test the API:**
   Use Postman, cURL, or any HTTP client to send a POST request to the booking API:

   ```bash
   POST http://localhost:8080/api/Booking
   Content-Type: application/json

   {
     "id": "1",
     "name": "John Doe",
     "flightNumber": "A123",
     "departure": "New York",
     "destination": "London"
   }
   ```

5. **Run the Consumer (Optional):**
   If you want to manually run the message consumer, navigate to the appropriate directory and run:
   ```bash
   dotnet run --project ConsumerApp.csproj
   ```
   This will print messages received from the `booking.queue` in RabbitMQ.

## Project Structure

- **Producer Service:** ASP.NET Core API for booking management.
- **RabbitMQ Configuration:** Configured with Docker Compose for local setup.
- **Consumer Service:** A .NET console app to consume and process booking messages.

## Environment Variables

The application uses the following environment variables:

- `RABBITMQ_DEFAULT_USER`: RabbitMQ username (default: `user`).
- `RABBITMQ_DEFAULT_PASS`: RabbitMQ password (default: `password`).
- `ASPNETCORE_ENVIRONMENT`: Application environment (default: `Development`).

## RabbitMQ Configuration

- **Exchange:** `booking.exchange` (Direct type).
- **Routing Key:** `booking.create`.
- **Queue:** `booking.queue`.

## Dependencies

- RabbitMQ
- ASP.NET Core
- Newtonsoft.Json (for serialization)
- RabbitMQ.Client (for RabbitMQ integration)

## License

This project is licensed under the MIT License. Feel free to use, modify, and share!

---

If you have any questions or issues, feel free to open an issue or reach out!
