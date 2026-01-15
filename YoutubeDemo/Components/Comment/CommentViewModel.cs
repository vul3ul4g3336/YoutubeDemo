using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Xml;
using YoutubeDemo.Command;
using YoutubeDemo.Presenter;
using static YoutubeAPI.Videos.Model.GetCommentModel;
using static YoutubeDemo.Contract.CommentContract;

namespace YoutubeDemo.Components.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CommentViewModel : ICommentView
    {
        public  ObservableCollection<CommentModel> Comments { get; set; } = new ObservableCollection<CommentModel>();
        /*   string ID = "UCsCh8O25n31QWEs90NgHBMA";*/ // UCsCh8O25n31QWEs90NgHBMA
        public ICommand removeCommand { get; set; }
        public ICommand saveEditCommand { get; set; }
        public ICommand sendReplyCommand { get; set; }
        public string CommentMessage { get; set; }
        private CommentPresenter presenter { get; set; }
        private string ReplyMessage { get; set; }
        public CommentViewModel(string videoID)
        {
            
            presenter = new CommentPresenter(this);
            _ = presenter.Comment_Request(videoID);
            removeCommand = new RelayCommand<CommentModel>(async x =>
            {
                await presenter.Comment_Delete(x.CommentID);
                RemoveComment(x);
            });
            saveEditCommand = new RelayCommand<CommentModel>(async x =>
            {
                var newComment = await presenter.EditComment(x.CommentID, x.TextOriginal);
                x.PublishedAt = newComment.PublishedAt;
                x.TextDisplay = newComment.TextDisplay; 
                x.EditStatus = Visibility.Collapsed;
                x.displayStatus = Visibility.Visible;
            });
            sendReplyCommand = new RelayCommand<CommentModel>(async x =>
            {
                var newComment = await presenter.PostCommentReply(x.CommentID, x.ReplyMessage);

                ReplyToComment(newComment);
                x.ReplyMessage = string.Empty;
                x.ReplyStatus = Visibility.Collapsed;
            });

        }
       
        public void ReplyToComment(CommentModel model)
        {
            foreach (var comment in Comments)
            {
                if (model.ParentId != comment.CommentID) continue;

                comment.TotalReplyCount++;
                if (comment.replies == null)
                {
                    comment.replies = new ObservableCollection<CommentModel>();
                }
                comment.replies.Add(model);
            }
        }
        public void RemoveComment(CommentModel comment)
        {

            if (Comments.Contains(comment))
            {
                Comments.Remove(comment);
                return;
            }
            var topCommentID = comment.CommentID.Split('.')[0];
            var target = Comments.FirstOrDefault(x => x.CommentID == topCommentID);
            target.replies.Remove(comment);

        }
        public void Comment_Response(List<CommentModel> models)
        {
            foreach (var comment in models)
            {

                Comments.Add(comment);
            }
        }
    }
}
