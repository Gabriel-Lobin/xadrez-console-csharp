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
        private bool PodeMover(Posicao posicao)
        {
            Peca peca = this.tabuleiro.peca(posicao);
            return peca == null || peca.cor != this.cor;
        }

        public override bool[,] MovimentosValidos()
        {
            bool[,] matriz = new bool[this.tabuleiro.linhas, this.tabuleiro.colunas];

            Posicao posicao = new Posicao(0, 0);

            // N
            posicao.DefinirValores(posicao.linha - 1, posicao.coluna);

            while (this.tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matriz[posicao.linha, posicao.coluna] = true;
                if (this.tabuleiro.peca(posicao) != null && this.tabuleiro.peca(posicao).cor != this.cor)
                {
                    break;
                }

                posicao.linha -= 1;
            }

            // S

            posicao.DefinirValores(posicao.linha + 1, posicao.coluna);

            while (this.tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matriz[posicao.linha, posicao.coluna] = true;
                if (this.tabuleiro.peca(posicao) != null && this.tabuleiro.peca(posicao).cor != this.cor)
                {
                    break;
                }

                posicao.linha += 1;
            }

            // L 
            posicao.DefinirValores(posicao.linha, posicao.coluna + 1);

            while (this.tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matriz[posicao.linha, posicao.coluna] = true;
                if (this.tabuleiro.peca(posicao) != null && this.tabuleiro.peca(posicao).cor != this.cor)
                {
                    break;
                }

                posicao.coluna += 1;
            }
            // O 
            posicao.DefinirValores(posicao.linha, posicao.coluna - 1);

            while (this.tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matriz[posicao.linha, posicao.coluna] = true;
                if (this.tabuleiro.peca(posicao) != null && this.tabuleiro.peca(posicao).cor != this.cor)
                {
                    break;
                }

                posicao.coluna -= 1;
            }

            return matriz;
        }
    }
}
