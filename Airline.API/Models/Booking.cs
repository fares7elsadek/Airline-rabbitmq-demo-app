namespace Airline.API.Models;

public class Booking
{
    public int Id { get; set; }
    public string PassengerName { get; set; } = default!;
    public string PassportNumber { get; set; } = default!;
    public string From { get; set; } = default!;
    public string To { get; set; } = default!;
    public int Status { get; set; } 
}
