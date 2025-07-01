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
        static Pixel[,] mapa;

        //Icones do mapa
        Pixel player = new Pixel('@', ConsoleColor.DarkYellow);
        Pixel parede = new Pixel('#', ConsoleColor.DarkGray);
        Pixel minerio = new Pixel('*', ConsoleColor.DarkCyan);
        Pixel escada = new Pixel('H', ConsoleColor.Magenta);
        Pixel espaco = new Pixel(' ', ConsoleColor.Black);
        
        
        //AxL do mapa 
        int largura = 40;
        int altura = 15;

        //Ponto atual do player
        int playerX = 2;
        int playerY = 2;


        // var do loop do mapa (feio, eu sei)
        static bool jogando = true;

        public void gerarMapa(Jogo jogo) //a função principal de mapa
        { 
            jogando = true ;
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
            Console.Clear();

            while (jogando)
            {
                Console.SetCursorPosition(0,0);
                desenharMapa(); //exiba

                var tecla = Console.ReadKey(true).Key; //le a tecla do usuário

                atualizarPosicao(tecla, jogo); //usa a tecla para modificar a matriz

                
            }

            Console.ForegroundColor = ConsoleColor.White;

        }


        // Função que cuida da mudança de posição do player no mapa
        public void atualizarPosicao(ConsoleKey tecla, Jogo jogo)
        {
            //
            int tempX = playerX;
            int tempY = playerY;

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
            if (mapa[tempX, tempY] == escada)
            {
                jogando = false;
                
            }
            if (mapa[tempX, tempY] != parede)
            {
                if(mapa[tempX, tempY] == minerio)
                {
                    //TODO pickdrop
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("    Ao quebrar a pedra encontra: ");
                    jogo.pickDrop();
                    Console.WriteLine("Aperte uma tecla para prosseguir!  ");
                    Console.WriteLine("============================================================");

                    Console.ReadKey(true);

                }
                mapa[playerX, playerY] = espaco;
                mapa[tempX, tempY] = player;
                playerX = tempX;
                playerY = tempY;
            }

        }

        // Função que cuida da exibição do mapa 
        public void desenharMapa()
        {
            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    var pixel = mapa[x, y];
                    pixel.show();
                    //Console.Write(mapa[x, y]);
                }
                Console.WriteLine();
            }
        }

        // Função que inicia a matriz do mapa
        public void iniciarMapa()
        {
            playerX = 2;
            playerY = 2;  
            Random rand = new Random();
            mapa = new Pixel[largura, altura];

            for (int x = 0; x < largura; x++)
            {
                for (int y = 0; y < altura; y++)
                {
                    if (x == 0 || y == 0 || x == largura - 1 || y == altura - 1)
                    {
                        mapa[x, y] = parede;
                    }
                    else
                    {
                        mapa[x, y] = espaco;
                    }
                }
            }

            //preencher com os objetos do mapa

            mapa[playerX,playerY] = player; //player
            mapa[1, 1] = escada; //saida

            //TODO
            //Nodes de mineração
            int quantidade = 5;
            
            for (int x = 0;x < quantidade; x++)
            {
                mapa[rand.Next(1, largura - 1), rand.Next(1, altura - 1)] = minerio;
            }

        }
    }
}
