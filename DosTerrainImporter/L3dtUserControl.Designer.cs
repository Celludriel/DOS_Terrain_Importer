namespace DosTerrainImporter
{
    partial class L3dtUserControl
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
            this.L3dtCancelButton = new System.Windows.Forms.Button();
            this.l3dtMaxHeightLabel = new System.Windows.Forms.Label();
            this.l3dtMinHeightLabel = new System.Windows.Forms.Label();
            this.L3dtBitmapFileLabel = new System.Windows.Forms.Label();
            this.L3dtDosFileLabel = new System.Windows.Forms.Label();
            this.L3dtGenerate = new System.Windows.Forms.Button();
            this.L3dtFileBrowse = new System.Windows.Forms.Button();
            this.L3dtDosBrowse = new System.Windows.Forms.Button();
            this.l3dtMaxHeightTextBox = new System.Windows.Forms.TextBox();
            this.l3dtMinHeightTextBox = new System.Windows.Forms.TextBox();
            this.l3dtTextBox = new System.Windows.Forms.TextBox();
            this.l3dtDosTextBox = new System.Windows.Forms.TextBox();
            this.L3dtProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // L3dtCancelButton
            // 
            this.L3dtCancelButton.Location = new System.Drawing.Point(456, 101);
            this.L3dtCancelButton.Name = "L3dtCancelButton";
            this.L3dtCancelButton.Size = new System.Drawing.Size(75, 23);
            this.L3dtCancelButton.TabIndex = 23;
            this.L3dtCancelButton.Text = "Cancel";
            this.L3dtCancelButton.UseVisualStyleBackColor = true;
            this.L3dtCancelButton.Click += new System.EventHandler(this.L3dtCancelButton_Click);
            // 
            // l3dtMaxHeightLabel
            // 
            this.l3dtMaxHeightLabel.AutoSize = true;
            this.l3dtMaxHeightLabel.Location = new System.Drawing.Point(364, 78);
            this.l3dtMaxHeightLabel.Name = "l3dtMaxHeightLabel";
            this.l3dtMaxHeightLabel.Size = new System.Drawing.Size(61, 13);
            this.l3dtMaxHeightLabel.TabIndex = 22;
            this.l3dtMaxHeightLabel.Text = "Max Height";
            // 
            // l3dtMinHeightLabel
            // 
            this.l3dtMinHeightLabel.AutoSize = true;
            this.l3dtMinHeightLabel.Location = new System.Drawing.Point(41, 78);
            this.l3dtMinHeightLabel.Name = "l3dtMinHeightLabel";
            this.l3dtMinHeightLabel.Size = new System.Drawing.Size(58, 13);
            this.l3dtMinHeightLabel.TabIndex = 21;
            this.l3dtMinHeightLabel.Text = "Min Height";
            // 
            // L3dtBitmapFileLabel
            // 
            this.L3dtBitmapFileLabel.AutoSize = true;
            this.L3dtBitmapFileLabel.Location = new System.Drawing.Point(14, 52);
            this.L3dtBitmapFileLabel.Name = "L3dtBitmapFileLabel";
            this.L3dtBitmapFileLabel.Size = new System.Drawing.Size(85, 13);
            this.L3dtBitmapFileLabel.TabIndex = 20;
            this.L3dtBitmapFileLabel.Text = "L3DT project file";
            // 
            // L3dtDosFileLabel
            // 
            this.L3dtDosFileLabel.AutoSize = true;
            this.L3dtDosFileLabel.Location = new System.Drawing.Point(3, 22);
            this.L3dtDosFileLabel.Name = "L3dtDosFileLabel";
            this.L3dtDosFileLabel.Size = new System.Drawing.Size(96, 13);
            this.L3dtDosFileLabel.TabIndex = 19;
            this.L3dtDosFileLabel.Text = "Divinity Terrain File";
            // 
            // L3dtGenerate
            // 
            this.L3dtGenerate.Location = new System.Drawing.Point(537, 101);
            this.L3dtGenerate.Name = "L3dtGenerate";
            this.L3dtGenerate.Size = new System.Drawing.Size(75, 23);
            this.L3dtGenerate.TabIndex = 18;
            this.L3dtGenerate.Text = "Generate";
            this.L3dtGenerate.UseVisualStyleBackColor = true;
            this.L3dtGenerate.Click += new System.EventHandler(this.L3dtGenerate_Click);
            // 
            // L3dtFileBrowse
            // 
            this.L3dtFileBrowse.Location = new System.Drawing.Point(537, 47);
            this.L3dtFileBrowse.Name = "L3dtFileBrowse";
            this.L3dtFileBrowse.Size = new System.Drawing.Size(75, 23);
            this.L3dtFileBrowse.TabIndex = 17;
            this.L3dtFileBrowse.Text = "...";
            this.L3dtFileBrowse.UseVisualStyleBackColor = true;
            this.L3dtFileBrowse.Click += new System.EventHandler(this.L3dtFileBrowse_Click);
            // 
            // L3dtDosBrowse
            // 
            this.L3dtDosBrowse.Location = new System.Drawing.Point(537, 17);
            this.L3dtDosBrowse.Name = "L3dtDosBrowse";
            this.L3dtDosBrowse.Size = new System.Drawing.Size(75, 23);
            this.L3dtDosBrowse.TabIndex = 16;
            this.L3dtDosBrowse.Text = "...";
            this.L3dtDosBrowse.UseVisualStyleBackColor = true;
            this.L3dtDosBrowse.Click += new System.EventHandler(this.L3dtDosBrowse_Click);
            // 
            // l3dtMaxHeightTextBox
            // 
            this.l3dtMaxHeightTextBox.Location = new System.Drawing.Point(431, 75);
            this.l3dtMaxHeightTextBox.Name = "l3dtMaxHeightTextBox";
            this.l3dtMaxHeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.l3dtMaxHeightTextBox.TabIndex = 15;
            this.l3dtMaxHeightTextBox.Text = "20";
            // 
            // l3dtMinHeightTextBox
            // 
            this.l3dtMinHeightTextBox.Location = new System.Drawing.Point(105, 75);
            this.l3dtMinHeightTextBox.Name = "l3dtMinHeightTextBox";
            this.l3dtMinHeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.l3dtMinHeightTextBox.TabIndex = 14;
            this.l3dtMinHeightTextBox.Text = "-20";
            // 
            // l3dtTextBox
            // 
            this.l3dtTextBox.Location = new System.Drawing.Point(105, 49);
            this.l3dtTextBox.Name = "l3dtTextBox";
            this.l3dtTextBox.ReadOnly = true;
            this.l3dtTextBox.Size = new System.Drawing.Size(426, 20);
            this.l3dtTextBox.TabIndex = 13;
            // 
            // l3dtDosTextBox
            // 
            this.l3dtDosTextBox.Location = new System.Drawing.Point(105, 19);
            this.l3dtDosTextBox.Name = "l3dtDosTextBox";
            this.l3dtDosTextBox.ReadOnly = true;
            this.l3dtDosTextBox.Size = new System.Drawing.Size(426, 20);
            this.l3dtDosTextBox.TabIndex = 12;
            // 
            // L3dtProgressBar
            // 
            this.L3dtProgressBar.Location = new System.Drawing.Point(9, 130);
            this.L3dtProgressBar.Name = "L3dtProgressBar";
            this.L3dtProgressBar.Size = new System.Drawing.Size(603, 23);
            this.L3dtProgressBar.TabIndex = 24;
            // 
            // L3dtUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.L3dtProgressBar);
            this.Controls.Add(this.L3dtCancelButton);
            this.Controls.Add(this.l3dtMaxHeightLabel);
            this.Controls.Add(this.l3dtMinHeightLabel);
            this.Controls.Add(this.L3dtBitmapFileLabel);
            this.Controls.Add(this.L3dtDosFileLabel);
            this.Controls.Add(this.L3dtGenerate);
            this.Controls.Add(this.L3dtFileBrowse);
            this.Controls.Add(this.L3dtDosBrowse);
            this.Controls.Add(this.l3dtMaxHeightTextBox);
            this.Controls.Add(this.l3dtMinHeightTextBox);
            this.Controls.Add(this.l3dtTextBox);
            this.Controls.Add(this.l3dtDosTextBox);
            this.Name = "L3dtUserControl";
            this.Size = new System.Drawing.Size(618, 164);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button L3dtCancelButton;
        private System.Windows.Forms.Label l3dtMaxHeightLabel;
        private System.Windows.Forms.Label l3dtMinHeightLabel;
        private System.Windows.Forms.Label L3dtBitmapFileLabel;
        private System.Windows.Forms.Label L3dtDosFileLabel;
        private System.Windows.Forms.Button L3dtGenerate;
        private System.Windows.Forms.Button L3dtFileBrowse;
        private System.Windows.Forms.Button L3dtDosBrowse;
        private System.Windows.Forms.TextBox l3dtMaxHeightTextBox;
        private System.Windows.Forms.TextBox l3dtMinHeightTextBox;
        private System.Windows.Forms.TextBox l3dtTextBox;
        private System.Windows.Forms.TextBox l3dtDosTextBox;
        private System.Windows.Forms.ProgressBar L3dtProgressBar;
    }
}
