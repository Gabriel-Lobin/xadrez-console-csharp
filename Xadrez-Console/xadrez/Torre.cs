using xadrez_console.tabuleiro;

namespace xadrez_console.xadrez
{
    internal class Torre : Peca
    {
        private char torre = 'T';
        private char torreBranca = '\u2656';
        private char torrePreta = '\u265C';
        public Torre(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return $"{torre}";
        }

        public override string PecaBranca()
        {
            return $"{torreBranca}";
        }
        public override string PecaPreta()
        {
            return $"{torrePreta}";
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

                posicaoInicial.linha -= 1;
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

                posicaoInicial.linha += 1;
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

                posicaoInicial.coluna += 1;
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

                posicaoInicial.coluna -= 1;
            }

            return matriz;
        }
    }
}
