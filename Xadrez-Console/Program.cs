using xadrez_console.tabuleiro;

namespace xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Tabuleiro tabuleiro = new Tabuleiro(8,8);

            Tela.imprimirTabuleiro(tabuleiro);

            Console.WriteLine();
        }
    }
}
