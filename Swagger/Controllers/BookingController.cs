using MatchAPI.ModelsDto;
using MatchAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MatchAPI.Controllers
{
    public class BookingController : Controller
    {
        private readonly BookingService _bookingService;
        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        [Route("availableBookings")]
        public async Task<IActionResult> GetAvailableBookingsSlotsAsync()
        {
            var availableSlots = await _bookingService.GetAvailableBookingSlotsAsync();

            if (availableSlots == null || !availableSlots.Any())
            {
                return NotFound("Inga lediga bokningar hittades.");
            }

            return Ok(availableSlots);
        }

        [HttpPost]
        [Route("bookSlot")]
        public async Task<IActionResult> BookSlot([FromBody] BookingSlotDto bookingSlotDto)
        {
            var success = await _bookingService.BookSlotAsync(bookingSlotDto.Id);

            if (!success)
            {
                return BadRequest($"Kunde inte boka slot med ID {bookingSlotDto.Id}. Kanske är den redan bokad?");
            }

            return Ok(new BookingSlotDto
            {
                Id = bookingSlotDto.Id,
                Message = $"Slot med ID {bookingSlotDto.Id} är nu bokad."
            });
        }

        [HttpPost]
        [Route("unbookSlot")]
        public async Task<IActionResult> UnbookSlot([FromBody] BookingSlotDto bookingSlotDto)
        {
            var success = await _bookingService.UnbookSlotAsync(bookingSlotDto.Id);

            if (!success)
            {
                return BadRequest($"Kunde inte avboka slot med ID {bookingSlotDto.Id}. Kanske är den redan avbokad?");
            }

            return Ok($"Slot med ID {bookingSlotDto.Id} är nu avbokad.");
        }
    }
}
