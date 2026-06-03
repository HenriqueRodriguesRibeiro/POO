using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21
{
    public partial class Form1 : Form
    {
        private Jogo jogo21;
        private List<PictureBox> cartasNaTela;

        private int xJogadorAtual;
        private int yJogadorAtual = 20;
        private int xBancaAtual;
        private int yBancAtual = 210;

        private int espacamentoCartas = 35;

        private PictureBox pbCartaOcultaBanca;
        private Cartas refCartaOcultaBanca;

        public Form1()
        {
            InitializeComponent();
            jogo21 = new Jogo();
            cartasNaTela = new List<PictureBox>();
        }

        private async Task DistribuirCartaAnimada(Cartas carta, int destX, int destY, bool oculta = false)
        {
            PictureBox pb = new PictureBox();
            pb.Size = new Size(120, 180);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BackColor = Color.Transparent;

            string imgPath = oculta ? "deck_2/back-red.png" : carta.Get_Path();
            if (System.IO.File.Exists(imgPath))
            {
                pb.Image = Image.FromFile(imgPath);
            }
            else
            {
                pb.BackColor = Color.White;
                pb.BorderStyle = BorderStyle.FixedSingle;
            }

            int startX = 35;
            int startY = 80;
            pb.Location = new Point(startX, startY);

            this.Controls.Add(pb);
            pb.BringToFront();
            cartasNaTela.Add(pb);

            if (oculta)
            {
                pbCartaOcultaBanca = pb;
                refCartaOcultaBanca = carta;
            }

            int frames = 15;
            int delaysMs = 15;

            float stepX = (destX - startX) / (float)frames;
            float stepY = (destY - startY) / (float)frames;

            for(int i = 1; i <= frames; i++)
            {
                pb.Left = (int)(startX +(i * stepX));
                pb.Top = (int)(startY +(i * stepY));
                await Task.Delay(delaysMs);
            }

            pb.Location = new Point(destX, destY);
        }

        private void AtualizarTextosPontuacao(bool esconderBanca)
        {
            ptnJogador.Text = jogo21.JogadorAtual.CalcularPontuacao().ToString();

            if (esconderBanca)
                ptnBanca.Text = "?";
            else
                ptnBanca.Text = jogo21.BancaAtual.CalcularPontuacao().ToString();
        }

        private void LimparMesa()
        {
            foreach(PictureBox pb in cartasNaTela)
            {
                this.Controls.Remove(pb);
                pb.Dispose();

            }

            cartasNaTela.Clear();
            ptnBanca.Text = "0";
            ptnJogador.Text= "0";
        }

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            btnCarta.Enabled = false;
            btnParar.Enabled = false;
            btnIniciar.Visible = false;
            btnReiniciar.Visible = true;

            LimparMesa();
            jogo21.IniciarJogo();

            xJogadorAtual = 180;
            xBancaAtual = 180;

            await DistribuirCartaAnimada(jogo21.JogadorAtual.Mao[0], xJogadorAtual, yJogadorAtual, false);
            xJogadorAtual += espacamentoCartas;
            await DistribuirCartaAnimada(jogo21.BancaAtual.Mao[0], xBancaAtual, yBancAtual, true);
            xBancaAtual += espacamentoCartas;
            await DistribuirCartaAnimada(jogo21.JogadorAtual.Mao[1], xJogadorAtual, yJogadorAtual, false);
            xJogadorAtual += espacamentoCartas;
            await DistribuirCartaAnimada(jogo21.BancaAtual.Mao[1], xBancaAtual, yBancAtual, false);
            xBancaAtual += espacamentoCartas;

            AtualizarTextosPontuacao(esconderBanca: true);

            btnCarta.Enabled = true;
            btnParar.Enabled = true;
        }

        private async void btnCarta_Click(object sender, EventArgs e)
        {
            if (!jogo21.JogoEmAndamento)
                return;

            btnCarta.Enabled = false;
            btnParar.Enabled = false;

            Cartas novaCarta = jogo21.BaralhoAtual.ComprarCarta();
            jogo21.JogadorAtual.AdicionarCarta(novaCarta);

            await DistribuirCartaAnimada(novaCarta, xJogadorAtual, yJogadorAtual, false);
            xJogadorAtual += espacamentoCartas;

            AtualizarTextosPontuacao(esconderBanca: true);

            string resultado = jogo21.VerificarVencedor();
            if (!string.IsNullOrEmpty(resultado))
            {
                FinalizarPartida(resultado);
            }
            else
            {
                btnCarta.Enabled = true;
                btnParar.Enabled = true;
            }
        }

        private async void btnParar_Click(object sender, EventArgs e)
        {
            if (!jogo21.JogoEmAndamento)
                return;
            btnCarta.Enabled=false;

            if(pbCartaOcultaBanca != null && refCartaOcultaBanca != null)
            {
                if (System.IO.File.Exists(refCartaOcultaBanca.Get_Path()))
                    pbCartaOcultaBanca.Image = Image.FromFile(refCartaOcultaBanca.Get_Path());
            }

            AtualizarTextosPontuacao(esconderBanca:  false);

            int ptsJogador = jogo21.JogadorAtual.CalcularPontuacao();

            while (jogo21.BancaAtual.DeveComprarCarta(ptsJogador))
            {
                Cartas novaCarta = jogo21.BaralhoAtual.ComprarCarta();
                jogo21.BancaAtual.AdicionarCarta(novaCarta);

                await DistribuirCartaAnimada(novaCarta, xBancaAtual, yBancAtual, false);
                xBancaAtual += espacamentoCartas;

                AtualizarTextosPontuacao(esconderBanca: false);
                await Task.Delay(600);
            }

            string resultado = jogo21.VerificarVencedor(true);
            FinalizarPartida(resultado);
        }

        private void FinalizarPartida(string mensagem)
        {
            AtualizarTextosPontuacao(esconderBanca: false);

            if(pbCartaOcultaBanca != null && refCartaOcultaBanca != null && System.IO.File.Exists(refCartaOcultaBanca.Get_Path()))
                pbCartaOcultaBanca.Image = Image.FromFile(refCartaOcultaBanca.Get_Path());
            //btnReiniciar.
            MessageBox.Show(mensagem, "Fim do Turno", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnReiniciar_Click(object sender, EventArgs e)
        {
            btnIniciar_Click(sender, e);
        }
    }
}
