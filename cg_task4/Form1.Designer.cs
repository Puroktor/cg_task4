
namespace cg_task4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panel = new System.Windows.Forms.Panel();
            this.playButton = new System.Windows.Forms.Button();
            this.readButton = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.forwardButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.compLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.swapLabel = new System.Windows.Forms.Label();
            this.actionTimer = new System.Windows.Forms.Timer(this.components);
            this.animationLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(800, 377);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.playButton);
            this.panel.Controls.Add(this.readButton);
            this.panel.Controls.Add(this.textBox);
            this.panel.Controls.Add(this.stopButton);
            this.panel.Controls.Add(this.backButton);
            this.panel.Controls.Add(this.forwardButton);
            this.panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel.Location = new System.Drawing.Point(0, 377);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(800, 73);
            this.panel.TabIndex = 0;
            this.panel.Resize += new System.EventHandler(this.Panel_Resize);
            // 
            // playButton
            // 
            this.playButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.playButton.Location = new System.Drawing.Point(469, 25);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(75, 23);
            this.playButton.TabIndex = 5;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // readButton
            // 
            this.readButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.readButton.Location = new System.Drawing.Point(388, 25);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(75, 23);
            this.readButton.TabIndex = 0;
            this.readButton.Text = "Read";
            this.readButton.UseVisualStyleBackColor = true;
            this.readButton.Click += new System.EventHandler(this.ReadButton_Click);
            // 
            // textBox
            // 
            this.textBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox.Location = new System.Drawing.Point(25, 25);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(350, 23);
            this.textBox.TabIndex = 3;
            this.textBox.Text = "5 4 3 2 1";
            // 
            // stopButton
            // 
            this.stopButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.stopButton.Location = new System.Drawing.Point(550, 25);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // backButton
            // 
            this.backButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.backButton.Location = new System.Drawing.Point(630, 25);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // forwardButton
            // 
            this.forwardButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.forwardButton.Location = new System.Drawing.Point(710, 25);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(75, 23);
            this.forwardButton.TabIndex = 4;
            this.forwardButton.Text = "Forward";
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.ForwardButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(693, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Сравнений:";
            // 
            // compLabel
            // 
            this.compLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.compLabel.AutoSize = true;
            this.compLabel.BackColor = System.Drawing.Color.White;
            this.compLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.compLabel.Location = new System.Drawing.Point(771, 9);
            this.compLabel.Name = "compLabel";
            this.compLabel.Size = new System.Drawing.Size(14, 15);
            this.compLabel.TabIndex = 5;
            this.compLabel.Text = "0";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(704, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Обменов:";
            // 
            // swapLabel
            // 
            this.swapLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.swapLabel.AutoSize = true;
            this.swapLabel.BackColor = System.Drawing.Color.White;
            this.swapLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.swapLabel.Location = new System.Drawing.Point(771, 33);
            this.swapLabel.Name = "swapLabel";
            this.swapLabel.Size = new System.Drawing.Size(14, 15);
            this.swapLabel.TabIndex = 7;
            this.swapLabel.Text = "0";
            // 
            // animationLabel
            // 
            this.animationLabel.AutoSize = true;
            this.animationLabel.BackColor = System.Drawing.Color.White;
            this.animationLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.animationLabel.Location = new System.Drawing.Point(12, 9);
            this.animationLabel.Name = "animationLabel";
            this.animationLabel.Size = new System.Drawing.Size(26, 15);
            this.animationLabel.TabIndex = 8;
            this.animationLabel.Text = "Off";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.animationLabel);
            this.Controls.Add(this.swapLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.compLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.panel);
            this.Name = "Form1";
            this.Text = "StoogeSort";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label compLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label swapLabel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Timer actionTimer;
        private System.Windows.Forms.Label animationLabel;
    }
}

