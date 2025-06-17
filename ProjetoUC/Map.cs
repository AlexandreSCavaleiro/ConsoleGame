using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUC
{
    class Map
    {
        static char[,] mapa;
        static int largura = 80;
        static int altura = 20;
        static int playerX = 1;
        static int playerY = 1;
        static bool jogando = true;


        public void gerarMapa()
        { //precisa da var jogando
            iniciarMapa();

            while (jogando)
            {
                Console.Clear();
                desenharMapa();

                var tecla = Console.ReadKey(true).Key;

                atualizarPosicao(tecla);

            }
        }


        // var tecla = Console.ReadKey(true).Key;
        public static void atualizarPosicao(ConsoleKey tecla)
        {
            int tempX = playerX;
            int tempY = playerY;

            switch (tecla)
            {
                case ConsoleKey.A:
                    tempX--;
                    break;
                case ConsoleKey.D:
                    tempX++;
                    break;
                case ConsoleKey.W:
                    tempY--;
                    break;
                case ConsoleKey.S:
                    tempY++;
                    break;
            }

            if (mapa[tempX, tempY] != '#')
            {
                mapa[playerX, playerY] = ' ';
                mapa[tempX, tempY] = '@';
                playerX = tempX;
                playerY = tempY;
            }
        }

        public static void desenharMapa()
        {
            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    Console.Write(mapa[x, y]);
                }
                Console.WriteLine();
            }
        }

        public static void iniciarMapa()
        {
            mapa = new char[largura, altura];

            for (int x = 0; x < largura; x++)
            {
                for (int y = 0; y < altura; y++)
                {
                    if (x == 0 || y == 0 || x == largura - 1 || y == altura - 1)
                    {
                        mapa[x, y] = '#';
                    }
                    else
                    {
                        mapa[x, y] = ' ';
                    }
                }
            }

            mapa[playerX, playerY] = '@';
        }
    }
}
