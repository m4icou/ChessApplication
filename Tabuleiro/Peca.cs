namespace ChessApplication.Tabuleiro
{
    class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMovimento { get; set; }
        public TabuleiroClass Tabuleiro { get; set; }

        public Peca(Posicao posicao, Cor cor, TabuleiroClass tabuleiro){
            Posicao = posicao;
            Cor = cor;
            Tabuleiro = tabuleiro;
            QtdMovimento = 0;
        }
    }
}