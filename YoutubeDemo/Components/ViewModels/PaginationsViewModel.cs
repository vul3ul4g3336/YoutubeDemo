using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeDemo.Components.PaginationComponent;

namespace YoutubeDemo.Components.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class PaginationsViewModel
    {
        
        public ObservableCollection<PageInfo> Pages { get; set; } = new ObservableCollection<PageInfo>();

        public void RenderPages(List<PageInfo> pageInfos)
        {
            this.Pages.Clear();
            foreach (var pageInfo in pageInfos)
            {
                   this.Pages.Add(pageInfo);
            }
        }

    }
}
