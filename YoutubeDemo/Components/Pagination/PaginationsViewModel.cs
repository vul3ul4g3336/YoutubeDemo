using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using YoutubeDemo.Command;
using YoutubeDemo.Components.PaginationComponent;
using static YoutubeDemo.Components.PaginationComponent.PaginationContract;

namespace YoutubeDemo.Components.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class PaginationsViewModel : IPaginationView
    {

        public ObservableCollection<PageInfo> Pages { get; set; } = new ObservableCollection<PageInfo>();

        IPaginationPresenter presenter;
        public ICommand movePageCommand { get; set; }
        public ICommand choosePageCommand { get; set; }

        public int Total
        {
            get
            {
                return presenter.Total;
            }
            set
            {
                presenter.Total = value;

            }
        }
        public int PageSize { get; set; } = 4;
        public event EventHandler<int> PageChanged;
        public PaginationsViewModel()
        {
            presenter = new PaginationPresenter(this);
            movePageCommand = new RelayCommand<ChangePageType>(presenter.ChangePage);
            choosePageCommand = new RelayCommand<int>(presenter.ChoosePage);
        }
        public void RenderPages(List<int> pages)
        {
            this.Pages.Clear();
            pages.ForEach((x) =>
            {
                this.Pages.Add(new PageInfo(x, false));
            });

            SetActivePageNumber(pages[0]);
        }

        public void SetActivePageNumber(int number) // IPagination.SetActivePgeNumber
        {
            Pages.ToList().ForEach(x => x.Active = false);
            Pages.ToList().FirstOrDefault(x => x.Number == presenter.CurrentPageIndex).Active = true;
            PageChanged?.Invoke(this, number);
        }


    }
}
