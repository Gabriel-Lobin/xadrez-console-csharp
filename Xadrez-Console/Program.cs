using xadrez_console.tabuleiro;
using xadrez_console.tabuleiro.exceptions;
using xadrez_console.xadrez;

namespace xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirPartida(partida);

                        Console.WriteLine();

                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoOrigem(origem);

                        bool[,] posicoes = partida.tabuleiro.peca(origem).MovimentosValidos();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.tabuleiro, posicoes);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoDestino(origem, destino);

                        partida.RealizaJogada(origem, destino);

                    }
                    catch (TabuleiroException erro)
                    {
                        Console.WriteLine(erro.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Tela.ImprimirPartida(partida);
            }
            catch (TabuleiroException erro)
            {
                Console.WriteLine(erro.Message);
            }

            Console.WriteLine();
        }
    }
}
