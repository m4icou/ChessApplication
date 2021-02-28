using System;
using Tabuleiro;

namespace Xadrez
{
    class Torre : Peca
    {
        public Torre(TabuleiroClass tabuleiro, Cor cor) : base(tabuleiro, cor){

        }

        public override string ToString()
        {
            return "T";
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
            pos.DefinirValores(Posicao.Linha - 1,Posicao.Coluna);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
                if(Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != Cor){
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }

            //abaixo
            pos.DefinirValores(Posicao.Linha + 1,Posicao.Coluna);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
                if(Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != Cor){
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }

            //direita
            pos.DefinirValores(Posicao.Linha,Posicao.Coluna + 1);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
                if(Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != Cor){
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }

            //esquerda
            pos.DefinirValores(Posicao.Linha,Posicao.Coluna - 1);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
                if(Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != Cor){
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }
            
            return matriz;

        }



    }
}