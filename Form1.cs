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
        int direcao = 0;
        // 0 = front view
        // 1 = window view
        // 2 = door view
        int celular = 0;
        // 0 = sem
        // 1 = com ele
        Button btnMoverE;
        Button btnMoverD;
        

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
        void desabilitarBotoes()
        {
            if (btnMoverD != null)
            {
                this.Controls.Remove(btnMoverD);
                btnMoverD.Dispose();
                btnMoverD = null;
            }
            if (btnMoverE != null)
            {
                this.Controls.Remove(btnMoverE);
                btnMoverE.Dispose();
                btnMoverE = null;
            }
        }
        void criarbtnE()
        {
            if (btnMoverE == null)
            {
                btnMoverE = new Button();
                btnMoverE.Text = " ";
                btnMoverE.BackColor = Color.Transparent;
                btnMoverE.FlatStyle = FlatStyle.Flat;
                btnMoverE.FlatAppearance.BorderSize = 0;
                btnMoverE.MouseEnter += btnMoverE_MouseEnter;
                btnMoverE.Location = new Point(-7, -6);
                btnMoverE.Size = new Size(82, 463);
                this.Controls.Add(btnMoverE);
            }
        }
        void criarbtnD()
        {
            if (btnMoverD == null)
            {
                btnMoverD = new Button();
                btnMoverD.Text = " ";
                btnMoverD.BackColor = Color.Transparent;
                btnMoverD.FlatStyle = FlatStyle.Flat;
                btnMoverD.FlatAppearance.BorderSize = 0;
                btnMoverD.MouseEnter += btnMoverD_MouseEnter;
                btnMoverD.Location = new Point(726, -6);
                btnMoverD.Size = new Size(82, 463);
                this.Controls.Add(btnMoverD);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            criarbtnD();
            criarbtnE();

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btnMoverD_MouseHover(object sender, EventArgs e)
        {

        }
        async Task transicaoJanela()
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

        private void btnMoverD_MouseEnter(object sender, EventArgs e)
        {
            desabilitarBotoes();
            switch (direcao)
            {
                case 0:
                    transicaoJanela();
                    this.BackgroundImage = Properties.Resources.wv1;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    criarbtnE();
                    break;
                case 2:
                    transicaoLousa2();
                    this.BackgroundImage = Properties.Resources.fv1;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    criarbtnE();
                    criarbtnD();
                    break;
                default:
                    break;
            }

        }
        async Task transicaoLousa()
        {

            desabilitarBotoes();
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
        async Task transicaoLousa2()
        {

            desabilitarBotoes();
            PictureBox transicao = new PictureBox();
            transicao.Width = this.ClientSize.Width;
            transicao.Height = this.ClientSize.Height;
            transicao.SizeMode = PictureBoxSizeMode.StretchImage;
            transicao.Image = Properties.Resources.tripitripi_ezgif_com_reverse;
            this.Controls.Add(transicao);
            await Task.Delay(950);
            this.Controls.Remove(transicao);
            transicao.Dispose();
            transicao = null;
            direcao = 0;
        }
        async Task transicaoPorta()
        {

            direcao = 2;

            desabilitarBotoes();
            PictureBox transicao = new PictureBox();
            transicao.Width = this.ClientSize.Width;
            transicao.Height = this.ClientSize.Height;
            transicao.SizeMode = PictureBoxSizeMode.StretchImage;
            transicao.Image = Properties.Resources.tripitripi;
            this.Controls.Add(transicao);
            await Task.Delay(950);
            this.Controls.Remove(transicao);
            transicao.Dispose();
            transicao = null;
        }
        private void btnMoverE_MouseEnter(object sender, EventArgs e)
        {
            desabilitarBotoes();
            switch (direcao)
            {
                case 0:
                    transicaoPorta();
                    this.BackgroundImage = Properties.Resources.dv1;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    criarbtnD();
                    break;
                case 1:
                    transicaoLousa();
                    this.BackgroundImage = Properties.Resources.fv1;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    criarbtnD();
                    criarbtnE();
                    break;
                default:
                    break;
            }
        }

        private void btnMoverD_MouseLeave(object sender, EventArgs e)
        {

        }



        private void timerProva_tick(object sender, EventArgs e)
        {
            tempo++;
            lblContador.Text = "Timer: " + tempo;
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
