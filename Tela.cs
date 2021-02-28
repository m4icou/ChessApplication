using System;
using Tabuleiro;
using Xadrez;


namespace ChessApplication
{
    class Tela
    {
        public static void ImprimeTabuleiro(TabuleiroClass tabuleiro)
        {

            for (int i = 0; i < tabuleiro.Linha; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabuleiro.Coluna; j++)
                {
                    ImprimePeca(tabuleiro.peca(i,j));
                }
                Console.WriteLine();     
            }
            Console.WriteLine("  a b c d e f g h");
        }

         public static void ImprimeTabuleiro(TabuleiroClass tabuleiro, bool[,] posicoesPossiveis)
        {

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tabuleiro.Linha; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabuleiro.Coluna; j++)
                {
                    if(posicoesPossiveis[i,j]){
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else{
                        Console.BackgroundColor = fundoOriginal;
                    }
                    ImprimePeca(tabuleiro.peca(i,j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();     
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez LerPosicaoXadrez(){
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);  
        }

        public static void ImprimePeca(Peca peca){

            if(peca == null){
                Console.Write("- ");
            }
            else{

                if(peca.Cor == Cor.Branca){
                    Console.Write(peca);
                }
                else{
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux; 
                }
                Console.Write(" ");

            }
        }
    }
}