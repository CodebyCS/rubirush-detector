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
            lstMembrosInimigos = new ListBox();
            lblTituloGuild = new Label();
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
            mainTimer.Interval = 100000;
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
            txtConsole.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
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
            // lstMembrosInimigos
            // 
            lstMembrosInimigos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstMembrosInimigos.BackColor = Color.FromArgb(29, 28, 26);
            lstMembrosInimigos.BorderStyle = BorderStyle.FixedSingle;
            lstMembrosInimigos.ForeColor = Color.FromArgb(214, 36, 27);
            lstMembrosInimigos.FormattingEnabled = true;
            lstMembrosInimigos.Location = new Point(422, 55);
            lstMembrosInimigos.Name = "lstMembrosInimigos";
            lstMembrosInimigos.Size = new Size(255, 482);
            lstMembrosInimigos.TabIndex = 9;
            lstMembrosInimigos.SelectedIndexChanged += GhostDivisionMembers_SelectedIndexChanged;
            // 
            // lblTituloGuild
            // 
            lblTituloGuild.AutoSize = true;
            lblTituloGuild.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloGuild.ForeColor = Color.FromArgb(214, 36, 27);
            lblTituloGuild.Location = new Point(458, 25);
            lblTituloGuild.Name = "lblTituloGuild";
            lblTituloGuild.Size = new Size(181, 20);
            lblTituloGuild.TabIndex = 10;
            lblTituloGuild.Text = "Ghost Division Members";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 28, 26);
            ClientSize = new Size(701, 561);
            Controls.Add(lblTituloGuild);
            Controls.Add(lstMembrosInimigos);
            Controls.Add(pictureBox1);
            Controls.Add(txtConsole);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            Text = "MataCoitado v1.0.1";
            Load += FormMain_Load;
            ((System.ComponentModel.ISupportInitialize)numMinimoXp).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private ListBox lstMembrosInimigos;
        private Label lblTituloGuild;
    }
}
