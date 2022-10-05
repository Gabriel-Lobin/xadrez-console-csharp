using xadrez_console.tabuleiro;

namespace xadrez_console.xadrez
{
    internal class Rei : Peca
    {
        private char rei = 'R';
        private char reiBranco = '\u2654';
        private char reiPreto = '\u265A';
        public Rei(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return $"{rei}";
        }
    }
}
