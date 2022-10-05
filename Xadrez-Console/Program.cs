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
            Tabuleiro tabuleiro = new Tabuleiro(8,8);

            tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(0,0));
            tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(1,3));
            tabuleiro.ColocarPeca(new Rei(tabuleiro, Cor.Preta), new Posicao(2,4));

            Tela.ImprimirTabuleiro(tabuleiro);

            Console.WriteLine();
            }
            catch (TabuleiroException erro)
            {
                Console.WriteLine(erro.Message);
            }
        }
    }
}
