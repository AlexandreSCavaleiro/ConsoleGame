using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Numerics;
using ProjetoUC.Model;

namespace ProjetoUC
{
    class Jogador
    {
        static private Jogador instancia;

        private Pixel pixel;
        private string nome;
        private int posX;
        private int posY;

        private Jogador()
        {
            this.posX = 2;
            this.posY = 2;
            this.nome = "player";
            this.pixel = new Pixel('@', ConsoleColor.DarkYellow);
        }
        
        static public Jogador Instancia => instancia??= new Jogador();

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
