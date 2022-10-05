using xadrez_console.tabuleiro;

namespace xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Posicao position;

            position = new Posicao(3,4);

            Console.WriteLine($"Posição: {position}");
        }
    }
}
