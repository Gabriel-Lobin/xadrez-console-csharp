using xadrez_console.tabuleiro;
using xadrez_console.xadrez;

namespace xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Tabuleiro tabuleiro = new Tabuleiro(8,8);

            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(0,0));
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(1,3));
            tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Preta), new Posicao(2,4));

            Tela.imprimirTabuleiro(tabuleiro);

            Console.WriteLine();
        }
    }
}
