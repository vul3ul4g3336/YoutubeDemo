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
using YoutubeDemo.Components.ViewModels;
using YoutubeDemo.Forms;
using YoutubeDemo.Presenter;
using static YoutubeDemo.Contract.RatingContract;

namespace YoutubeDemo.Components
{
    /// <summary>
    /// Card.xaml 的互動邏輯
    /// </summary>
    public partial class Card : UserControl
    {
        private IRatingPresenter ratingPresenter;
        public CardViewModel model { get; set; }
        public Card(CardViewModel model)
        {
            InitializeComponent();
            this.model = model;
            this.model.LikeStatus = model.LikeStatus;
            DataContext = this.model;
            ratingPresenter = new RatingPresenter();
        }
        public void RatingButton_Click(object sender, MouseButtonEventArgs e)
        {
            Border border = (Border)sender;
            if (Enum.TryParse<LikeStatusEnum>(border.Tag.ToString(), out var targetStatus))
            {
                model.LikeStatus = (model.LikeStatus == targetStatus)
                    ? LikeStatusEnum.none : targetStatus;
            }
            ratingPresenter.RatingRequest(model.VideoID, model.LikeStatus.ToString());
        }

        private void CoverImg_Click(object sender, MouseButtonEventArgs e)
        {
            VideosForm form = new VideosForm(model);
            form.ShowDialog();
        }
    }
}
