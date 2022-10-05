using xadrez_console.tabuleiro;

namespace xadrez_console
{
    internal class Tela
    {
        private static char quadrado = '\u25A1';
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for (int index = 0; index < tabuleiro.linhas; index++)
            {
                Console.Write($"{8 - index}-");
                for (int index2 = 0; index2 < tabuleiro.colunas; index2++)
                {
                    if (tabuleiro.peca(index, index2) == null)
                    {
                        Console.Write($"{quadrado} ");
                    }
                    else
                    {
                        Tela.ImprimirPeca(tabuleiro.peca(index, index2));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  ' ' ' ' ' ' ' '");
            Console.WriteLine("  A B C D E F G H");
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca.cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor corPadrao = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = corPadrao;
            }
        }
    }
}
