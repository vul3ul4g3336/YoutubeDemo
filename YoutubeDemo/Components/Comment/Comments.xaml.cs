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
using YoutubeDemo.Presenter;
using static YoutubeDemo.Contract.CommentContract;

namespace YoutubeDemo.Components.Comment
{
    /// <summary>
    /// Comments.xaml 的互動邏輯
    /// </summary>
    public partial class Comments : UserControl
    {
        //private CommentViewModel viewModel;
        //private CommentModel model;


        //public Comments(CommentModel Model, CommentViewModel viewModel)
        //{
        //    InitializeComponent();
        //    this.viewModel = viewModel;
        //    this.DataContext = Model;

        //}
        VideoForm videoForm;
        public Comments()
        {
            InitializeComponent();
            videoForm = VideoForm.CurrentInstance;
            // 在沒有參數傳入時，DataContext 預設為 null，等待 VideoForm 設置。
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            
            MenuToggle.IsChecked = false;
            Button btn = sender as Button;
            CommentModel model = (CommentModel)btn.DataContext;
            if (btn.Tag is VideoForm form)
            {
                form.commentViewModel.Remove(model);
            }
            else if(btn.Tag is CommentModel commentModel)
            {
                commentModel.replies.Remove(model);
            }
            videoForm.DeleteComment(model.CommentID);
            

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
