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
        
        public RatingPresenter()
        {
             
        }
        public async Task RatingRequest(string VideoID, string rating)
        {
            var response = await User.Context.Videos.SetVideoRating(VideoID, rating);
        }
    }
}
