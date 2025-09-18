namespace YoutubeDemo.Components
{
    partial class VideoCard
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.coverImg = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblChannel = new System.Windows.Forms.Label();
            this.lblViews = new System.Windows.Forms.Label();
            this.like = new System.Windows.Forms.Label();
            this.dislike = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.coverImg)).BeginInit();
            this.SuspendLayout();
            // 
            // coverImg
            // 
            this.coverImg.Dock = System.Windows.Forms.DockStyle.Top;
            this.coverImg.Location = new System.Drawing.Point(0, 0);
            this.coverImg.Name = "coverImg";
            this.coverImg.Size = new System.Drawing.Size(370, 214);
            this.coverImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coverImg.TabIndex = 4;
            this.coverImg.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoEllipsis = true;
            this.lblTitle.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.lblTitle.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(3, 217);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(370, 30);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "這Roblox玩家花了20萬新台幣課金！現在流落街頭😨 我請他來我家住24小時！ (組電腦初體驗＋玩21點卡牌)【有感筆電】";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChannel
            // 
            this.lblChannel.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.lblChannel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.lblChannel.Location = new System.Drawing.Point(0, 247);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size(370, 30);
            this.lblChannel.TabIndex = 6;
            this.lblChannel.Text = "JOLIN 蔡依林";
            this.lblChannel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblViews
            // 
            this.lblViews.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.lblViews.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.lblViews.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblViews.Location = new System.Drawing.Point(3, 271);
            this.lblViews.Name = "lblViews";
            this.lblViews.Size = new System.Drawing.Size(235, 30);
            this.lblViews.TabIndex = 7;
            this.lblViews.Text = "觀看次數：1500996";
            this.lblViews.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // like
            // 
            this.like.Location = new System.Drawing.Point(194, 277);
            this.like.Name = "like";
            this.like.Size = new System.Drawing.Size(34, 23);
            this.like.TabIndex = 8;
            this.like.Text = "label1";
            // 
            // dislike
            // 
            this.dislike.Location = new System.Drawing.Point(244, 277);
            this.dislike.Name = "dislike";
            this.dislike.Size = new System.Drawing.Size(60, 23);
            this.dislike.TabIndex = 9;
            this.dislike.Text = "label2";
            // 
            // VideoCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.dislike);
            this.Controls.Add(this.like);
            this.Controls.Add(this.coverImg);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblChannel);
            this.Controls.Add(this.lblViews);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "VideoCard";
            this.Size = new System.Drawing.Size(370, 310);
            ((System.ComponentModel.ISupportInitialize)(this.coverImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox coverImg;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblChannel;
        private System.Windows.Forms.Label lblViews;
        private System.Windows.Forms.Label like;
        private System.Windows.Forms.Label dislike;
    }
}
