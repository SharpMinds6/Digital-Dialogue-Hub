using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DigitalDialogueHub.Mobile.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public ObservableCollection<CommentDto> Replies { get; set; } = new ObservableCollection<CommentDto>();

       
        public ICommand LikeCommand { get; set; }
        public ICommand DislikeCommand { get; set; }
    }
}
