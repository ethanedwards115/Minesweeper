namespace Minesweeper
{
    partial class Minesweeper
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
            this.components = new System.ComponentModel.Container();
            this.EasyStartBtn = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.displayTime = new System.Windows.Forms.Label();
            this.MediumStartBtn = new System.Windows.Forms.Button();
            this.HardStartBtn = new System.Windows.Forms.Button();
            this.HelpBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EasyStartBtn
            // 
            this.EasyStartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.EasyStartBtn.Location = new System.Drawing.Point(12, 67);
            this.EasyStartBtn.Name = "EasyStartBtn";
            this.EasyStartBtn.Size = new System.Drawing.Size(120, 40);
            this.EasyStartBtn.TabIndex = 0;
            this.EasyStartBtn.Text = "Easy";
            this.EasyStartBtn.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // displayTime
            // 
            this.displayTime.AutoSize = true;
            this.displayTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.displayTime.Location = new System.Drawing.Point(525, 33);
            this.displayTime.Name = "displayTime";
            this.displayTime.Size = new System.Drawing.Size(150, 36);
            this.displayTime.TabIndex = 1;
            this.displayTime.Text = "00:00.000";
            // 
            // MediumStartBtn
            // 
            this.MediumStartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.MediumStartBtn.Location = new System.Drawing.Point(12, 113);
            this.MediumStartBtn.Name = "MediumStartBtn";
            this.MediumStartBtn.Size = new System.Drawing.Size(120, 40);
            this.MediumStartBtn.TabIndex = 2;
            this.MediumStartBtn.Text = "Medium";
            this.MediumStartBtn.UseVisualStyleBackColor = true;
            // 
            // HardStartBtn
            // 
            this.HardStartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.HardStartBtn.Location = new System.Drawing.Point(14, 159);
            this.HardStartBtn.Name = "HardStartBtn";
            this.HardStartBtn.Size = new System.Drawing.Size(120, 40);
            this.HardStartBtn.TabIndex = 3;
            this.HardStartBtn.Text = "Hard";
            this.HardStartBtn.UseVisualStyleBackColor = true;
            // 
            // HelpBtn
            // 
            this.HelpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.HelpBtn.Location = new System.Drawing.Point(12, 12);
            this.HelpBtn.Name = "HelpBtn";
            this.HelpBtn.Size = new System.Drawing.Size(120, 40);
            this.HelpBtn.TabIndex = 4;
            this.HelpBtn.Text = "Help";
            this.HelpBtn.UseVisualStyleBackColor = true;
            this.HelpBtn.Click += new System.EventHandler(this.HelpBtn_Click);
            // 
            // Minesweeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 886);
            this.Controls.Add(this.HelpBtn);
            this.Controls.Add(this.HardStartBtn);
            this.Controls.Add(this.MediumStartBtn);
            this.Controls.Add(this.displayTime);
            this.Controls.Add(this.EasyStartBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Minesweeper";
            this.Text = "Minesweeper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EasyStartBtn;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label displayTime;
        private System.Windows.Forms.Button MediumStartBtn;
        private System.Windows.Forms.Button HardStartBtn;
        private System.Windows.Forms.Button HelpBtn;
    }
}
