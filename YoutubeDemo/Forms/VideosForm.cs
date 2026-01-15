using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using YoutubeAPI.Videos;
using YoutubeDemo.Components;
using YoutubeDemo.Components.ViewModels;
using YoutubeDemo.Presenter;

namespace YoutubeDemo.Forms
{
    public partial class VideosForm : Form
    {
       
        CardViewModel cardViewModel;
        RatingPresenter ratingPresenter;
        VideoForm form;
        public VideosForm(CardViewModel cardViewModel)
        {
            InitializeComponent();
            form = new VideoForm(cardViewModel);
            elementHost1.Child = form;
        }
       
    }
}
