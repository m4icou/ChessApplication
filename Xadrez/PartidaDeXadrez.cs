using System;
using Tabuleiro;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        public TabuleiroClass Tabuleiro { get; private set; }
        public int Turno {get; private set; }
        public Cor JogadorAtual {get; private set; }
        public bool Terminada {get; private set;}


        public PartidaDeXadrez()
        {
            Tabuleiro = new TabuleiroClass(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            ColocarPecas();
        }


        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tabuleiro.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(p, destino);
        }

        public void RealizaJogada(Posicao origem, Posicao destino){
            executaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }

        public void ValidarPosicaoDeOrigem(Posicao posicao){
            if(Tabuleiro.peca(posicao) == null){
                throw new TabuleiroException("Não existe peça na posição de origem escolhida");
            }
            if(JogadorAtual != Tabuleiro.peca(posicao).Cor){
                throw new TabuleiroException("A peça de origem escolhida não é sua");
            }
            if(!Tabuleiro.peca(posicao).ExisteMovimentosPossiveis()){
                throw new TabuleiroException("Não há movimentos possiveis para a peça de origem escolhida");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino){
            if(!Tabuleiro.peca(origem).PodeMoverPara(destino)){
                throw new TabuleiroException("Posição de destino inválida");
            }
        }

        private void MudaJogador(){
            if(JogadorAtual == Cor.Branca){
                JogadorAtual = Cor.Preta;
            }
            else{
                JogadorAtual = Cor.Branca;
            }
        }

        public void ColocarPecas()
        {
            Tabuleiro.ColocarPeca(new Rei(Tabuleiro, Cor.Branca), new PosicaoXadrez('d', 1).toPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('a', 1).toPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('h', 1).toPosicao());

            Tabuleiro.ColocarPeca(new Rei(Tabuleiro, Cor.Preta), new PosicaoXadrez('e', 8).toPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('a', 8).toPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('h', 8).toPosicao());
        }

    }
}