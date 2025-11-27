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

    public class CommentViewModel
    {
        public ObservableCollection<CommentModel> Comments { get; set; }
        string ID = "UCsCh8O25n31QWEs90NgHBMA"; // UCsCh8O25n31QWEs90NgHBMA
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
            Comments.Add(model);
        }
        
    }
}
