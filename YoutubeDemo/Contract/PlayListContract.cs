using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeDemo.Models.DTOs;

namespace YoutubeDemo.Contract
{
    public class PlayListContract
    {
        public interface IPlayListView
        {
           
        }
        public interface IPlayListPresenter
        {
            public Task GetPlayListRequest();
            public Task<bool> AddVideoToPlaylist(string videoID, string playListID);
        }
    }
}
