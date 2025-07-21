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

        public Pixel pixel;
        public string nome;
        public Inventario inventario;
        public Vector2 pos = new Vector2(2,2);

        private Jogador()
        {
            this.nome = "player";
            this.pixel = new Pixel('@', ConsoleColor.DarkYellow);
            this.inventario = Inventario.Instance;
        }
        static public Jogador Instance => instancia??= new Jogador();

        public void movimentar(ConsoleKey tecla)
        {

            int tempX = pos.x;
            int tempY = pos.y;
            int x = pos.x;
            int y = pos.y;

            switch (tecla)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A: //Movimenta para a Esquerda
                    x = pos.Left; 
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D: //Movimenta para a Direita
                    x = pos.Rigth; 
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W: //Movimenta para Cima
                    y = pos.Up; 
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S: //Movimenta para baixo
                    y = pos.Down; 
                    break;
            }


            if (Map.mapa[x, y] == Map.escada)
            {
                Map.jogando = false;
            }
            if (Map.mapa[x, y] != Map.parede)
            {
                if (Map.mapa[x, y] == Map.minerio)
                {
                    //TODO pickdrop
                    Console.Clear();
                    Map.desenharMapa();
                    Console.WriteLine("============================================================");
                    Console.WriteLine("    Ao quebrar a pedra encontra: ");
                    GameManager.Instance.pickDrop();
                    Console.WriteLine("Aperte uma tecla para prosseguir!  ");
                    Console.WriteLine("============================================================");

                    Console.ReadKey(true);

                }
                Map.mapa[tempX, tempY] = Map.espaco;
                Map.mapa[x, y] = Map.player;
                pos.x = x;
                pos.y = y;
            }
            else
            {
                pos.x = tempX;
                pos.y = tempY;
            }
        }
    }
}
