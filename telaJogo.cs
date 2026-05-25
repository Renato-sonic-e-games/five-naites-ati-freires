using five_naites_ati_freires.Properties;

namespace five_naites_ati_freires
{
    public partial class telaJogo : Form
    {
        public telaJogo()
        {
            InitializeComponent();
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
        Button btnProva;
        PictureBox transicao;
        PictureBox telaPreta;
        int centroY = 0;
        int aProva = 0;
        int opacidade = 0;

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (direcao == -1)
            {
                tamanhoBtnMenu();
            }
            tamanhoBtnCell();
            tamanhoBtnProva();
            tamanhoCelular();
            tamanhoProva();
            tamanhoTransicao();
            tamanhoBtnC();
        }
        private void timerPopup_Tick(object sender, EventArgs e)
        {
            centroY = this.ClientSize.Height / 2 - (prova.Height / 2);
            if (prova.Top > centroY)
            {
                prova.Top -= centroY / 2;
                aProva = prova.Top;
            }
            else
            {
                prova.Top = centroY;
            }
            if (opacidade < 150)
            {
                opacidade += 25;
                telaPreta.BackColor = Color.FromArgb(opacidade, 0, 0, 0);
            }
            if (prova.Top == centroY && opacidade >= 150)
            {
                timerPopup.Stop();
            }
        }
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
                btnMoverD.Visible = false;

            if (btnMoverE != null)
                btnMoverE.Visible = false;

            if (btnMoverB != null)
                btnMoverB.Visible = false;

            if (btnMoverC != null)
                btnMoverC.Visible = false;

            if (btnCell != null)
                btnCell.Visible = false;

            if (btnProva != null)
                btnProva.Visible = false;
        }
        void desabilitarLabels()
        {
            lblC.Visible = false;
            lblContador.Visible = false;
            lbldirecao.Visible = false;
            lblRespostas.Visible = false;
            lblteste.Visible = false;
        }
        void habilitarLabels()
        {
            lblC.Visible = true;
            lblContador.Visible = true;
            lbldirecao.Visible = true;
            lblRespostas.Visible = true;
            lblteste.Visible = true;
        }
        void criarTelaPreta()
        {
            opacidade = 0;
            telaPreta = new PictureBox();
            telaPreta.Width = this.ClientSize.Width;
            telaPreta.Height = this.ClientSize.Height;
            telaPreta.BackColor = Color.FromArgb(opacidade, 0, 0, 0);
            telaPreta.MouseClick += (s, e) =>
            {
                fecharProva();
                telaPreta.Visible = false;
            };
            this.Controls.Add(telaPreta);
        }
        void criarTransicao()
        {
            if (transicao == null)
            {
                transicao = new PictureBox();
                transicao.Width = this.ClientSize.Width;
                transicao.Height = this.ClientSize.Height;
                transicao.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(transicao);
            }
            transicao.Visible = true;
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
            btnMoverE.Visible = true;
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
            btnMoverB.Visible = true;
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
            btnMoverD.Visible = true;
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
                tamanhoBtnC();
                this.Controls.Add(btnMoverC);
            }
            btnMoverC.Visible = true;
        }
        void tamanhoBtnC()
        {
            if (btnMoverC != null)
            {
                btnMoverC.Size = new Size(this.ClientSize.Width, this.ClientSize.Height / 8);
                btnMoverC.Location = new Point(0, 0);
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
                this.Controls.Add(btnCell);
            }
            btnCell.Visible = true;
        }

        void criarbtnAbrirP()
        {
            if (btnProva == null)
            {
                btnProva = new Button();
                btnProva.BackColor = Color.White;
                btnProva.FlatStyle = FlatStyle.Flat;
                btnProva.Cursor = Cursors.Hand;
                btnProva.FlatAppearance.BorderSize = 0;
                btnProva.MouseClick += btnProva_MouseEnter;
                btnProva.Text = "Abrir Prova";

                tamanhoBtnProva();
                this.Controls.Add(btnProva);
            }
            btnProva.Visible = true;
        }

        void tamanhoBtnCell()
        {

            if (btnCell != null)
            {
                btnCell.Size = new Size(this.ClientSize.Width, this.ClientSize.Height / 8);
                btnCell.Location = new Point(
                    (0),
                    (this.ClientSize.Height - btnCell.Height)
                    );
            }

        }

        void tamanhoBtnProva()
        {

            if (btnProva != null)
            {
                btnProva.Size = new Size(this.ClientSize.Width / 2, this.ClientSize.Height / 2);
                btnProva.Location = new Point(
                    (this.ClientSize.Width / 2 - (btnProva.Width / 2)),
                    (this.ClientSize.Height / 2 - (btnProva.Height / 2))
                    );
            }

        }
        void tamanhoBtnMenu()
        {
            btnJogar.Size = new Size
                ((this.ClientSize.Width * 130) / 816,
                (this.ClientSize.Height * 60) / 489
                );
            btnJogar.Location = new Point(
                (this.ClientSize.Width * 331) / 816,
                (this.ClientSize.Height * 195) / 489
                );
        }
        void tamanhoTransicao()
        {
            if (transicao != null)
            {
                transicao.Width = this.ClientSize.Width;
                transicao.Height = this.ClientSize.Height;
                transicao.SizeMode = PictureBoxSizeMode.StretchImage;
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

        PictureBox prova;
        void abrirProva()
        {
            if (prova == null)
            {
                prova = new PictureBox();
                prova.Image = Properties.Resources.prova;
                prova.BackColor = Color.Transparent;
                prova.SizeMode = PictureBoxSizeMode.StretchImage;
                tamanhoProva();
                this.Controls.Add(prova);
            }
            aProva = this.ClientSize.Height;
            tamanhoProva();
            prova.Visible = true;
            prova.BringToFront();
        }
        void fecharProva()
        {
            prova.Visible = false;
            criarbtnC();
            criarbtnAbrirC();
            criarbtnAbrirP();
        }


        void tamanhoProva()
        {
            if (prova != null)
            {
                prova.Size = new Size(
                    (int)((this.ClientSize.Width) * 0.80),
                    (int)((this.ClientSize.Height) * 0.80)
                );

                prova.Location = new Point(
                    (this.ClientSize.Width / 2 - (prova.Width / 2)),
                    (aProva)
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
            transicao.Image = Properties.Resources.ltoc2;
            await Task.Delay(950);
            transicao.Visible = false;
            lbldirecao.Text = "direcao: " + direcao;
        }
        async Task transicaoLousa()
        {

            desabilitarBotoes();
            criarTransicao();
            transicao.Image = Properties.Resources.wtol2;
            await Task.Delay(1000);
            transicao.Visible = false;
            direcao = 0;
            lbldirecao.Text = "direcao: " + direcao;
        }
        async Task transicaoJanela()
        {

            direcao = 1;
            criarTransicao();
            transicao.Image = Properties.Resources.ltow2;
            await Task.Delay(1000);
            transicao.Visible = false;
            lbldirecao.Text = "direcao: " + direcao;

        }
        async Task transicaoLousa2()
        {

            desabilitarBotoes();
            criarTransicao();
            transicao.Image = Properties.Resources.dtol2;
            await Task.Delay(1000);
            transicao.Visible = false;
            direcao = 0;
            lbldirecao.Text = "direcao: " + direcao;
        }
        async Task transicaoLousa3()
        {

            desabilitarBotoes();
            criarTransicao();
            transicao.Image = Properties.Resources.ctol2;
            await Task.Delay(950);
            transicao.Visible = false;
            direcao = 0;
            lbldirecao.Text = "direcao: " + direcao;
        }
        async Task transicaoPorta()
        {

            direcao = 2;

            desabilitarBotoes();
            criarTransicao();
            transicao.Image = Properties.Resources.ltod2;
            await Task.Delay(1000);
            transicao.Visible = false;
            lbldirecao.Text = "direcao: " + direcao;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            direcao = -1;
            this.Resize += Form1_Resize;
            this.ClientSize = new Size(1366, 768);
            desabilitarLabels();
        }
        void iniciarJogo()
        {
            timerGeral.Start();
            direcao = 0;
            habilitarLabels();
            this.BackgroundImage = Resources.fv4;
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
                    this.BackgroundImage = Properties.Resources.paredeJanelaZoom;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    criarbtnE();
                    break;
                case 2:
                    await transicaoLousa2();
                    this.BackgroundImage = Properties.Resources.fv4;
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
                    this.BackgroundImage = Properties.Resources.cv3;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    criarbtnAbrirC();
                    criarbtnC();
                    criarbtnAbrirP();
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
                    this.BackgroundImage = Properties.Resources.fv4;
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
                    this.BackgroundImage = Properties.Resources.portaZoomAberta;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    criarbtnD();
                    break;
                case 1:
                    await transicaoLousa();
                    this.BackgroundImage = Properties.Resources.fv4;
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

        private async void btnProva_MouseEnter(object sender, EventArgs e)
        {
            criarTelaPreta();
            abrirProva();
            timerPopup.Start();
            desabilitarBotoes();
            return;
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.E)
            {
            }
        }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            iniciarJogo();
            btnJogar.Visible = false;
        }

        private void btnJogar_MouseEnter(object sender, EventArgs e)
        {
            this.btnJogar.BackgroundImage = Resources.BotãoJogarSelecionado2;
        }

        private void btnJogar_MouseLeave(object sender, EventArgs e)
        {
            this.btnJogar.BackgroundImage = Resources.BotãoJogar;
        }
    }
}

