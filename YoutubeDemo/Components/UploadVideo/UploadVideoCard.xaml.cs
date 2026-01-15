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


namespace YoutubeDemo.Components.UploadVideo
{
    /// <summary>
    /// UploadVideoCard.xaml 的互動邏輯
    /// </summary>
    public partial class UploadVideoCard : UserControl
    {
        public UploadViewModel viewModel;
        public UploadVideoCard(string filePath)
        {
            InitializeComponent();
            viewModel = new UploadViewModel(filePath);
            this.DataContext = viewModel;
        }

    }
}
