using xadrez_console.tabuleiro;

namespace xadrez_console.xadrez
{
    internal class Torre : Peca
    {
        private char torre = 'T';
        private char torreBranca = '\u2656';
        private char torrePreta = '\u265C';
        public Torre(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return $"{torre}";
        }
    }
}
