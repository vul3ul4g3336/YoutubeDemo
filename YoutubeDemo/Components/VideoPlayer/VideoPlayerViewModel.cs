using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeAPI.Videos;
using static YoutubeDemo.Contract.RatingContract;
using YoutubeDemo.Presenter;
using System.Windows.Input;
using YoutubeDemo.Command;
using YoutubeDemo.Components.ViewModels;
using System.Windows.Controls;

namespace YoutubeDemo.Components.VideoPlayer
{
    [AddINotifyPropertyChangedInterface]
    public class VideoPlayerViewModel :IRatingView
    {
        public CardViewModel model { get; set; }
        IRatingPresenter ratingPresenter;
        private ICommand ratingCommand;

        public VideoPlayerViewModel(CardViewModel model)
        {
            this.model = model;
            ratingPresenter = new RatingPresenter();
            ratingCommand = new RelayCommand<string>((x) =>
            {
                if (Enum.TryParse<LikeStatusEnum>(x, out var targetStatus))
                {
                    model.LikeStatus = (model.LikeStatus == targetStatus)
                        ? LikeStatusEnum.none : targetStatus;
                }
                ratingPresenter.RatingRequest(model.VideoID, model.LikeStatus.ToString());
            });
            LoadVideo(model.VideoID);
        }

        public ICommand RatingCommand => ratingCommand;

        public string VideoHtml { get; set; }

        public void LoadVideo(string videoID)
        {
            // 確保 src 網址正確，並且 HTML 結構乾淨
            VideoHtml = $@"<!DOCTYPE html>
        <html>
        <head>
            <meta charset=""UTF-8"">
            <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />
            <style>
                body, html {{ margin: 0; padding: 0; width: 100%; height: 100%; overflow: hidden; background-color: #000; }}
                iframe {{ width: 100%; height: 100%; border: none; }}
            </style>
        </head>
        <body>
            <iframe src=""https://www.youtube.com/embed/{videoID}?autoplay=1&rel=0"" 
                    allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"" 
                    allowfullscreen></iframe>
        </body>
        </html>";
        }
    }
}