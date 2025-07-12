using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DigitalDialogueHub.Mobile.DTOs;
using DigitalDialogueHub.Mobile.Views;

namespace DigitalDialogueHub.Mobile.ViewModels
{
    public partial class CommentsPopupViewModel : ObservableObject
    {
        [ObservableProperty]
        private string newComment;

        [ObservableProperty]
        private bool isReplying;

        [ObservableProperty]
        private string replyingToAuthor;

        [ObservableProperty]
        private CommentDto replyTo; // DTO umjesto modela

        public ObservableCollection<CommentDto> Comments { get; set; }

        public ICommand SendCommentCommand { get; }
        public ICommand ReplyToCommentCommand { get; }

        public CommentsPopupViewModel()
        {
            Comments = new ObservableCollection<CommentDto>
            {
                new CommentDto { Author = "Test", Text = "Test komentar", Likes = 1, Dislikes = 0 }
            };

            SendCommentCommand = new RelayCommand(SendComment);
            ReplyToCommentCommand = new RelayCommand<CommentDto>(ReplyToComment);
        }

        private void SendComment()
        {
            if (string.IsNullOrWhiteSpace(NewComment)) return;

            if (IsReplying && ReplyTo != null)
            {
                // Ako CommentDto ima Replies kolekciju
                ReplyTo.Replies ??= new ObservableCollection<CommentDto>();
                ReplyTo.Replies.Add(new CommentDto
                {
                    Author = "Me",
                    Text = NewComment
                });
                IsReplying = false;
                ReplyingToAuthor = "";
                ReplyTo = null;
            }
            else
            {
                Comments.Add(new CommentDto
                {
                    Author = "Me",
                    Text = NewComment
                });
            }
            NewComment = string.Empty;
        }

        private void ReplyToComment(CommentDto comment)
        {
            if (comment != null)
            {
                IsReplying = true;
                ReplyingToAuthor = comment.Author;
                ReplyTo = comment;
            }
        }
    }
}
