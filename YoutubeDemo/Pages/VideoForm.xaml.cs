using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using YoutubeAPI.Comments;
using YoutubeDemo.Components;
using YoutubeDemo.Components.Comment;
using YoutubeDemo.Components.VideoPlayer;
using YoutubeDemo.Components.ViewModels;
using YoutubeDemo.Presenter;
using static YoutubeAPI.Videos.Model.GetCommentModel;
using static YoutubeDemo.Contract.CommentContract;
using static YoutubeDemo.Contract.RatingContract;
using Comments = YoutubeDemo.Components.Comment.Comments;

namespace YoutubeDemo
{
    /// <summary>
    /// VideoForm.xaml 的互動邏輯
    /// </summary>
    public partial class VideoForm : UserControl
    {
        public CardViewModel model { get; set; }
        public CommentViewModel commentViewModel { get; set; }

       public ICommentPresenter commentPresenter;

        

        public VideoForm(CardViewModel model)
        {
            InitializeComponent();
            commentViewModel = new CommentViewModel(model.VideoID);
            this.model = model;
            this.DataContext = commentViewModel;

             
            VideoPlayers videoPlayers = new VideoPlayers(model);
            VideoPlayerContainer.Child = videoPlayers;
        }

    }
}