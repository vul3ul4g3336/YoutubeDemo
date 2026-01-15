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
using YoutubeDemo.Pages;

namespace YoutubeDemo.Forms
{
    public partial class PlayListDialog : Form
    {
        PlayListForm form;
        ElementHost elementHost = new ElementHost();
        public PlayListDialog()
        {
            InitializeComponent();
            form = new PlayListForm();
            elementHost.Dock = DockStyle.Fill;
            elementHost.Child = form;
            this.Controls.Add(elementHost);
        }
    }
}
