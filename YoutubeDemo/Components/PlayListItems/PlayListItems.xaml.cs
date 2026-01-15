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

namespace YoutubeDemo.Components.PlayListItems
{
    /// <summary>
    /// PlayListItems.xaml 的互動邏輯
    /// </summary>
    public partial class PlayListItems : UserControl
    {
        public PlayListItems()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                "Command",               // XAML 裡用的屬性名稱
                typeof(ICommand),           // 屬性的型別
                typeof(PlayListItems),       // 擁有者
                new PropertyMetadata(null)); // 預設值

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // 2. 定義 CommandParameter 的依賴屬性 (用來傳送資料，例如 ID 或 Model 本身)
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register(
                "CommandParameter",
                typeof(object),
                typeof(PlayListItems),
                new PropertyMetadata(null));

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
    }
}
