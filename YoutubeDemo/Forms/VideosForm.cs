using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using YoutubeAPI.Videos;
using YoutubeDemo.Components;
using YoutubeDemo.Components.ViewModels;
using YoutubeDemo.Presenter;

namespace YoutubeDemo.Forms
{
    public partial class VideosForm : Form
    {
        //CardViewModel cardViewModel;
        //RatingPresenter ratingPresenter;
        //public VideoForm(CardViewModel cardViewModel)
        //{
        //    InitializeComponent();
        //    this.cardViewModel = cardViewModel;
        //    ratingPresenter = new RatingPresenter();    
        //    //like.Click += RatingClick;
        //    //dislike.Click += RatingClick;
            
        //}
        CardViewModel cardViewModel;
        RatingPresenter ratingPresenter;
        VideoForm form;
        public VideosForm(CardViewModel cardViewModel)
        {
            InitializeComponent();
            form = new VideoForm(cardViewModel);
            elementHost1.Child = form;
        }
        //private void RatingClick(object sender, EventArgs e)
        //{
        //    Label lbl = (Label)sender;
        //    if (lbl.ForeColor == Color.Red)
        //    {
        //        ratingPresenter.RatingRequest(this.Tag.ToString(), "none");
        //        RatingStatus(cardViewModel, LikeStatusEnum.none);
        //    }
        //    else
        //    {
        //        ratingPresenter.RatingRequest(this.Tag.ToString(), lbl.Text);
        //        RatingStatus(cardViewModel, (LikeStatusEnum)Enum.Parse(typeof(LikeStatusEnum), lbl.Text));
        //    }
        //}
        private void RatingStatus(VideoCardModel videoCardModel, LikeStatusEnum likeStatus)
        {
            //List<Label> labels = videoCardModel.Controls.OfType<Label>().ToList();
            //switch (likeStatus)
            //{
            //    case LikeStatusEnum.like:
            //    case LikeStatusEnum.dislike:

            //        labels.ForEach(x => x.ForeColor = Color.Black);
            //        labels.FirstOrDefault(x => x.Text == likeStatus.ToString()).ForeColor = Color.Red;
            //        break;
            //    case LikeStatusEnum.none:
            //        labels.ForEach(x => x.ForeColor = Color.Black);
            //        break;
            //}
            //return;
        }
        //private async void VideoForm_Load(object sender, EventArgs e)
        //{
        //    await InitializeWebView2Async();

        //    VideoDetail();
        //}

        //private async Task InitializeWebView2Async()
        //{
        //    // 等待 WebView2 的核心環境初始化完成
        //    // 這是使用 WebView2 前必須的步驟
        //    await webView.EnsureCoreWebView2Async(null);
        //}
        //private void LoadYouTubeVideo(string videoId)
        //{
        //    // 確保 WebView2 核心已準備就緒
        //    if (webView != null && webView.CoreWebView2 != null)
        //    {

        //        string htmlContent = $@"
        //        <!DOCTYPE html>
        //        <html>
        //        <head>
        //            <style>
        //                body, html {{ margin: 0; padding: 0; width: 100%; height: 100%; overflow: hidden; }}
        //                iframe {{ position: absolute; top: 0; left: 0; width: 100%; height: 100%; }}
        //            </style>
        //        </head>
        //        <body>
        //              <iframe width=""695"" height=""391"" src=""https://www.youtube.com/embed/{videoId}"" frameborder=""0""
        //allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share""
        //referrerpolicy=""strict-origin-when-cross-origin"" allowfullscreen></iframe>
        //        </body>
        //        </html>";
        //        // 使用 NavigateToString 來載入我們動態產生的 HTML 內容
        //        webView.CoreWebView2.NavigateToString(htmlContent);
        //    }
        //}
 
  

        //// 關閉視窗時，釋放 WebView2 資源
        //private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    webView?.Dispose();
        //}
        //private void VideoDetail()
        //{
        //    LoadYouTubeVideo(cardViewModel.VideoID);
        //    VideoTitle.Text = cardViewModel.Title;
        //    ChannelTitle.Text = cardViewModel.ChannelTitle;
        //    ViewCount.Text = cardViewModel.ViewCount;
        //    VideoTitle.Text = cardViewModel.Title;
        //}

       
    }
}
