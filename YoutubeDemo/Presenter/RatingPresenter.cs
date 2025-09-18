using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeAPI;
using static YoutubeDemo.Contract.RatingContract;
using static YoutubeDemo.Contract.SearchVideoContract;

namespace YoutubeDemo.Presenter
{
    public class RatingPresenter : IRatingPresenter
    {
        public event EventHandler<string> ratingEvent;
        private IRatingView ratingView;
        public YoutubeAPI.YoutubeContext youtubeContext;
        public RatingPresenter()
        {
            youtubeContext = new YoutubeAPI.YoutubeContext();   
        }
        public async Task RatingRequest(string VideoID, string rating)
        {
            var response = await youtubeContext.Videos.SetVideoRating(VideoID, rating);
        }
    }
}
