using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YoutubeAPI.Videos;
using YoutubeAPI.Videos.Model;
using YoutubeDemo.Components;
using static YoutubeDemo.Contract.CommentContract;
using static YoutubeDemo.Contract.RatingContract;

namespace YoutubeDemo.Presenter
{
    public class CommentPresenter : ICommentPresenter
    {
        public YoutubeAPI.YoutubeContext youtubeContext;


        private ICommentView commentView;
        public CommentPresenter(ICommentView commentView)
        {
            this.commentView = commentView;
            youtubeContext = new YoutubeAPI.YoutubeContext();
        }

        public async Task Comment_Delete(string commentID)
        {
            var response = await youtubeContext.Comments.DeleteComment(commentID);

        }

        public async Task Comment_Request(string videoID)
        {
            var response = await youtubeContext.Comments.GetComment(videoID);
            List<CommentModel> models = Utility.Mapper.Map<GetCommentModel.Item, CommentModel>(response.Data.items, mapping =>
            {
                mapping.ForMember(x => x.CommentID, y => y.MapFrom(z => z.snippet.topLevelComment.id))
                       .ForMember(x => x.AuthorDisplayName, y => y.MapFrom(z => z.snippet.topLevelComment.snippet.authorDisplayName))
        .ForMember(x => x.AuthorProfileImageUrl, y => y.MapFrom(z => z.snippet.topLevelComment.snippet.authorProfileImageUrl))
        .ForMember(x => x.CanRate, y => y.MapFrom(z => z.snippet.topLevelComment.snippet.canRate))
        .ForMember(x => x.ViewerRatingString, y => y.MapFrom(z => z.snippet.topLevelComment.snippet.viewerRating))
        .ForMember(x => x.LikeCount, y => y.MapFrom(z => z.snippet.topLevelComment.snippet.likeCount))
        .ForMember(x => x.TextDisplay, y => y.MapFrom(z => z.snippet.topLevelComment.snippet.textDisplay))
        .ForMember(x => x.PublishedAt, y => y.MapFrom(z => z.snippet.topLevelComment.snippet.publishedAt))
        .ForMember(x => x.TotalReplyCount, y => y.MapFrom(z => z.snippet.totalReplyCount))
        .ForMember(x => x.replies, y => y.MapFrom(z => z.snippet.totalReplyCount > 0 ? DataTransform(z.replies) : null))
        .ForMember(x => x.commentSegment, y => y.MapFrom(z => SegmentTextByUrls(z.snippet.topLevelComment.snippet.textDisplay)))
        .ForMember(x => x.AuthorChannelId, y => y.MapFrom(z => z.snippet.topLevelComment.snippet.authorChannelId.value));
        
            }).ToList();
            commentView.Comment_Response(models);
        }

        public CommentModel[] DataTransform(GetCommentModel.Replies replies)
        {
            CommentModel[] models = Utility.Mapper.Map<GetCommentModel.Comment, CommentModel>(replies.comments, mapping =>
            {
                mapping.ForMember(x => x.CommentID, y => y.MapFrom(z => z.id))
                       .ForMember(x => x.AuthorDisplayName, y => y.MapFrom(z => z.snippet.authorDisplayName))
        .ForMember(x => x.AuthorProfileImageUrl, y => y.MapFrom(z => z.snippet.authorProfileImageUrl))
        .ForMember(x => x.CanRate, y => y.MapFrom(z => z.snippet.canRate))
        .ForMember(x => x.ViewerRatingString, y => y.MapFrom(z => z.snippet.viewerRating))
        .ForMember(x => x.LikeCount, y => y.MapFrom(z => z.snippet.likeCount))
        .ForMember(x => x.TextDisplay, y => y.MapFrom(z => z.snippet.textDisplay))
        .ForMember(x => x.PublishedAt, y => y.MapFrom(z => z.snippet.publishedAt))
         .ForMember(x => x.commentSegment, y => y.MapFrom(z => SegmentTextByUrls(z.snippet.textDisplay)))
         .ForMember(x=>x.AuthorChannelId,y=> y.MapFrom(z=> z.snippet.authorChannelId.value));
            }).ToArray();
            
            return models;
        }

        private List<CommentSegment> SegmentTextByUrls(string Text)
        {
            string pattern = @"<a\s+href\s*=\s*""([^""]+)""\s*>(.*?)<\/a>";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            List<CommentSegment> segments = new List<CommentSegment>();
            int lastIndex = 0;
           

                var matches = regex.Matches(Text);
                if (matches.Count == 0)
                {
                    segments.Add(new CommentSegment { Text =Text, IsHyperLink = false });
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
                if(lastIndex < Text.Length)
                {
                    string textAfter = Text.Substring(lastIndex);
                    segments.Add(new CommentSegment() { Text = textAfter, IsHyperLink = false });
                }
               
                return segments;
            

        }
        public async Task PostNewCommentThread(string videoID,string text)
        {
            var response = await youtubeContext.Comments.PostNewCommentThread(videoID, text);
        }
        public async Task PostCommentReply(string commentID,string text)
        {
            var response = await youtubeContext.Comments.PostCommentReply(commentID, text);
        }
    }
}
