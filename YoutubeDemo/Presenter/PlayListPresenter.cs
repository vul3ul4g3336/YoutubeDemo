using HttpUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using YoutubeAPI.PlayLists.Model;
using YoutubeAPI.Videos.Model;
using YoutubeDemo.Components.PlayListCard;
using YoutubeDemo.Components.ViewModels;
using YoutubeDemo.Models.DTOs;
using static YoutubeDemo.Contract.PlayListContract;

namespace YoutubeDemo.Presenter
{
    public class PlayListPresenter : IPlayListPresenter 
    {

        public PlayListPresenter()
        {

        }

        public async Task<bool> AddVideoToPlaylist(string videoID, string playListID)
        {
            var response = await User.Context.PlayLists.AddVideoToPlaylist(videoID, playListID);
            return response.IsSuccess;
        }

        public async Task GetPlayListRequest()
        {
            var response = await User.Context.PlayLists.GetAllPlaylists("50");

            List<PlayListModel> models = Utility.Mapper.Map<VideoListResponseModel.Item, PlayListModel>(response.Data.items, mapping =>
            {
                mapping.ForMember(x => x.id, y => y.MapFrom(z => z.id))
                       .ForMember(x => x.title, y => y.MapFrom(z => z.snippet.title))
                       .ForMember(x => x.thumbnails, y => y.MapFrom(z => z.snippet.thumbnails.high.url));

            }).ToList();
            User.playListModels = models;
        }
        public async Task<List<PlayListVideoModel>> GetMyPlaylistVideos(string playListID)
        {
            var response = await User.Context.PlayLists.GetMyPlaylistVideos(playListID);

            List<PlayListVideoModel> models = Utility.Mapper.Map<GetMyPlaylistVideosResponse.Item, PlayListVideoModel>(response.Data.items, mapping =>
            {
                mapping.ForMember(x => x.videoID, y => y.MapFrom(z => z.snippet.resourceId.videoId))
                       .ForMember(x => x.title, y => y.MapFrom(z => z.snippet.title))
                       .ForMember(x => x.thumbnails, y => y.MapFrom(z => z.snippet.thumbnails.high.url));

            }).ToList();
            return models;
        }
        public async Task<CardViewModel> GetVideoByID(string videoID)
        {
            var response = await User.Context.Videos.GetVideoByID(videoID);
            CardViewModel model = Utility.Mapper.Map<GetVideoByID_Model.Item, CardViewModel>(response.Data.items[0], mapping =>
            {
                mapping.ForMember(x => x.Title, y => y.MapFrom(z => z.snippet.title))
                       .ForMember(x => x.ChannelTitle, y => y.MapFrom(z => z.snippet.channelTitle))
                       .ForMember(x => x.ThumbnailUrl, y => y.MapFrom(z => z.snippet.thumbnails.medium.url))
                       .ForMember(x => x.VideoID, y => y.MapFrom(z => z.id))
                       .ForMember(x => x.ViewCount, y => y.MapFrom(z => z.statistics.viewCount))
                       .ForMember(x => x.description, y => y.MapFrom(z => z.snippet.description));
            });
            var rating = await User.Context.Videos.GetVideoRating(videoID);  // 
            var ratingStr = rating.Data?.items?.FirstOrDefault()?.rating; // null 

            model.LikeStatus = Enum.TryParse<LikeStatusEnum>(ratingStr, true, out var status)
                ? status
                : LikeStatusEnum.none;
            return model;
        }
    }
}
