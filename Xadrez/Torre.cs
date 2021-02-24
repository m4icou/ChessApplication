using Tabuleiro;

namespace Xadrez
{
    class Torre : Peca
    {
        public Torre(TabuleiroClass tabuleiro, Cor cor):base(tabuleiro,cor)
        {
        }

        public override string ToString()
        {
            return "T";
        }
    }
}