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
        void gameover()
        {
            PictureBox jumpscare = new PictureBox();
            jumpscare.Image = Properties.Resources.foxy_jumpscare;
            jumpscare.Size = new Size(200, 200);
            jumpscare.SizeMode = PictureBoxSizeMode.Zoom;
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

        private void btnJanela_MouseEnter(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.wv1;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnJanela_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.fv1;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void timerProva_tick(object sender, EventArgs e)
        {
            tempo++;
            lblContador.Text = "Timer: "+ tempo;
            if (tempo == 10)
            {
                gameover();

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
