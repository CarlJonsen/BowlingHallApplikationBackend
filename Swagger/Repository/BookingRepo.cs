using DatabaseModule.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchAPI.Repository
{
    public class BookingRepo 
    {
        private readonly BowlingDbContext dbContext;
        public BookingRepo(BowlingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<BookingSlot>> GetAvailableBookingSlotsAsync()
        {
            var oneHourFromNow = DateTime.Now.AddHours(1);

            return await dbContext.BookingSlots
                .Where(slot => !slot.IsBooked && slot.BookingTime >= oneHourFromNow)
                .Include(slot => slot.BowlingLane)
                .ToListAsync();
        }

        public async Task<BookingSlot> GetBookingSlotByIdAsync(int bookingSlotId)
        {
            return await dbContext.BookingSlots
                .FirstOrDefaultAsync(slot => slot.Id == bookingSlotId);
        }

        public async Task UpdateBookingSlotAsync(BookingSlot slot)
        {
            dbContext.BookingSlots.Update(slot);
            await dbContext.SaveChangesAsync();
        }


    }
}
