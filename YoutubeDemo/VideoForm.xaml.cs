﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using YoutubeAPI.Comments;
using YoutubeDemo.Components;
using YoutubeDemo.Components.Comment;
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
    public partial class VideoForm : UserControl, ICommentView
    {
        CardViewModel model;
        IRatingPresenter ratingPresenter = new RatingPresenter();
        ICommentPresenter commentPresenter;
        Comments comments;

        public CommentViewModel commentViewModel { get; set; }

        public VideoForm(CardViewModel model)
        {
            InitializeComponent();
            commentViewModel = new CommentViewModel();
            this.model = model;
            this.DataContext = model;
            commentPresenter = new CommentPresenter(this);
            commentPresenter.Comment_Request(model.VideoID);
        }


        private async Task InitializeWebView2Async()
        {
            await webView.EnsureCoreWebView2Async(null);
        }

        private void LoadYouTubeVideo(string videoId)
        {
            if (webView != null && webView.CoreWebView2 != null)
            {

                string htmlContent = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <style>
                        body, html {{ margin: 0; padding: 0; width: 100%; height: 100%; overflow: hidden; }}
                        iframe {{ position: absolute; top: 0; left: 0; width: 100%; height: 100%; }}
                    </style>
                </head>
                <body>
                     <iframe width=""695"" height=""391"" src=""https://www.youtube.com/embed/{videoId}"" frameborder=""0""
        allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share""
        referrerpolicy=""strict-origin-when-cross-origin"" allowfullscreen></iframe>
                </body>
                </html>";
                webView.CoreWebView2.NavigateToString(htmlContent);
            }
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await InitializeWebView2Async();
            LoadYouTubeVideo(model.VideoID);
        }

        private void RatingButton_Click(object sender, MouseButtonEventArgs e)
        {
            Border border = (Border)sender;
            if (Enum.TryParse<LikeStatusEnum>(border.Tag.ToString(), out var targetStatus))
            {
                model.LikeStatus = (model.LikeStatus == targetStatus)
                    ? LikeStatusEnum.none : targetStatus;
            }
            ratingPresenter.RatingRequest(model.VideoID, model.LikeStatus.ToString());
        }


        public void Comment_Response(List<CommentModel> models)
        {
            foreach (var model in models)
            {
                // 2. 創建 Comments 元件，並傳入單個 CommentModel
                // 這會觸發 Comments.xaml.cs 中的 Comments(CommentModel model) 建構函式
                Components.Comment.Comments commentComponent = new Components.Comment.Comments(model);

                // 3. 將新的 Comments 元件添加到 StackPanel 中
                // 這是將 UI 顯示在右側欄位的必要步驟
                CommentsHostPanel.Children.Add(commentComponent);

            }


        }
    }
}