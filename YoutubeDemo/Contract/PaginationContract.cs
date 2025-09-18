using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeDemo.Components.PaginationComponent
{
    public class PaginationContract
    {

        public enum ChangePageType
        {
            Next,
            Previous,
            JumpPrevious,
            JumpNext
        }

        public interface IPaginationView
        {
            int Total { get; set; }
            int PageSize { get; set; }

            void SetActivePageNumber(int number);
            void RenderPages(List<int> pages);

        }

        public interface IPaginationPresenter
        {
            int PageSize { get; set; }   
            int Total { get; set; } // 整體資料 
            int MaxPage { get;  }   // 總共幾頁
            int CurrentPageIndex { get; set; }
            int jumpPage { get; set; }
            void ChangePage(ChangePageType changeType);
            void ChoosePage(int pageNumber);        }
    }
}
