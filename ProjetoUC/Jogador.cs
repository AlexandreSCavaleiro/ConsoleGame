using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Numerics;

namespace ProjetoUC
{
    static class Jogador
    {
        static public Pixel pixel = new Pixel('@', ConsoleColor.DarkYellow);
        static public string nome = "player";
        static public int posX = 2;
        static public int posY = 2;
         
        public static void movimentar(ConsoleKey tecla)
        {
            //
            int tempX = posX;
            int tempY = posY;

            switch (tecla)
            {

                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    tempX--; //Movimenta para a Esquerda
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    tempX++; //Movimenta para a Direita
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    tempY--; //Movimenta para Cima
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    tempY++; //Movimenta para baixo
                    break;
            }
            if (Map.mapa[tempX, tempY] == Map.escada)
            {
                Map.jogando = false;

            }
            if (Map.mapa[tempX, tempY] != Map.parede)
            {
                if (Map.mapa[tempX, tempY] == Map.minerio)
                {
                    //TODO pickdrop
                    Console.Clear();
                    Map.desenharMapa();
                    Console.WriteLine("============================================================");
                    Console.WriteLine("    Ao quebrar a pedra encontra: ");
                    GameManager.pickDrop();
                    Console.WriteLine("Aperte uma tecla para prosseguir!  ");
                    Console.WriteLine("============================================================");

                    Console.ReadKey(true);

                }
                Map.mapa[posX,posY] = Map.espaco;
                Map.mapa[tempX, tempY] = Map.player;
                posX = tempX;
                posY = tempY;
            }
        }
    }
}
