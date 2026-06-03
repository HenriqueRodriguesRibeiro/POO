using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace _21
{

    public class Cartas
    {
        private string Valor;
        private string Naipe;
        private int Peso;
        private string Path;

        public string[] NaipesValidos = { "Paus", "Copas", "Espadas", "Ouros" };
        public string[] ValoresValidos = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };


        public string Get_Naipe()
        {
            return Naipe;
        }

        public string Get_Valor()
        {
            return Valor;
        }

        public int Get_Peso()
        {
            return Peso;
        }

        public string Get_Path()
        {
            return Path;
        }

        public void Set_Naipe(string Naipe)
        {
            if (NaipesValidos.Contains(Naipe))
                this.Naipe = Naipe;
            else
                throw new Exception("Naipe inválido!");
        }
        
        public void Set_Valor(string Valor)
        {
            if (ValoresValidos.Contains(Valor))
                this.Valor = Valor;
            else
                throw new Exception("Valor inválida!");
        }

        public void Set_Peso(int Peso)
        {
            this.Peso = Peso;
        }

        public void Set_path(string Path)
        {
            this.Path = Path;
        }

        private void atribuiPeso()
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic["A"] = 11;
            dic["2"] = 2;
            dic["3"] = 3;
            dic["4"] = 4;
            dic["5"] = 5;
            dic["6"] = 6;
            dic["7"] = 7;
            dic["8"] = 8;
            dic["9"] = 9;
            dic["10"] = 10;
            dic["Q"] = 10;
            dic["J"] = 10;
            dic["K"] = 10;

            string valorLimpo = this.Valor != null ? this.Valor.Trim() : "";

            if (dic.ContainsKey(valorLimpo))
            {
                this.Peso = dic[valorLimpo];
            }
            else
            {
                this.Peso = 0;
            }
        }

        public void atribuirPath()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["Paus"] = "clubs";
            dic["Copas"] = "hearts";
            dic["Espadas"] = "spades";
            dic["Ouros"] = "diamonds";
            Path = "deck_2/" + dic[this.Naipe] + "_" + this.Valor + ".png";
        }
        public Cartas(string _valor, string _naipe) 
        {
            Naipe = _naipe;
            Valor = _valor;
            atribuiPeso();
            atribuirPath();
        }

        public Cartas()
        {
            Random rnd = new Random();
            Naipe = this.NaipesValidos[rnd.Next(0, this.NaipesValidos.Length)];
            Valor = this.ValoresValidos[rnd.Next(0,this.ValoresValidos.Length)];
            atribuiPeso();
            atribuirPath();

        }

        public override string ToString()
        {
            return ($"{Valor} de {Naipe}");
        }
        
    }

    public class Baralho
    {
        private List<Cartas> carta;
        private Random rnd = new Random();

        public List<Cartas> Carta        {
            get 
            { 
                return carta; 
            }
            set 
            { 
                carta = value; 
            }
        }

        public Baralho()
        {
            Carta = new List<Cartas>();
            rnd = new Random();
            InicializarBaralho();
            Embaralhar();
        }

        private void InicializarBaralho()
        {
            Carta.Clear();
            Cartas cartaTemp = new Cartas();

            foreach(string naipe in cartaTemp.NaipesValidos)
            {
                foreach(string valor in cartaTemp.ValoresValidos)
                {
                    Carta.Add(new Cartas(valor, naipe));
                }
            }
        }

        public void Embaralhar()
        {
            int n = Carta.Count;
            while(n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                Cartas value = Carta[k];
                Carta[k] = Carta[n];
                Carta[n] = value; 
            }
        }

        public Cartas ComprarCarta()
        {
            if(Carta.Count > 0)
            {
                Cartas cartaComprada = Carta[0];
                Carta.RemoveAt(0);
                return cartaComprada;
            }
            return null;
        }

    }

    public abstract class JogadorBase
    {
        private List<Cartas> mao;
        private string nome;

        public List<Cartas> Mao
        {
            get
            {
                return mao;
            }
            protected set
            {
                mao = value;
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }
            protected set
            {
                nome = value;
            }
        }

        public JogadorBase(string nome)
        {
            Nome = nome;
            Mao = new List<Cartas>();
        }

        public void AdicionarCarta(Cartas carta)
        {
            if(carta != null)
            {
                Mao.Add(carta);
            }
        }

        public int CalcularPontuacao()
        {
            int soma = 0;
            int asCount = 0;

            foreach(Cartas carta in Mao)
            {
                soma += carta.Get_Peso();
                if(carta.Get_Valor() == "A")
                {
                    asCount++;
                }
            }

            while(soma > 21 && asCount > 0)
            {
                soma -= 10;
                asCount--;
            }
            
            return soma;
        }

        public void LimparMao()
        {
            Mao.Clear();
        }
    }

    public class Jogador : JogadorBase
    {
        public Jogador() : base("Jogador") { }
    }

    public class Banca : JogadorBase
    {
        public Banca() : base("Banca") { }

        public bool DeveComprarCarta(int pontuacaoJogador)
        {
            return CalcularPontuacao() < pontuacaoJogador && CalcularPontuacao() < 21;
        }
    }

    public class Jogo
    {
        private Baralho baralhoAtual;
        private Jogador jogadorAtual;
        private Banca bancaAtual;
        private bool jogoEmAndamento;

        public Baralho BaralhoAtual
        {
            get
            {
                return baralhoAtual;
            }
            private set
            {
                this.baralhoAtual = value;
            }
        }

        public Jogador JogadorAtual
        {
            get
            {
                return jogadorAtual;
            }
            private set
            {
                this.jogadorAtual = value;
            }
        }

        public Banca BancaAtual
        {
            get
            {
                return bancaAtual;
            }
            private set
            {
                this.bancaAtual = value;
            }
        }

        public bool JogoEmAndamento
        {
            get
            {
                return jogoEmAndamento;
            }
            set
            {
                jogoEmAndamento = value;
            }
        }

        public Jogo()
        {
            BaralhoAtual = new Baralho();
            JogadorAtual = new Jogador();
            BancaAtual = new Banca();
            JogoEmAndamento = false;
        }

        public void IniciarJogo()
        {
            BaralhoAtual = new Baralho();
            JogadorAtual.LimparMao();
            BancaAtual.LimparMao();

            JogadorAtual.AdicionarCarta(BaralhoAtual.ComprarCarta());
            BancaAtual.AdicionarCarta(BaralhoAtual.ComprarCarta());
            JogadorAtual.AdicionarCarta(BaralhoAtual.ComprarCarta());
            BancaAtual.AdicionarCarta(BaralhoAtual.ComprarCarta());

            JogoEmAndamento = true;
        }

        public string VerificarVencedor(bool jogadorParou = false)
        {
            int ptsJogador = JogadorAtual.CalcularPontuacao();
            int ptsBanca = BancaAtual.CalcularPontuacao();

            if(ptsJogador > 21)
            {
                JogoEmAndamento = false;
                return ("Você estourou 21! A Banca venceu.");
            }

            if (jogadorParou)
            {
                JogoEmAndamento = false;
                if (ptsBanca > 21)
                    return ("A Banca estourou! Você venceu");
                if (ptsJogador > ptsBanca)
                    return ("Você venceu a Banca!");
                if (ptsBanca >= ptsJogador)
                    return ("A Banca venceu!");
            }

            return ("");
        }
    }
}
