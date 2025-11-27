using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeAPI.Auth;
using YoutubeDemo.Forms;
using YoutubeDemo.Login;

namespace YoutubeDemo
{
    internal static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Auth auth = new Auth();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form form = auth.IsLogin ? new SearchForm() : new LoginForm();

            Application.Run(form);
        }
    }
}
