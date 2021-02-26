using Tabuleiro;

namespace Tabuleiro
{
    class TabuleiroClass
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }
        private Peca[,] Pecas;

        public TabuleiroClass(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
            Pecas = new Peca[linha, coluna];
        }

        public bool ExistePeca(Posicao posicao){
            VaidarPosicao(posicao);
            return peca(posicao) != null;
        }

        public Peca peca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }

        public Peca peca(Posicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

        public bool PosicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha > Linha || pos.Coluna < 0 || pos.Coluna > Coluna)
            {
                return false;
            }
            return true;
        }

        public void VaidarPosicao(Posicao posicao){
            if(!PosicaoValida(posicao)){
                throw new TabuleiroException ("Posição invalida");
            }
        }
    }
}