using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeDemo.Components.PaginationComponent;
using static YoutubeDemo.Components.PaginationComponent.PaginationContract;

namespace YoutubeDemo.Components
{
    public partial class Pagination : UserControl, IPaginationView
    {
        public int Total
        {
            get => paginationPresenter.Total;
            set => paginationPresenter.Total = value;
        }
        public int PageSize
        {
            get => paginationPresenter.PageSize;
            set => paginationPresenter.PageSize = value;
        }
        int PageJumpSize
        {
            get => paginationPresenter.jumpPage;
            set => paginationPresenter.jumpPage = value;
        }
        int pageIndex = 1;
        private IPaginationPresenter paginationPresenter;

        public event EventHandler<int> OnChangePage;

        public Pagination()
        {
            InitializeComponent();
            paginationPresenter = new PaginationPresenter(this);
            flowLayoutPanel1.AutoSize = true;
            this.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;

        }
        private void CreateDirecLabel(string context, ChangePageType type)
        {
            Label label = new Label();
            label.Text = context.ToString();
            label.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            label.AutoSize = true;
            label.Margin = new Padding(0, 0, 10, 0);
            flowLayoutPanel1.Controls.Add(label);
            label.Click += MovePage;
            label.Tag = type;
        }

        private void MovePage(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            paginationPresenter.ChangePage((ChangePageType)lbl.Tag);
           
        }


        private void CreateIndexLabel(string context)
        {
            Label label = new Label();
            label.Text = context.ToString();
            label.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            label.AutoSize = true;
            label.Margin = new Padding(0, 0, 10, 0);
            flowLayoutPanel1.Controls.Add(label);
            label.Click += ChoosePage;

        }
        private void ChoosePage(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            paginationPresenter.ChoosePage(int.Parse(label.Text));
        }

        public void SetActivePageNumber(int number)
        {
            var pageNumbers = flowLayoutPanel1.Controls.OfType<Label>().ToList();
            pageNumbers.ForEach(i => i.ForeColor = Color.Black);
            pageNumbers.First(i => i.Text == number.ToString()).ForeColor = Color.Red;
            Console.WriteLine(pageIndex);
            OnChangePage.Invoke(this, number);
        }

        public void RenderPages(List<int> pages)
        {
            flowLayoutPanel1.Controls.Clear();
            CreateDirecLabel("<<", ChangePageType.JumpPrevious);
            CreateDirecLabel("<", ChangePageType.Previous);
            for (int i = 0; i < pages.Count; i++)
            {
                CreateIndexLabel(pages[i].ToString());

            }
            CreateDirecLabel(">", ChangePageType.Next);
            CreateDirecLabel(">>", ChangePageType.JumpNext);
        }
    }
}
