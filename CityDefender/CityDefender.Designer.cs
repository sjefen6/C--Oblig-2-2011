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
            this.gamePanel1 = new GamePanel();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.rightButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // gamePanel1
            // 
            this.gamePanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gamePanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gamePanel1.Location = new System.Drawing.Point(12, 8);
            this.gamePanel1.Name = "gamePanel1";
            this.gamePanel1.Size = new System.Drawing.Size(600, 542);
            this.gamePanel1.TabIndex = 2;
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // rightButton
            // 
            this.rightButton.Location = new System.Drawing.Point(688, 253);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(75, 23);
            this.rightButton.TabIndex = 3;
            this.rightButton.Text = "right";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // CityDefender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.gamePanel1);
            this.Name = "CityDefender";
            this.Text = "CityDefender";
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GamePanel gamePanel1;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.Button rightButton;
    }
}