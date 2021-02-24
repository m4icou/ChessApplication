using Tabuleiro;

namespace Xadrez
{
    class Rei : Peca
    {
        public Rei(TabuleiroClass tabuleiro, Cor cor):base(tabuleiro,cor)
        {
        }

        public override string ToString()
        {
            return "R";
        }
    }
}