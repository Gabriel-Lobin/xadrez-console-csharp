using xadrez_console.tabuleiro;

namespace xadrez_console.xadrez
{
    internal class Cavalo : Peca
    {
        private char cavalo = 'C';
        private char cavaloBranca = 'c';
        private char cavaloPreta = 'c';
        public Cavalo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return $"{cavalo}";
        }

        public override string PecaBranca()
        {
            return $"{cavaloBranca}";
        }
        public override string PecaPreta()
        {
            return $"{cavaloPreta}";
        }

        private bool PodeMover(Posicao posicao)
        {
            Peca peca = this.tabuleiro.peca(posicao);
            return peca == null || peca.cor != this.cor;
        }

        public override bool[,] MovimentosValidos()
        {
            bool[,] matriz = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao posicaoInicial = new Posicao(0, 0);

            // N
            posicaoInicial.DefinirValores(posicao.linha - 1, posicao.coluna - 2);

            if (tabuleiro.PosicaoValida(posicaoInicial) && PodeMover(posicaoInicial))
            {
                matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;
            }
            // NE
            posicaoInicial.DefinirValores(posicao.linha - 2, posicao.coluna - 1);

            if (tabuleiro.PosicaoValida(posicaoInicial) && PodeMover(posicaoInicial))
            {
                matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;
            }
            // L
            posicaoInicial.DefinirValores(posicao.linha - 2, posicao.coluna + 1);

            if (tabuleiro.PosicaoValida(posicaoInicial) && PodeMover(posicaoInicial))
            {
                matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;
            }
            // SE
            posicaoInicial.DefinirValores(posicao.linha - 1, posicao.coluna + 2);

            if (tabuleiro.PosicaoValida(posicaoInicial) && PodeMover(posicaoInicial))
            {
                matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;
            }
            // S
            posicaoInicial.DefinirValores(posicao.linha + 1, posicao.coluna + 2);

            if (tabuleiro.PosicaoValida(posicaoInicial) && PodeMover(posicaoInicial))
            {
                matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;
            }
            // SO
            posicaoInicial.DefinirValores(posicao.linha + 2, posicao.coluna + 1);

            if (tabuleiro.PosicaoValida(posicaoInicial) && PodeMover(posicaoInicial))
            {
                matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;
            }
            // O
            posicaoInicial.DefinirValores(posicao.linha + 2 , posicao.coluna - 1);

            if (tabuleiro.PosicaoValida(posicaoInicial) && PodeMover(posicaoInicial))
            {
                matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;
            }
            // NO 
            posicaoInicial.DefinirValores(posicao.linha + 1, posicao.coluna - 2);

            if (tabuleiro.PosicaoValida(posicaoInicial) && PodeMover(posicaoInicial))
            {
                matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;
            }

            return matriz;
        }
    }
}

