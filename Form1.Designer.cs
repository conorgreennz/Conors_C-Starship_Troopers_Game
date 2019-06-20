namespace DiveBomb
{
    partial class Form1
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
            this.TmrGame = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.LblPoints = new System.Windows.Forms.Label();
            this.BtnReset = new System.Windows.Forms.Button();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.LblName = new System.Windows.Forms.Label();
            this.TxtLives = new System.Windows.Forms.TextBox();
            this.LblPts = new System.Windows.Forms.Label();
            this.LblLives = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TmrGame
            // 
            this.TmrGame.Interval = 50;
            this.TmrGame.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 67);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(993, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.LblPoints);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BtnReset);
            this.panel1.Controls.Add(this.TxtName);
            this.panel1.Controls.Add(this.LblName);
            this.panel1.Controls.Add(this.TxtLives);
            this.panel1.Controls.Add(this.LblPts);
            this.panel1.Controls.Add(this.LblLives);
            this.panel1.Location = new System.Drawing.Point(843, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 514);
            this.panel1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Papyrus", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 30);
            this.label2.TabIndex = 19;
            this.label2.Text = "Dive Bomb";
            // 
            // LblPoints
            // 
            this.LblPoints.BackColor = System.Drawing.SystemColors.Window;
            this.LblPoints.Font = new System.Drawing.Font("Papyrus", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPoints.Location = new System.Drawing.Point(23, 210);
            this.LblPoints.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblPoints.Name = "LblPoints";
            this.LblPoints.Size = new System.Drawing.Size(98, 28);
            this.LblPoints.TabIndex = 18;
            this.LblPoints.Text = "0";
            this.LblPoints.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BtnReset
            // 
            this.BtnReset.Font = new System.Drawing.Font("Papyrus", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReset.Location = new System.Drawing.Point(22, 249);
            this.BtnReset.Margin = new System.Windows.Forms.Padding(2);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(99, 49);
            this.BtnReset.TabIndex = 0;
            this.BtnReset.TabStop = false;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(19, 89);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(100, 20);
            this.TxtName.TabIndex = 14;
            this.TxtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtName_KeyPress);
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Papyrus", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblName.Location = new System.Drawing.Point(38, 66);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(49, 21);
            this.LblName.TabIndex = 16;
            this.LblName.Text = "Name";
            // 
            // TxtLives
            // 
            this.TxtLives.Location = new System.Drawing.Point(22, 151);
            this.TxtLives.MaxLength = 2;
            this.TxtLives.Name = "TxtLives";
            this.TxtLives.Size = new System.Drawing.Size(100, 20);
            this.TxtLives.TabIndex = 15;
            this.TxtLives.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtLives_KeyPress);
            // 
            // LblPts
            // 
            this.LblPts.AutoSize = true;
            this.LblPts.Font = new System.Drawing.Font("Papyrus", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPts.Location = new System.Drawing.Point(38, 188);
            this.LblPts.Name = "LblPts";
            this.LblPts.Size = new System.Drawing.Size(53, 21);
            this.LblPts.TabIndex = 13;
            this.LblPts.Text = "Points";
            // 
            // LblLives
            // 
            this.LblLives.AutoSize = true;
            this.LblLives.Font = new System.Drawing.Font("Papyrus", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLives.Location = new System.Drawing.Point(25, 128);
            this.LblLives.Name = "LblLives";
            this.LblLives.Size = new System.Drawing.Size(94, 21);
            this.LblLives.TabIndex = 12;
            this.LblLives.Text = "Lives Count";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(0, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(838, 514);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 536);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Dive Bomb";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer TmrGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblPoints;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.TextBox TxtLives;
        private System.Windows.Forms.Label LblPts;
        private System.Windows.Forms.Label LblLives;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

