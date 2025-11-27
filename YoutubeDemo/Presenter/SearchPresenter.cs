using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeAPI;
using YoutubeAPI.Channel;
using YoutubeAPI.Videos.Model;
using YoutubeDemo.Models;
using static YoutubeDemo.Contract.SearchVideoContract;
using System.Xml;
using YoutubeDemo.Models.Enum;
namespace YoutubeDemo.Presenter
{
    public class SearchPresenter : ISearchPresenter
    {
        public event EventHandler<string> ratingEvent;
        private ISearchView searchView;
       
        public SearchPresenter(ISearchView searchView)
        {
            
            this.searchView = searchView;
        }

        public async Task SearchRequest(SearchRequestModel model)
        {
            var task = String.IsNullOrEmpty(model.keyword)
                ? TW_TrendingRequest(model) : SearchKeywordRequest(model);
            var combinedTask = task.ContinueWith(async models =>
            {
                var res = await models;
                var tasks = res.Select(async x =>
                {
                    var rating = await User.Context.Videos.GetVideoRating(x.VideoID);  // 
                    var ratingStr = rating.Data?.items?.FirstOrDefault()?.rating; // null 

                    x.LikeStatus = Enum.TryParse<LikeStatusEnum>(ratingStr, true, out var status)
                        ? status
                        : LikeStatusEnum.none; // 
                });
                await Task.WhenAll(tasks);
                return res;
            }).Unwrap();
            var result = await combinedTask;
            searchView.SearchResponse(result);
        }
        private async Task<List<VideoCardModel>> TW_TrendingRequest(SearchRequestModel model)
        {

            var twTrendingResponseresponse = model.category == Models.Enum.CategoryType.全部 ?
                            await User.Context.Videos.GetVideos("TW", "mostPopular")
                           : await User.Context.Videos.GetVideos(regionCode: "TW", chart: "mostPopular", videoCategoryId: ((int)model.category).ToString());

            List<VideoCardModel> videoCardModels = Utility.Mapper.Map<GetVideosResponseModel.Item, VideoCardModel>
                (twTrendingResponseresponse.Data.items, mapping =>
            {
                mapping.ForMember(x => x.Title, y => y.MapFrom(z => z.snippet.title))
                       .ForMember(x => x.ChannelTitle, y => y.MapFrom(z => z.snippet.channelTitle))
                       .ForMember(x => x.url, y => y.MapFrom(z => z.snippet.thumbnails.medium.url))
                       .ForMember(x => x.VideoID, y => y.MapFrom(z => z.id))
                       .ForMember(x => x.ViewCount, y => y.MapFrom(z => z.statistics.viewCount))
                       .ForMember(x => x.description, y => y.MapFrom(z => z.snippet.description));
            }).ToList();
            return videoCardModels;

        }

        private async Task<List<VideoCardModel>> SearchKeywordRequest(SearchRequestModel model)
        {
            List<VideoCardModel> videoCardModels = new List<VideoCardModel>();
            var searchResponse = await User.Context.Channel.SearchByKeyword(model.keyword, model.type.ToString());
            if (model.type == Models.Enum.SearchType.shorts)
            {
                List<Task<HttpUtility.HttpResponse<VideoDetailModel>>> tasks = searchResponse.Data.items.Select(x => User.Context.Videos.GetVideoDetail(x.id.videoId)).ToList();
                #region
                //var results = await Task.WhenAll(tasks);
                //var probe = results.Select((r, idx) => new
                //{
                //    idx,
                //    HttpOk = r?.IsSuccess,      // 依你的 HttpResponse 型別調整
                //    Count = r?.Data?.items?.Length ?? -1,
                //    Dur = r?.Data?.items?.FirstOrDefault()?.contentDetails?.duration,
                //    // 若你能從封裝物取到 videoId 也列出來
                //}).ToList();

                //// 印出問題條目
                //foreach (var p in probe.Where(p => p.Count <= 0 || string.IsNullOrEmpty(p.Dur)))
                //{
                //    Console.WriteLine($"[{p.idx}] items.Count={p.Count}, duration='{p.Dur}', HttpOk={p.HttpOk}");
                //}
                #endregion 
                List<VideoDetailModel> videoDetailModels = (await Task.WhenAll(tasks))
                    .Where(x =>
                    {
                        if (x.Data.items.Length == 0) return false;
                        var second = XmlConvert.ToTimeSpan(x.Data.items[0].contentDetails.duration).TotalSeconds;
                        return second < 60;
                    })
                    .Select(x => x.Data)
                    .ToList(); //List<model>

                videoCardModels = Utility.Mapper.Map<VideoDetailModel, VideoCardModel>(videoDetailModels, mapping =>
                {
                    mapping.ForMember(x => x.Title, y => y.MapFrom(z => z.items[0].snippet.title))
                           .ForMember(x => x.ChannelTitle, y => y.MapFrom(z => z.items[0].snippet.channelTitle))
                           .ForMember(x => x.url, y => y.MapFrom(z => z.items[0].snippet.thumbnails.medium.url))
                           .ForMember(x => x.description, y => y.MapFrom(z => z.items[0].snippet.description))
                           ;


                }).ToList();//Task.WhenAll(())

            }
            else
            {
                videoCardModels = Utility.Mapper.Map<GetYouTubeSearchModel.Item, VideoCardModel>(searchResponse.Data.items, mapping =>
                                 {
                                     mapping.ForMember(x => x.Title, y => y.MapFrom(z => z.snippet.title))
                                            .ForMember(x => x.ChannelTitle, y => y.MapFrom(z => z.snippet.channelTitle))
                                            .ForMember(x => x.url, y => y.MapFrom(z => z.snippet.thumbnails.medium.url))
                                            .ForMember(x => x.VideoID, y => y.MapFrom(z => z.id.videoId))
                                            .ForMember(x => x.description, y => y.MapFrom(z => z.snippet.description));
                                 }).ToList();
            }
            return videoCardModels;

        }



    }
}
