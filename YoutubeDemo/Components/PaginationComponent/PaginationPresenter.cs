using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static YoutubeDemo.Components.PaginationComponent.PaginationContract;

namespace YoutubeDemo.Components.PaginationComponent
{
    public class PaginationPresenter : IPaginationPresenter
    {
        private IPaginationView paginationView;
        public PaginationPresenter(IPaginationView paginationView)
        {
            this.paginationView = paginationView;
        }
        public int MaxPage => Total % PageSize != 0 ? (Total / PageSize) + 1 : Total / PageSize; // 28頁
      
        public int CurrentPageIndex { get; set; } = 1;
        private int _total = 0;
        public int Total {
            get => _total; 
            set  {
                _total = value;
                GeneratePages();
            }
        }

        public int PageSize { get; set; } = 4;
        public int jumpPage { get; set; } = 3;

        private void GeneratePages(int start=1)
        {
            List<int> pages = new List<int>();
            start = ((start - 1) / 10) * 10 + 1;
            for (int i = 0; i < 10 ; i++)
            {
                if (i +start > MaxPage) break;
                pages.Add(i + start);
            }
            this.paginationView.RenderPages(pages);
            //paginationView.SetActivePageNumber(CurrentPageIndex);
        }

        void IPaginationPresenter.ChangePage(ChangePageType changeType)
        {

            int oldIndex = CurrentPageIndex;
            int oldGroup = (oldIndex - 1) / 10;

            switch (changeType)
            {
                case ChangePageType.Next:
                    CurrentPageIndex = Math.Min(CurrentPageIndex + 1, MaxPage);
                    break;

                case ChangePageType.Previous:
                    CurrentPageIndex = Math.Max(1, CurrentPageIndex - 1);
                    break;

                case ChangePageType.JumpNext:
                    CurrentPageIndex = Math.Min(MaxPage, CurrentPageIndex + jumpPage);
                    break;

                case ChangePageType.JumpPrevious:
                    CurrentPageIndex = Math.Max(1, CurrentPageIndex - jumpPage);
                    break;
            }

            // 是否跨組（例如 10→11 或 11→10）
            int newGroup = (CurrentPageIndex - 1) / 10;
            if (newGroup != oldGroup)
            {
                GeneratePages(CurrentPageIndex); // 用目前頁碼重生分頁列（會自算 1..10 或 11..20）
            }

            //if ((oldIndex - 1) / PageSize != (CurrentPageIndex - 1) / PageSize)
            //    GeneratePages(CurrentPageIndex);
            //paginationView.SetActivePageNumber(CurrentPageIndex);
            
        }

        void IPaginationPresenter.ChoosePage(int pageNumber)
        {
            CurrentPageIndex = pageNumber;
            paginationView.SetActivePageNumber(pageNumber);
        }

     
    }
}
