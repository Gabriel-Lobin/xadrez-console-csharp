using System;
using xadrez_console.tabuleiro;
using xadrez_console.tabuleiro.exceptions;

namespace xadrez_console.xadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro tabuleiro { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> pecasComidas;
        public bool xeque { get; private set; }

        public PartidaDeXadrez()
        {
            this.tabuleiro = new Tabuleiro(8, 8);
            this.turno = 1;
            this.jogadorAtual = Cor.Branca;
            this.terminada = false;
            this.xeque = false;
            pecas = new HashSet<Peca>();
            pecasComidas = new HashSet<Peca>();
            ColocarPecas();
        }

        public Peca ExecuteMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = tabuleiro.RetirarPeca(origem);
            peca.AumentaQtdMovimentos();
            Peca pecaComida = tabuleiro.RetirarPeca(destino);
            tabuleiro.ColocarPeca(peca, destino);
            if (pecaComida != null)
            {
                pecasComidas.Add(pecaComida);
            }

            return pecaComida;
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaComida)
        {
            Peca p = tabuleiro.RetirarPeca(destino);
            p.DiminuirQtdMovimentos();

            if (pecaComida != null)
            {
                tabuleiro.ColocarPeca(pecaComida, destino);
                pecasComidas.Remove(pecaComida);
            }

            tabuleiro.ColocarPeca(p, origem);
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaComida = ExecuteMovimento(origem, destino);

            if (EstaEmXeque(jogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaComida);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            if (EstaEmXeque(Adversario(jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }

            if (TesteXequeMate(Adversario(jogadorAtual)))
            {
                terminada = true;
            }
            else
            {
                turno++;
                MudaJogador();
            }

        }

        public void ValidarPosicaoOrigem(Posicao posicao)
        {
            if (tabuleiro.peca(posicao) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (jogadorAtual != tabuleiro.peca(posicao).cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!tabuleiro.peca(posicao).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!tabuleiro.peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private void MudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> PecasComidasLista(Cor cor)
        {
            HashSet<Peca> lista = new HashSet<Peca>();

            foreach (Peca p in pecasComidas)
            {
                if (p.cor == cor)
                {
                    lista.Add(p);
                }
            }

            return lista;
        }

        public HashSet<Peca> PecasEmJogoLista(Cor cor)
        {
            HashSet<Peca> lista = new HashSet<Peca>();

            foreach (Peca p in pecas)
            {
                if (p.cor == cor)
                {
                    lista.Add(p);
                }
            }

            lista.ExceptWith(PecasComidasLista(cor));

            return lista;
        }

        private Cor Adversario(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }

            return Cor.Branca;
        }

        private Peca ReiPeca(Cor cor)
        {
            foreach (Peca p in PecasEmJogoLista(cor))
            {
                if (p is Rei)
                {
                    return p;
                }
            }

            return null;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca R = ReiPeca(cor);

            if (R == null)
            {
                throw new TabuleiroException($"Não tem rei da cor {cor} no tabuleiro!");
            }

            foreach (Peca p in PecasEmJogoLista(Adversario(cor)))
            {
                bool[,] matriz = p.MovimentosValidos();
                if (matriz[R.posicao.linha, R.posicao.coluna])
                {
                    return true;
                }
            }

            return false;
        }

        public bool TesteXequeMate(Cor cor)
        {
            if (!EstaEmXeque(cor))
            {
                return false;
            }

            foreach (Peca p in PecasEmJogoLista(cor))
            {
                bool[,] matriz = p.MovimentosValidos();
                for (int index = 0; index < tabuleiro.linhas; index++)
                {
                    for (int index2 = 0; index2 < tabuleiro.colunas; index2++)
                    {
                        if (matriz[index, index2])
                        {
                            Posicao origem = p.posicao;
                            Posicao destino = new Posicao(index, index2);
                            Peca pecaComida = ExecuteMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaComida);

                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecas.Add(peca);
        }

        private void ColocarPecas()
        {
            // brancas
            ColocarNovaPeca('c', 1, new Torre(tabuleiro, Cor.Branca));
            ColocarNovaPeca('c', 2, new Torre(tabuleiro, Cor.Branca));
            ColocarNovaPeca('d', 2, new Torre(tabuleiro, Cor.Branca));
            ColocarNovaPeca('e', 1, new Torre(tabuleiro, Cor.Branca));
            ColocarNovaPeca('e', 2, new Torre(tabuleiro, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(tabuleiro, Cor.Branca));

            // pretas
            ColocarNovaPeca('c', 8, new Torre(tabuleiro, Cor.Preta));
            ColocarNovaPeca('c', 7, new Torre(tabuleiro, Cor.Preta));
            ColocarNovaPeca('d', 7, new Torre(tabuleiro, Cor.Preta));
            ColocarNovaPeca('e', 8, new Torre(tabuleiro, Cor.Preta));
            ColocarNovaPeca('e', 7, new Torre(tabuleiro, Cor.Preta));
            ColocarNovaPeca('d', 8, new Rei(tabuleiro, Cor.Preta));

        }
    }
}
