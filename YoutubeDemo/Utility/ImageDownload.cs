using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeDemo.Utility
{

    public static class ImageDownload
    {
        // 加上 static，這樣你才能用 ImageDownload.DownloadImage(...) 呼叫
        // 建議將 HttpClient 改為靜態成員，重複使用以提升效能
        private static readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

        public static async Task<Image> DownloadImage(string url)
        {
            if (string.IsNullOrEmpty(url)) return null;

            try
            {
                // 直接使用靜態 client，不再使用 using
                byte[] imageBytes = await client.GetByteArrayAsync(url);

                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    Image originalImage = Image.FromStream(ms);
                    // 維持你要求的強制縮放，這對選單效能非常重要
                    return new Bitmap(originalImage, new Size(16, 16));
                }
            }
            catch
            {
                // 維持你寫的錯誤處理
                return SystemIcons.Application.ToBitmap();
            }
        }
    }

}
