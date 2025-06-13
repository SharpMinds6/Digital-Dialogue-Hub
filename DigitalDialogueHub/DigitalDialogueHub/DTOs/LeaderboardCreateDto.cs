using System.ComponentModel.DataAnnotations;

namespace DigitalDialogueHub.DTOs
{
    public class LeaderboardCreateDto
    {
        public int UserId { get; set; }

        [Range(0, int.MaxValue)]
        public int Points { get; set; }

        [Range(0, int.MaxValue)]
        public int Rank { get; set; }
    }

}
