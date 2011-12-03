namespace CityDefender
{
    partial class CityDefender
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
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.gamePanel1 = new GamePanel();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // gamePanel1
            // 
            this.gamePanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gamePanel1.Location = new System.Drawing.Point(12, 12);
            this.gamePanel1.Name = "gamePanel1";
            this.gamePanel1.Size = new System.Drawing.Size(600, 538);
            this.gamePanel1.TabIndex = 0;
            // 
            // CityDefender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.gamePanel1);
            this.Name = "CityDefender";
            this.Text = "CityDefender";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CityDefender_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CityDefender_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Diagnostics.EventLog eventLog1;
        private GamePanel gamePanel1;
    }
}