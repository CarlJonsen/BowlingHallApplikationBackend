namespace MatchAPI.ModelsDto
{
    public class MatchHistoryDto
    {
        public string MatchName { get; set; }
        public string WinnerName { get; set; }
        public DateTime BookingTime { get; set; }
        public string LaneName { get; set; }
        public List<string> PlayerNames { get; set; }

    }
}
