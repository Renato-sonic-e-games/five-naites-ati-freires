namespace five_naites_ati_freires
{
    partial class telaJogo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(telaJogo));
            timerGeral = new System.Windows.Forms.Timer(components);
            lblContador = new Label();
            timerC = new System.Windows.Forms.Timer(components);
            lblRespostas = new Label();
            lblC = new Label();
            lblteste = new Label();
            lbldirecao = new Label();
            timerPopup = new System.Windows.Forms.Timer(components);
            btnJogar = new Button();
            timerFreirezada = new System.Windows.Forms.Timer(components);
            lblFreirep = new Label();
            btnajuda = new Button();
            btnopcao = new Button();
            btnSair = new Button();
            pbtimer = new PictureBox();
            lblhora = new Label();
            lblMinutos = new Label();
            pbload = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbtimer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbload).BeginInit();
            SuspendLayout();
            // 
            // timerGeral
            // 
            timerGeral.Interval = 1000;
            timerGeral.Tick += timerProva_tick;
            // 
            // lblContador
            // 
            lblContador.AutoSize = true;
            lblContador.Location = new Point(45, 258);
            lblContador.Name = "lblContador";
            lblContador.Size = new Size(44, 15);
            lblContador.TabIndex = 1;
            lblContador.Text = "Timer: ";
            // 
            // timerC
            // 
            timerC.Interval = 1000;
            timerC.Tick += timerC_Tick;
            // 
            // lblRespostas
            // 
            lblRespostas.AutoSize = true;
            lblRespostas.Location = new Point(45, 283);
            lblRespostas.Name = "lblRespostas";
            lblRespostas.Size = new Size(70, 15);
            lblRespostas.TabIndex = 2;
            lblRespostas.Text = "nr respostas";
            // 
            // lblC
            // 
            lblC.AutoSize = true;
            lblC.Location = new Point(45, 307);
            lblC.Name = "lblC";
            lblC.Size = new Size(73, 15);
            lblC.TabIndex = 3;
            lblC.Text = "celular timer";
            // 
            // lblteste
            // 
            lblteste.AutoSize = true;
            lblteste.Location = new Point(45, 333);
            lblteste.Name = "lblteste";
            lblteste.Size = new Size(38, 15);
            lblteste.TabIndex = 4;
            lblteste.Text = "teste: ";
            // 
            // lbldirecao
            // 
            lbldirecao.AutoSize = true;
            lbldirecao.Location = new Point(727, 46);
            lbldirecao.Name = "lbldirecao";
            lbldirecao.Size = new Size(52, 15);
            lbldirecao.TabIndex = 5;
            lbldirecao.Text = "direcao: ";
            // 
            // timerPopup
            // 
            timerPopup.Interval = 20;
            timerPopup.Tick += timerPopup_Tick;
            // 
            // btnJogar
            // 
            btnJogar.Anchor = AnchorStyles.None;
            btnJogar.BackColor = Color.Transparent;
            btnJogar.BackgroundImage = Properties.Resources.BotãoJogar;
            btnJogar.BackgroundImageLayout = ImageLayout.Zoom;
            btnJogar.FlatAppearance.BorderSize = 0;
            btnJogar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnJogar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnJogar.FlatStyle = FlatStyle.Flat;
            btnJogar.ForeColor = Color.Transparent;
            btnJogar.Location = new Point(463, 304);
            btnJogar.Name = "btnJogar";
            btnJogar.Size = new Size(438, 78);
            btnJogar.TabIndex = 6;
            btnJogar.UseVisualStyleBackColor = false;
            btnJogar.Click += btnJogar_Click;
            btnJogar.MouseEnter += btnJogar_MouseEnter;
            btnJogar.MouseLeave += btnJogar_MouseLeave;
            // 
            // timerFreirezada
            // 
            timerFreirezada.Interval = 1000;
            timerFreirezada.Tick += timerFreirezada_Tick;
            // 
            // lblFreirep
            // 
            lblFreirep.AutoSize = true;
            lblFreirep.Location = new Point(45, 364);
            lblFreirep.Name = "lblFreirep";
            lblFreirep.Size = new Size(85, 15);
            lblFreirep.TabIndex = 7;
            lblFreirep.Text = "FreirePosition: ";
            lblFreirep.Visible = false;
            // 
            // btnajuda
            // 
            btnajuda.Anchor = AnchorStyles.None;
            btnajuda.BackColor = Color.Transparent;
            btnajuda.BackgroundImage = Properties.Resources.btnajuda;
            btnajuda.BackgroundImageLayout = ImageLayout.Zoom;
            btnajuda.FlatAppearance.BorderSize = 0;
            btnajuda.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnajuda.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnajuda.FlatStyle = FlatStyle.Flat;
            btnajuda.ForeColor = Color.Transparent;
            btnajuda.Location = new Point(465, 393);
            btnajuda.Name = "btnajuda";
            btnajuda.Size = new Size(438, 54);
            btnajuda.TabIndex = 9;
            btnajuda.UseVisualStyleBackColor = false;
            btnajuda.Click += btnajuda_Click;
            btnajuda.MouseEnter += btnajuda_MouseEnter;
            btnajuda.MouseLeave += btnajuda_MouseLeave;
            // 
            // btnopcao
            // 
            btnopcao.Anchor = AnchorStyles.None;
            btnopcao.BackColor = Color.Transparent;
            btnopcao.BackgroundImage = Properties.Resources.btnopcao;
            btnopcao.BackgroundImageLayout = ImageLayout.Zoom;
            btnopcao.FlatAppearance.BorderSize = 0;
            btnopcao.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnopcao.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnopcao.FlatStyle = FlatStyle.Flat;
            btnopcao.ForeColor = Color.Transparent;
            btnopcao.Location = new Point(463, 457);
            btnopcao.Name = "btnopcao";
            btnopcao.Size = new Size(438, 65);
            btnopcao.TabIndex = 10;
            btnopcao.UseVisualStyleBackColor = false;
            btnopcao.Click += btnopcao_Click;
            btnopcao.MouseEnter += btnopcao_MouseEnter;
            btnopcao.MouseLeave += btnopcao_MouseLeave;
            // 
            // btnSair
            // 
            btnSair.Anchor = AnchorStyles.None;
            btnSair.BackColor = Color.Transparent;
            btnSair.BackgroundImage = Properties.Resources.btnsair;
            btnSair.BackgroundImageLayout = ImageLayout.Zoom;
            btnSair.FlatAppearance.BorderSize = 0;
            btnSair.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnSair.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSair.FlatStyle = FlatStyle.Flat;
            btnSair.ForeColor = Color.Transparent;
            btnSair.Location = new Point(463, 539);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(438, 78);
            btnSair.TabIndex = 11;
            btnSair.UseVisualStyleBackColor = false;
            btnSair.Click += btnSair_Click;
            btnSair.MouseEnter += btnSair_MouseEnter;
            btnSair.MouseLeave += btnSair_MouseLeave;
            // 
            // pbtimer
            // 
            pbtimer.BackColor = SystemColors.ActiveCaptionText;
            pbtimer.Image = Properties.Resources.relogio;
            pbtimer.Location = new Point(0, 0);
            pbtimer.Name = "pbtimer";
            pbtimer.Size = new Size(203, 96);
            pbtimer.SizeMode = PictureBoxSizeMode.StretchImage;
            pbtimer.TabIndex = 12;
            pbtimer.TabStop = false;
            pbtimer.Visible = false;
            // 
            // lblhora
            // 
            lblhora.BackColor = SystemColors.ActiveCaptionText;
            lblhora.Font = new Font("DS-Digital", 39.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblhora.ForeColor = Color.Red;
            lblhora.Location = new Point(14, 16);
            lblhora.Name = "lblhora";
            lblhora.Size = new Size(81, 64);
            lblhora.TabIndex = 13;
            lblhora.Text = "05";
            lblhora.TextAlign = ContentAlignment.MiddleCenter;
            lblhora.Visible = false;
            lblhora.Click += lblhora_Click;
            // 
            // lblMinutos
            // 
            lblMinutos.AutoSize = true;
            lblMinutos.BackColor = SystemColors.ActiveCaptionText;
            lblMinutos.Font = new Font("DS-Digital", 40F, FontStyle.Bold | FontStyle.Italic);
            lblMinutos.ForeColor = Color.Red;
            lblMinutos.Location = new Point(110, 22);
            lblMinutos.Name = "lblMinutos";
            lblMinutos.Size = new Size(77, 53);
            lblMinutos.TabIndex = 14;
            lblMinutos.Text = "00";
            lblMinutos.TextAlign = ContentAlignment.MiddleCenter;
            lblMinutos.Visible = false;
            // 
            // pbload
            // 
            pbload.BackColor = Color.Black;
            pbload.BackgroundImageLayout = ImageLayout.None;
            pbload.Image = Properties.Resources.iconeloading;
            pbload.Location = new Point(1126, 517);
            pbload.Name = "pbload";
            pbload.Size = new Size(245, 234);
            pbload.SizeMode = PictureBoxSizeMode.StretchImage;
            pbload.TabIndex = 15;
            pbload.TabStop = false;
            pbload.Visible = false;
            // 
            // telaJogo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources.FNAFTitleScreen__1_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1366, 749);
            Controls.Add(pbload);
            Controls.Add(lblMinutos);
            Controls.Add(lblhora);
            Controls.Add(pbtimer);
            Controls.Add(btnSair);
            Controls.Add(btnopcao);
            Controls.Add(btnajuda);
            Controls.Add(lblFreirep);
            Controls.Add(btnJogar);
            Controls.Add(lbldirecao);
            Controls.Add(lblteste);
            Controls.Add(lblC);
            Controls.Add(lblRespostas);
            Controls.Add(lblContador);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "telaJogo";
            StartPosition = FormStartPosition.WindowsDefaultBounds;
            Text = "FNAFreire";
            TopMost = true;
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pbtimer).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbload).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblContador;
        private System.Windows.Forms.Timer timerGeral;
        private System.Windows.Forms.Timer timerC;
        private Label lblRespostas;
        private Label lblC;
        private Label lblteste;
        private Label lbldirecao;
        private System.Windows.Forms.Timer timerPopup;
        private Button btnJogar;
        private System.Windows.Forms.Timer timerFreirezada;
        private Label lblFreirep;
        private Button btnajuda;
        private Button btnopcao;
        private Button btnSair;
        private PictureBox pbtimer;
        private Label lblhora;
        private Label lblMinutos;
        private PictureBox pbload;
    }
}

