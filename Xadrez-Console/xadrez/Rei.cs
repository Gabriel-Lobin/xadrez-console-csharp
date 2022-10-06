using xadrez_console.tabuleiro;

namespace xadrez_console.xadrez
{
    internal class Rei : Peca
    {
        private string rei = "R";
        private char reiBranco = '\u2654';
        private char reiPreto = '\u265A';
        public Rei(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
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

            return matriz;
        }
    }
}
