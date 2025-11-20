using GoogleOauthConsole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeAPI;
using YoutubeAPI.Auth;

namespace YoutubeDemo.Login
{
    public partial class LoginForm : Form
    {
        private Auth auth;
        public LoginForm()
        {
            InitializeComponent();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            auth = new Auth();
            if (auth.IsLogin)
            {

                LoginSuccess();
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            YoutubeContext context = await auth.Login();
            LoginSuccess();
        }
        private void LoginSuccess()
        {
            this.Hide();
            SearchForm searchForm = new SearchForm();
            searchForm.ShowDialog();
        }
    }
}
