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
            Console.OutputEncoding = System.Text.Encoding.UTF8;
                PosicaoXadrez pos = new PosicaoXadrez('c', 7);

                Console.WriteLine(pos);

                Console.WriteLine(pos.ToPosicao());

            }
            catch (TabuleiroException erro)
            {
                Console.WriteLine(erro.Message);
            }
            Console.WriteLine();
        }
    }
}
