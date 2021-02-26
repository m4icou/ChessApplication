using System;
using Tabuleiro;
using Xadrez;

namespace ChessApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            TabuleiroClass tab = new TabuleiroClass(8,8);
            
            tab.ColocarPeca(new Rei(tab,Cor.Preta), new Posicao(3,2));
            tab.ColocarPeca(new Rei(tab,Cor.Branca), new Posicao(2,1));
            tab.ColocarPeca(new Torre(tab,Cor.Preta), new Posicao(1,1));
            tab.ColocarPeca(new Rei(tab,Cor.Preta), new Posicao(5,5));
            
            Tela.ImprimeTabuleiro(tab);
            
        }
    }
}
