using Tabuleiro;

namespace Xadrez
{
    class Peao : Peca
    {

        public Peao(TabuleiroClass tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public bool PodeMover(Posicao posicao)
        {
            Peca p = Tabuleiro.peca(posicao);
            return p == null || p.Cor != Cor;
        }

        public bool ExisteInimigo(Posicao pos)
        {
            Peca p = Tabuleiro.peca(pos);
            return p != null && p.Cor != Cor;
        }

        private bool Livre(Posicao pos)
        {
            return Tabuleiro.peca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.Linha, Tabuleiro.Coluna];

            Posicao pos = new Posicao(0, 0);
            

            if (Cor == Cor.Branca)
            {
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                Posicao p2 = new Posicao(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos) && Livre(p2) && QtdMovimento == 0 )
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

            }

            else{
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                Posicao p2 = new Posicao(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos) && QtdMovimento == 0 && Livre(p2))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }
            }
            //acima




            return matriz;

        }

        public override string ToString()
        {
            return "P";
        }
    }
}