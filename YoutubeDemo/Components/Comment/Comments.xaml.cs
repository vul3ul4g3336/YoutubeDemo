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
        

        
        VideoForm videoForm;

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
   
        private void CancelEdit_Click(object sender, RoutedEventArgs e)
        {
            DisplayPanel.Visibility = Visibility.Visible;
            EditPanel.Visibility = Visibility.Collapsed;

            // 這裡可以視情況還原原本的文字，例如：
            // EditCommentBox.Text = ...
        }

        // 3. 點擊「儲存」：還原並觸發後續邏輯
       
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // 1. 切換顯示狀態
            DisplayPanel.Visibility = Visibility.Collapsed;
            EditPanel.Visibility = Visibility.Visible;

            // 2. 關閉選單
            MenuToggle.IsChecked = false;

            // 3. 讓輸入框取得焦點並將游標移到最後
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input, new System.Action(() =>
            {
                EditCommentBox.Focus();
                EditCommentBox.CaretIndex = EditCommentBox.Text.Length;
            }));
        }

        private void Reply_Click(object sender, RoutedEventArgs e)
        {
           Button button = sender as Button;
            CommentModel commentModel = (CommentModel)button.DataContext;
            // 顯示回覆輸入框
            ReplyInputPanel.Visibility = Visibility.Visible;

            // 自動聚焦到輸入框
            ReplyBox.Focus();

        }

        private void CancelReply_Click(object sender, RoutedEventArgs e)
        {
            ReplyInputPanel.Visibility = Visibility.Collapsed;

            // 清空輸入框內容
            ReplyBox.Clear();
        }

        //private async void SendReply_Click(object sender, RoutedEventArgs e)
        //{
        //    Button btn = sender as Button;
        //    CommentModel model = (CommentModel)btn.DataContext;

        //    // 取得回覆內容
        //    string replyText = ReplyBox.Text;
        //    if (string.IsNullOrWhiteSpace(replyText)) return;

            
        //    var comment = await videoForm.commentPresenter.PostCommentReply(model.CommentID, ReplyBox.Text);
        //    videoForm.commentViewModel.ReplyToComment(comment);
        //    // 送出後隱藏輸入框
        //    ReplyInputPanel.Visibility = Visibility.Collapsed;

        //    // 清空輸入框
        //    ReplyBox.Clear();


        //}
    }
}
