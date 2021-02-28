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
                        Tela.ImprimeTabuleiro(partida.Tabuleiro);
                        System.Console.WriteLine();
                        System.Console.WriteLine("Turno: " + partida.Turno);
                        System.Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);

                        System.Console.WriteLine();
                        System.Console.WriteLine("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().toPosicao();
                        partida.ValidarPosicaoDeOrigem(origem);

                        bool [,] posicoesPossiveis = partida.Tabuleiro.peca(origem).MovimentosPossiveis();
                        Console.Clear();
                        Tela.ImprimeTabuleiro(partida.Tabuleiro, posicoesPossiveis);    

                        System.Console.WriteLine("Destino: ");
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
