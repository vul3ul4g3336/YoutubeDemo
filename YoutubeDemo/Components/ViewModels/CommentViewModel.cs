using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeDemo.Components.ViewModels
{
    public class CommentViewModel
    {
        public ObservableCollection<CommentModel> commentModels { get; set; } = new ObservableCollection<CommentModel>();

        public void RenderComments(List<CommentModel> models)
        {
            commentModels.Clear();
            foreach (var model in models)
            {
               commentModels.Add(model);
            }
        }
    }
}
