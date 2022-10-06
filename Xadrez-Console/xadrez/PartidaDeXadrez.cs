﻿using System;
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

        public PartidaDeXadrez()
        {
            this.tabuleiro = new Tabuleiro(8, 8);
            this.turno = 1;
            this.jogadorAtual = Cor.Branca;
            this.terminada = false;
            pecas = new HashSet<Peca>();
            pecasComidas = new HashSet<Peca>();
            ColocarPecas();
        }

        public void ExecuteMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = tabuleiro.RetirarPeca(origem);
            peca.AumentaQtdMovimentos();
            // variavel temporaria para deletar.
            Peca pecaComida = tabuleiro.RetirarPeca(destino);
            tabuleiro.ColocarPeca(peca, destino);
            if (pecaComida != null)
            {
                pecasComidas.Add(pecaComida);
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecuteMovimento(origem, destino);
            turno++;
            MudaJogador();
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
