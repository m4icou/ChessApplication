namespace Tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMovimento { get; protected set; }
        public TabuleiroClass Tabuleiro { get; protected set; }

        public Peca(TabuleiroClass tabuleiro, Cor cor)
        {
            Posicao = null;
            Tabuleiro = tabuleiro;
            Cor = cor;
            QtdMovimento = 0;
        }

        public void IncrementarQteMovimentos()
        {
            QtdMovimento++;
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}