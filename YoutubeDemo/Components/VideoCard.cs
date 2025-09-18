using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeAPI.Channel;
using YoutubeAPI.Videos.Model;
using YoutubeDemo.Forms;
using YoutubeDemo.Models.Enum;
using YoutubeDemo.Presenter;
using static YoutubeDemo.Contract.RatingContract;
using static YoutubeDemo.Contract.SearchVideoContract;

namespace YoutubeDemo.Components
{
    public partial class VideoCard : UserControl, IRatingView
    {

        private IRatingPresenter ratingPresenter;
        private VideoCardModel model;
        public VideoCard(VideoCardModel videoItem)
        {
            InitializeComponent();
            model = videoItem;
            ratingPresenter = new RatingPresenter();
            RenderCard();
            BuildActionBar();
        }
        public event EventHandler<string> ratingClick;
        public void BuildActionBar()
        {
            like.Text = "like";
            dislike.Text = "dislike";
            like.Click += RatingClick;
            dislike.Click += RatingClick;
            RatingStatus(this, model.LikeStatus);
        }

        private void RatingClick(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            if (lbl.ForeColor == Color.Red)
            {
                ratingPresenter.RatingRequest(this.Tag.ToString(), "none");
                RatingStatus(this, LikeStatusEnum.none);
            }
            else
            {
                ratingPresenter.RatingRequest(this.Tag.ToString(), lbl.Text);
                RatingStatus(this, (LikeStatusEnum)Enum.Parse(typeof(LikeStatusEnum), lbl.Text));
            }

        }
        private void RatingStatus(VideoCard card, LikeStatusEnum likeStatus)
        {
            List<Label> labels = card.Controls.OfType<Label>().ToList();
            switch (likeStatus)
            {
                case LikeStatusEnum.like:
                case LikeStatusEnum.dislike:

                    labels.ForEach(x => x.ForeColor = Color.Black);
                    labels.FirstOrDefault(x => x.Text == likeStatus.ToString()).ForeColor = Color.Red;
                    break;
                case LikeStatusEnum.none:
                    labels.ForEach(x => x.ForeColor = Color.Black);
                    break;
            }
            return;
        }
        public void RenderCard()
        {
            coverImg.LoadAsync(model.url);
            lblTitle.Text = model.Title;
            lblChannel.Text = model.ChannelTitle;
            lblViews.Text = (model.ViewCount == null) ? "" : $"觀看次數：{model.ViewCount}";
            
            Margin = new Padding(0, 5, 5, 0);
            this.Tag = model.VideoID;
        }

        private Size _laysize;
        public Size LayoutSize
        {
            get { return _laysize; }
            set
            {
                _laysize = value;
                //Console.WriteLine(value.Width);
                SizeChanged();

            }
        }
        private void SizeChanged()
        {
            this.Size = _laysize;
            this.lblTitle.Width = this.Size.Width;
            this.lblChannel.Width = this.Size.Width;
            this.lblViews.Width = this.Size.Width;
        }

        //private void coverImg_Click(object sender, EventArgs e)
        //{
        //    VideoForm form = new VideoForm(model);
        //    form.ShowDialog();
        //}
    }
}
