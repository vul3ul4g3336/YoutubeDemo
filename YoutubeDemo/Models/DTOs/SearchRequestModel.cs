using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeDemo.Models.Enum;

namespace YoutubeDemo.Models
{
    public class SearchRequestModel
    {
        public SearchType type;
        public CategoryType category;
        public string keyword;
        public int maxResults = 50;

    }
}
