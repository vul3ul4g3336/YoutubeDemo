namespace YoutubeDemo.Components
{
    partial class Rating
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
            this.like = new System.Windows.Forms.Label();
            this.dislike = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // like
            // 
            this.like.AutoSize = true;
            this.like.Location = new System.Drawing.Point(96, 102);
            this.like.Name = "like";
            this.like.Size = new System.Drawing.Size(22, 12);
            this.like.TabIndex = 0;
            this.like.Text = "like";
            // 
            // dislike
            // 
            this.dislike.AutoSize = true;
            this.dislike.Location = new System.Drawing.Point(274, 102);
            this.dislike.Name = "dislike";
            this.dislike.Size = new System.Drawing.Size(35, 12);
            this.dislike.TabIndex = 1;
            this.dislike.Text = "dislike";
            // 
            // Rating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dislike);
            this.Controls.Add(this.like);
            this.Name = "Rating";
            this.Size = new System.Drawing.Size(592, 217);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label like;
        private System.Windows.Forms.Label dislike;
    }
}
