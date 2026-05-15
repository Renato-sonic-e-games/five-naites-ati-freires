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
        PictureBox transicao;

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
            desabilitarBotoes();
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
        void criarTransicao()
        {
            transicao = new PictureBox();
            transicao.Width = this.ClientSize.Width;
            transicao.Height = this.ClientSize.Height;
            transicao.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        void criarbtnE()
        {
            if (btnMoverE == null)
            {
                btnMoverE = new Button();
                btnMoverE.Text = " ";
                btnMoverE.BackColor = Color.White;
                btnMoverE.FlatStyle = FlatStyle.Flat;
                btnMoverE.FlatAppearance.BorderSize = 0;
                btnMoverE.MouseEnter += btnMoverE_MouseEnter;
                btnMoverE.Location = new Point(0, 0);
                btnMoverE.Size = new Size(this.ClientSize.Width / 8, this.ClientSize.Height);
                btnMoverE.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom);
                this.Controls.Add(btnMoverE);
            }
        }
        void criarbtnD()
        {
            if (btnMoverD == null)
            {
                btnMoverD = new Button();
                btnMoverD.Text = " ";
                btnMoverD.BackColor = Color.Red;
                btnMoverD.FlatStyle = FlatStyle.Flat;
                btnMoverD.FlatAppearance.BorderSize = 0;
                btnMoverD.MouseEnter += btnMoverD_MouseEnter;
                btnMoverD.Size = new Size(this.ClientSize.Width / 8, this.ClientSize.Height);
                btnMoverD.Location = new Point(
                    (this.ClientSize.Width - btnMoverD.Width),
                    (0)
                    );
                btnMoverD.Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);
                this.Controls.Add(btnMoverD);
            }
        }
        async Task transicaoLousa()
        {

            desabilitarBotoes();
            criarTransicao();
            transicao.Image = Properties.Resources.wtol;
            this.Controls.Add(transicao);
            await Task.Delay(1000);
            this.Controls.Remove(transicao);
            transicao.Dispose();
            transicao = null;
            direcao = 0;
        }
        async Task transicaoJanela()
        {

            direcao = 1;
            criarTransicao();
            transicao.Image = Properties.Resources.ltow;
            this.Controls.Add(transicao);
            await Task.Delay(1000);
            this.Controls.Remove(transicao);
            transicao.Dispose();
            transicao = null;

        }
        async Task transicaoLousa2()
        {

            desabilitarBotoes();
            criarTransicao();
            transicao.Image = Properties.Resources.dtol;
            this.Controls.Add(transicao);
            await Task.Delay(1000);
            this.Controls.Remove(transicao);
            transicao.Dispose();
            transicao = null;
            direcao = 0;
        }
        async Task transicaoPorta()
        {

            direcao = 2;

            desabilitarBotoes();
            criarTransicao();
            transicao.Image = Properties.Resources.ltod;
            this.Controls.Add(transicao);
            await Task.Delay(1000);
            this.Controls.Remove(transicao);
            transicao.Dispose();
            transicao = null;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            criarbtnD();
            criarbtnE();
                
        }
        private async void btnMoverD_MouseEnter(object sender, EventArgs e)
        {
            desabilitarBotoes();
            switch (direcao)
            {
                case 0:
                    await transicaoJanela();
                    this.BackgroundImage = Properties.Resources.wv2;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    criarbtnE();
                    break;
                case 2:
                    await transicaoLousa2();
                    this.BackgroundImage = Properties.Resources.fv2;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    criarbtnE();
                    criarbtnD();
                    break;
                default:
                    break;
            }

        }
        private async void btnMoverE_MouseEnter(object sender, EventArgs e)
        {
            desabilitarBotoes();
            switch (direcao)
            {
                case 0:
                    await transicaoPorta();
                    this.BackgroundImage = Properties.Resources.dv2;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    criarbtnD();
                    break;
                case 1:
                    await transicaoLousa();
                    this.BackgroundImage = Properties.Resources.fv2;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    criarbtnD();
                    criarbtnE();
                    break;
                default:
                    break;
            }
        }


        private void timerProva_tick(object sender, EventArgs e)
        {
            tempo++;
            lblContador.Text = "Timer: " + tempo;
            if (tempo == 10)
            {
                gameover();

            }
        }
    }
}
