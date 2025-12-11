using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using YoutubeDemo.Models.Enum;

namespace YoutubeDemo.Components
{
    [AddINotifyPropertyChangedInterface]
    public class CommentModel
    {

        public Visibility VisibilityButton => AuthorChannelId == User.ID ? Visibility.Visible : Visibility.Collapsed;
        public string AuthorChannelId { get; set; }
        public string CommentID { get; set; }
        public string AuthorDisplayName { get; set; }
        public string AuthorProfileImageUrl { get; set; }
        public bool CanRate { get; set; }
        public bool CanReply { get; set; } = true;
        public string ParentId { get; set; }
        public string ViewerRatingString
        {
            get => ViewerRating.ToString();
            set
            {
                ViewerRating = Enum.TryParse<LikeStatusEnum>(value, true, out var status) ? status : LikeStatusEnum.none;
            }
        }
        public LikeStatusEnum ViewerRating { get; set; }
        public int LikeCount { get; set; }
        public string TextOriginal { get; set; }
        public DateTime PublishedAt { get; set; }
        public int TotalReplyCount { get; set; }

        private string _TextDisplay;

        [AlsoNotifyFor(nameof(commentSegment))]
        public string TextDisplay
        {
            get
            {
                return _TextDisplay;
            }
            set
            {
                _TextDisplay = value;
                commentSegment = SegmentTextByUrls(value);
            }
        }
        //public List<CommentSegment> commentSegment => SegmentTextByUrls(TextDisplay);
        private List<CommentSegment> _commentSegment;

        public List<CommentSegment> commentSegment
        {
            get
            {
                return _commentSegment;
            }
            set => _commentSegment = value;
        }       
        public ObservableCollection<CommentModel> replies { get; set; } //public CommentModel[] replies { get; set; }



        private List<CommentSegment> SegmentTextByUrls(string Text)
        {
            string pattern = @"<a\s+href\s*=\s*""([^""]+)""\s*>(.*?)<\/a>";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            List<CommentSegment> segments = new List<CommentSegment>();
            int lastIndex = 0;


            var matches = regex.Matches(Text);
            if (matches.Count == 0)
            {
                segments.Add(new CommentSegment { Text = Text, IsHyperLink = false });
                return segments;
            }

            foreach (Match match in matches)
            {
                if (match.Index > lastIndex)
                {
                    string textBefore = Text.Substring(lastIndex, match.Index - lastIndex);
                    segments.Add(new CommentSegment() { Text = textBefore.Replace("<br>", "\n"), IsHyperLink = false });

                }

                segments.Add(new CommentSegment
                {
                    Text = match.Groups[2].Value.Replace("<br>", "\n"), // 顯示的文字 (Group 2)
                    IsHyperLink = true,
                    Url = match.Groups[1].Value // 實際的 URL (Group 1)
                });
                lastIndex = match.Index + match.Length;
            }
            if (lastIndex < Text.Length)
            {
                string textAfter = Text.Substring(lastIndex);
                segments.Add(new CommentSegment() { Text = textAfter, IsHyperLink = false });
            }

            return segments;
            //if (string.IsNullOrEmpty(Text)) return new List<CommentSegment>();

            //// 1. 修改正則表達式：改為抓取 http 或 https 開頭，直到遇到空白為止的字串
            //string pattern = @"(https?:\/\/[^\s]+)";
            //var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            //List<CommentSegment> segments = new List<CommentSegment>();
            //int lastIndex = 0;

            //var matches = regex.Matches(Text);

            //if (matches.Count == 0)
            //{
            //    // 記得這裡也要處理換行
            //    segments.Add(new CommentSegment { Text = Text.Replace("\r\n", "\n"), IsHyperLink = false });
            //    return segments;
            //}

            //foreach (Match match in matches)
            //{
            //    // 處理網址前的文字
            //    if (match.Index > lastIndex)
            //    {
            //        string textBefore = Text.Substring(lastIndex, match.Index - lastIndex);
            //        segments.Add(new CommentSegment() { Text = textBefore.Replace("\r\n", "\n"), IsHyperLink = false });
            //    }

            //    // 處理網址本身
            //    segments.Add(new CommentSegment
            //    {
            //        // 2. 修改取值方式：純網址沒有 Group[1] 或 Group[2]，直接用 match.Value 即可
            //        Text = match.Value,      // 顯示的文字就是網址本身
            //        IsHyperLink = true,
            //        Url = match.Value        // 連結也是網址本身
            //    });

            //    lastIndex = match.Index + match.Length;
            //}

            //// 處理剩下的文字
            //if (lastIndex < Text.Length)
            //{
            //    string textAfter = Text.Substring(lastIndex);
            //    segments.Add(new CommentSegment() { Text = textAfter.Replace("\r\n", "\n"), IsHyperLink = false });
            //}

            //return segments;

        }
    }
    public class CommentSegment
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public bool IsHyperLink { get; set; }
    }


}
