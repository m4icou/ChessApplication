using Tabuleiro;

namespace ChessApplication
{
    class Tela
    {
        public static void ImprimeTabuleiro(TabuleiroClass tabuleiro)
        {

            for (int i = 0; i < tabuleiro.Linha; i++)
            {
                for (int j = 0; j < tabuleiro.Coluna; j++)
                {
                    if (tabuleiro.peca(i,j) == null){
                        System.Console.Write(" - ");
                    }
                    System.Console.Write(tabuleiro.peca(i,j) + " ");
                }
                System.Console.WriteLine("\n");
            }
        }
    }
}