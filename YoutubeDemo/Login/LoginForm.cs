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

        private async  void LoginForm_Load(object sender, EventArgs e)
        {
            auth = new Auth();
            if (auth.IsLogin)
            {

                // this.Hide();

                await LoginSuccess();
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            await auth.Login();
            await LoginSuccess();
        }
        private async Task LoginSuccess()
        {
            this.Hide();
            SearchForm searchForm = new SearchForm();
            searchForm.ShowDialog();

            
        }
    }
}
