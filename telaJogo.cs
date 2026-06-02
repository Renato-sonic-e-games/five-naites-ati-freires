using five_naites_ati_freires.Properties;
using Microsoft.Win32;
using NAudio.Wave;
using System.Diagnostics;
using System.Net.PeerToPeer.Collaboration;

namespace five_naites_ati_freires
{


    public partial class telaJogo : Form
    {
        //jogo principau:
        bool morreu;

        public telaJogo()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            lblFreirep.Visible = false;
            criarMenuInicial();
        }
        void criarMenuInicial()
        {

            direcao = -1;
            this.Resize += Form1_Resize;
            this.ClientSize = new Size(1366, 768);
            desabilitarLabels();
            musicaReader = new AudioFileReader("musgas/ttscreen.m4a");
            musicaPlayer = new WaveOutEvent();
            TrocarMusica("musgas/ttscreen.m4a");
        }
        void iniciarJogo()
        {
            morreu = false;

            TrocarMusica("musgas/game.m4a");
            timerFreirezada.Start();
            timerGeral.Start();
            direcao = 0;
            perguntas = 0;
            this.BackgroundImage = sala;
            criarbtnE();
            criarbtnD();
            criarbtnB();
            spawnarBotoes();
            verificaNrP();
            verificarFreire();
        }
        void tiraromenudatela()
        {
            btnajuda.Visible = false;
            btnJogar.Visible = false;
            btnSair.Visible = false;
            btnopcao.Visible = false;
        }
        void colocaromenudatela()
        {
            btnajuda.Visible = true;
            btnJogar.Visible = true;
            btnSair.Visible = true;
            btnopcao.Visible = true;
        }

        PictureBox jumpscare;
        async Task gameover()
        {
            if (morreu) return;
            morreu = true;
            if (jumpscare == null)
            {
                jumpscare = new PictureBox();
                jumpscare.Width = this.ClientSize.Width;
                jumpscare.Height = this.ClientSize.Height;
                jumpscare.Image = Properties.Resources.freire_jumpscare;
                jumpscare.SizeMode = PictureBoxSizeMode.StretchImage;
                jumpscare.Location = new Point(
                     (this.ClientSize.Width - jumpscare.Width) / 2,
                     (this.ClientSize.Height - jumpscare.Height) / 2);
                jumpscare.BackColor = Color.Transparent;
            }
            else
            {
                jumpscare.Image = Properties.Resources.freire_jumpscare;
                jumpscare.Visible = true;
            }
            jumpscare.BringToFront();
            this.Controls.Add(jumpscare);
            TrocarMusica("musgas/nada.mp3");
            TocarSom("sons/Jumpscare.m4a");
            if (pcelular != null)
                fecharCelular();
            if (prova != null)
                fecharProva();
            desabilitarTelaPreta();
            desabilitarBotoes();
            timerGeral.Stop();
            timerC.Stop();
            timerFreirezada.Stop();
            timerPopup.Stop();
            musicaPlayer.Stop();
            await Task.Delay(2150);
            jumpscare.Visible = false;
            this.BackgroundImage = null;
            this.BackColor = Color.Black;
            await Task.Delay(3000);
            this.BackgroundImage = Properties.Resources.gameOverFull;
            TrocarMusica("musgas/over.m4a");
        }

        // audio
        private List<WaveOutEvent> players = new();
        private List<AudioFileReader> readers = new();

        private WaveOutEvent musicaPlayer;
        private AudioFileReader musicaReader;
        void TrocarMusica(string arquivo)
        {
            musicaPlayer?.Stop();
            musicaPlayer?.Dispose();
            musicaReader?.Dispose();

            musicaReader = new AudioFileReader(arquivo);
            musicaPlayer = new WaveOutEvent();

            musicaPlayer.PlaybackStopped += MusicaTerminou;

            musicaPlayer.Init(musicaReader);
            musicaPlayer.Play();
        }
        private void TocarSom(string arquivo)
        {
            var reader = new AudioFileReader(arquivo);
            var player = new WaveOutEvent();

            player.Init(reader);
            player.Play();

            player.PlaybackStopped += (s, e) =>
            {
                player.Dispose();
                reader.Dispose();

                players.Remove(player);
                readers.Remove(reader);
            };
            readers.Add(reader);
            players.Add(player);
        }
        private void MusicaTerminou(object? sender, StoppedEventArgs e)
        {
            musicaReader.Position = 0;
            musicaPlayer.Play();
        }

        // freire

        int agressividadeFreire;
        int lvlAgressividadeFreire = 10;
        int posicaoFreire = 1;
        // -1 = fora da visão
        // 0 = porta longe
        // 1 = porta
        // 2 = janela
        // 3 = sala
        Random random = new Random();
        int tempos = 0;
        int tempoFreire = 15;
        int moverFreire;
        // 1 esquerda
        // 2 direita
        Image pfCorrendo = Properties.Resources.pfcorreno;
        private async void timerFreirezada_Tick(object sender, EventArgs e)
        {
            tempos++;
            if ((tempos % tempoFreire) == 0)
            {
                agressividadeFreire = random.Next(1, 3);
                if (agressividadeFreire <= lvlAgressividadeFreire)
                {
                    moverFreire = random.Next(1, 3);
                    switch (posicaoFreire)
                    {
                        case -1:
                            if (moverFreire == 1)
                            {
                                posicaoFreire = 0;
                            }
                            else
                            {
                                posicaoFreire = 2;
                            }
                            break;
                        case 0:
                            if ((direcao == 2) && (portaAberta == true))
                            {
                                this.BackgroundImage = Resources.pZoom;
                                portaAberta = false;
                                TocarSom("sons/fechando1.wav");
                            }
                            if (moverFreire == 1)
                            {
                                posicaoFreire = 1;
                            }
                            else
                            {
                                posicaoFreire = -1;
                            }
                            break;
                        case 1:
                            if ((direcao == 2) && (portaAberta == true))
                            {
                                this.BackgroundImage = Resources.pZoom;
                                portaAberta = false;
                                TocarSom("sons/fechando1.wav");
                            }
                            if (moverFreire == 1)
                            {
                                posicaoFreire = 3;
                            }
                            else
                            {

                                posicaoFreire = 0;
                            }
                            break;
                        case 2:
                            posicaoFreire = 3;
                            break;
                        case 3:
                            if (direcao != 3)
                                await Blecaute();
                            if (moverFreire == 1)
                            {
                                posicaoFreire = 1;
                            }
                            else
                            {
                                posicaoFreire = 0;
                            }
                            break;
                    }
                }
                verificarFreire();
                //  lblFreirep.Text = "lvl agressividade freire: " + lvlAgressividadeFreire + " | \r\n posicao freire: " + posicaoFreire + " | \r\n freire agressividade: " + agressividadeFreire;
            }
        }
        Panel telaP;
        async Task Blecaute()
        {
            if (morreu)
                return;
            if (telaP == null)
            {
                telaP = new Panel();
                telaP.Size = this.ClientSize;
                telaP.Location = new Point(0, 0);
                this.Controls.Add(telaP);
                telaP.BackColor = Color.Black;

            }
            telaP.BringToFront();
            telaP.Visible = true;

            await Task.Delay(450);

            telaP.Visible = false;
        }
        async Task verificarFreire()
        {
            sala = Properties.Resources.fv4;
            portaaberta = Properties.Resources.portaZoomAberta;

            switch (posicaoFreire)
            {
                case 3:
                    if (celular == 1)
                    {
                        gameover();
                    }
                    if (direcao != 3)
                        await Blecaute();
                    sala = Properties.Resources.fv5_freire_;
                    break;

                case 2:
                    if (direcao == 1)
                    {
                        await criarPFcorreno();
                        posicaoFreire = 3;
                    }
                    break;
                case 1:
                    portaaberta = Properties.Resources.pfportaperto;
                    break;
                case 0:
                    portaaberta = Properties.Resources.pfportalonge;
                    break;
                default:
                    break;
            }

            switch (direcao)
            {
                case 0:
                    this.BackgroundImage = sala;
                    break;
                case 2:
                    if (portaAberta == true)
                    {
                        this.BackgroundImage = portaaberta;
                    }
                    break;
            }
        }
        void aumentarLvlAgressividade()
        {
            tempoFreire--;
            lvlAgressividadeFreire += 2;
        }
        PictureBox pfcorrendo;
        async Task criarPFcorreno()
        {
            if (pfcorrendo == null)
            {
                pfcorrendo = new PictureBox();
                pfcorrendo.Width = this.ClientSize.Width;
                pfcorrendo.Height = this.ClientSize.Height;
                pfcorrendo.Image = Properties.Resources.Paulofreire_janela;
                pfcorrendo.SizeMode = PictureBoxSizeMode.StretchImage;
                pfcorrendo.Location = new Point(0, 0);
                pfcorrendo.BackColor = Color.Transparent;
                this.Controls.Add(pfcorrendo);
            }
            else
            {
                pfcorrendo.Image = null;
                pfcorrendo.Image = Properties.Resources.Paulofreire_janela;
            }
            pfcorrendo.SendToBack();
            pfcorrendo.Visible = true;
            TocarSom("sons/Running.wav");
            await Task.Delay(550);
            pfcorrendo.Visible = false;
            await Task.Delay(3000);
            posicaoFreire = 3;
            verificarFreire();
        }

        //celular
        async Task TransicaoFecharCelular()
        {
            if (celular == 1)
            {
                TocarSom("sons/igptri.m4a");
                fecharCelular();
                pararCelular();
                btnCell.Visible = false;
                TransicaoCellFechando();
                desabilitarBotoes();
                await Task.Delay(450);
                btnCell.Visible = true;
                transicaoCellFechando.Visible = false;
                celular = 0;
                lblteste.Text = "teste: " + celular;
                btnCell.Visible = false;
                await Task.Delay(450);
                btnCell.Visible = true;
                criarbtnC();
                criarbtnAbrirP();
                criarbtnAbrirC();

                return;
            }
}

        Button btnCell;

        PictureBox pcelular;
        void abrirCelular()
        {
            if (pcelular == null)
            {
                pcelular = new PictureBox();
                pcelular.Image = Properties.Resources.celularCarregano;
                pcelular.BackColor = Color.Transparent;
                pcelular.SizeMode = PictureBoxSizeMode.StretchImage;
                pcelular.MouseClick += (s, e) =>
                {
                    TransicaoFecharCelular();
                };
                tamanhoCelular();
                this.Controls.Add(pcelular);
            }
            pcelular.BringToFront();
            if (resposta == 0)
            {
                pcelular.Image = Properties.Resources.celularCarregano;
            }
            else
            {
                pcelular.Image = Properties.Resources.celularRespo;
            }
            pcelular.Visible = true;
            timerC.Start();
        }
        void fecharCelular()
        {
            if (pcelular != null)
            {
                pcelular.Visible = false;
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
            transicao.BringToFront();
            transicao.Image = Properties.Resources.ltoc2;
            await Task.Delay(950);
            transicao.Visible = false;
            lbldirecao.Text = "direcao: " + direcao;
        }
        PictureBox transicaoCel;
        void TransicaoCell()
        {
            if (transicaoCel == null)
            {
                transicaoCel = new PictureBox();
                transicaoCel.Image = Properties.Resources.transicaoCelular;
                transicaoCel.BackColor = Color.Transparent;
                transicaoCel.SizeMode = PictureBoxSizeMode.StretchImage;
                tamanhoCelular();
                this.Controls.Add(transicaoCel);
            }
            else
            {
                transicaoCel.Image = null;
                transicaoCel.Image = Properties.Resources.transicaoCelular;
            }
            transicaoCel.BringToFront();
            transicaoCel.Visible = true;
        }
        PictureBox transicaoCellFechando;
        void TransicaoCellFechando()
        {
            if (transicaoCellFechando == null)
            {
                transicaoCellFechando = new PictureBox();
                transicaoCellFechando.Image = Properties.Resources.fechandocelular;
                transicaoCellFechando.BackColor = Color.Transparent;
                transicaoCellFechando.SizeMode = PictureBoxSizeMode.StretchImage;
                tamanhoCelular();
                this.Controls.Add(transicaoCellFechando);
            }
            else
            {
                transicaoCellFechando.Image = null;
                transicaoCellFechando.Image = Properties.Resources.fechandocelular;
            }
            transicaoCellFechando.Visible = true;
            transicaoCellFechando.BringToFront();
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
            if (transicaoCel != null)
            {
                transicaoCel.Size = new Size
                    (
                    this.ClientSize.Width / 2,
                    (int)((this.ClientSize.Height / 2) * 1.77)
                    );
                transicaoCel.Location = new Point(
                    (this.ClientSize.Width - transicaoCel.Width),
                    (this.ClientSize.Height - transicaoCel.Height)
                    );
                if (transicaoCellFechando != null)
                {
                    transicaoCellFechando.Size = new Size
                        (
                        this.ClientSize.Width / 2,
                        (int)((this.ClientSize.Height / 2) * 1.77)
                        );
                    transicaoCellFechando.Location = new Point(
                        (this.ClientSize.Width - transicaoCellFechando.Width),
                        (this.ClientSize.Height - transicaoCellFechando.Height)
                        );
                }
            }
        }
        async Task criarbtnAbrirC()
        {
            if (btnCell == null)
            {
                btnCell = new Button();
                btnCell.BackColor = Color.Transparent;
                btnCell.FlatStyle = FlatStyle.Flat;
                btnCell.FlatAppearance.MouseDownBackColor = Color.Transparent;
                btnCell.FlatAppearance.MouseOverBackColor = Color.Transparent;
                btnCell.ForeColor = Color.Transparent;
                btnCell.Cursor = Cursors.Hand;
                btnCell.FlatAppearance.BorderSize = 0;
                btnCell.MouseClick += btnCell_MouseEnter;
                tamanhoBtnCell();
                this.Controls.Add(btnCell);
                btnCell.SendToBack();
            }
            btnCell.Visible = true;
        }
        void tamanhoBtnCell()
        {

            if (btnCell != null)
            {
                btnCell.Size = new Size(this.ClientSize.Width, this.ClientSize.Height / 4);
                btnCell.Location = new Point(
                (0),
                (this.ClientSize.Height - btnCell.Height)
                );
            }

        }
        private async void btnCell_MouseEnter(object sender, EventArgs e)
        {
            if (celular == 1)
            {
                TocarSom("sons/igptri.m4a");
                fecharCelular();
                pararCelular();
                btnCell.Visible = false;
                TransicaoCellFechando();
                desabilitarBotoes();
                await Task.Delay(450);
                btnCell.Visible = true;
                transicaoCellFechando.Visible = false;
                celular = 0;
                lblteste.Text = "teste: " + celular;
                btnCell.Visible = false;
                await Task.Delay(450);
                btnCell.Visible = true;
                criarbtnC();
                criarbtnAbrirP();
                criarbtnAbrirC();

                return;
            }
            if (celular == 0)
            {
                TocarSom("sons/igptiniciar.m4a");
                btnCell.Visible = false;
                desabilitarBotoes();
                TransicaoCell();
                await Task.Delay(450);
                btnCell.Visible = true;
                transicaoCel.Visible = false;
                abrirCelular();
                celular = 1;
                lblteste.Text = "teste: " + celular;
                if (posicaoFreire == 3)
                {
                    gameover();
                    return;
                }
                criarbtnC();
                criarbtnAbrirP();
                criarbtnAbrirC();

                return;
            }
        }
        private void timerC_Tick(object sender, EventArgs e)
        {
            tempoRespo++;
            int respostaEscala = (perguntas * 5) + 10;
            if (resposta != 1)
            {
                if (tempoRespo == respostaEscala)
                {
                    resposta = 1;
                    timerC.Stop();
                    pcelular.Image = Properties.Resources.celularRespo;
                    TocarSom("sons/resenhado.m4a");
                    tempoRespo = 0;
                }
            }
            else
            {
                tempoRespo = 0;
                timerC.Stop();
            }
            lblC.Text = "nr res: " + resposta;
            int porcentagem = Math.Min(100,
            tempoRespo * 100 / respostaEscala);

            lblRespostas.Text = $"tempo celular: {porcentagem}%";
        }

        // Prova
        int tempoRespo = 0;
        int resposta = 0;
        int perguntas = 0;
        Button btnProva;
        PictureBox telaPreta;
        int centroY = 0;
        int aProva = 0;
        int opacidade = 0;

        Button[] btnPr = new Button[21];
        List<Button> botoesProva;
        void verificaNrP()
        {
            foreach (Button btn in botoesProva)
            {
                btn.Enabled = false;
            }
            switch (perguntas)
            {
                case 0:
                    btnPr[1].Enabled = true;
                    btnPr[2].Enabled = true;
                    btnPr[3].Enabled = true;
                    btnPr[4].Enabled = true;
                    break;
                case 1:
                    btnPr[5].Enabled = true;
                    btnPr[6].Enabled = true;
                    btnPr[7].Enabled = true;
                    btnPr[8].Enabled = true;
                    break;
                case 2:
                    btnPr[9].Enabled = true;
                    btnPr[10].Enabled = true;
                    btnPr[11].Enabled = true;
                    btnPr[12].Enabled = true;
                    break;
                case 3:
                    btnPr[13].Enabled = true;
                    btnPr[14].Enabled = true;
                    btnPr[15].Enabled = true;
                    btnPr[16].Enabled = true;
                    break;
                case 4:
                    btnPr[17].Enabled = true;
                    btnPr[18].Enabled = true;
                    btnPr[19].Enabled = true;
                    btnPr[0].Enabled = true;
                    break;
                case 5:
                    desabilitarBotoes();
                    timerC.Stop();
                    timerGeral.Stop();
                    timerFreirezada.Stop();
                    timerPopup.Stop();
                    criarbtnvoltar();
                    this.BackgroundImage = Properties.Resources.gameWon;
                    break;
            }
        }
        void criarBotoesP()
        {
            btnPr[1] = new Button();
            btnPr[2] = new Button();
            btnPr[3] = new Button();
            btnPr[4] = new Button();
            btnPr[5] = new Button();
            btnPr[6] = new Button();
            btnPr[7] = new Button();
            btnPr[8] = new Button();
            btnPr[9] = new Button();
            btnPr[10] = new Button();
            btnPr[11] = new Button();
            btnPr[12] = new Button();
            btnPr[13] = new Button();
            btnPr[14] = new Button();
            btnPr[15] = new Button();
            btnPr[16] = new Button();
            btnPr[17] = new Button();
            btnPr[18] = new Button();
            btnPr[19] = new Button();
            btnPr[0] = new Button();
            // 
            // btnPr[1]
            // 
            btnPr[1].BackColor = Color.Transparent;
            btnPr[1].BackgroundImage = Properties.Resources.p1;
            btnPr[1].BackgroundImageLayout = ImageLayout.Center;
            btnPr[1].FlatAppearance.BorderSize = 0;
            btnPr[1].FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPr[1].FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPr[1].FlatStyle = FlatStyle.Flat;
            btnPr[1].Location = new Point(170, 272);
            btnPr[1].Name = "btnPr[1]";
            btnPr[1].Size = new Size(136, 29);
            btnPr[1].TabIndex = 20;
            btnPr[1].UseVisualStyleBackColor = false;
            btnPr[1].MouseClick += btnRespostaE_MouseEnter;
            // 
            // btnPr[2]
            // 
            btnPr[2].BackColor = Color.Transparent;
            btnPr[2].BackgroundImage = Properties.Resources.p2;
            btnPr[2].BackgroundImageLayout = ImageLayout.Center;
            btnPr[2].FlatAppearance.BorderSize = 0;
            btnPr[2].FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPr[2].FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPr[2].FlatStyle = FlatStyle.Flat;
            btnPr[2].Location = new Point(327, 272);
            btnPr[2].Name = "btnPr[2]";
            btnPr[2].Size = new Size(136, 29);
            btnPr[2].TabIndex = 21;
            btnPr[2].UseVisualStyleBackColor = false;
            btnPr[2].MouseClick += btnRespostaE_MouseEnter;
            // 
            // btnPr[3]
            // 
            btnPr[3].BackColor = Color.Transparent;
            btnPr[3].BackgroundImage = Properties.Resources.p3;
            btnPr[3].BackgroundImageLayout = ImageLayout.Center;
            btnPr[3].FlatAppearance.BorderSize = 0;
            btnPr[3].FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPr[3].FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPr[3].FlatStyle = FlatStyle.Flat;
            btnPr[3].Location = new Point(170, 307);
            btnPr[3].Name = "btnPr[3]";
            btnPr[3].Size = new Size(136, 29);
            btnPr[3].TabIndex = 22;
            btnPr[3].UseVisualStyleBackColor = false;
            btnPr[3].MouseClick += btnRespostaC_MouseEnter;
            // 
            // btnPr[4]
            // 
            btnPr[4].BackColor = Color.Transparent;
            btnPr[4].BackgroundImage = Properties.Resources.p4;
            btnPr[4].BackgroundImageLayout = ImageLayout.Center;
            btnPr[4].FlatAppearance.BorderSize = 0;
            btnPr[4].FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPr[4].FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPr[4].FlatStyle = FlatStyle.Flat;
            btnPr[4].Location = new Point(327, 307);
            btnPr[4].Name = "btnPr[4]";
            btnPr[4].Size = new Size(182, 29);
            btnPr[4].TabIndex = 23;
            btnPr[4].UseVisualStyleBackColor = false;
            btnPr[4].MouseClick += btnRespostaE_MouseEnter;
            // 
            // btnPr[5]
            // 
            btnPr[5].BackColor = Color.Transparent;
            btnPr[5].BackgroundImage = Properties.Resources.p5;
            btnPr[5].BackgroundImageLayout = ImageLayout.Center;
            btnPr[5].FlatAppearance.BorderSize = 0;
            btnPr[5].FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPr[5].FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPr[5].FlatStyle = FlatStyle.Flat;
            btnPr[5].Location = new Point(181, 392);
            btnPr[5].Name = "btnPr[5]";
            btnPr[5].Size = new Size(392, 29);
            btnPr[5].TabIndex = 24;
            btnPr[5].UseVisualStyleBackColor = false;
            btnPr[5].MouseClick += btnRespostaE_MouseEnter;
            // 
            // btnPr[6]
            // 
            btnPr[6].BackColor = Color.Transparent;
            btnPr[6].BackgroundImage = Properties.Resources.p6;
            btnPr[6].BackgroundImageLayout = ImageLayout.Center;
            btnPr[6].FlatAppearance.BorderSize = 0;
            btnPr[6].FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPr[6].FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPr[6].FlatStyle = FlatStyle.Flat;
            btnPr[6].Location = new Point(181, 427);
            btnPr[6].Name = "btnPr[6]";
            btnPr[6].Size = new Size(282, 29);
            btnPr[6].TabIndex = 25;
            btnPr[6].UseVisualStyleBackColor = false;
            btnPr[6].MouseClick += btnRespostaE_MouseEnter;
            // 
            // btnPr[7]
            // 
            btnPr[7].BackColor = Color.Transparent;
            btnPr[7].BackgroundImage = Properties.Resources.p7;
            btnPr[7].BackgroundImageLayout = ImageLayout.Center;
            btnPr[7].FlatAppearance.BorderSize = 0;
            btnPr[7].FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPr[7].FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPr[7].FlatStyle = FlatStyle.Flat;
            btnPr[7].Location = new Point(181, 462);
            btnPr[7].Name = "btnPr[7]";
            btnPr[7].Size = new Size(282, 29);
            btnPr[7].TabIndex = 26;
            btnPr[7].UseVisualStyleBackColor = false;
            btnPr[7].MouseClick += btnRespostaC_MouseEnter;
            // 
            // btnPr[8]
            // 
            btnPr[8].BackColor = Color.Transparent;
            btnPr[8].BackgroundImage = Properties.Resources.p8;
            btnPr[8].BackgroundImageLayout = ImageLayout.Center;
            btnPr[8].FlatAppearance.BorderSize = 0;
            btnPr[8].FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPr[8].FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPr[8].FlatStyle = FlatStyle.Flat;
            btnPr[8].Location = new Point(181, 497);
            btnPr[8].Name = "btnPr[8]";
            btnPr[8].Size = new Size(282, 29);
            btnPr[8].TabIndex = 27;
            btnPr[8].UseVisualStyleBackColor = false;
            btnPr[8].MouseClick += btnRespostaE_MouseEnter;
            // 
            // btnPr[9]
            // 
            btnPr[9].BackColor = Color.Transparent;
            btnPr[9].BackgroundImage = Properties.Resources.p9;
            btnPr[9].BackgroundImageLayout = ImageLayout.Center;
            btnPr[9].FlatAppearance.BorderSize = 0;
            btnPr[9].FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPr[9].FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPr[9].FlatStyle = FlatStyle.Flat;
            btnPr[9].Location = new Point(181, 605);
            btnPr[9].Name = "btnPr[9]";
            btnPr[9].Size = new Size(147, 29);
            btnPr[9].TabIndex = 28;
            btnPr[9].UseVisualStyleBackColor = false;
            btnPr[9].MouseClick += btnRespostaE_MouseEnter;
            // 
            // btnPr[10]
            // 
            btnPr[10].BackColor = Color.Transparent;
            btnPr[10].BackgroundImage = Properties.Resources.p10;
            btnPr[10].BackgroundImageLayout = ImageLayout.Center;
            btnPr[10].FlatAppearance.BorderSize = 0;
            btnPr[10].FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPr[10].FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPr[10].FlatStyle = FlatStyle.Flat;
            btnPr[10].Location = new Point(327, 605);
            btnPr[10].Name = "btnPr[10]";
            btnPr[10].Size = new Size(147, 29);
            btnPr[10].TabIndex = 29;
            btnPr[10].UseVisualStyleBackColor = false;
            btnPr[10].MouseClick += btnRespostaE_MouseEnter;
            // 
            // btnPr[11]
            // 
            btnPr[11].BackColor = Color.Transparent;
            btnPr[11].BackgroundImage = Properties.Resources.p11;
            btnPr[11].BackgroundImageLayout = ImageLayout.Center;
            btnPr[11].FlatAppearance.BorderSize = 0;
            btnPr[11].FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPr[11].FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPr[11].FlatStyle = FlatStyle.Flat;
            btnPr[11].Location = new Point(181, 640);
            btnPr[11].Name = "btnPr[11]";
            btnPr[11].Size = new Size(147, 29);
            btnPr[11].TabIndex = 30;
            btnPr[11].UseVisualStyleBackColor = false;
            btnPr[11].MouseClick += btnRespostaC_MouseEnter;
            // 
            // btnPr[12]
            // 
            btnPr[12].BackColor = Color.Transparent;
            btnPr[12].BackgroundImage = Properties.Resources.p12;
            btnPr[12].BackgroundImageLayout = ImageLayout.Center;
            btnPr[12].FlatAppearance.BorderSize = 0;
            btnPr[12].FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPr[12].FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPr[12].FlatStyle = FlatStyle.Flat;
            btnPr[12].Location = new Point(327, 640);
            btnPr[12].Name = "btnPr[12]";
            btnPr[12].Size = new Size(147, 29);
            btnPr[12].TabIndex = 31;
            btnPr[12].UseVisualStyleBackColor = false;
            btnPr[12].MouseClick += btnRespostaE_MouseEnter;
            // 
            // btnPr[13]
            // 
            btnPr[13].BackColor = Color.Transparent;
            btnPr[13].BackgroundImage = Properties.Resources.p13;
            btnPr[13].BackgroundImageLayout = ImageLayout.Center;
            btnPr[13].FlatAppearance.BorderSize = 0;
            btnPr[13].FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPr[13].FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPr[13].FlatStyle = FlatStyle.Flat;
            btnPr[13].Location = new Point(691, 244);
            btnPr[13].Name = "btnPr[13]";
            btnPr[13].Size = new Size(415, 29);
            btnPr[13].TabIndex = 32;
            btnPr[13].UseVisualStyleBackColor = false;
            btnPr[13].MouseClick += btnRespostaE_MouseEnter;
            // 
            // btnPr[14]
            // 
            btnPr[14].BackColor = Color.Transparent;
            btnPr[14].BackgroundImage = Properties.Resources.p14;
            btnPr[14].BackgroundImageLayout = ImageLayout.Center;
            btnPr[14].FlatAppearance.BorderSize = 0;
            btnPr[14].FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPr[14].FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPr[14].FlatStyle = FlatStyle.Flat;
            btnPr[14].Location = new Point(691, 279);
            btnPr[14].Name = "btnPr[14]";
            btnPr[14].Size = new Size(415, 29);
            btnPr[14].TabIndex = 33;
            btnPr[14].UseVisualStyleBackColor = false;
            btnPr[14].MouseClick += btnRespostaE_MouseEnter;
            // 
            // btnPr[15]
            // 
            btnPr[15].BackColor = Color.Transparent;
            btnPr[15].BackgroundImage = Properties.Resources.p15;
            btnPr[15].BackgroundImageLayout = ImageLayout.Center;
            btnPr[15].FlatAppearance.BorderSize = 0;
            btnPr[15].FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPr[15].FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPr[15].FlatStyle = FlatStyle.Flat;
            btnPr[15].Location = new Point(691, 314);
            btnPr[15].Name = "btnPr[15]";
            btnPr[15].Size = new Size(415, 29);
            btnPr[15].TabIndex = 34;
            btnPr[15].UseVisualStyleBackColor = false;
            btnPr[15].MouseClick += btnRespostaC_MouseEnter;
            // 
            // btnPr[16]
            // 
            btnPr[16].BackColor = Color.Transparent;
            btnPr[16].BackgroundImage = Properties.Resources.p16;
            btnPr[16].BackgroundImageLayout = ImageLayout.Center;
            btnPr[16].FlatAppearance.BorderSize = 0;
            btnPr[16].FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPr[16].FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPr[16].FlatStyle = FlatStyle.Flat;
            btnPr[16].Location = new Point(691, 349);
            btnPr[16].Name = "btnPr[16]";
            btnPr[16].Size = new Size(465, 29);
            btnPr[16].TabIndex = 35;
            btnPr[16].UseVisualStyleBackColor = false;
            btnPr[16].MouseClick += btnRespostaE_MouseEnter;
            // 
            // btnPr[17]
            // 
            btnPr[17].BackColor = Color.Transparent;
            btnPr[17].BackgroundImage = Properties.Resources.p17;
            btnPr[17].BackgroundImageLayout = ImageLayout.Center;
            btnPr[17].FlatAppearance.BorderSize = 0;
            btnPr[17].FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPr[17].FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPr[17].FlatStyle = FlatStyle.Flat;
            btnPr[17].Location = new Point(691, 480);
            btnPr[17].Name = "btnPr[17]";
            btnPr[17].Size = new Size(292, 29);
            btnPr[17].TabIndex = 36;
            btnPr[17].UseVisualStyleBackColor = false;
            btnPr[17].MouseClick += btnRespostaE_MouseEnter;
            // 
            // btnPr[18]
            // 
            btnPr[18].BackColor = Color.Transparent;
            btnPr[18].BackgroundImage = Properties.Resources.p18;
            btnPr[18].BackgroundImageLayout = ImageLayout.Center;
            btnPr[18].FlatAppearance.BorderSize = 0;
            btnPr[18].FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPr[18].FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPr[18].FlatStyle = FlatStyle.Flat;
            btnPr[18].Location = new Point(691, 515);
            btnPr[18].Name = "btnPr[18]";
            btnPr[18].Size = new Size(292, 29);
            btnPr[18].TabIndex = 37;
            btnPr[18].UseVisualStyleBackColor = false;
            btnPr[18].MouseClick += btnRespostaE_MouseEnter;
            // 
            // btnPr[19]
            // 
            btnPr[19].BackColor = Color.Transparent;
            btnPr[19].BackgroundImage = Properties.Resources.p19;
            btnPr[19].BackgroundImageLayout = ImageLayout.Center;
            btnPr[19].FlatAppearance.BorderSize = 0;
            btnPr[19].FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPr[19].FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPr[19].FlatStyle = FlatStyle.Flat;
            btnPr[19].Location = new Point(691, 550);
            btnPr[19].Name = "btnPr[19]";
            btnPr[19].Size = new Size(292, 29);
            btnPr[19].TabIndex = 39;
            btnPr[19].UseVisualStyleBackColor = false;
            btnPr[19].MouseClick += btnRespostaC_MouseEnter;
            // 
            // btnPr[0]
            // 
            btnPr[0].BackColor = Color.Transparent;
            btnPr[0].BackgroundImage = Properties.Resources.p20;
            btnPr[0].BackgroundImageLayout = ImageLayout.Center;
            btnPr[0].FlatAppearance.BorderSize = 0;
            btnPr[0].FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPr[0].FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPr[0].FlatStyle = FlatStyle.Flat;
            btnPr[0].Location = new Point(691, 585);
            btnPr[0].Name = "btnPr[0]";
            btnPr[0].Size = new Size(292, 29);
            btnPr[0].TabIndex = 40;
            btnPr[0].UseVisualStyleBackColor = false;
            btnPr[0].MouseClick += btnRespostaE_MouseEnter;

            botoesProva = new List<Button>()
           {
             btnPr[1], btnPr[2], btnPr[3], btnPr[4],
             btnPr[5], btnPr[6], btnPr[7], btnPr[8],
             btnPr[9], btnPr[10], btnPr[11], btnPr[12],
             btnPr[13], btnPr[14], btnPr[15], btnPr[16],
             btnPr[17], btnPr[18], btnPr[19], btnPr[0]
            };
        }
        void spawnarBotoes()
        {
            if (btnPr[1] == null)
            {
                criarBotoesP();
                Controls.Add(btnPr[0]);
                Controls.Add(btnPr[19]);
                Controls.Add(btnPr[18]);
                Controls.Add(btnPr[17]);
                Controls.Add(btnPr[16]);
                Controls.Add(btnPr[15]);
                Controls.Add(btnPr[14]);
                Controls.Add(btnPr[13]);
                Controls.Add(btnPr[12]);
                Controls.Add(btnPr[11]);
                Controls.Add(btnPr[10]);
                Controls.Add(btnPr[9]);
                Controls.Add(btnPr[8]);
                Controls.Add(btnPr[7]);
                Controls.Add(btnPr[6]);
                Controls.Add(btnPr[5]);
                Controls.Add(btnPr[4]);
                Controls.Add(btnPr[3]);
                Controls.Add(btnPr[2]);
                Controls.Add(btnPr[1]);
                desabilitarBtnsProva();
            }
        }

        void desabilitarBtnsProva()
        {
            foreach (Button btn in botoesProva)
            {
                btn.Visible = false;
            }
        }
        void habilitarBtnsProva()
        {
            foreach (Button btn in botoesProva)
            {
                btn.Visible = true;
                btn.BringToFront();
            }
        }
        private async void btnRespostaE_MouseEnter(object sender, EventArgs e)
        {
            gameover();
        }
        private async void btnRespostaC_MouseEnter(object sender, EventArgs e)
        {
            if (resposta > 0)
            {
                aumentarLvlAgressividade();
                resposta--;
                lblRespostas.Text = "nr respostas: " + resposta;
                perguntas++;
                switch (perguntas)
                {
                    case 1:
                        btnPr[3].BackgroundImage = Properties.Resources.p3x;
                        break;
                    case 2:
                        btnPr[7].BackgroundImage = Properties.Resources.p7x;
                        break;
                    case 3:
                        btnPr[11].BackgroundImage = Properties.Resources.p11x;
                        break;
                    case 4:
                        btnPr[15].BackgroundImage = Properties.Resources.p15x;
                        break;
                    case 5:
                        btnPr[19].BackgroundImage = Properties.Resources.p19x;
                        break;
                    default:
                        break;
                }
                verificaNrP();

            }
            else
            {
                MessageBox.Show("Eu não posso chutar nessa prova...");
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
            TocarSom("sons/prova1.wav");
            prova.BringToFront();
        }
        void fecharProva()
        {
            prova.Visible = false;
            criarbtnC();
            criarbtnAbrirC();
            criarbtnAbrirP();
            if (pcelular != null)
            {
                pcelular.BringToFront();
            }
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
                habilitarBtnsProva();
                timerPopup.Stop();
            }
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
                desabilitarTelaPreta();
                timerPopup.Stop();
                if (btnPr[1] != null)
                {
                    desabilitarBtnsProva();
                }
            };
            this.Controls.Add(telaPreta);
        }
        void desabilitarTelaPreta()
        {
            if (telaPreta != null)
                telaPreta.Visible = false;
        }

        void criarbtnAbrirP()
        {
            if (btnProva == null)
            {
                btnProva = new Button();
                btnProva.BackColor = Color.Transparent;
                btnProva.FlatStyle = FlatStyle.Flat;
                btnProva.FlatAppearance.MouseDownBackColor = Color.Transparent;
                btnProva.FlatAppearance.MouseOverBackColor = Color.Transparent;
                btnProva.Cursor = Cursors.Hand;
                btnProva.FlatAppearance.BorderSize = 0;
                btnProva.MouseClick += btnProva_MouseEnter;

                tamanhoBtnProva();
                this.Controls.Add(btnProva);
            }
            btnProva.Visible = true;
            btnProva.SendToBack();
        }
        void tamanhoBtnProva()
        {

            if (btnProva != null)
            {
                btnProva.Size = new Size(this.ClientSize.Width, (int)((this.ClientSize.Height) * 0.50));
                btnProva.Location = new Point(
                    (0),
                    (this.ClientSize.Height / 2 - (btnProva.Height / 2))
                    );
            }
        }

        bool portaAberta = false;
        int tempo = 0;

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
        PictureBox transicao;

        Image sala = Properties.Resources.fv4;
        Image portaaberta = Properties.Resources.portaZoomAberta;



        private void Form1_Resize(object sender, EventArgs e)
        {
            //tamanhoBtnCell();
            //tamanhoBtnProva();
            //tamanhoCelular();
            //tamanhoProva();
            //tamanhoTransicao();
            //tamanhoBtnC();
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
            if (btnPr[1] != null)
                desabilitarBtnsProva();
            if (btnPorta != null)
                btnPorta.Visible = false;
        }
        bool labelsVisiveis = true;
        void desabilitarLabels()
        {
            lblC.Visible = false;
            lblContador.Visible = false;
            lbldirecao.Visible = false;
            lblRespostas.Visible = false;
            lblteste.Visible = false;
            if (btnMoverE != null)
                btnMoverE.BackColor = Color.Transparent;
            if (btnMoverB != null)
                btnMoverB.BackColor = Color.Transparent;
            if (btnMoverD != null)
                btnMoverD.BackColor = Color.Transparent;
            if (btnMoverC != null)
                btnMoverC.BackColor = Color.Transparent;
            if (btnProva != null)
            {
                btnProva.BackColor = Color.Transparent;
                btnProva.Text = " ";
            }
            if (btnCell != null)
            {
                btnCell.BackColor = Color.Transparent;
                btnCell.Text = " ";
            }
            if (btnPorta != null)
            {
                btnPorta.BackColor = Color.Transparent;
                btnPorta.Text = " ";
            }
            labelsVisiveis = false;
        }
        void habilitarLabels()
        {
            labelsVisiveis = true;
            lblC.Visible = true;
            lblContador.Visible = true;
            lbldirecao.Visible = true;
            lblRespostas.Visible = true;
            lblteste.Visible = true;
            if (btnMoverE != null)
                btnMoverE.BackColor = Color.Transparent;
            if (btnMoverB != null)
                btnMoverB.BackColor = Color.Transparent;
            if (btnMoverD != null)
                btnMoverD.BackColor = Color.Transparent;
            if (btnMoverC != null)
                btnMoverC.BackColor = Color.Transparent;
            if (btnProva != null)
            {
                btnProva.BackColor = Color.Transparent;
                btnProva.Text = "Prova";
            }
            if (btnCell != null)
            {
                btnCell.BackColor = Color.Transparent;
                btnCell.Text = "Celular";
            }
            if (btnPorta != null)
            {
                btnPorta.BackColor = Color.Transparent;
                btnPorta.Text = "Porta";
            }
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
                btnMoverE.BackColor = Color.Transparent;
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
                btnMoverB.BackColor = Color.Transparent;
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
                btnMoverD.BackColor = Color.Transparent;
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
                btnMoverC.BackColor = Color.Transparent;
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



        Button btnPorta;
        void criarbtnAbrirPr()
        {
            if (btnPorta == null)
            {
                btnPorta = new Button();
                btnPorta.BackColor = Color.Transparent;
                btnPorta.FlatStyle = FlatStyle.Flat;
                btnPorta.FlatAppearance.MouseDownBackColor = Color.Transparent;
                btnPorta.FlatAppearance.MouseOverBackColor = Color.Transparent;
                btnPorta.Cursor = Cursors.Hand;
                btnPorta.FlatAppearance.BorderSize = 0;
                btnPorta.MouseClick += btnPorta_MouseEnter;
                tamanhobtnPorta();
                this.Controls.Add(btnPorta);
            }
            btnPorta.Visible = true;
        }
        void tamanhobtnPorta()
        {

            if (btnPorta != null)
            {
                btnPorta.Size = new Size((this.ClientSize.Width) / 3, this.ClientSize.Height);
                btnPorta.Location = new Point(
                (this.ClientSize.Width / 2 - (btnPorta.Width / 2)),
                (this.ClientSize.Height / 2 - (btnPorta.Height / 2))
                );
            }
        }



        //void tamanhoBtnMenu()
        //{
        //    btnJogar.Size = new Size
        //        ((this.ClientSize.Width * 130) / 816,
        //        (this.ClientSize.Height * 60) / 489
        //        );
        //    btnJogar.Location = new Point(
        //        (this.ClientSize.Width * 331) / 816,
        //        (this.ClientSize.Height * 195) / 489
        //        );
        //}
        void tamanhoTransicao()
        {
            if (transicao != null)
            {
                transicao.Width = this.ClientSize.Width;
                transicao.Height = this.ClientSize.Height;
                transicao.SizeMode = PictureBoxSizeMode.StretchImage;
            }
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
                    if (posicaoFreire == 2)
                    {
                        await criarPFcorreno();
                        posicaoFreire = 3;
                    }
                    break;
                case 2:
                    if (portaAberta == true)
                    {
                        portaAberta = false;
                        TocarSom("sons/fechando1.wav");
                    }
                    await transicaoLousa2();
                    this.BackgroundImage = sala;
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
                    await criarbtnAbrirC();
                    criarbtnC();
                    criarbtnAbrirP();
                    btnProva.BringToFront();
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
                    this.BackgroundImage = sala;
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
                    this.BackgroundImage = Properties.Resources.pZoom;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    criarbtnD();
                    criarbtnAbrirPr();
                    break;
                case 1:
                    await transicaoLousa();
                    this.BackgroundImage = sala;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    criarbtnD();
                    criarbtnE();
                    criarbtnB();
                    break;
                default:
                    break;
            }
        }

        private async void btnProva_MouseEnter(object sender, EventArgs e)
        {
            switch (direcao)
            {
                case 3:
                    criarTelaPreta();
                    abrirProva();
                    if (pcelular != null)
                    {
                        pcelular.SendToBack();
                    }
                    timerPopup.Start();
                    desabilitarBotoes();
                    break;
            }
        }
        private async void btnPorta_MouseEnter(object sender, EventArgs e)
        {
            if (portaAberta == false)
            {
                this.BackgroundImage = portaaberta;
                portaAberta = true;
                TocarSom("sons/abrindo1.wav");
                if (celular == 1 && posicaoFreire == 1)
                {
                    gameover();
                }
                return;
            }
            else
            {
                this.BackgroundImage = Resources.pZoom;
                portaAberta = false;
                TocarSom("sons/fechando1.wav");
                return;
            }
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.E)
            {
                desabilitarLabels();
                return;
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            if (keyData == Keys.F1)
            {
                desabilitarLabels();
                return true;
            }
            if (keyData == Keys.F2)
            {
                habilitarLabels();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        //menu

        private void btnJogar_Click(object sender, EventArgs e)
        {
            TocarSom("sons/selected.wav");
            iniciarJogo();
            tiraromenudatela();
        }

        private void btnJogar_MouseEnter(object sender, EventArgs e)
        {
            this.btnJogar.BackgroundImage = Resources.BotãoJogarSelecionado2;
        }

        private void btnJogar_MouseLeave(object sender, EventArgs e)
        {
            this.btnJogar.BackgroundImage = Resources.BotãoJogar;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSair_MouseEnter(object sender, EventArgs e)
        {
            btnSair.BackgroundImage = Resources.btnsairselecionado;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            btnSair.BackgroundImage = Resources.btnsair;
        }

        private void btnopcao_Click(object sender, EventArgs e)
        {
            tiraromenudatela();
            this.BackgroundImage = Resources.opcao;
            criarbtnvoltar();    
        }

        private void btnopcao_MouseEnter(object sender, EventArgs e)
        {
            btnopcao.BackgroundImage = Resources.btnopcaoselecionado;
        }

        private void btnopcao_MouseLeave(object sender, EventArgs e)
        {
            btnopcao.BackgroundImage = Resources.btnopcao;
        }

        private void btnajuda_Click(object sender, EventArgs e)
        {
            tiraromenudatela();
            this.BackgroundImage = Resources.diario1;
            criarbtnvoltar();
        }
        Button btnvoltar;
        void criarbtnvoltar()
        {
            if (btnvoltar == null)
            {
                btnvoltar = new Button();
                btnvoltar.BackColor = Color.Transparent;
                btnvoltar.FlatStyle = FlatStyle.Flat;
                btnvoltar.FlatAppearance.MouseDownBackColor = Color.Transparent;
                btnvoltar.FlatAppearance.MouseOverBackColor = Color.Transparent;
                btnvoltar.Cursor = Cursors.Hand;
                btnvoltar.FlatAppearance.BorderSize = 0;
                btnvoltar.MouseClick += btnvoltar_MouseEnter;
                btnvoltar.BackgroundImage = Resources.voltar;
                btnvoltar.BackgroundImageLayout = ImageLayout.Zoom;
                this.Controls.Add(btnvoltar);
                btnvoltar.Size = new Size(this.ClientSize.Width/10, this.ClientSize.Height/10);
                btnvoltar.Location = new Point(
                    (0),
                    (0)
                    );
            }
            btnvoltar.Visible = true;
        }
        private void btnvoltar_MouseEnter(object sender, EventArgs e)
        {
            colocaromenudatela();
            btnvoltar.Visible = false;
            this.BackgroundImage = Resources.FNAFTitleScreen__1_;
        }
        private void btnajuda_MouseEnter(object sender, EventArgs e)
        {
            btnajuda.BackgroundImage = Resources.btnajudaselecionado;
        }

        private void btnajuda_MouseLeave(object sender, EventArgs e)
        {
            btnajuda.BackgroundImage = Resources.btnajuda;
        }
    }
}

