using Airline.API.Models;
using Airline.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Airline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController(IMessageProducer message) : ControllerBase
    {

        private readonly List<Booking> bookings = new();

        [HttpPost]
        public async Task<ActionResult> CreateBooking(Booking newBook)
        {
            bookings.Add(newBook);
            await message.SendMessage<Booking>("booking.create",newBook);
            return Ok(newBook);

        }
    }
}
