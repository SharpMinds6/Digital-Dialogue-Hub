using System.Collections.ObjectModel;
using DigitalDialogueHub.Mobile.DTOs;
using DigitalDialogueHub.Mobile.Views;

namespace DigitalDialogueHub.Mobile.ViewModels
{
    public class BadgesPageViewModel : UserViewModel
    {
        private ObservableCollection<BadgeDto> badges;
        public ObservableCollection<BadgeDto> Badges
        {
            get => badges;
            set
            {
                badges = value;
                OnPropertyChanged();
            }
        }

        public BadgesPageViewModel()
        {
            Username = "student.user";
            Email = "student@edu.com";

            Badges = new ObservableCollection<BadgeDto>
            {
                new BadgeDto
                {
                    Name = "Newbie",
                    Description = "Earned after the first login to the application.",
                    IconPath = "newbie.png"
                },
                new BadgeDto
                {
                    Name = "Active User",
                    Description = "Earned after one week of active participation.",
                    IconPath = "active_user.png"
                },
                new BadgeDto
                {
                    Name = "Responder",
                    Description = "Earned after 1 user replied to the topic in the app.",
                    IconPath = "responder.png"
                },
                new BadgeDto
                {
                    Name = "Topic Expert",
                    Description = "Earned after sharing 5 different topics.",
                    IconPath = "topic_expert.png"
                },
                new BadgeDto
                {
                    Name = "Liker",
                    Description = "Earned after receiving 5 likes through ideas.",
                    IconPath = "liker.png"
                },
                new BadgeDto
                {
                    Name = "Ace",
                    Description = "Earned after 10 successful answers and receiving over 50 activity.",
                    IconPath = "ace.png"
                }
            };
        }
    }
}
