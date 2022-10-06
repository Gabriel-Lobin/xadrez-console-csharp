namespace xadrez_console.tabuleiro
{
    internal abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtdMovimentos { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            this.posicao = null;
            this.tabuleiro = tabuleiro;
            this.cor = cor;
            this.qtdMovimentos = 0;
        }

        public abstract string PecaBranca();

        public abstract string PecaPreta();

        public void AumentaQtdMovimentos()
        {
            qtdMovimentos++;
        }

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] matriz = MovimentosValidos();

            for (int index = 0; index < tabuleiro.linhas; index++)
            {
                for (int index2 = 0; index2 < tabuleiro.colunas; index2++)
                {
                    if (matriz[index, index2])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PodeMoverPara(Posicao posicao)
        {
            return MovimentosValidos()[posicao.linha, posicao.coluna];
        }

        public abstract bool[,] MovimentosValidos();

    }
}
