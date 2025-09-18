using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
