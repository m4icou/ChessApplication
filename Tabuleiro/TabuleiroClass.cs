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

        public Peca peca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }

        public Peca peca(Posicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
        }

        public bool ExistePeca(Posicao posicao)
        {
            ValidarPosicao(posicao);
            return peca(posicao) != null;
        }

        public void ColocarPeca(Peca p, Posicao posicao)
        {
            if (ExistePeca(posicao))
            {
                throw new TabuleiroException("Já existe uma peça nesta posição");
            }
            Pecas[posicao.Linha, posicao.Coluna] = p;
            p.Posicao = posicao;
        }

        public Peca RetirarPeca(Posicao posicao){
            if(peca(posicao) == null){
                return null;
            }
            Peca aux = peca(posicao);
            aux.Posicao = null;
            Pecas[posicao.Linha, posicao.Coluna] = null;
            return aux;
        }

        public bool PosicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linha || pos.Coluna < 0 || pos.Coluna >= Coluna)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao posicao)
        {
            if (!PosicaoValida(posicao))
            {
                throw new TabuleiroException("Posição invalida");
            }
        }
    }
}