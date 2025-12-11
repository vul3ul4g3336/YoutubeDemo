using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using YoutubeDemo.Command;
using YoutubeDemo.Presenter;
using static YoutubeAPI.Videos.Model.GetCommentModel;
using static YoutubeDemo.Contract.CommentContract;

namespace YoutubeDemo.Components.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CommentViewModel
    {
        public ObservableCollection<CommentModel> Comments { get; set; }
        string ID = "UCsCh8O25n31QWEs90NgHBMA"; // UCsCh8O25n31QWEs90NgHBMA
        public string CommentMessage { get; set; }
        public CommentViewModel()
        {
            Comments = new ObservableCollection<CommentModel>();
        }

        public void Remove(CommentModel model)
        {
            Comments.Remove(model);
        }

        public void RenderComments(List<CommentModel> list)
        {

            foreach (var comment in list)
            {

                Comments.Add(comment);
            }
        }
        public void AddComments(CommentModel model)
        {
            Comments.Insert(0, model);
        }
        public void EditComments(CommentModel target, CommentModel source)
        {
            target.TextDisplay = source.TextDisplay;
            target.TextOriginal = source.TextOriginal;
            target.PublishedAt = source.PublishedAt;
        //    if (string.IsNullOrEmpty(model.ParentId))
        //    {
        //        var main = Comments.FirstOrDefault(c => c.CommentID == model.CommentID);
        //        if (main != null) UpdateCommentData(main, model);
        //    }
        //    else
        //    {
        //        var parent = Comments.FirstOrDefault(c => c.CommentID == model.ParentId);
        //        var sub = parent?.replies?.FirstOrDefault(r => r.CommentID == model.CommentID);
        //        if (sub != null) UpdateCommentData(sub, model);
        //    }
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

    }
}
