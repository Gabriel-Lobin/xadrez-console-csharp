using xadrez_console.tabuleiro;

namespace xadrez_console.xadrez
{
    internal class Rei : Peca
    {
        private char rei = 'R';
        private char reiBranco = '\u2654';
        private char reiPreto = '\u265A';
        public Rei(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return $"{rei}";
        }

        private bool PodeMover(Posicao posicao)
        {
            Peca peca = tabuleiro.peca(posicao);
            return peca == null || peca.cor != cor;
        }

        public override bool[,] MovimentosValidos()
        {
            bool[,] matriz = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao posicao = new Posicao(0, 0);

            // N
            posicao.DefinirValores(posicao.linha - 1, posicao.coluna);

            if (tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matriz[posicao.linha, posicao.coluna] = true;
            }
            // NE
            posicao.DefinirValores(posicao.linha - 1, posicao.coluna + 1);

            if (tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matriz[posicao.linha, posicao.coluna] = true;
            }
            // L
            posicao.DefinirValores(posicao.linha, posicao.coluna + 1);

            if (tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matriz[posicao.linha, posicao.coluna] = true;
            }
            // SE
            posicao.DefinirValores(posicao.linha + 1, posicao.coluna + 1);

            if (tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matriz[posicao.linha, posicao.coluna] = true;
            }
            // S
            posicao.DefinirValores(posicao.linha + 1, posicao.coluna);

            if (tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matriz[posicao.linha, posicao.coluna] = true;
            }
            // SO
            posicao.DefinirValores(posicao.linha + 1, posicao.coluna - 1);

            if (tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matriz[posicao.linha, posicao.coluna] = true;
            }
            // O
            posicao.DefinirValores(posicao.linha, posicao.coluna - 1);

            if (tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matriz[posicao.linha, posicao.coluna] = true;
            }
            // NO 
            posicao.DefinirValores(posicao.linha - 1, posicao.coluna - 1);

            if (tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matriz[posicao.linha, posicao.coluna] = true;
            }

            return matriz;
        }
    }
}
