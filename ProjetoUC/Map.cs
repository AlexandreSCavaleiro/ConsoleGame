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
        int largura = 40;
        int altura = 15;

        //Ponto atual do player
        int playerX = 2;
        int playerY = 2;

        //Ponto inicial do player
        int playerXini = 2;
        int playerYini = 2;


        //var do loop do mapa (feio, eu sei)
        static bool jogando = true;

        public void gerarMapa() //a função principal de mapa
        { 
            iniciarMapa(); //popule
            Console.Clear();
            Console.WriteLine($"""
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

            //reset de posição

            //Console.ReadKey(true);
        }


        // var tecla = Console.ReadKey(true).Key;
        public void atualizarPosicao(ConsoleKey tecla)
        {
            //
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
            if (mapa[tempX, tempY] == 'H')
            {
                jogando = false;
            }
            if (mapa[tempX, tempY] != '#')
            {
                mapa[playerX, playerY] = ' ';
                mapa[tempX, tempY] = '@';
                playerX = tempX;
                playerY = tempY;
            }
        }

        public void desenharMapa()
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

        public void iniciarMapa()
        {
            Random rand = new Random();
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

            //preencher com os objetos do mapa

            mapa[playerXini,playerYini] = '@'; //player
            mapa[1, 1] = 'H'; //saida

            //TODO
            //Nodes de mineração
            int quantidade = 5;
            
            for (int x = 0;x < quantidade; x++)
            {
                mapa[rand.Next(1, largura - 1), rand.Next(1, altura - 1)] = '*';
            }

        }
    }
}
