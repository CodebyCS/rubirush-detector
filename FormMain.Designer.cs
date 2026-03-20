namespace MonitorBot
{
    public partial class FormMain : Form
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            btnStart = new Button();
            btnStop = new Button();
            numMinimoXp = new NumericUpDown();
            mainTimer = new System.Windows.Forms.Timer(components);
            MinXpRadar = new Label();
            groupBox1 = new GroupBox();
            txtConsole = new RichTextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)numMinimoXp).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(52, 85);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 1;
            btnStart.Text = "On ";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(52, 125);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 2;
            btnStop.Text = "Off";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // numMinimoXp
            // 
            numMinimoXp.Location = new Point(26, 45);
            numMinimoXp.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numMinimoXp.Name = "numMinimoXp";
            numMinimoXp.Size = new Size(120, 23);
            numMinimoXp.TabIndex = 3;
            numMinimoXp.ValueChanged += numMinimoXp_ValueChanged;
            // 
            // mainTimer
            // 
            mainTimer.Interval = 240000;
            mainTimer.Tick += mainTimer_Tick;
            // 
            // MinXpRadar
            // 
            MinXpRadar.Font = new Font("Segoe UI", 12F);
            MinXpRadar.ForeColor = Color.FromArgb(214, 36, 27);
            MinXpRadar.Location = new Point(26, 19);
            MinXpRadar.Name = "MinXpRadar";
            MinXpRadar.Size = new Size(101, 23);
            MinXpRadar.TabIndex = 5;
            MinXpRadar.Text = "MinXpRadar";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnStop);
            groupBox1.Controls.Add(MinXpRadar);
            groupBox1.Controls.Add(numMinimoXp);
            groupBox1.Controls.Add(btnStart);
            groupBox1.ForeColor = Color.FromArgb(214, 36, 27);
            groupBox1.Location = new Point(33, 25);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(175, 178);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Config";
            // 
            // txtConsole
            // 
            txtConsole.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtConsole.BackColor = Color.FromArgb(29, 28, 26);
            txtConsole.BorderStyle = BorderStyle.FixedSingle;
            txtConsole.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConsole.ForeColor = Color.FromArgb(214, 36, 27);
            txtConsole.Location = new Point(33, 249);
            txtConsole.Name = "txtConsole";
            txtConsole.ReadOnly = true;
            txtConsole.Size = new Size(361, 286);
            txtConsole.TabIndex = 7;
            txtConsole.Text = "Exp Monitor";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(209, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(185, 178);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 28, 26);
            ClientSize = new Size(437, 561);
            Controls.Add(pictureBox1);
            Controls.Add(txtConsole);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            Text = "MataCoitado v1.0";
            Load += FormMain_Load;
            ((System.ComponentModel.ISupportInitialize)numMinimoXp).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnStart;
        private Button btnStop;
        private NumericUpDown numMinimoXp;
        private System.Windows.Forms.Timer mainTimer;
        private Label MinXpRadar;
        private GroupBox groupBox1;
        private RichTextBox txtConsole;
        private PictureBox pictureBox1;
    }
}
