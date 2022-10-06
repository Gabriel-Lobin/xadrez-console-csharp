using xadrez_console.tabuleiro;

namespace xadrez_console.xadrez
{
    internal class Bispo : Peca
    {
        private string bispo = "B";
        private char bispoBranco = 'b';
        private char bispoPreto = 'b';
        public Bispo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }
        public override string ToString()
        {
            return $"{bispo}";
        }

        public override string PecaBranca()
        {
            return $"{bispoBranco}";
        }

        public override string PecaPreta()
        {
            return $"{bispoPreto}";
        }
        private bool PodeMover(Posicao posicao)
        {
            Peca peca = tabuleiro.peca(posicao);
            return peca == null || peca.cor != cor;
        }

        public override bool[,] MovimentosValidos()
        {
            bool[,] matriz = new bool[this.tabuleiro.linhas, this.tabuleiro.colunas];

            Posicao posicaoInicial = new Posicao(0, 0);

            // NO
            posicaoInicial.DefinirValores(posicao.linha - 1, posicao.coluna - 1);

            while (this.tabuleiro.PosicaoValida(posicaoInicial) && PodeMover(posicaoInicial))
            {
                matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;

                if (this.tabuleiro.peca(posicaoInicial) != null && this.tabuleiro.peca(posicaoInicial).cor != this.cor)
                {
                    break;
                }

                posicaoInicial.DefinirValores(posicaoInicial.linha - 1, posicaoInicial.coluna - 1);
            }

            // NE

            posicaoInicial.DefinirValores(posicao.linha + 1, posicao.coluna + 1);

            while (this.tabuleiro.PosicaoValida(posicaoInicial) && PodeMover(posicaoInicial))
            {
                matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;

                if (this.tabuleiro.peca(posicaoInicial) != null && this.tabuleiro.peca(posicaoInicial).cor != this.cor)
                {
                    break;
                }

                posicaoInicial.DefinirValores(posicaoInicial.linha - 1, posicaoInicial.coluna + 1);
            }

            // SE 
            posicaoInicial.DefinirValores(posicao.linha + 1, posicao.coluna + 1);

            while (this.tabuleiro.PosicaoValida(posicaoInicial) && PodeMover(posicaoInicial))
            {
                matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;

                if (this.tabuleiro.peca(posicaoInicial) != null && this.tabuleiro.peca(posicaoInicial).cor != this.cor)
                {
                    break;
                }

                posicaoInicial.DefinirValores(posicaoInicial.linha + 1, posicaoInicial.coluna + 1);
            }
            // SO 
            posicaoInicial.DefinirValores(posicao.linha + 1, posicao.coluna - 1);

            while (this.tabuleiro.PosicaoValida(posicaoInicial) && PodeMover(posicaoInicial))
            {
                matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;

                if (this.tabuleiro.peca(posicaoInicial) != null && this.tabuleiro.peca(posicaoInicial).cor != this.cor)
                {
                    break;
                }

                posicaoInicial.DefinirValores(posicaoInicial.linha + 1, posicaoInicial.coluna - 1);
            }

            return matriz;
        }
    }
}
