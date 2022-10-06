using xadrez_console.tabuleiro;
using xadrez_console.xadrez;

namespace xadrez_console
{
    internal class Tela
    {
        private static char quadrado = '\u2022';

        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            Tela.ImprimirTabuleiro(partida.tabuleiro);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine($"Turno: {partida.turno}");

            if (!partida.terminada)
            {
                Console.WriteLine($"Aguardando jogada: {partida.jogadorAtual}");
                if (partida.xeque)
                {
                    Console.WriteLine();
                    Console.WriteLine("XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine($"VENCEDOR É {partida.jogadorAtual}");
            }


        }

        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasComidasLista(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");

            ImprimirConjunto(partida.PecasComidasLista(Cor.Preta));

            Console.WriteLine();

        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {

            Console.Write("[");
            foreach (Peca p in conjunto)
            {
                if (p.cor == Cor.Branca)
                {
                    Console.Write($"{p} ");
                }
                else
                {
                    ConsoleColor corPadrao = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{p} ");
                    Console.ForegroundColor = corPadrao;
                }
            }
            Console.Write("]");

        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for (int index = 0; index < tabuleiro.linhas; index++)
            {
                Console.Write($"{8 - index} ");
                for (int index2 = 0; index2 < tabuleiro.colunas; index2++)
                {
                    Tela.ImprimirPeca(tabuleiro.peca(index, index2));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicoes)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoMarcado = ConsoleColor.Yellow;

            for (int index = 0; index < tabuleiro.linhas; index++)
            {
                Console.Write($"{8 - index} ");
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
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(peca);
                    Console.ForegroundColor = corPadrao;
                }
                Console.Write(" ");
            }
        }
    }
}
