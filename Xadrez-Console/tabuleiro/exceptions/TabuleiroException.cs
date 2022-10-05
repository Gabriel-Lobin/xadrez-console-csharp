using System;

namespace xadrez_console.tabuleiro.exceptions
{
    internal class TabuleiroException : Exception
    {
        public TabuleiroException(string mensagem) : base(mensagem)
        {
        }
    }
}
