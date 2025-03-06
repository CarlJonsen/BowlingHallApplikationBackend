namespace MatchAPI.ModelsDto
{
    public class CreateMatchDto
    {
        public string MatchName { get; set; } = "DefaultMatch";
        public int AccountId { get; set; }
        public int BookingSlotId { get; set; }
        public string WinnerName { get; set; }
        public List<string> PlayerNames { get; set; } = new List<string>();
    }
}
