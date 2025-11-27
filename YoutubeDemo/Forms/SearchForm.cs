using AutoMapper;
using CredentialManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using YoutubeAPI;
using YoutubeAPI.Channel;
using YoutubeAPI.Videos;
using YoutubeAPI.Videos.Model;
using YoutubeDemo.Components;
using YoutubeDemo.Components.ViewModels;
using YoutubeDemo.Models;
using YoutubeDemo.Models.Enum;
using YoutubeDemo.Presenter;

using static YoutubeDemo.Contract.SearchVideoContract;

namespace YoutubeDemo
{
    public partial class SearchForm : Form, ISearchView
    {

        private ISearchPresenter searchPresenter;
        private Paginations paginations;
        SearchRequestModel requestModel = new SearchRequestModel();
        PaginationsViewModel viewModel = new PaginationsViewModel();
        List<CardViewModel> videos;
        public SearchForm()
        {
            InitializeComponent();

            this.Width = 1400;
            this.videoCardContainer.Width = 1300;
            paginations = new Paginations();

            paginations.PageChanged += Paginations_PageChanged;
            comboBox1.DataSource = Enum.GetValues(typeof(SearchType));
            requestModel.category = Models.Enum.CategoryType.全部;
           
            elementHost1.Child = paginations;/*show();*/
        }

        private void Paginations_PageChanged(object sender, int e) // 2/3/4/5/6 n頁
        {
            videoCardContainer.Controls.Clear();
            for (int i = 0; i < paginations.PageSize; i++)
            {
                var infoPanel = new Card(videos[((e - 1) * paginations.PageSize) + i]);
                //infoPanel.ratingClick += RatingClick;
                ElementHost elementHost = new ElementHost();
                elementHost.Width = 430;
                elementHost.Height = 380;
                elementHost.Child = infoPanel;
                videoCardContainer.Controls.Add(elementHost);
            }
        }
        public void SearchResponse(List<VideoCardModel> videos)
        {

            this.videos = Utility.Mapper.Map<VideoCardModel, CardViewModel>(videos, cfg =>
            {
                cfg.ForMember(x => x.ThumbnailUrl, y => y.MapFrom(z => z.url));
            }).ToList();

            videoCardContainer.Controls.Clear();
            paginations.Total = this.videos.Count;

        }


        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            // 1300 => 4
            // 1000~1300 => 3
            // 700~1000 => 2
            // 700以下 => 1
            var panel = (FlowLayoutPanel)sender;
            int width = panel.Width;

            int column = width >= 1300 ? 4 : width >= 1250 ? 3 : width >= 900 ? 2 : 1;
            width = width / column - 5;
            foreach (ElementHost card in panel.Controls)
            {
                card.Size = new Size(width, 380);
            }

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            requestModel.category = Models.Enum.CategoryType.全部;
            requestModel.type = (SearchType)comboBox1.SelectedIndex;
            requestModel.keyword = search.Text;
            await searchPresenter.SearchRequest(requestModel);
        }

        private async void CategoryChange(object sender, EventArgs e)
        {
            #region 顏色
            var secondaryForeColor = System.Drawing.ColorTranslator.FromHtml("#AAAAAA");
            var controlForeColor = System.Drawing.ColorTranslator.FromHtml("#F1F1F1");

            // 將所有 RadioButton 的顏色先重設為未選中的灰色
            foreach (var control in this.panel1.Controls)
            {
                if (control is RadioButton rb)
                {
                    rb.ForeColor = secondaryForeColor;
                }
            }

            // 將當前被選中的 RadioButton 的文字顏色設為高亮的白色
            if (sender is RadioButton checkedRadioButton && checkedRadioButton.Checked)
            {
                checkedRadioButton.ForeColor = controlForeColor;
            }
            #endregion
            RadioButton random = sender as RadioButton;

            if (random == null || !random.Checked) return;
            requestModel.keyword = string.Empty;
            requestModel.type = SearchType.video;
            requestModel.category = (CategoryType)Enum.Parse(typeof(CategoryType), random.Text);
            await searchPresenter.SearchRequest(requestModel);

        }

        private  async void SearchForm_Load(object sender, EventArgs e)
        {
            //var cred = CredentialManager.Load<GoogleCredentialModel>("MyYoutubeApp_Token");
            //if (cred != null) button2.Text = "登出";
            await User.Setup();

             searchPresenter = new SearchPresenter(this);
            await searchPresenter.SearchRequest(requestModel);


            // ==========================================================
            // 步驟 1: 定義統一的顏色主題 (已更新背景色)
            // ==========================================================

            // 【關鍵修改】將主背景色從 #0F0F0F 改為 #2C2C2C
            var themeBackColor = System.Drawing.ColorTranslator.FromHtml("#2C2C2C");

            var controlBackColor = System.Drawing.ColorTranslator.FromHtml("#1A1A1A"); // 控制項背景色 (保持不變)
            var controlForeColor = System.Drawing.ColorTranslator.FromHtml("#F1F1F1"); // 主要文字顏色
            var borderColor = System.Drawing.ColorTranslator.FromHtml("#2A2A2A");      // 邊框顏色
            var accentColor = System.Drawing.ColorTranslator.FromHtml("#4A9EFF");      // 強調色 (藍色)
            var accentHoverColor = System.Drawing.ColorTranslator.FromHtml("#6A96C2"); // 強調色 (滑鼠懸浮)
            var secondaryForeColor = System.Drawing.ColorTranslator.FromHtml("#AAAAAA"); // 次要文字顏色

            // ==========================================================
            // 步驟 2: 設定 Form 本身與 ElementHost 的背景
            // ==========================================================
            this.BackColor = themeBackColor;
            this.elementHost1.BackColor = themeBackColor;

            // ==========================================================
            // 步驟 3: 風格化各個控制項 (此部分邏輯不變，會自動套用新背景色)
            // ==========================================================

            // --- 搜尋按鈕 (button1) ---
            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.BackColor = accentColor;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseOverBackColor = accentHoverColor;
            this.button1.Font = new System.Drawing.Font(this.Font.FontFamily, 9F, System.Drawing.FontStyle.Bold);

            // --- 搜尋文字方塊 (search) ---
            this.search.BackColor = controlBackColor;
            this.search.ForeColor = controlForeColor;
            this.search.BorderStyle = BorderStyle.FixedSingle;

            // --- 下拉選單 (comboBox1) ---
            this.comboBox1.BackColor = controlBackColor;
            this.comboBox1.ForeColor = controlForeColor;
            this.comboBox1.FlatStyle = FlatStyle.Flat;

            // --- 放置 RadioButton 的容器 (panel1) ---
            this.panel1.BackColor = themeBackColor;

            // --- 分類選項 (所有 RadioButton) ---
            foreach (var control in this.panel1.Controls)
            {
                if (control is RadioButton rb)
                {
                    rb.ForeColor = secondaryForeColor;
                }
            }

            // --- 卡片容器 (videoCardContainer) ---
            this.videoCardContainer.BackColor = themeBackColor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User.SignOut();
            this.Close();
            
        }
    }
}
