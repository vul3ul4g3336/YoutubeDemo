using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using YoutubeDemo.Components.ViewModels;

namespace YoutubeDemo.Components.Comment
{
    /// <summary>
    /// Comments.xaml 的互動邏輯
    /// </summary>
    public partial class Comments : UserControl
    {
        private CommentModel model;
        public Comments(CommentModel Model )
        {
            InitializeComponent();
            
            this.DataContext = Model;
        }
        public Comments()
        {
            InitializeComponent();

            // 在沒有參數傳入時，DataContext 預設為 null，等待 VideoForm 設置。
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }
    }
}
