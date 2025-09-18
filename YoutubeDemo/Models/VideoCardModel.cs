using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeDemo
{
    public class VideoCardModel
    {
        public string Title { get; set; }         
        public string ChannelTitle { get; set; }  
        public string ViewCount { get; set; }       
        public string url { get; set; }
        public string VideoID { get; set; }
        public LikeStatusEnum LikeStatus { get; set; }
        public string description { get; set; } 
    }
}
