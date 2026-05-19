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
        int tempoRespo = 0;
        int resposta = 0;
        int perguntas = 0;
        int direcao = 0;
        // 0 = front view
        // 1 = window view
        // 2 = door view
        // 3 = phone view
        int celular = 0;
        // 0 = sem
        // 1 = com ele
        Button btnMoverE;
        Button btnMoverD;
        Button btnMoverB;
        Button btnMoverC;
        Button btnCell;
        PictureBox transicao;
        

        
        private void timerC_Tick(object sender, EventArgs e)
        {
            tempoRespo++;
            int respostaEscala = (perguntas * 5) + 5;
            if (tempoRespo == 10)
            {
                if (resposta < 1)
                {
                    resposta++;
                    timerC.Stop();
                }
            }
            lblC.Text = "nr res: " + resposta;
            lblRespostas.Text = "tempo celular: " + (tempoRespo * 100) / (10 * 1) + "%";
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
            if (btnMoverB != null)
            {
                this.Controls.Remove(btnMoverB);
                btnMoverB.Dispose();
                btnMoverB = null;
            }
            if (btnMoverC != null)
            {
                this.Controls.Remove(btnMoverC);
                btnMoverC.Dispose();
                btnMoverC = null;
            }
            if (btnCell != null)
            {
                this.Controls.Remove(btnCell);
                btnCell.Dispose();
                btnCell = null;
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
                btnMoverE.BackColor = Color.Transparent;
                btnMoverE.FlatStyle = FlatStyle.Flat;
                btnMoverE.FlatAppearance.BorderSize = 0;
                btnMoverE.MouseEnter += btnMoverE_MouseEnter;
                btnMoverE.Location = new Point(0, 0);
                btnMoverE.Size = new Size(this.ClientSize.Width / 8, this.ClientSize.Height);
                btnMoverE.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom);
                this.Controls.Add(btnMoverE);
            }
        }
        void criarbtnB()
        {
            if (btnMoverB == null)
            {
                btnMoverB = new Button();
                btnMoverB.Text = " ";
                btnMoverB.BackColor = Color.Gray;
                btnMoverB.FlatStyle = FlatStyle.Flat;
                btnMoverB.FlatAppearance.BorderSize = 0;
                btnMoverB.MouseEnter += btnMoverB_MouseEnter;
                btnMoverB.Size = new Size(this.ClientSize.Width, this.ClientSize.Height / 8);
                btnMoverB.Location = new Point(0, this.ClientSize.Height - btnMoverB.Height);
                btnMoverB.Anchor = (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom);
                this.Controls.Add(btnMoverB);
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
        void criarbtnC()
        {
            if (btnMoverC == null)
            {
                btnMoverC = new Button();
                btnMoverC.Text = " ";
                btnMoverC.BackColor = Color.Gray;
                btnMoverC.FlatStyle = FlatStyle.Flat;
                btnMoverC.FlatAppearance.BorderSize = 0;
                btnMoverC.MouseEnter += btnMoverC_MouseEnter;
                btnMoverC.Size = new Size(this.ClientSize.Width, this.ClientSize.Height / 8);
                btnMoverC.Location = new Point(0, 0);
                btnMoverC.Anchor = (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom);
                this.Controls.Add(btnMoverC);
            }
        }
        void criarbtnAbrirC()
        {
            if (btnCell == null)
            {
                btnCell = new Button();
                btnCell.BackColor = Color.White;
                btnCell.FlatStyle = FlatStyle.Flat;
                btnCell.Cursor = Cursors.Hand;
                btnCell.FlatAppearance.BorderSize = 0;
                btnCell.MouseClick += btnCell_MouseEnter;
                if (celular == 0)
                {
                    btnCell.Text = "Abrir celular";
                }
                if (celular == 1)
                {
                    btnCell.Text = "Fechar celular";
                }
                tamanhoBtnCell();
                this.Resize += (s, e) => tamanhoBtnCell();
                this.Controls.Add(btnCell);
            }



        }
        void tamanhoBtnCell()
        {

            if (btnCell != null) {
                btnCell.Size = new Size(this.ClientSize.Width / 4, this.ClientSize.Height / 4);
                btnCell.Location = new Point(
                    (this.ClientSize.Width / 2),
                    (this.ClientSize.Height / 2)
                    );
            }

        }
        PictureBox pcelular;

        void abrirCelular()
        {
            if (pcelular == null)
            {
                pcelular = new PictureBox();
                pcelular.Image = Properties.Resources.celular;
                pcelular.BackColor = Color.Transparent;
                pcelular.SizeMode = PictureBoxSizeMode.StretchImage;
                tamanhoCelular();
                this.Controls.Add(pcelular);
                timerC.Start();
                this.Resize += (s, e) => tamanhoCelular();
            }
        }

        PictureBox prova;
        void abrirProva()
        {
            if (prova == null)
            {
                prova = new PictureBox();
                prova.Image = Properties.Resources.celular;
                prova.BackColor = Color.Transparent;
                prova.SizeMode = PictureBoxSizeMode.StretchImage;
                tamanhoCelular();
                this.Controls.Add(prova);
                this.Resize += (s, e) => tamanhoCelular();
            }
        }

        void tamanhoCelular()
        {
            if (pcelular != null)
            {
                pcelular.Size = new Size
                    (
                    this.ClientSize.Width / 2,
                    (int)((this.ClientSize.Height / 2) * 1.77)
                    );
                pcelular.Location = new Point(
                    (this.ClientSize.Width - pcelular.Width),
                    (this.ClientSize.Height - pcelular.Height)
                    );

            }
        }
        void fecharCelular()
        {
            if (pcelular != null)
            {
                this.Controls.Remove(pcelular);
                pcelular.Dispose();
                pcelular = null;
            }
        }
        void pararCelular()
        { 
            timerC.Stop();
            tempoRespo = 0;
            lblRespostas.Text = "0";
        }
        async Task transicaoCelular()
        {
            direcao = 3;
            if (btnCell != null)
            {
                this.Controls.Remove(btnCell);
                btnCell.Dispose();
                btnCell = null;
            }
            criarTransicao();
            transicao.Image = Properties.Resources.ltoc;
            this.Controls.Add(transicao);
            await Task.Delay(1000);
            this.Controls.Remove(transicao);
            transicao.Dispose();
            transicao = null;
            lbldirecao.Text = "direcao: " + direcao;
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
            lbldirecao.Text = "direcao: " + direcao;
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
            lbldirecao.Text = "direcao: " + direcao;

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
            lbldirecao.Text = "direcao: " + direcao;
        }
        async Task transicaoLousa3()
        {

            desabilitarBotoes();
            criarTransicao();
            transicao.Image = Properties.Resources.ctol;
            this.Controls.Add(transicao);
            await Task.Delay(1000);
            this.Controls.Remove(transicao);
            transicao.Dispose();
            transicao = null;
            direcao = 0;
            lbldirecao.Text = "direcao: " + direcao;
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
            lbldirecao.Text = "direcao: " + direcao;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(1366, 768);
            criarbtnD();
            criarbtnE();
            criarbtnB();

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
                    criarbtnB();
                    break;
                default:
                    break;
            }

        }
        private async void btnMoverB_MouseEnter(object sender, EventArgs e)
        {
            desabilitarBotoes();
            switch (direcao)
            {
                case 0:
                    await transicaoCelular();
                    this.BackgroundImage = Properties.Resources.czoom;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    criarbtnAbrirC();
                    criarbtnC();
                    if (celular == 1)
                    { 
                        abrirCelular();
                    }
                    break;
                default:
                    break;
            }

        }
        private async void btnMoverC_MouseEnter(object sender, EventArgs e)
        {
            desabilitarBotoes();
            switch (direcao)
            {
                case 3:
                    desabilitarBotoes();
                        fecharCelular();
                    await transicaoLousa3();
                    this.BackgroundImage = Properties.Resources.fv2;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    criarbtnD();
                    criarbtnE();
                    criarbtnB();
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
                    criarbtnB();
                    break;
                default:
                    break;
            }
        }
        private async void btnCell_MouseEnter(object sender, EventArgs e)
        {
            if (celular == 1)
            {
                btnCell.Text = "Abrir celular";
                fecharCelular();
                celular = 0;
                lblteste.Text = "teste: " + celular;
                pararCelular();
                return;
            }
            if (celular == 0)
            {
                abrirCelular();
                btnCell.Text = "Fechar celular";
                celular = 1;
                lblteste.Text = "teste: " + celular;
                return;
            }
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

    }
}

