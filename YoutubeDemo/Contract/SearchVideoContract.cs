using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeDemo.Models;

namespace YoutubeDemo.Contract
{
    public  class SearchVideoContract
    {
        public interface ISearchView
        {
            void SearchResponse(List<VideoCardModel> videos);
            
        }

        public interface ISearchPresenter
        {
            Task SearchRequest(SearchRequestModel model);
        }

    }
}
