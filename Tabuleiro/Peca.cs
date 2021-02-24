namespace Tabuleiro
{
    class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMovimento { get; set; }
        public TabuleiroClass Tabuleiro { get; set; }

        public Peca(TabuleiroClass tabuleiro,Cor cor){
            Posicao = null;
            Cor = cor;
            Tabuleiro = tabuleiro;
            QtdMovimento = 0;
        }
    }
}