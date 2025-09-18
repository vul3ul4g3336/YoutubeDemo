using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeDemo.Contract
{
    public class RatingContract
    {
        public interface IRatingView
        {
            
        }
        public interface IRatingPresenter
        {
            Task RatingRequest(string VideoID, string rating);

        }
    }
}
