namespace ImageExplorer
{
    partial class PHashCompare
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
            this.lblImgPath1 = new System.Windows.Forms.Label();
            this.lblImgPath2 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnImg1 = new System.Windows.Forms.Button();
            this.btnImg2 = new System.Windows.Forms.Button();
            this.btnResult = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblImgPath1
            // 
            this.lblImgPath1.AutoSize = true;
            this.lblImgPath1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblImgPath1.Location = new System.Drawing.Point(7, 184);
            this.lblImgPath1.Name = "lblImgPath1";
            this.lblImgPath1.Size = new System.Drawing.Size(78, 15);
            this.lblImgPath1.TabIndex = 0;
            this.lblImgPath1.Text = "Image1 Path";
            // 
            // lblImgPath2
            // 
            this.lblImgPath2.AutoSize = true;
            this.lblImgPath2.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblImgPath2.Location = new System.Drawing.Point(7, 234);
            this.lblImgPath2.Name = "lblImgPath2";
            this.lblImgPath2.Size = new System.Drawing.Size(78, 15);
            this.lblImgPath2.TabIndex = 1;
            this.lblImgPath2.Text = "Image2 Path";
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblResult.Location = new System.Drawing.Point(320, 318);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(60, 21);
            this.lblResult.TabIndex = 2;
            this.lblResult.Text = "Result";
            // 
            // btnImg1
            // 
            this.btnImg1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImg1.Location = new System.Drawing.Point(512, 167);
            this.btnImg1.Name = "btnImg1";
            this.btnImg1.Size = new System.Drawing.Size(92, 53);
            this.btnImg1.TabIndex = 3;
            this.btnImg1.Text = "Import Image 1";
            this.btnImg1.UseVisualStyleBackColor = true;
            this.btnImg1.Click += new System.EventHandler(this.btnImg1_Click);
            // 
            // btnImg2
            // 
            this.btnImg2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImg2.Location = new System.Drawing.Point(512, 217);
            this.btnImg2.Name = "btnImg2";
            this.btnImg2.Size = new System.Drawing.Size(92, 53);
            this.btnImg2.TabIndex = 4;
            this.btnImg2.Text = "Import Image 2";
            this.btnImg2.UseVisualStyleBackColor = true;
            this.btnImg2.Click += new System.EventHandler(this.btnImg2_Click);
            // 
            // btnResult
            // 
            this.btnResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResult.Location = new System.Drawing.Point(512, 305);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(92, 53);
            this.btnResult.TabIndex = 5;
            this.btnResult.Text = "Result";
            this.btnResult.UseVisualStyleBackColor = true;
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // PHashCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnResult);
            this.Controls.Add(this.btnImg2);
            this.Controls.Add(this.btnImg1);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblImgPath2);
            this.Controls.Add(this.lblImgPath1);
            this.Name = "PHashCompare";
            this.Size = new System.Drawing.Size(607, 361);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblImgPath1;
        private System.Windows.Forms.Label lblImgPath2;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnImg1;
        private System.Windows.Forms.Button btnImg2;
        private System.Windows.Forms.Button btnResult;
    }
}
