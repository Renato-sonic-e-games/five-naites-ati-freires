namespace five_naites_ati_freires
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
            components = new System.ComponentModel.Container();
            timerGeral = new System.Windows.Forms.Timer(components);
            lblContador = new Label();
            timerC = new System.Windows.Forms.Timer(components);
            lblRespostas = new Label();
            lblC = new Label();
            lblteste = new Label();
            lbldirecao = new Label();
            timerPopup = new System.Windows.Forms.Timer(components);
            btnJogar = new Button();
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
            btnJogar.BackgroundImageLayout = ImageLayout.Stretch;
            btnJogar.FlatAppearance.BorderSize = 0;
            btnJogar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnJogar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnJogar.FlatStyle = FlatStyle.Flat;
            btnJogar.Location = new Point(331, 176);
            btnJogar.Name = "btnJogar";
            btnJogar.Size = new Size(130, 60);
            btnJogar.TabIndex = 6;
            btnJogar.UseVisualStyleBackColor = false;
            btnJogar.Click += btnJogar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources.FNAFTitleScreen;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btnJogar);
            Controls.Add(lbldirecao);
            Controls.Add(lblteste);
            Controls.Add(lblC);
            Controls.Add(lblRespostas);
            Controls.Add(lblContador);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "FNAFreire";
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
    }
}

