using MatchAPI.ModelsDto;
using MatchAPI.Repository;

namespace MatchAPI.Services
{
    public class BookingService
    {
        private readonly BookingRepo _bookingRepo;
        public BookingService(BookingRepo bookingRepo) 
        {
            _bookingRepo = bookingRepo;
        }

        public async Task<List<BookingSlotDto>> GetAvailableBookingSlotsAsync()
        {
            try
            {
                var slots = await _bookingRepo.GetAvailableBookingSlotsAsync();

                if (slots == null || !slots.Any())
                {
                    Console.WriteLine("Inga lediga banor hittades.");
                    return new List<BookingSlotDto>();
                }

                var slotDtos = slots.Select(slot => new BookingSlotDto
                {
                    Id = slot.Id,
                    BookingTime = slot.BookingTime,
                    LaneName = slot.BowlingLane?.LaneName ?? "Unknown"
                }).ToList();

                return slotDtos;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel uppstod vid hämtning av lediga banor: {ex.Message}");
                return new List<BookingSlotDto>();
            }
        }

        public async Task<bool> BookSlotAsync(int bookingSlotId)
        {
            var slot = await _bookingRepo.GetBookingSlotByIdAsync(bookingSlotId);

            if (slot == null)
            {
                Console.WriteLine($"Slot med ID {bookingSlotId} hittades inte.");
                return false;
            }

            if (slot.IsBooked)
            {
                Console.WriteLine($"Slot med ID {bookingSlotId} är redan bokad.");
                return false;
            }

            slot.IsBooked = true;
            await _bookingRepo.UpdateBookingSlotAsync(slot);

            Console.WriteLine($"Slot med ID {bookingSlotId} är nu bokad.");
            return true;
        }

        public async Task<bool> UnbookSlotAsync(int bookingSlotId)
        {
            var slot = await _bookingRepo.GetBookingSlotByIdAsync(bookingSlotId);

            if (slot == null)
            {
                Console.WriteLine($"Slot med ID {bookingSlotId} hittades inte.");
                return false;
            }

            if (!slot.IsBooked)
            {
                Console.WriteLine($"Slot med ID {bookingSlotId} är redan avbokad.");
                return false;
            }

            slot.IsBooked = false;
            await _bookingRepo.UpdateBookingSlotAsync(slot);

            Console.WriteLine($"Slot med ID {bookingSlotId} är nu avbokad.");
            return true;
        }
    }
}
