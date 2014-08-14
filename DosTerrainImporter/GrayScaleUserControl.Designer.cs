namespace DosTerrainImporter
{
    partial class GrayScaleUserControl
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
            this.grayDosTextBox = new System.Windows.Forms.TextBox();
            this.grayBitmapTextBox = new System.Windows.Forms.TextBox();
            this.grayMinHeightTextBox = new System.Windows.Forms.TextBox();
            this.grayMaxHeightTextBox = new System.Windows.Forms.TextBox();
            this.GrayDosBrowse = new System.Windows.Forms.Button();
            this.GrayBitmapBrowse = new System.Windows.Forms.Button();
            this.GrayGenerate = new System.Windows.Forms.Button();
            this.GrayDosFileLabel = new System.Windows.Forms.Label();
            this.GrayBitmapFileLabel = new System.Windows.Forms.Label();
            this.grayMinHeightLabel = new System.Windows.Forms.Label();
            this.GrayMaxHeightLabel = new System.Windows.Forms.Label();
            this.GrayCancelButton = new System.Windows.Forms.Button();
            this.GrayProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // grayDosTextBox
            // 
            this.grayDosTextBox.Location = new System.Drawing.Point(101, 19);
            this.grayDosTextBox.Name = "grayDosTextBox";
            this.grayDosTextBox.ReadOnly = true;
            this.grayDosTextBox.Size = new System.Drawing.Size(426, 20);
            this.grayDosTextBox.TabIndex = 0;
            // 
            // grayBitmapTextBox
            // 
            this.grayBitmapTextBox.Location = new System.Drawing.Point(101, 48);
            this.grayBitmapTextBox.Name = "grayBitmapTextBox";
            this.grayBitmapTextBox.ReadOnly = true;
            this.grayBitmapTextBox.Size = new System.Drawing.Size(426, 20);
            this.grayBitmapTextBox.TabIndex = 1;
            // 
            // grayMinHeightTextBox
            // 
            this.grayMinHeightTextBox.Location = new System.Drawing.Point(101, 74);
            this.grayMinHeightTextBox.Name = "grayMinHeightTextBox";
            this.grayMinHeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.grayMinHeightTextBox.TabIndex = 2;
            this.grayMinHeightTextBox.Text = "-1";
            // 
            // grayMaxHeightTextBox
            // 
            this.grayMaxHeightTextBox.Location = new System.Drawing.Point(427, 74);
            this.grayMaxHeightTextBox.Name = "grayMaxHeightTextBox";
            this.grayMaxHeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.grayMaxHeightTextBox.TabIndex = 3;
            this.grayMaxHeightTextBox.Text = "20";
            // 
            // GrayDosBrowse
            // 
            this.GrayDosBrowse.Location = new System.Drawing.Point(534, 17);
            this.GrayDosBrowse.Name = "GrayDosBrowse";
            this.GrayDosBrowse.Size = new System.Drawing.Size(75, 23);
            this.GrayDosBrowse.TabIndex = 4;
            this.GrayDosBrowse.Text = "...";
            this.GrayDosBrowse.UseVisualStyleBackColor = true;
            this.GrayDosBrowse.Click += new System.EventHandler(this.GrayDosBrowse_Click);
            // 
            // GrayBitmapBrowse
            // 
            this.GrayBitmapBrowse.Location = new System.Drawing.Point(534, 46);
            this.GrayBitmapBrowse.Name = "GrayBitmapBrowse";
            this.GrayBitmapBrowse.Size = new System.Drawing.Size(75, 23);
            this.GrayBitmapBrowse.TabIndex = 5;
            this.GrayBitmapBrowse.Text = "...";
            this.GrayBitmapBrowse.UseVisualStyleBackColor = true;
            this.GrayBitmapBrowse.Click += new System.EventHandler(this.GrayBitmapBrowse_Click);
            // 
            // GrayGenerate
            // 
            this.GrayGenerate.Location = new System.Drawing.Point(534, 100);
            this.GrayGenerate.Name = "GrayGenerate";
            this.GrayGenerate.Size = new System.Drawing.Size(75, 23);
            this.GrayGenerate.TabIndex = 6;
            this.GrayGenerate.Text = "Generate";
            this.GrayGenerate.UseVisualStyleBackColor = true;
            this.GrayGenerate.Click += new System.EventHandler(this.GrayGenerate_Click);
            // 
            // GrayDosFileLabel
            // 
            this.GrayDosFileLabel.AutoSize = true;
            this.GrayDosFileLabel.Location = new System.Drawing.Point(3, 22);
            this.GrayDosFileLabel.Name = "GrayDosFileLabel";
            this.GrayDosFileLabel.Size = new System.Drawing.Size(96, 13);
            this.GrayDosFileLabel.TabIndex = 7;
            this.GrayDosFileLabel.Text = "Divinity Terrain File";
            // 
            // GrayBitmapFileLabel
            // 
            this.GrayBitmapFileLabel.AutoSize = true;
            this.GrayBitmapFileLabel.Location = new System.Drawing.Point(37, 51);
            this.GrayBitmapFileLabel.Name = "GrayBitmapFileLabel";
            this.GrayBitmapFileLabel.Size = new System.Drawing.Size(58, 13);
            this.GrayBitmapFileLabel.TabIndex = 8;
            this.GrayBitmapFileLabel.Text = "Bitmap File";
            // 
            // grayMinHeightLabel
            // 
            this.grayMinHeightLabel.AutoSize = true;
            this.grayMinHeightLabel.Location = new System.Drawing.Point(41, 77);
            this.grayMinHeightLabel.Name = "grayMinHeightLabel";
            this.grayMinHeightLabel.Size = new System.Drawing.Size(58, 13);
            this.grayMinHeightLabel.TabIndex = 9;
            this.grayMinHeightLabel.Text = "Min Height";
            // 
            // GrayMaxHeightLabel
            // 
            this.GrayMaxHeightLabel.AutoSize = true;
            this.GrayMaxHeightLabel.Location = new System.Drawing.Point(360, 77);
            this.GrayMaxHeightLabel.Name = "GrayMaxHeightLabel";
            this.GrayMaxHeightLabel.Size = new System.Drawing.Size(61, 13);
            this.GrayMaxHeightLabel.TabIndex = 10;
            this.GrayMaxHeightLabel.Text = "Max Height";
            // 
            // GrayCancelButton
            // 
            this.GrayCancelButton.Location = new System.Drawing.Point(452, 100);
            this.GrayCancelButton.Name = "GrayCancelButton";
            this.GrayCancelButton.Size = new System.Drawing.Size(75, 23);
            this.GrayCancelButton.TabIndex = 11;
            this.GrayCancelButton.Text = "Cancel";
            this.GrayCancelButton.UseVisualStyleBackColor = true;
            this.GrayCancelButton.Click += new System.EventHandler(this.GrayCancelButton_Click);
            // 
            // GrayProgressBar
            // 
            this.GrayProgressBar.Location = new System.Drawing.Point(6, 129);
            this.GrayProgressBar.Name = "GrayProgressBar";
            this.GrayProgressBar.Size = new System.Drawing.Size(603, 23);
            this.GrayProgressBar.TabIndex = 12;
            // 
            // GrayScaleUserControl
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
            this.Name = "GrayScaleUserControl";
            this.Size = new System.Drawing.Size(618, 164);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox grayDosTextBox;
        private System.Windows.Forms.TextBox grayBitmapTextBox;
        private System.Windows.Forms.TextBox grayMinHeightTextBox;
        private System.Windows.Forms.TextBox grayMaxHeightTextBox;
        private System.Windows.Forms.Button GrayDosBrowse;
        private System.Windows.Forms.Button GrayBitmapBrowse;
        private System.Windows.Forms.Button GrayGenerate;
        private System.Windows.Forms.Label GrayDosFileLabel;
        private System.Windows.Forms.Label GrayBitmapFileLabel;
        private System.Windows.Forms.Label grayMinHeightLabel;
        private System.Windows.Forms.Label GrayMaxHeightLabel;
        private System.Windows.Forms.Button GrayCancelButton;
        private System.Windows.Forms.ProgressBar GrayProgressBar;
    }
}
