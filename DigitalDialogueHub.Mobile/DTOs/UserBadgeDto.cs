namespace DigitalDialogueHub.Mobile.DTOs
{
    public class UserBadgeDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BadgeId { get; set; }
        public DateTime EarnedAt { get; set; }
    }

    public class UserBadgeCreateDto
    {
        public int UserId { get; set; }
        public int BadgeId { get; set; }
    }

    public class UserBadgeUpdateDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BadgeId { get; set; }
        public DateTime EarnedAt { get; set; }
    }
}