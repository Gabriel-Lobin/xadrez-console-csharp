using xadrez_console.tabuleiro;
using xadrez_console.xadrez;

namespace xadrez_console
{
    internal class Tela
    {
        private static char quadrado = '\u2022';
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for (int index = 0; index < tabuleiro.linhas; index++)
            {
                Console.Write($"{8 - index}-");
                for (int index2 = 0; index2 < tabuleiro.colunas; index2++)
                {
                    Tela.ImprimirPeca(tabuleiro.peca(index, index2));
                }
                Console.WriteLine();
            }

            Console.WriteLine("  A B C D E F G H");
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicoes)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoMarcado = ConsoleColor.DarkGray;

            for (int index = 0; index < tabuleiro.linhas; index++)
            {
                Console.Write($"{8 - index}-");
                for (int index2 = 0; index2 < tabuleiro.colunas; index2++)
                {
                    if (posicoes[index, index2])
                    {
                        Console.BackgroundColor = fundoMarcado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    Tela.ImprimirPeca(tabuleiro.peca(index, index2));
                }
                Console.WriteLine();
            }

            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string imputConsole = Console.ReadLine();
            char coluna = imputConsole[0];
            int linha = int.Parse(imputConsole[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write($"{quadrado} ");
            }
            else
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
                Console.Write(" ");
            }
        }
    }
}
