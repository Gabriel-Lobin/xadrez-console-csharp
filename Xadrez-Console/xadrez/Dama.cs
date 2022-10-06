using xadrez_console.tabuleiro;

namespace xadrez_console.xadrez
{
    internal class Dama : Peca
    {
        private char dama = 'D';
        private char damaBranca = 'd';
        private char damaPreta = 'd';
        public Dama(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return $"{dama}";
        }

        public override string PecaBranca()
        {
            return $"{damaBranca}";
        }
        public override string PecaPreta()
        {
            return $"{damaPreta}";
        }

        private bool PodeMover(Posicao posicao)
        {
            Peca peca = this.tabuleiro.peca(posicao);
            return peca == null || peca.cor != this.cor;
        }

        public override bool[,] MovimentosValidos()
        {
            bool[,] matriz = new bool[this.tabuleiro.linhas, this.tabuleiro.colunas];

            Posicao posicaoInicial = new Posicao(0, 0);

            // N
            posicaoInicial.DefinirValores(posicao.linha - 1, posicao.coluna);

            while (this.tabuleiro.PosicaoValida(posicaoInicial) && PodeMover(posicaoInicial))
            {
                matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;

                if (this.tabuleiro.peca(posicaoInicial) != null && this.tabuleiro.peca(posicaoInicial).cor != this.cor)
                {
                    break;
                }

                posicaoInicial.DefinirValores(posicaoInicial.linha - 1, posicao.coluna);
            }

            // S

            posicaoInicial.DefinirValores(posicao.linha + 1, posicao.coluna);

            while (this.tabuleiro.PosicaoValida(posicaoInicial) && PodeMover(posicaoInicial))
            {
                matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;

                if (this.tabuleiro.peca(posicaoInicial) != null && this.tabuleiro.peca(posicaoInicial).cor != this.cor)
                {
                    break;
                }

                posicaoInicial.DefinirValores(posicaoInicial.linha + 1, posicao.coluna);
            }

            // L 
            posicaoInicial.DefinirValores(posicao.linha, posicao.coluna + 1);

            while (this.tabuleiro.PosicaoValida(posicaoInicial) && PodeMover(posicaoInicial))
            {
                matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;

                if (this.tabuleiro.peca(posicaoInicial) != null && this.tabuleiro.peca(posicaoInicial).cor != this.cor)
                {
                    break;
                }

                posicaoInicial.DefinirValores(posicaoInicial.linha, posicao.coluna + 1);
            }
            // O 
            posicaoInicial.DefinirValores(posicao.linha, posicao.coluna - 1);

            while (this.tabuleiro.PosicaoValida(posicaoInicial) && PodeMover(posicaoInicial))
            {
                matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;

                if (this.tabuleiro.peca(posicaoInicial) != null && this.tabuleiro.peca(posicaoInicial).cor != this.cor)
                {
                    break;
                }

                posicaoInicial.DefinirValores(posicaoInicial.linha, posicao.coluna - 1);
            }

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

