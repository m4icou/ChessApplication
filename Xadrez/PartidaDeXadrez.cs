using System;
using Tabuleiro;
using System.Collections.Generic;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        public TabuleiroClass Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;
        public bool Xeque { get; private set; }

        public Peca VulneravelEnPassant;

        public PartidaDeXadrez()
        {
            Tabuleiro = new TabuleiroClass(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Pecas = new HashSet<Peca>();
            Xeque = false;
            VulneravelEnPassant = null;
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }


        public Peca executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tabuleiro.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca PecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(p, destino);
            if (PecaCapturada != null)
            {
                Capturadas.Add(PecaCapturada);
            }

            //#jogada especial roque pequeno
            if (p is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Posicao OrigemT = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao DestinoT = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca T = Tabuleiro.RetirarPeca(OrigemT);
                T.IncrementarQteMovimentos();
                Tabuleiro.ColocarPeca(T, DestinoT);
            }

            //#jogada especial roque grande
            if (p is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao OrigemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao DestinoT = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca T = Tabuleiro.RetirarPeca(OrigemT);
                T.IncrementarQteMovimentos();
                Tabuleiro.ColocarPeca(T, DestinoT);
            }

            //#jogada especial en passant
            if(p is Peao){
                if(origem.Coluna != destino.Coluna && PecaCapturada == null){
                    Posicao posP;
                    if(p.Cor == Cor.Branca){
                        posP = new Posicao(destino.Linha + 1, destino.Coluna);
                    }
                    else{
                        posP = new Posicao(destino.Linha - 1, destino.Coluna);
                    }
                    PecaCapturada = Tabuleiro.RetirarPeca(posP);
                    Capturadas.Add(PecaCapturada);
                }
            }

            return PecaCapturada;
        }



        public void DesfazMovimento(Posicao origem, Posicao destino, Peca PecaCapturada)
        {
            Peca p = Tabuleiro.RetirarPeca(destino);
            p.DecrementarQteMovimentos();
            if (PecaCapturada != null)
            {
                Tabuleiro.ColocarPeca(PecaCapturada, destino);
                Capturadas.Remove(PecaCapturada);
            }
            Tabuleiro.ColocarPeca(p, origem);

            if (p is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Posicao OrigemT = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao DestinoT = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca T = Tabuleiro.RetirarPeca(DestinoT);
                T.DecrementarQteMovimentos();
                Tabuleiro.ColocarPeca(T, OrigemT);
            }

            //desfazendo #jogada especial roque grande
            if (p is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao OrigemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao DestinoT = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca T = Tabuleiro.RetirarPeca(DestinoT);
                T.DecrementarQteMovimentos();
                Tabuleiro.ColocarPeca(T, OrigemT);
            }


            //desfazendo #jogada especial en passant
            if(p is Peao){
                if(origem.Coluna != destino.Coluna && PecaCapturada == null){
                    Peca peao = Tabuleiro.RetirarPeca(destino);
                    Posicao posP;
                    if(p.Cor == Cor.Branca){
                        posP = new Posicao(3, destino.Coluna);
                    }
                    else{
                        posP = new Posicao(4, destino.Coluna);
                    }
                    Tabuleiro.ColocarPeca(peao, posP);
                }
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca PecaCapturada = executaMovimento(origem, destino);

            if (EstaEmCheque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, PecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            Peca p = Tabuleiro.peca(destino);

            //#jogada especial promocao
            if(p is Peao){
                if((p.Cor == Cor.Branca && destino.Linha == 0) || (p.Cor == Cor.Preta && destino.Linha == 7)){
                    p = Tabuleiro.RetirarPeca(destino);
                    Pecas.Remove(p);
                    Peca dama = new Dama(Tabuleiro, p.Cor);
                    Tabuleiro.ColocarPeca(dama, destino);
                    Pecas.Add(dama);
                }
            }

            if (EstaEmCheque(Adversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }

            if (TestaXequeMate(Adversaria(JogadorAtual)))
            {
                Terminada = true;
            }
            else
            {
                Turno++;
                MudaJogador();
            }

            
            //#jogada especial en passant

            if(p is Peao && (destino.Linha == origem.Linha - 2) || destino.Linha == origem.Linha + 2){
                VulneravelEnPassant = p;
            }
            else{
                VulneravelEnPassant = null;
            }

        }

        public void ValidarPosicaoDeOrigem(Posicao posicao)
        {
            if (Tabuleiro.peca(posicao) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida");
            }
            if (JogadorAtual != Tabuleiro.peca(posicao).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua");
            }
            if (!Tabuleiro.peca(posicao).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possiveis para a peça de origem escolhida");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.peca(origem).MovimentoPossivel(destino))
            {
                throw new TabuleiroException("Posição de destino inválida");
            }
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            Pecas.Add(peca);
        }

        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        private Cor Adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        private Peca Rei(Cor cor)
        {
            foreach (Peca x in PecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        public bool TestaXequeMate(Cor cor)
        {
            if (!EstaEmCheque(cor))
            {
                return false;
            }
            foreach (Peca x in PecasEmJogo(cor))
            {
                bool[,] mat = x.MovimentosPossiveis();
                for (int i = 0; i < Tabuleiro.Linha; i++)
                {
                    for (int j = 0; j < Tabuleiro.Coluna; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = x.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca PecaCapturada = executaMovimento(origem, destino);
                            bool TesteXeque = EstaEmCheque(cor);
                            DesfazMovimento(origem, destino, PecaCapturada);
                            if (!TesteXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public bool EstaEmCheque(Cor cor)
        {
            Peca R = Rei(cor);
            if (R == null)
            {
                throw new TabuleiroException("Não tem Rei da cor" + cor + "no tabuleiro.");
            }
            foreach (Peca x in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = x.MovimentosPossiveis();
                if (mat[R.Posicao.Linha, R.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public void ColocarPecas()
        {

            ColocarNovaPeca('a', 2, new Peao(this, Tabuleiro, Cor.Branca));
            ColocarNovaPeca('b', 2, new Peao(this, Tabuleiro, Cor.Branca));
            //ColocarNovaPeca('c', 2, new Peao(this, Tabuleiro, Cor.Branca));
            //ColocarNovaPeca('d', 2, new Peao(this, Tabuleiro, Cor.Branca));
            //ColocarNovaPeca('e', 2, new Peao(this, Tabuleiro, Cor.Branca));
            //ColocarNovaPeca('f', 2, new Peao(this, Tabuleiro, Cor.Branca));
            //ColocarNovaPeca('g', 2, new Peao(this, Tabuleiro, Cor.Branca));
            ColocarNovaPeca('h', 7, new Peao(this, Tabuleiro, Cor.Branca));

            //ColocarNovaPeca('a', 1, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('h', 1, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('b', 1, new Cavalo(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('g', 1, new Cavalo(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('c', 1, new Bispo(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('f', 1, new Bispo(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('e', 1, new Rei(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('d', 1, new Dama(Tabuleiro, Cor.Branca));



            //ColocarNovaPeca('a', 7, new Peao(this, Tabuleiro, Cor.Preta));
            //ColocarNovaPeca('b', 7, new Peao(this, Tabuleiro, Cor.Preta));
            //ColocarNovaPeca('c', 7, new Peao(this, Tabuleiro, Cor.Preta));
            //ColocarNovaPeca('d', 7, new Peao(this, Tabuleiro, Cor.Preta));
            //ColocarNovaPeca('e', 7, new Peao(this, Tabuleiro, Cor.Preta));
            //ColocarNovaPeca('f', 7, new Peao(this, Tabuleiro, Cor.Preta));
            //ColocarNovaPeca('g', 7, new Peao(this, Tabuleiro, Cor.Preta));
            //ColocarNovaPeca('h', 7, new Peao(this, Tabuleiro, Cor.Preta));

            ColocarNovaPeca('a', 8, new Torre(Tabuleiro, Cor.Preta));
            //ColocarNovaPeca('h', 8, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('b', 8, new Cavalo(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('g', 8, new Cavalo(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('c', 8, new Bispo(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('f', 8, new Bispo(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('e', 8, new Rei(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('d', 8, new Dama(Tabuleiro, Cor.Preta));
        }

    }
}