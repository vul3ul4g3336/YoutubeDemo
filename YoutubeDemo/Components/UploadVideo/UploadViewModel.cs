using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YoutubeAPI.Videos.Model;
using YoutubeDemo.Command;
using YoutubeDemo.Models.DTOs;
using YoutubeDemo.Presenter;
using static YoutubeDemo.Components.UploadVideo.UploadContract;
using static YoutubeDemo.Contract.PlayListContract;

namespace YoutubeDemo.Components.UploadVideo 
{
    [AddINotifyPropertyChangedInterface()]
    public class UploadViewModel:IPlayListView , IUploadView
    {
        IUploadPresenter presenter;
        IPlayListPresenter playListPresenter;
        public UploadModel model { get; set; }
        public ICommand UploadVideo { get; set; }

        public PlayListModel SelectedPlayListItem { get; set; }
        public event EventHandler eventHandler;
        public UploadViewModel(string filePath) {

            presenter = new UploadPresenter();
            playListPresenter = new PlayListPresenter();   
            
            model = new UploadModel();
            model.filePath = filePath;
            UploadVideo = new RelayCommand<UploadModel>(async x =>
            {
                UploadVideoResposeModel responseModel =  await presenter.UploadVideo(x);
                if(SelectedPlayListItem != null)
                    await playListPresenter.AddVideoToPlaylist(responseModel.id, SelectedPlayListItem.id);
                eventHandler.Invoke(this, new EventArgs());
            });

           
        }

       
    }
}
