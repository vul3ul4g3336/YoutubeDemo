using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeAPI.Videos.Model;

namespace YoutubeDemo.Components.UploadVideo
{
    public class UploadContract
    {
        public interface IUploadPresenter
        {
            Task<UploadVideoResposeModel> UploadVideo(UploadModel model);
        }
        public interface IUploadView
        {
            
        }
    }
}
