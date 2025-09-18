using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        .ForMember(x => x.replies, y => y.MapFrom(z => z.snippet.totalReplyCount > 0 ? DataTransform(z.replies) : null));
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
        .ForMember(x => x.PublishedAt, y => y.MapFrom(z => z.snippet.publishedAt));
            }).ToArray();
            return models;
        }
    }
}
