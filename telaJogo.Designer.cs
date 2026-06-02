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
            pbCelular = new ProgressBar();
            btnajuda = new Button();
            btnopcao = new Button();
            btnSair = new Button();
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
            lblContador.Location = new Point(49, 35);
            lblContador.Name = "lblContador";
            lblContador.Size = new Size(43, 15);
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
            lblRespostas.Location = new Point(49, 60);
            lblRespostas.Name = "lblRespostas";
            lblRespostas.Size = new Size(70, 15);
            lblRespostas.TabIndex = 2;
            lblRespostas.Text = "nr respostas";
            // 
            // lblC
            // 
            lblC.AutoSize = true;
            lblC.Location = new Point(49, 84);
            lblC.Name = "lblC";
            lblC.Size = new Size(73, 15);
            lblC.TabIndex = 3;
            lblC.Text = "celular timer";
            // 
            // lblteste
            // 
            lblteste.AutoSize = true;
            lblteste.Location = new Point(49, 110);
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
            btnJogar.Location = new Point(463, 313);
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
            lblFreirep.Location = new Point(49, 141);
            lblFreirep.Name = "lblFreirep";
            lblFreirep.Size = new Size(85, 15);
            lblFreirep.TabIndex = 7;
            lblFreirep.Text = "FreirePosition: ";
            // 
            // pbCelular
            // 
            pbCelular.Location = new Point(1127, -1);
            pbCelular.Name = "pbCelular";
            pbCelular.Size = new Size(238, 23);
            pbCelular.TabIndex = 8;
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
            btnajuda.Location = new Point(464, 406);
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
            btnopcao.Location = new Point(463, 473);
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
            btnSair.Location = new Point(463, 556);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(438, 78);
            btnSair.TabIndex = 11;
            btnSair.UseVisualStyleBackColor = false;
            btnSair.Click += btnSair_Click;
            btnSair.MouseEnter += btnSair_MouseEnter;
            btnSair.MouseLeave += btnSair_MouseLeave;
            // 
            // telaJogo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources.FNAFTitleScreen__1_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1366, 768);
            Controls.Add(btnSair);
            Controls.Add(btnopcao);
            Controls.Add(btnajuda);
            Controls.Add(pbCelular);
            Controls.Add(lblFreirep);
            Controls.Add(btnJogar);
            Controls.Add(lbldirecao);
            Controls.Add(lblteste);
            Controls.Add(lblC);
            Controls.Add(lblRespostas);
            Controls.Add(lblContador);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "telaJogo";
            Text = "FNAFreire";
            TopMost = true;
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
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
        private ProgressBar pbCelular;
        private Button btnajuda;
        private Button btnopcao;
        private Button btnSair;
    }
}

