using System;
using Tabuleiro;
using Xadrez;

namespace ChessApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            PartidaDeXadrez partida = new PartidaDeXadrez();

            while (!partida.Terminada)
            {
                Console.Clear();
                Tela.ImprimeTabuleiro(partida.Tabuleiro);

                System.Console.WriteLine();
                System.Console.WriteLine("Origem: ");
                Posicao origem = Tela.LerPosicaoXadrez().toPosicao();

                bool [,] posicoesPossiveis = partida.Tabuleiro.peca(origem).MovimentosPossiveis();
                Console.Clear();
                Tela.ImprimeTabuleiro(partida.Tabuleiro, posicoesPossiveis);    

                System.Console.WriteLine("Destino: ");
                Posicao destino = Tela.LerPosicaoXadrez().toPosicao();

                partida.executaMovimento(origem,destino);

            }


        }
    }
}
