namespace DigitalDialogueHub.DTOs
{
    public class LeaderboardDto
    {
        public int Id { get; set; }
        public int? Rank { get; set; }
        public int Points { get; set; }
        public int UserId { get; set; } // ili UserName ako trebaš
    }
}
