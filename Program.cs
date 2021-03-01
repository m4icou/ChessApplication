using System;
using Tabuleiro;
using Xadrez;

namespace ChessApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
               PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada)
                {
                    try{
                        Console.Clear();
                        Tela.ImprimirPartida(partida);

                        System.Console.WriteLine();
                        System.Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().toPosicao();
                        partida.ValidarPosicaoDeOrigem(origem);

                        bool [,] posicoesPossiveis = partida.Tabuleiro.peca(origem).MovimentosPossiveis();
                        Console.Clear();
                        Tela.ImprimeTabuleiro(partida.Tabuleiro, posicoesPossiveis);    

                        System.Console.WriteLine();
                        System.Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().toPosicao();
                        partida.ValidarPosicaoDeDestino(origem,destino);

                        partida.RealizaJogada(origem,destino);
                    }
                    catch(TabuleiroException e){
                        System.Console.WriteLine(e.Message);
                        System.Console.ReadLine();
                    } 
                }

            }
            catch(Exception e){
                System.Console.WriteLine(e.Message);
            }


        }
    }
}
