using FormulaAir.API.Models;
using FormulaAir.API.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FormulaAir.API.Controllers
{


	[ApiController]
	[Route("[controller]")]
	public class BookingsController : ControllerBase
	{


		private readonly ILogger<WeatherForecastController> _logger;
		private readonly IMessageProducer _messageProducer;

		//IN-MEMORY-DB
		public static  readonly List<Booking> _bookings = new List<Booking>();

		public BookingsController(ILogger<WeatherForecastController> logger, IMessageProducer messageProducer)
		{
			_logger = logger;
			_messageProducer = messageProducer;
		}
		[HttpPost]
		public  IActionResult CreatingBooking(Booking newBooking)

		{
			if (!ModelState.IsValid) BadRequest();
			_bookings.Add(newBooking);
			_messageProducer.SendingMessage<Booking>(newBooking);
			return Ok();
			
		}


	}

}

