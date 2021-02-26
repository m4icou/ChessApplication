using System;
using Tabuleiro;

namespace ChessApplication
{
    class Tela
    {
        public static void ImprimeTabuleiro(TabuleiroClass tabuleiro)
        {

            for (int i = 0; i < tabuleiro.Linha; i++)
            {
                System.Console.Write(8 - i + " ");
                for (int j = 0; j < tabuleiro.Coluna; j++)
                {
                    if (tabuleiro.peca(i,j) == null){
                        System.Console.Write("- ");
                    }
                    else{
                        ImprimePeca(tabuleiro.peca(i,j));
                        Console.Write(" ");
                    }
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine("  a b c d e f g h");
        }


        public static void ImprimePeca(Peca peca){
            if(peca.Cor == Cor.Branca){
                System.Console.Write(peca);
            }
            else{
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.Write(peca);
                Console.ForegroundColor = color; 
            }
        }
    }
}