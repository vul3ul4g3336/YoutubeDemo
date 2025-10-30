using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeDemo.Models.Enum;

namespace YoutubeDemo.Components
{
    [AddINotifyPropertyChangedInterface]
    public class CommentModel
    {
        public string CommentID { get; set; }
        public string AuthorDisplayName { get; set; }
        public string AuthorProfileImageUrl { get; set; }
        public bool CanRate { get; set; }
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
        public string TextDisplay { get; set; }
        public DateTime PublishedAt { get; set; }
        public int TotalReplyCount { get; set; }
        public CommentModel[] replies { get; set; }
        public List<CommentSegment> commentSegment { get; set; }
    }
    public class CommentSegment
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public bool IsHyperLink { get; set; }   
    }
}
