using System;
using Tabuleiro;
using Xadrez;

namespace ChessApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            TabuleiroClass tabuleiro = new TabuleiroClass(8,8);
            

            tabuleiro.ColocarPeca(new Rei(tabuleiro,Cor.Preta),new Posicao(0,0));
            tabuleiro.ColocarPeca(new Torre(tabuleiro,Cor.Preta),new Posicao(1,2));
            tabuleiro.ColocarPeca(new Torre(tabuleiro,Cor.Preta),new Posicao(3,4));

            Tela.ImprimeTabuleiro(tabuleiro);
        }
    }
}
