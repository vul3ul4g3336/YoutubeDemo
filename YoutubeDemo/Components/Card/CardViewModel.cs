using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using YoutubeDemo.Command;
using YoutubeDemo.Forms;
using YoutubeDemo.Presenter;

namespace YoutubeDemo.Components.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CardViewModel
    {
        public string Title { get; set; }
        public string ChannelTitle { get; set; }
        public string ViewCount { get; set; }
        public string ThumbnailUrl { get; set; }
        public string VideoID { get; set; }
        public LikeStatusEnum LikeStatus { get; set; }
        public string description { get; set; }
        public ICommand ratingCommand { get; set; }
        public ICommand mapsToVideoCommand { get; set; }
        public CardViewModel()
        {
            RatingPresenter presenter = new RatingPresenter();
            ratingCommand = new RelayCommand<string>(async (likeStatus) =>
            {
                if (Enum.TryParse<LikeStatusEnum>(likeStatus, out var targetStatus))
                {
                    LikeStatus = (LikeStatus == targetStatus)
                        ? LikeStatusEnum.none : targetStatus;
                }
                await presenter.RatingRequest(this.VideoID, LikeStatus.ToString());
            });
            mapsToVideoCommand = new RelayCommand(() =>
            {
                VideosForm form = new VideosForm(this);
                form.ShowDialog();
            });
        }
    }
}
