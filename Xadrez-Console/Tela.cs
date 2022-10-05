using xadrez_console.tabuleiro;

namespace xadrez_console
{
    internal class Tela
    {
        private static char quadrado = '\u25A1';
        public static void imprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for (int index = 0; index < tabuleiro.linhas; index++)
            {
                for (int index2 = 0; index2 < tabuleiro.colunas; index2++)
                {
                    if (tabuleiro.peca(index, index2) == null)
                    {
                        Console.Write($"{quadrado} ");
                    }
                    else
                    {
                        Console.Write($"{tabuleiro.peca(index, index2)} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
