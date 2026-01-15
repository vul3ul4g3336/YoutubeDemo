//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using static YoutubeDemo.Contract.VideoPlayerContract;

//namespace YoutubeDemo.Components.VideoPlayer
//{
//    public class VideoPlayerPresenter : IVideoPlayerPresenter
//    {
//        private IVideoPlayerView videoPlayerView;
//        public VideoPlayerPresenter(IVideoPlayerView view)
//        {
//            videoPlayerView = view;
//        }

//        public async void LoadVideo(string videoID)
//        {
//            await InitializeWebView2Async();
//            LoadYouTubeVideo(videoID);
//        }

//        private async Task InitializeWebView2Async()
//        {
//            await webView.EnsureCoreWebView2Async(null);
//        }

//        private void LoadYouTubeVideo(string videoId)
//        {
//            if (webView != null && webView.CoreWebView2 != null)
//            {

//                string htmlContent = $@"
//                <!DOCTYPE html>
//                <html>
//                <head>
//                    <style>
//                        body, html {{ margin: 0; padding: 0; width: 100%; height: 100%; overflow: hidden; }}
//                        iframe {{ position: absolute; top: 0; left: 0; width: 100%; height: 100%; }}
//                    </style>
//                </head>
//                <body>
//                     <iframe width=""695"" height=""391"" src=""https://www.youtube.com/embed/{videoId}"" frameborder=""0""
//        allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share""
//        referrerpolicy=""strict-origin-when-cross-origin"" allowfullscreen></iframe>
//                </body>
//                </html>";
//                webView.CoreWebView2.NavigateToString(htmlContent);
//            }
//        }

//        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
//        {
//            await InitializeWebView2Async();
//            LoadYouTubeVideo(model.VideoID);
//        }
//    }
//}
