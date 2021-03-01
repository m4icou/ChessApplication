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

        public void DecrementarQteMovimentos()
        {
            QtdMovimento--;
        }

        public bool ExisteMovimentosPossiveis(){
            bool[,] mat = MovimentosPossiveis();
            for(int i = 0; i < Tabuleiro.Linha; i++){
                for(int j=0; j < Tabuleiro.Coluna; j++){
                    if(mat[i,j]){
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PodeMoverPara(Posicao posicao){
            return MovimentosPossiveis()[posicao.Linha, posicao.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}