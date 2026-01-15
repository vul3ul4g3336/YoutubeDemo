using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using YoutubeAPI.PlayLists.Model;
using YoutubeDemo.Command;
using YoutubeDemo.Components.ViewModels;
using YoutubeDemo.Forms;
using YoutubeDemo.Models.DTOs;
using YoutubeDemo.Presenter;
using static YoutubeDemo.Contract.PlayListContract;

namespace YoutubeDemo.Components.PlayListCard
{
    public class PlayListCardViewModel : IPlayListView
    {
        public ObservableCollection<PlayListModel> playListModels { get; set; } = new ObservableCollection<PlayListModel>();
        public ObservableCollection<PlayListVideoModel> playListVideoModels { get; set; } = new ObservableCollection<PlayListVideoModel>();
        PlayListPresenter presenter = new PlayListPresenter();
        public ICommand FetchPlaylistItems { get; set; }
        public ICommand DirectToVideo { get; set; } 
        public PlayListCardViewModel()
        {
            RenderCard(User.playListModels , playListModels);
            FetchPlaylistItems = new RelayCommand<string>(async x =>
            {
                playListVideoModels.Clear();
                List<PlayListVideoModel> models =  await presenter.GetMyPlaylistVideos(x);
                RenderCard(models , playListVideoModels);
            });
            DirectToVideo = new RelayCommand<string>(async x =>
            {
                CardViewModel model = await presenter.GetVideoByID(x);
                VideosForm videoForm = new VideosForm(model);
                videoForm.ShowDialog();
            });
        }
        private void RenderCard<T>(IEnumerable<T> source, ICollection<T> target)
        {
            foreach (var item in source)
            {
                target.Add(item);
            }
        }
    }
}
