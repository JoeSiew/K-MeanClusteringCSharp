namespace kMeanClustering
{
    partial class frmGraph
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GraphPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // GraphPanel
            // 
            this.GraphPanel.Location = new System.Drawing.Point(6, 0);
            this.GraphPanel.Name = "GraphPanel";
            this.GraphPanel.Size = new System.Drawing.Size(711, 561);
            this.GraphPanel.TabIndex = 0;
            this.GraphPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GraphPanel_Paint);
            // 
            // frmGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(717, 561);
            this.Controls.Add(this.GraphPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGraph";
            this.ShowIcon = false;
            this.Text = "Graph to Determine Suitable K-Value";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel GraphPanel;
    }
}