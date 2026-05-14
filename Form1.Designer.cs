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
            btnJanela = new Button();
            timerGeral = new System.Windows.Forms.Timer(components);
            lblContador = new Label();
            SuspendLayout();
            // 
            // btnJanela
            // 
            btnJanela.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnJanela.BackColor = Color.Transparent;
            btnJanela.BackgroundImageLayout = ImageLayout.Stretch;
            btnJanela.FlatAppearance.BorderSize = 0;
            btnJanela.FlatStyle = FlatStyle.Flat;
            btnJanela.ForeColor = SystemColors.ActiveCaptionText;
            btnJanela.Location = new Point(726, -6);
            btnJanela.Name = "btnJanela";
            btnJanela.Size = new Size(82, 463);
            btnJanela.TabIndex = 0;
            btnJanela.UseVisualStyleBackColor = false;
            btnJanela.Click += button1_Click;
            btnJanela.MouseEnter += btnJanela_MouseEnter;
            btnJanela.MouseLeave += btnJanela_MouseLeave;
            btnJanela.MouseHover += btnJanela_MouseHover;
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
            lblContador.Size = new Size(44, 15);
            lblContador.TabIndex = 1;
            lblContador.Text = "Timer: ";
            lblContador.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fv1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(lblContador);
            Controls.Add(btnJanela);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "FNAFreire";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnJanela;
        private Label lblContador;
        private System.Windows.Forms.Timer timerGeral;
    }
}
