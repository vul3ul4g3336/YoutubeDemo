using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static YoutubeDemo.Contract.SearchVideoContract;

namespace YoutubeDemo
{
    public class SearchViewModel :Window, ISearchView
    {
        public ObservableCollection<List<VideoCardModel>> Result = new ObservableCollection<List<VideoCardModel>>();
        List<VideoCardModel> VideoCards { get; set; }   
        public ICommand searchTask { get; set; }
        public SearchViewModel()
        {
            DataContext = VideoCards;

        }

        public void SearchResponse(List<VideoCardModel> videos)
        {
            throw new NotImplementedException();
        }
    }
}
