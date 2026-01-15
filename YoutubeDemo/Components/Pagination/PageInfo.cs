using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeAPI.Videos;

namespace YoutubeDemo.Components.PaginationComponent
{
    [AddINotifyPropertyChangedInterface]
    public class PageInfo
    {
        public int Number { get; set; }
        public bool Active { get; set; } = false;

        
        public PageInfo(int number,bool active = false)
        {
            this.Number = number;
            this.Active = active;
        }
    }
}