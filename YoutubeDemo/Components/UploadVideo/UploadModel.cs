using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeDemo.Models.DTOs;

namespace YoutubeDemo.Components.UploadVideo
{
    public class UploadModel
    {
        public string title { get; set; }   
        public string filePath { get; set; }
        public string description { get; set; }
        public string[] tags { get; set; } = null;
        public PrivacyStatus privacy { get; set; }

        public List<PlayListModel> selectedPlaylist { get; set; } = User.playListModels;



        public enum PrivacyStatus
        {
            Public,    // 公開
            Unlisted,  // 不公開 (這最常用，建議加上)
            Private    // 私人
        }
    }
}
