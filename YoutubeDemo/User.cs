using CredentialManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeAPI;
using Newtonsoft.Json;
namespace YoutubeDemo
{
    public static class User
    {
        public static YoutubeContext Context { get; set; }
        public static string ID;
        public static string Title;
        public static string CustomUrl;
        public static string ThumbNails;
        private static ClientModel model;
        static string filePath = @"C:\Users\TUF\Documents\.youtube\credential.json";
        public static async Task Setup()
        {
            
            string jsonContent = File.ReadAllText(filePath);
            model = JsonConvert.DeserializeObject<ClientModel>(jsonContent);
            Context = new YoutubeContext(model.AccessToken);
            Context.CreateRequest();
            var response = await Context.Channel.GetUserInfo();
            var profileModel = response.Data;

            model.UserID = profileModel.items[0].id;
            model.NickName = profileModel.items[0].snippet.title;
            model.CustomUrl = profileModel.items[0].snippet.customUrl;
            model.ThumbNails = profileModel.items[0].snippet.thumbnails.@default.url;

            ID = model.UserID;
            Title = model.NickName;
            CustomUrl = model.CustomUrl;
            ThumbNails = model.ThumbNails;
            string outputJson = JsonConvert.SerializeObject(model, Formatting.Indented);
            File.WriteAllText(filePath, outputJson);
        }
        public static void SignOut()
        {
            model.AccessToken = string.Empty;
            model.RefreshToken = string.Empty;
            model.ExpireTime = string.Empty;
            model.UserID = string.Empty;
            model.NickName = string.Empty;
            model.CustomUrl = string.Empty;
            model.ThumbNails = string.Empty;
            string outputJson = JsonConvert.SerializeObject(model, Formatting.Indented);
            File.WriteAllText(filePath, outputJson);
        }
    }
}
