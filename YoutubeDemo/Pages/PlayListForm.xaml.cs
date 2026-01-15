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
using YoutubeDemo.Components.PlayListCard;

namespace YoutubeDemo.Pages
{
    /// <summary>
    /// PlayListForm.xaml 的互動邏輯
    /// </summary>
    public partial class PlayListForm : UserControl
    {
        public PlayListCardViewModel viewModel { get; set; }
        public PlayListForm()
        {
            InitializeComponent();
            viewModel = new PlayListCardViewModel();
            this.DataContext = viewModel;
        }
    }
}
