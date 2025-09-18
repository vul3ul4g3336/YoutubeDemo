using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace YoutubeDemo
{
    public class SearchViewModel :Window
    {
        public ObservableCollection<List<VideoCardModel>> Result = new ObservableCollection<List<VideoCardModel>>();
        List<VideoCardModel> VideoCards { get; set; }   
        public SearchViewModel()
        {
            DataContext = VideoCards;
        }
    }
}
