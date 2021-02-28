using Tabuleiro;

namespace Xadrez
{
    class Rei : Peca
    {
        public Rei(TabuleiroClass tabuleiro, Cor cor):base(tabuleiro,cor)
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
            
            return matriz;

        }

        public override string ToString()
        {
            return "R";
        }

        
    }
}