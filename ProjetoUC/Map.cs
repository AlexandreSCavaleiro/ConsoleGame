using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUC
{
    class Map
    {
        //mapa vazio
        static char[,] mapa;

        //AxL do mapa 
        static int largura = 40;
        static int altura = 15;

        //Ponto inicial do player
        static int playerXini = 3;
        static int playerYini = 3;

        //var do loop do mapa (feio, eu sei)
        static bool jogando = true;

        public void gerarMapa() //a função principal de mapa
        { 
            iniciarMapa(); //popule
            Console.Clear();
            Console.WriteLine("""
                ============================================================
                    Sobre a mineração:
                        @ - Você
                        # - Parede 
                        H - Escada (voltar a superficie)
                        * - Minério

                    Movimente-se com WASD

                - aperte qualquer tecla para continuar.

                ============================================================
                """);
            Console.ReadKey(true);

            while (jogando)
            {
                Console.Clear();
                desenharMapa(); //exiba

                var tecla = Console.ReadKey(true).Key; //le a tecla do usuário

                atualizarPosicao(tecla); //usa a tecla para modificar a matriz

            }

        }


        // var tecla = Console.ReadKey(true).Key;
        public static void atualizarPosicao(ConsoleKey tecla)
        {
            //
            int tempX = playerXini;
            int tempY = playerYini;

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
            if (mapa[tempX, tempY] == 'H')
            {
                jogando = false;
            }
            if (mapa[tempX, tempY] != '#')
            {
                mapa[playerXini, playerYini] = ' ';
                mapa[tempX, tempY] = '@';
                playerXini = tempX;
                playerYini = tempY;
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

            mapa[playerXini, playerYini] = '@';
            mapa[1, 1] = 'H';
        }
    }
}
