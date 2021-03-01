using Tabuleiro;

namespace Xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez Partida;

        public Rei(TabuleiroClass tabuleiro, Cor cor, PartidaDeXadrez partida):base(tabuleiro,cor)
        {
            Partida = partida;
        }

        public bool PodeMover(Posicao posicao){
            Peca p = Tabuleiro.peca(posicao);
            return p == null || p.Cor != Cor;
        }


        private bool TesteTorreParaRoque(Posicao pos){
            Peca p = Tabuleiro.peca(pos);
            return p != null && p is Torre && p.Cor == Cor && p.QtdMovimento == 0;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.Linha,Tabuleiro.Coluna];

            Posicao pos = new Posicao(0,0);

            //acima
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //ne
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //abaixo
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //se
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
            }


            //no
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
            }


            //so
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
            }
            
            //#jogada especial roque
            if(QtdMovimento == 0 && !Partida.Xeque){
                //#jogada especial roque pequeno
                Posicao PosT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if(TesteTorreParaRoque(PosT1)){
                    Posicao p1 = new Posicao(Tabuleiro.Linha, Tabuleiro.Coluna + 1);
                    Posicao p2 = new Posicao(Tabuleiro.Linha, Tabuleiro.Coluna + 2);
                    if(Tabuleiro.peca(p1) == null && Tabuleiro.peca(p2) == null){
                        matriz[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }
            }



            return matriz;

        }

        public override string ToString()
        {
            return "R";
        }

        
    }
}