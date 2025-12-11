using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YoutubeAPI.Comments;
using YoutubeAPI.Comments.Model;
using YoutubeAPI.Videos;
using YoutubeAPI.Videos.Model;
using YoutubeDemo.Components;
using static YoutubeDemo.Contract.CommentContract;
using static YoutubeDemo.Contract.RatingContract;

namespace YoutubeDemo.Presenter
{
    public class CommentPresenter : ICommentPresenter
    {



        private ICommentView commentView;
        public CommentPresenter(ICommentView commentView)
        {
            this.commentView = commentView;

        }

        public async Task Comment_Delete(string commentID)
        {
            var response = await User.Context.Comments.DeleteComment(commentID);

        }

        public async Task Comment_Request(string videoID)
        {
            var response = await User.Context.Comments.GetComment(videoID);
            if (response.IsSuccess == false) return;

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
        .ForMember(x => x.TextOriginal, y => y.MapFrom(z => z.snippet.topLevelComment.snippet.textOriginal))
        .ForMember(x => x.CanReply, y => y.MapFrom(z => z.snippet.canReply))
        .ForMember(x => x.AuthorChannelId, y => y.MapFrom(z => z.snippet.topLevelComment.snippet.authorChannelId.value));

            }).ToList();
            commentView.Comment_Response(models);
        }

        public CommentModel[] DataTransform(GetCommentModel.Replies replies)
        {
            if (replies == null) return null;
            CommentModel[] models = Utility.Mapper.Map<GetCommentModel.Comment, CommentModel>(replies.comments, mapping =>
            {
                mapping.ForMember(x => x.CommentID, y => y.MapFrom(z => z.id))
                       .ForMember(x => x.AuthorDisplayName, y => y.MapFrom(z => z.snippet.authorDisplayName))
        .ForMember(x => x.AuthorProfileImageUrl, y => y.MapFrom(z => z.snippet.authorProfileImageUrl))
        .ForMember(x => x.CanRate, y => y.MapFrom(z => z.snippet.canRate))
        .ForMember(x => x.ViewerRatingString, y => y.MapFrom(z => z.snippet.viewerRating))
        .ForMember(x => x.LikeCount, y => y.MapFrom(z => z.snippet.likeCount))
        .ForMember(x => x.TextDisplay, y => y.MapFrom(z => z.snippet.textDisplay))
        .ForMember(x => x.TextOriginal, y => y.MapFrom(z => z.snippet.textOriginal))
        .ForMember(x => x.PublishedAt, y => y.MapFrom(z => z.snippet.publishedAt))
         //.ForMember(x => x.commentSegment, y => y.MapFrom(z => SegmentTextByUrls(z.snippet.textDisplay)))
         .ForMember(x => x.AuthorChannelId, y => y.MapFrom(z => z.snippet.authorChannelId.value));
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


        }
        public async Task<CommentModel> PostNewCommentThread(string videoID, string text)
        {
            var response = await User.Context.Comments.PostNewCommentThread(videoID, text);
            CommentModel model = Utility.Mapper.Map<PostNewCommentThreadResponseModel, CommentModel>(response.Data, mapping =>
            {
                mapping.ForMember(x => x.AuthorChannelId, y => y.MapFrom(z => z.snippet.channelId))
                .ForMember(x => x.CommentID, y => y.MapFrom(z => z.id))
                .ForMember(x => x.AuthorDisplayName, y => y.MapFrom(z => z.snippet.topLevelComment.snippet.authorDisplayName))
                .ForMember(x => x.AuthorProfileImageUrl, y => y.MapFrom(z => z.snippet.topLevelComment.snippet.authorProfileImageUrl))
                .ForMember(x => x.CanRate, y => y.MapFrom(z => z.snippet.topLevelComment.snippet.canRate))
                .ForMember(x => x.ViewerRatingString, y => y.MapFrom(z => z.snippet.topLevelComment.snippet.viewerRating))
                .ForMember(x => x.LikeCount, y => y.MapFrom(z => z.snippet.topLevelComment.snippet.likeCount))
                .ForMember(x => x.TextDisplay, y => y.MapFrom(z => z.snippet.topLevelComment.snippet.textDisplay))
                .ForMember(x => x.TextOriginal, y => y.MapFrom(z => z.snippet.topLevelComment.snippet.textOriginal))
                .ForMember(x => x.PublishedAt, y => y.MapFrom(z => z.snippet.topLevelComment.snippet.publishedAt))
         .ForMember(x => x.AuthorChannelId, y => y.MapFrom(z => z.snippet.topLevelComment.snippet.authorChannelId.value));
            });

            return model;
        }
        public async Task<CommentModel> PostCommentReply(string commentID, string text)
        {
            string _commentID = commentID.Split('.')[0];
            var response = await User.Context.Comments.PostCommentReply(_commentID, text);
            CommentModel model = Utility.Mapper.Map<PostCommentReplyResponseModel, CommentModel>(response.Data, mapping =>
            {
                mapping.ForMember(x => x.CommentID, y => y.MapFrom(z => z.id))
               .ForMember(x => x.AuthorDisplayName, y => y.MapFrom(z => z.snippet.authorDisplayName))
               .ForMember(x => x.AuthorProfileImageUrl, y => y.MapFrom(z => z.snippet.authorProfileImageUrl))
               .ForMember(x => x.CanRate, y => y.MapFrom(z => z.snippet.canRate))
               .ForMember(x => x.ViewerRatingString, y => y.MapFrom(z => z.snippet.viewerRating))
               .ForMember(x => x.LikeCount, y => y.MapFrom(z => z.snippet.likeCount))
               .ForMember(x => x.TextDisplay, y => y.MapFrom(z => z.snippet.textDisplay))
               .ForMember(x => x.TextOriginal, y => y.MapFrom(z => z.snippet.textOriginal))
               .ForMember(x => x.PublishedAt, y => y.MapFrom(z => z.snippet.publishedAt))
               .ForMember(x => x.ParentId, y => y.MapFrom(z => z.snippet.parentId))
               .ForMember(x => x.AuthorChannelId, y => y.MapFrom(z => z.snippet.authorChannelId.value));

            });

            return model;
        }

        public async Task<CommentModel> EditComment(string videoID, string text)
        {
            var response = await User.Context.Comments.EditComment(videoID, text);
            CommentModel model = Utility.Mapper.Map<EditCommentResponseModel, CommentModel>(response.Data, mapping =>
            {
                mapping.ForMember(x => x.AuthorChannelId, y => y.MapFrom(z => z.snippet.channelId))
                .ForMember(x => x.CommentID, y => y.MapFrom(z => z.id))
                .ForMember(x => x.AuthorDisplayName, y => y.MapFrom(z => z.snippet.authorDisplayName))
                .ForMember(x => x.AuthorProfileImageUrl, y => y.MapFrom(z => z.snippet.authorProfileImageUrl))
                .ForMember(x => x.CanRate, y => y.MapFrom(z => z.snippet.canRate))
                .ForMember(x => x.ViewerRatingString, y => y.MapFrom(z => z.snippet.viewerRating))
                .ForMember(x => x.LikeCount, y => y.MapFrom(z => z.snippet.likeCount))
                .ForMember(x => x.TextDisplay, y => y.MapFrom(z => z.snippet.textDisplay))
                .ForMember(x => x.TextOriginal, y => y.MapFrom(z => z.snippet.textOriginal))
                
                .ForMember(x => x.PublishedAt, y => y.MapFrom(z => z.snippet.publishedAt))

         //.ForMember(x => x.commentSegment, y => y.MapFrom(z => SegmentTextByUrls(z.snippet.textDisplay)))
         .ForMember(x => x.AuthorChannelId, y => y.MapFrom(z => z.snippet.authorChannelId.value));
            });
            return model;
        }
    }
}
