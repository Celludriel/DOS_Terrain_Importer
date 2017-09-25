namespace DosTerrainImporter
{
    partial class Dos2GrayScaleUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GrayProgressBar = new System.Windows.Forms.ProgressBar();
            this.GrayCancelButton = new System.Windows.Forms.Button();
            this.GrayMaxHeightLabel = new System.Windows.Forms.Label();
            this.grayMinHeightLabel = new System.Windows.Forms.Label();
            this.GrayBitmapFileLabel = new System.Windows.Forms.Label();
            this.GrayDosFileLabel = new System.Windows.Forms.Label();
            this.GrayGenerate = new System.Windows.Forms.Button();
            this.GrayBitmapBrowse = new System.Windows.Forms.Button();
            this.GrayDosBrowse = new System.Windows.Forms.Button();
            this.grayMaxHeightTextBox = new System.Windows.Forms.TextBox();
            this.grayMinHeightTextBox = new System.Windows.Forms.TextBox();
            this.grayBitmapTextBox = new System.Windows.Forms.TextBox();
            this.grayDosTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // GrayProgressBar
            // 
            this.GrayProgressBar.Location = new System.Drawing.Point(11, 127);
            this.GrayProgressBar.Name = "GrayProgressBar";
            this.GrayProgressBar.Size = new System.Drawing.Size(603, 23);
            this.GrayProgressBar.TabIndex = 25;
            // 
            // GrayCancelButton
            // 
            this.GrayCancelButton.Location = new System.Drawing.Point(458, 98);
            this.GrayCancelButton.Name = "GrayCancelButton";
            this.GrayCancelButton.Size = new System.Drawing.Size(75, 23);
            this.GrayCancelButton.TabIndex = 24;
            this.GrayCancelButton.Text = "Cancel";
            this.GrayCancelButton.UseVisualStyleBackColor = true;
            // 
            // GrayMaxHeightLabel
            // 
            this.GrayMaxHeightLabel.AutoSize = true;
            this.GrayMaxHeightLabel.Location = new System.Drawing.Point(366, 75);
            this.GrayMaxHeightLabel.Name = "GrayMaxHeightLabel";
            this.GrayMaxHeightLabel.Size = new System.Drawing.Size(61, 13);
            this.GrayMaxHeightLabel.TabIndex = 23;
            this.GrayMaxHeightLabel.Text = "Max Height";
            // 
            // grayMinHeightLabel
            // 
            this.grayMinHeightLabel.AutoSize = true;
            this.grayMinHeightLabel.Location = new System.Drawing.Point(43, 75);
            this.grayMinHeightLabel.Name = "grayMinHeightLabel";
            this.grayMinHeightLabel.Size = new System.Drawing.Size(58, 13);
            this.grayMinHeightLabel.TabIndex = 22;
            this.grayMinHeightLabel.Text = "Min Height";
            // 
            // GrayBitmapFileLabel
            // 
            this.GrayBitmapFileLabel.AutoSize = true;
            this.GrayBitmapFileLabel.Location = new System.Drawing.Point(43, 48);
            this.GrayBitmapFileLabel.Name = "GrayBitmapFileLabel";
            this.GrayBitmapFileLabel.Size = new System.Drawing.Size(58, 13);
            this.GrayBitmapFileLabel.TabIndex = 21;
            this.GrayBitmapFileLabel.Text = "Bitmap File";
            // 
            // GrayDosFileLabel
            // 
            this.GrayDosFileLabel.AutoSize = true;
            this.GrayDosFileLabel.Location = new System.Drawing.Point(5, 19);
            this.GrayDosFileLabel.Name = "GrayDosFileLabel";
            this.GrayDosFileLabel.Size = new System.Drawing.Size(91, 13);
            this.GrayDosFileLabel.TabIndex = 20;
            this.GrayDosFileLabel.Text = "Divinity Patch File";
            // 
            // GrayGenerate
            // 
            this.GrayGenerate.Location = new System.Drawing.Point(539, 98);
            this.GrayGenerate.Name = "GrayGenerate";
            this.GrayGenerate.Size = new System.Drawing.Size(75, 23);
            this.GrayGenerate.TabIndex = 19;
            this.GrayGenerate.Text = "Generate";
            this.GrayGenerate.UseVisualStyleBackColor = true;
            this.GrayGenerate.Click += new System.EventHandler(this.GrayGenerate_Click);
            // 
            // GrayBitmapBrowse
            // 
            this.GrayBitmapBrowse.Location = new System.Drawing.Point(539, 44);
            this.GrayBitmapBrowse.Name = "GrayBitmapBrowse";
            this.GrayBitmapBrowse.Size = new System.Drawing.Size(75, 23);
            this.GrayBitmapBrowse.TabIndex = 18;
            this.GrayBitmapBrowse.Text = "...";
            this.GrayBitmapBrowse.UseVisualStyleBackColor = true;
            this.GrayBitmapBrowse.Click += new System.EventHandler(this.GrayBitmapBrowse_Click);
            // 
            // GrayDosBrowse
            // 
            this.GrayDosBrowse.Location = new System.Drawing.Point(539, 14);
            this.GrayDosBrowse.Name = "GrayDosBrowse";
            this.GrayDosBrowse.Size = new System.Drawing.Size(75, 23);
            this.GrayDosBrowse.TabIndex = 17;
            this.GrayDosBrowse.Text = "...";
            this.GrayDosBrowse.UseVisualStyleBackColor = true;
            this.GrayDosBrowse.Click += new System.EventHandler(this.GrayDosBrowse_Click);
            // 
            // grayMaxHeightTextBox
            // 
            this.grayMaxHeightTextBox.Location = new System.Drawing.Point(433, 72);
            this.grayMaxHeightTextBox.Name = "grayMaxHeightTextBox";
            this.grayMaxHeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.grayMaxHeightTextBox.TabIndex = 16;
            this.grayMaxHeightTextBox.Text = "20";
            // 
            // grayMinHeightTextBox
            // 
            this.grayMinHeightTextBox.Location = new System.Drawing.Point(107, 72);
            this.grayMinHeightTextBox.Name = "grayMinHeightTextBox";
            this.grayMinHeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.grayMinHeightTextBox.TabIndex = 15;
            this.grayMinHeightTextBox.Text = "-1";
            // 
            // grayBitmapTextBox
            // 
            this.grayBitmapTextBox.Location = new System.Drawing.Point(107, 46);
            this.grayBitmapTextBox.Name = "grayBitmapTextBox";
            this.grayBitmapTextBox.ReadOnly = true;
            this.grayBitmapTextBox.Size = new System.Drawing.Size(426, 20);
            this.grayBitmapTextBox.TabIndex = 14;
            // 
            // grayDosTextBox
            // 
            this.grayDosTextBox.Location = new System.Drawing.Point(107, 16);
            this.grayDosTextBox.Name = "grayDosTextBox";
            this.grayDosTextBox.ReadOnly = true;
            this.grayDosTextBox.Size = new System.Drawing.Size(426, 20);
            this.grayDosTextBox.TabIndex = 13;
            // 
            // Dos2GrayScaleUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GrayProgressBar);
            this.Controls.Add(this.GrayCancelButton);
            this.Controls.Add(this.GrayMaxHeightLabel);
            this.Controls.Add(this.grayMinHeightLabel);
            this.Controls.Add(this.GrayBitmapFileLabel);
            this.Controls.Add(this.GrayDosFileLabel);
            this.Controls.Add(this.GrayGenerate);
            this.Controls.Add(this.GrayBitmapBrowse);
            this.Controls.Add(this.GrayDosBrowse);
            this.Controls.Add(this.grayMaxHeightTextBox);
            this.Controls.Add(this.grayMinHeightTextBox);
            this.Controls.Add(this.grayBitmapTextBox);
            this.Controls.Add(this.grayDosTextBox);
            this.Name = "Dos2GrayScaleUserControl";
            this.Size = new System.Drawing.Size(618, 164);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar GrayProgressBar;
        private System.Windows.Forms.Button GrayCancelButton;
        private System.Windows.Forms.Label GrayMaxHeightLabel;
        private System.Windows.Forms.Label grayMinHeightLabel;
        private System.Windows.Forms.Label GrayBitmapFileLabel;
        private System.Windows.Forms.Label GrayDosFileLabel;
        private System.Windows.Forms.Button GrayGenerate;
        private System.Windows.Forms.Button GrayBitmapBrowse;
        private System.Windows.Forms.Button GrayDosBrowse;
        private System.Windows.Forms.TextBox grayMaxHeightTextBox;
        private System.Windows.Forms.TextBox grayMinHeightTextBox;
        private System.Windows.Forms.TextBox grayBitmapTextBox;
        private System.Windows.Forms.TextBox grayDosTextBox;
    }
}
