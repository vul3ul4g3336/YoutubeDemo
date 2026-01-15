using Microsoft.Web.WebView2.Wpf;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace YoutubeDemo.Components.VideoPlayer
{
    public static class WebView2Helper
    {
        public static readonly DependencyProperty HtmlContentProperty =
            DependencyProperty.RegisterAttached(
                "HtmlContent",
                typeof(string),
                typeof(WebView2Helper),
                new PropertyMetadata(null, OnHtmlContentChanged));

        public static string GetHtmlContent(DependencyObject obj) => (string)obj.GetValue(HtmlContentProperty);
        public static void SetHtmlContent(DependencyObject obj, string value) => obj.SetValue(HtmlContentProperty, value);

        private static async void OnHtmlContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is WebView2 webView && e.NewValue is string html && !string.IsNullOrEmpty(html))
            {
                // 1. 確保初始化
                await webView.EnsureCoreWebView2Async();

                // 2. 解決 Error 153 的關鍵：對應一個虛擬資料夾路徑
                // 這樣 WebView2 會認為這是一個正常的網站環境
                string tempPath = Path.Combine(Path.GetTempPath(), "YoutubeDemo");
                if (!Directory.Exists(tempPath)) Directory.CreateDirectory(tempPath);

                // 將 HTML 寫入暫存檔 (或是直接使用 NavigateToString 但對應虛擬主機)
                string fileName = "index.html";
                File.WriteAllText(Path.Combine(tempPath, fileName), html, Encoding.UTF8);

                // 3. 設定虛擬主機名稱映射到暫存資料夾
                webView.CoreWebView2.SetVirtualHostNameToFolderMapping(
                    "youtube.local", tempPath, Microsoft.Web.WebView2.Core.CoreWebView2HostResourceAccessKind.Allow);

                // 4. 導向虛擬網址
                webView.Source = new Uri("https://youtube.local/index.html");
            }
        }
    }
}