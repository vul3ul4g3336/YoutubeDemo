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
        public Card(CardViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
