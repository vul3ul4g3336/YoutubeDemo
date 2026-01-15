using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using YoutubeDemo.Components.UploadVideo;

namespace YoutubeDemo.Forms
{
    public partial class UploadForm : Form
    {
        public UploadForm(string filePath)
        {
            InitializeComponent();
            ElementHost elementHost = new ElementHost();
            UploadVideoCard card = new UploadVideoCard(filePath);
            elementHost.Child = card;
            elementHost.Dock = DockStyle.Fill;
            card.viewModel.eventHandler += OnUploadSuccess; ;
            this.Controls.Add(elementHost);
        }

        private void OnUploadSuccess(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
