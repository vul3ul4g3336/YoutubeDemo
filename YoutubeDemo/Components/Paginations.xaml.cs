using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YoutubeDemo.Components.PaginationComponent;
using YoutubeDemo.Components.ViewModels;
using YoutubeDemo.Presenter;
using static YoutubeDemo.Components.PaginationComponent.PageInfo;
using static YoutubeDemo.Components.PaginationComponent.PaginationContract;

namespace YoutubeDemo.Components
{
    /// <summary>
    /// Paginations.xaml 的互動邏輯
    /// </summary>
    public partial class Paginations : UserControl, IPaginationView
    {
        private IPaginationPresenter paginationPresenter;
        public PaginationsViewModel paginationsViewModel { get; set; } = new PaginationsViewModel();
        private int _total;
        public int Total
        {
            get
            {
                return _total;
            }
            set
            {
                paginationPresenter.Total = value;
            }
        }
        public int PageSize { get; set; } = 4;
        public event EventHandler<int> PageChanged;
        public Paginations()
        {
            InitializeComponent();
            this.DataContext = paginationsViewModel;
            paginationPresenter = new PaginationPresenter(this);

        }


        public void SetActivePageNumber(int number)
        {
            paginationsViewModel.Pages.ToList().ForEach(x => x.Active = false);
            paginationsViewModel.Pages.ToList().FirstOrDefault(x => x.Number == paginationPresenter.CurrentPageIndex).Active = true;
            PageChanged?.Invoke(this, number);
        }

        public void RenderPages(List<int> pages)
        {
            List<PageInfo> pageInfos = pages.Select((x, index) =>
            {
                bool isActive = false;
                return new PageInfo(x, isActive);
            }).ToList();

            this.paginationsViewModel.RenderPages(pageInfos);
            SetActivePageNumber(paginationPresenter.CurrentPageIndex);
        }

        private void NavigationButton_Click(object sender, MouseButtonEventArgs e)
        {
            Border border = (Border)sender;
            if (Enum.TryParse<ChangePageType>(border.Tag.ToString(), out var target))
            {
                paginationPresenter.ChangePage(target);
                SetActivePageNumber(paginationPresenter.CurrentPageIndex);
            }

        }

        private void PageButton_Click(object sender, MouseButtonEventArgs e)
        {
            Border border = (Border)sender;
            if (border.DataContext is PageInfo pageInfo)
            {
                paginationPresenter.CurrentPageIndex = pageInfo.Number;
                SetActivePageNumber(paginationPresenter.CurrentPageIndex);
            }
        }
    }
}
