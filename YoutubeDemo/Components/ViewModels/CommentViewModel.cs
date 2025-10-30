using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace YoutubeDemo.Components.ViewModels
{

    public class CommentViewModel
    {
        List<CommentModel> models;
        public CommentViewModel(List<CommentModel> models)
        {

           
            RenderComments(this.models);
        }
        
        public void RenderComments(List<CommentModel> models)
        {

        }
    }
}
