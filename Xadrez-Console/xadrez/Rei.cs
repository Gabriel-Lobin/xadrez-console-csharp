using xadrez_console.tabuleiro;

namespace xadrez_console.xadrez
{
    internal class Rei : Peca
    {
        private string rei = "R";
        private char reiBranco = '\u2654';
        private char reiPreto = '\u265A';

        private PartidaDeXadrez partida;
        public Rei(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partida) : base(tabuleiro, cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {            
            return $"{rei}";
        }

        public override string PecaBranca()
        {
            return $"{reiBranco}";
        }

        public override string PecaPreta()
        {
            return $"{reiPreto}";
        }

        private bool PodeMover(Posicao posicao)
        {
            Peca peca = tabuleiro.peca(posicao);
            return peca == null || peca.cor != cor;
        }

        private bool TesteTorreRoque(Posicao posicao)
        {
            Peca p = tabuleiro.peca(posicao);
            return p != null && p is Torre && p.cor == cor && p.qtdMovimentos == 0;
        }

        public override bool[,] MovimentosValidos()
        {
            bool[,] matriz = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao posicaoInicial = new Posicao(0, 0);

            // N
            posicaoInicial.DefinirValores(posicao.linha - 1, posicao.coluna);

            if (tabuleiro.PosicaoValida(posicaoInicial) && PodeMover(posicaoInicial))
            {
                matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;
            }
            // NE
            posicaoInicial.DefinirValores(posicao.linha - 1, posicao.coluna + 1);

            if (tabuleiro.PosicaoValida(posicaoInicial) && PodeMover(posicaoInicial))
            {
                matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;
            }
            // L
            posicaoInicial.DefinirValores(posicao.linha, posicao.coluna + 1);

            if (tabuleiro.PosicaoValida(posicaoInicial) && PodeMover(posicaoInicial))
            {
                matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;
            }
            // SE
            posicaoInicial.DefinirValores(posicao.linha + 1, posicao.coluna + 1);

            if (tabuleiro.PosicaoValida(posicaoInicial) && PodeMover(posicaoInicial))
            {
                matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;
            }
            // S
            posicaoInicial.DefinirValores(posicao.linha + 1, posicao.coluna);

            if (tabuleiro.PosicaoValida(posicaoInicial) && PodeMover(posicaoInicial))
            {
                matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;
            }
            // SO
            posicaoInicial.DefinirValores(posicao.linha + 1, posicao.coluna - 1);

            if (tabuleiro.PosicaoValida(posicaoInicial) && PodeMover(posicaoInicial))
            {
                matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;
            }
            // O
            posicaoInicial.DefinirValores(posicao.linha, posicao.coluna - 1);

            if (tabuleiro.PosicaoValida(posicaoInicial) && PodeMover(posicaoInicial))
            {
                matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;
            }
            // NO 
            posicaoInicial.DefinirValores(posicao.linha - 1, posicao.coluna - 1);

            if (tabuleiro.PosicaoValida(posicaoInicial) && PodeMover(posicaoInicial))
            {
                matriz[posicaoInicial.linha, posicaoInicial.coluna] = true;
            }

            // ESPECIAIS
            // ROQUE
            if (qtdMovimentos == 0 && !partida.xeque)
            {
                // pequena
                Posicao posicao1 = new Posicao(posicao.linha, posicao.coluna + 3);

                if (TesteTorreRoque(posicao1))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);

                    if (tabuleiro.peca(p1) == null && tabuleiro.peca(p2) == null)
                    {
                        matriz[posicao.linha, posicao.coluna + 2] = true;
                    }
                }

                // grande
                Posicao posicao2 = new Posicao(posicao.linha, posicao.coluna - 4);

                if (TesteTorreRoque(posicao2))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);

                    if (tabuleiro.peca(p1) == null && tabuleiro.peca(p2) == null && tabuleiro.peca(p3) == null)
                    {
                        matriz[posicao.linha, posicao.coluna - 2] = true;
                    }
                }
            }

            return matriz;
        }
    }
}
