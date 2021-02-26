using Tabuleiro;

namespace Xadrez
{
    class Torre : Peca
    {
        public Torre(TabuleiroClass tabuleiro, Cor cor):base(tabuleiro,cor)
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
            pos.DefinirValores(pos.Linha - 1,pos.Coluna);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
                if(Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != Cor){
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }

            //direita
            pos.DefinirValores(pos.Linha,pos.Coluna);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
                if(Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != Cor){
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }
            
            return matriz;

        }


        public override string ToString()
        {
            return "T";
        }
    }
}