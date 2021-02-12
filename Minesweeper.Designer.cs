
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
            this.NewGameBtn = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.displayTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NewGameBtn
            // 
            this.NewGameBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.NewGameBtn.Location = new System.Drawing.Point(10, 10);
            this.NewGameBtn.Name = "NewGameBtn";
            this.NewGameBtn.Size = new System.Drawing.Size(120, 40);
            this.NewGameBtn.TabIndex = 0;
            this.NewGameBtn.Text = "New Game";
            this.NewGameBtn.UseVisualStyleBackColor = true;
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
            // Minesweeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 886);
            this.Controls.Add(this.displayTime);
            this.Controls.Add(this.NewGameBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Minesweeper";
            this.Text = "Minesweeper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NewGameBtn;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label displayTime;
    }
}

