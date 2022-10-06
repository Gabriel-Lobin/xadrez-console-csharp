using xadrez_console.tabuleiro;

namespace xadrez_console.xadrez
{
    internal class Peao : Peca
    {
        private char peao = 'P';
        private char peaoBranca = 'p';
        private char peaoPreta = 'p';
        public Peao(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return $"{peao}";
        }

        public override string PecaBranca()
        {
            return $"{peaoBranca}";
        }
        public override string PecaPreta()
        {
            return $"{peaoPreta}";
        }

        private bool ExisteInimigo(Posicao posicao)
        {
            Peca p = tabuleiro.peca(posicao);
            return p != null && p.cor != cor;
        }

        private bool Livre(Posicao posicao)
        {
            return tabuleiro.peca(posicao) == null;
        }

        public override bool[,] MovimentosValidos()
        {
            bool[,] matriz = new bool[this.tabuleiro.linhas, this.tabuleiro.colunas];

            Posicao posicaoInicial = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {
                posicaoInicial.DefinirValores(posicao.linha - 1, posicao.coluna);

                if (tabuleiro.PosicaoValida(posicaoInicial) && Livre(posicaoInicial))
                {
                    matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;
                }

                posicaoInicial.DefinirValores(posicao.linha - 2, posicao.coluna);

                if (tabuleiro.PosicaoValida(posicaoInicial) && Livre(posicaoInicial) && qtdMovimentos == 0)
                {
                    matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;
                }

                posicaoInicial.DefinirValores(posicao.linha - 1, posicao.coluna - 1);

                if (tabuleiro.PosicaoValida(posicaoInicial) && Livre(posicaoInicial))
                {
                    matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;
                }

                posicaoInicial.DefinirValores(posicao.linha - 1, posicao.coluna + 1);

                if (tabuleiro.PosicaoValida(posicaoInicial) && Livre(posicaoInicial))
                {
                    matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;
                }
            }
            else
            {
                posicaoInicial.DefinirValores(posicao.linha + 1, posicao.coluna);

                if (tabuleiro.PosicaoValida(posicaoInicial) && Livre(posicaoInicial))
                {
                    matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;
                }

                posicaoInicial.DefinirValores(posicao.linha + 2, posicao.coluna);

                if (tabuleiro.PosicaoValida(posicaoInicial) && Livre(posicaoInicial) && qtdMovimentos == 0)
                {
                    matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;
                }

                posicaoInicial.DefinirValores(posicao.linha + 1, posicao.coluna - 1);

                if (tabuleiro.PosicaoValida(posicaoInicial) && Livre(posicaoInicial))
                {
                    matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;
                }

                posicaoInicial.DefinirValores(posicao.linha + 1, posicao.coluna + 1);

                if (tabuleiro.PosicaoValida(posicaoInicial) && Livre(posicaoInicial))
                {
                    matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;
                }
            }

            return matriz;
        }
    }
}

