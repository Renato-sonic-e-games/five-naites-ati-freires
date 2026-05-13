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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // btnJanela
            // 
            btnJanela.Location = new Point(726, 74);
            btnJanela.Name = "btnJanela";
            btnJanela.Size = new Size(33, 275);
            btnJanela.TabIndex = 0;
            btnJanela.Text = "Janela";
            btnJanela.UseVisualStyleBackColor = true;
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
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(363, 87);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(200, 100);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(192, 72);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(192, 72);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fv1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Controls.Add(lblContador);
            Controls.Add(btnJanela);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "FNAFreire";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnJanela;
        private Label lblContador;
        private System.Windows.Forms.Timer timerGeral;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}
