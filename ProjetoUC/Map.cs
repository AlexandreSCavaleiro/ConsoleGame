using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoUC.Model;

namespace ProjetoUC
{
    static class Map
    {
        //mapa vazio
        static public Pixel[,] mapa;

        //Icones do mapa
        static public Pixel player = Jogador.Instance.pixel;
        static public Pixel parede = new Pixel('#', ConsoleColor.DarkGray);
        static public Pixel minerio = new Pixel('*', ConsoleColor.Cyan);
        static public Pixel escada = new Pixel('H', ConsoleColor.White);
        static public Pixel espaco = new Pixel(' ', ConsoleColor.Black);
        
        
        //AxL do mapa 
        static int largura = 40;
        static int altura = 15;


        // var do loop do mapa (feio, eu sei)
        static public bool jogando = true;

        static public void gerarMapa() //a função principal de mapa
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

                //atualizarPosicao(tecla); //usa a tecla para modificar a matriz
                Jogador.Instance.movimentar(tecla);
                
            }
        }


        // Função que cuida da exibição do mapa 
        static public void desenharMapa()
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
        static public void iniciarMapa()
        {
            Jogador.Instance.posX = 2;
            Jogador.Instance.posY = 2;
            
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

            //Nodes de mineração
            int quantidade = rand.Next(5,10);
            
            for (int x = 0;x < quantidade; x++)
            {
                mapa[rand.Next(1, largura - 1), rand.Next(1, altura - 1)] = minerio;
            }

            mapa[Jogador.Instance.posX, Jogador.Instance.posY] = player; //player
            mapa[1, 1] = escada; //saida

        }
    }
}
