namespace DosTerrainImporter
{
    partial class GameSelector
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
            this.MainL3dtButton = new System.Windows.Forms.Button();
            this.MainGrayScaleButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MainL3dtButton
            // 
            this.MainL3dtButton.Location = new System.Drawing.Point(377, 122);
            this.MainL3dtButton.Margin = new System.Windows.Forms.Padding(60, 122, 337, 122);
            this.MainL3dtButton.Name = "MainL3dtButton";
            this.MainL3dtButton.Size = new System.Drawing.Size(200, 129);
            this.MainL3dtButton.TabIndex = 3;
            this.MainL3dtButton.Text = "DO:S 2";
            this.MainL3dtButton.UseVisualStyleBackColor = true;
            this.MainL3dtButton.Click += new System.EventHandler(this.MainL3dtButton_Click);
            // 
            // MainGrayScaleButton
            // 
            this.MainGrayScaleButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MainGrayScaleButton.Location = new System.Drawing.Point(57, 122);
            this.MainGrayScaleButton.Margin = new System.Windows.Forms.Padding(373, 122, 60, 122);
            this.MainGrayScaleButton.Name = "MainGrayScaleButton";
            this.MainGrayScaleButton.Size = new System.Drawing.Size(200, 129);
            this.MainGrayScaleButton.TabIndex = 2;
            this.MainGrayScaleButton.Text = "DO:S";
            this.MainGrayScaleButton.UseVisualStyleBackColor = true;
            this.MainGrayScaleButton.Click += new System.EventHandler(this.MainGrayScaleButton_Click);
            // 
            // GameSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainL3dtButton);
            this.Controls.Add(this.MainGrayScaleButton);
            this.Name = "GameSelector";
            this.Size = new System.Drawing.Size(635, 372);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MainL3dtButton;
        private System.Windows.Forms.Button MainGrayScaleButton;
    }
}
