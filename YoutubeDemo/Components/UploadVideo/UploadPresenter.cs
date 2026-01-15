using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeAPI.Videos.Model;
using static YoutubeDemo.Components.UploadVideo.UploadContract;

namespace YoutubeDemo.Components.UploadVideo
{
    public class UploadPresenter: IUploadPresenter
    {
        public async Task<UploadVideoResposeModel> UploadVideo(UploadModel model)
        {
            UploadVideoModel videoModel = new UploadVideoModel(model.title, model.description, model.privacy.ToString(), model.tags);
            var result = await User.Context.Videos.UploadVideo(videoModel, model.filePath);
            return result.Data;
        }
    }
}
