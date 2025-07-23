using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoUC.Model;

namespace ProjetoUC
{
    class Map : MonoBehaviour
    {
        //Singleton
        static private Map instancia;
        private Map()
        {
            Run();
        }
        static public Map Instance => instancia ??= new Map();

        //mapa vazio
        public Pixel[,] mapa;

        //Icones do mapa
        public Pixel player = Jogador.Instance.pixel;
        public Pixel parede = new Pixel('#', ConsoleColor.DarkGray);
        public Pixel minerio = new Pixel('*', ConsoleColor.Cyan);
        public Pixel escada = new Pixel('H', ConsoleColor.White);
        public Pixel espaco = new Pixel(' ', ConsoleColor.Black);
        
        //AxL do mapa 
        int largura = 40;
        int altura = 15;

        
        // Função de exibição do mapa 
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

        // Função que popula a matriz do mapa
        public void iniciarMapa()
        {
            Jogador.Instance.pos.x = 2;
            Jogador.Instance.pos.y = 2;
            
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

            mapa[Jogador.Instance.pos.x, Jogador.Instance.pos.y] = player; //player
            mapa[1, 1] = escada; //saida

        }

        public override void Start()
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
            Console.Clear();

        }

        public override void Update()
        {
            Console.SetCursorPosition(0, 0);
            desenharMapa(); //exiba

            
            var tecla = Console.ReadKey(true).Key; //le a tecla do usuário

            //usa a tecla para modificar a matriz
            Jogador.Instance.movimentar(tecla);
        }
    }
}
