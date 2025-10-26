﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeDemo.Components;

namespace YoutubeDemo.Contract
{
    public class CommentContract
    {
        public interface ICommentPresenter
        {
            Task Comment_Request(string videoID);
        }
        public interface ICommentView
        {
            void Comment_Response(List<CommentModel> models);
        }
    }
}
