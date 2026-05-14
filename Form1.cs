namespace five_naites_ati_freires
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timerGeral.Start();
        }
        int tempo = 0;
        int direcao= 0;
        // 0 = front view
        // 1 = window view
        // 2 = door view
        int celular = 0;
        // 0 = sem
        // 1 = com ele
        Button btnMover;
        void desabilitarBotões()
        { 
        }
        void gameover()
        {
            PictureBox jumpscare = new PictureBox();
            jumpscare.Width = this.ClientSize.Width;
            jumpscare.Height = this.ClientSize.Height;
            jumpscare.Image = Properties.Resources.foxy_jumpscare;
            jumpscare.SizeMode = PictureBoxSizeMode.StretchImage;
            jumpscare.Location = new Point(
                 (this.ClientSize.Width - jumpscare.Width) / 2,
                 (this.ClientSize.Height - jumpscare.Height) / 2);
            jumpscare.BackColor = Color.Transparent;
            this.Controls.Add(jumpscare);
            timerGeral.Stop();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btnJanela_MouseHover(object sender, EventArgs e)
        {

        }
        async Task transicaoJanela()
        {
            if (direcao == 0)
            {
                direcao = 1;

                PictureBox transicao = new PictureBox();
                transicao.Width = this.ClientSize.Width;
                transicao.Height = this.ClientSize.Height;
                transicao.SizeMode = PictureBoxSizeMode.StretchImage;
                transicao.Image = Properties.Resources.transitiontest1;
                this.Controls.Add(transicao);
                await Task.Delay(950);
                this.Controls.Remove(transicao);
                transicao.Dispose();
                transicao = null;
            }
        }
         
        private void btnJanela_MouseEnter(object sender, EventArgs e)
        {
            transicaoJanela();
            this.BackgroundImage = Properties.Resources.wv1;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            if (btnMover == null) { 
            btnMover = new Button();
            btnMover.Text = " ";
            btnMover.BackColor = Color.Transparent;
            btnMover.FlatStyle = FlatStyle.Flat;
            btnMover.FlatAppearance.BorderSize = 0;
            btnMover.MouseEnter += btnMover_MouseEnter;
            btnMover.Location = new Point(-7, -6);
            btnMover.Size = new Size(82, 463);
            this.Controls.Add(btnMover);
            }
        }
        async Task transicaoLousa()
        {
            if (direcao == 1)
            {
                btnMover.Visible = false;
                this.Controls.Remove(btnMover);
                btnMover.Dispose();
                btnMover = null;
                PictureBox transicao = new PictureBox();
                transicao.Width = this.ClientSize.Width;
                transicao.Height = this.ClientSize.Height;
                transicao.SizeMode = PictureBoxSizeMode.StretchImage;
                transicao.Image = Properties.Resources.transitiontest_ezgif_com_reverse;
                this.Controls.Add(transicao);
                await Task.Delay(950);
                this.Controls.Remove(transicao);
                transicao.Dispose();
                transicao = null;
                direcao = 0;
                
            }
        }
        private void btnMover_MouseEnter(object sender, EventArgs e)
        {
            transicaoLousa();
            this.BackgroundImage = Properties.Resources.fv1;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void btnJanela_MouseLeave(object sender, EventArgs e)
        {

        }



        private void timerProva_tick(object sender, EventArgs e)
        {
            tempo++;
            lblContador.Text = "Timer: "+ tempo;
            if (tempo == 300)
            {
                gameover();

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
