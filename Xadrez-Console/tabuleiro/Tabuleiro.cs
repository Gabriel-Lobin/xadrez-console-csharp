using xadrez_console.tabuleiro.exceptions;

namespace xadrez_console.tabuleiro
{
    internal class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }
        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public Peca peca(Posicao posicao)
        {
            return pecas[posicao.linha, posicao.coluna];
        }

        public bool ExistePeca(Posicao posicao)
        {
            ValidarPosicao(posicao);
            return peca(posicao) != null;
        }

        public void ColocarPeca(Peca peca, Posicao posicao)
        {
            if (ExistePeca(posicao))
            {
                throw new TabuleiroException("Já existe peça nesta posição!");
            }

            this.pecas[posicao.linha, posicao.coluna] = peca;
            peca.posicao = posicao;
        }

        public Peca RetirarPeca(Posicao posicao)
        {
            if (peca(posicao) == null)
            {
                return null;
            }

            Peca pecaRetirada = peca(posicao);
            pecaRetirada.posicao = null;
            pecas[posicao.linha, posicao.coluna] = null;
            return pecaRetirada;
        }

        public bool PosicaoValida(Posicao posicao)
        {
            if (posicao.linha < 0 || posicao.linha >= linhas || posicao.coluna < 0 || posicao.coluna >= colunas)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao posicao)
        {
            if (!PosicaoValida(posicao))
            {
                throw new TabuleiroException("Posição Inválida!");
            }
        }
    }
}
