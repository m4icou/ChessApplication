using Tabuleiro;

namespace Xadrez
{
    class Cavalo : Peca
    {
         public Cavalo(TabuleiroClass tabuleiro, Cor cor):base(tabuleiro,cor)
        {
        }

        public bool PodeMover(Posicao posicao){
            Peca p = Tabuleiro.peca(posicao);
            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.Linha,Tabuleiro.Coluna];

            Posicao pos = new Posicao(0,0);


            //ne1
            pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna + 1);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //ne2
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 2);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
            }


            //se1
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 2);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //se2
            pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna + 1);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
            }


            //no1
            pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna - 1);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //ne2
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 2);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
            }


            //se1
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 2);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //se2
            pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna - 1);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
            }

  
            
            return matriz;

        }

        public override string ToString()
        {
            return "C";
        }

    }
}