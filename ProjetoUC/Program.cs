using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUC
{
    class Program
    {
        public static void exibirMenu()
        {
            Console.WriteLine("""
                 =========================== Menu ===========================
                
                    1. Iniciar mineração.
                    2. Meus pontos.
                    3. Ver meu inventário.

                    0. Sair.

                 ============================================================
                 """);
        }

        public static void clean()
        {
            Console.Clear();
            exibirMenu();
            //Console.WriteLine("============================================================");
        } 

        public static void Main()
        {
            Jogo jogo = new Jogo();
            Map map = new Map();   
            Persistence persisManager = new Persistence();
        
            int op = -1;

            exibirMenu();
            

            while (op!=0)
            {

                Console.Write("- Selecione uma opção: ");

                //TODO sair de oceano azul e lidar com as entradas tortas
                op = Convert.ToInt32(Console.ReadLine());

                switch (op)
                {

                    case 1: // Iniciar mineração.

                        clean();
                        map.gerarMapa(jogo);
                        //map.iniciarMapa();
                        clean();
                        Console.WriteLine("""
                                Voltando a superficie.....
                                Seu inventário depois da mineração: 
                            """);
                        Inv.showInv();

                        break;
                    case 2: //total de pontos no inventario
                        clean();
                        Console.WriteLine($"""

                            Voce tem {Inv.totalPontos()} pontos.

                        """);

                        break;
                    case 3: //mostrar inventário
                        clean();
                        Inv.showInv();
                        
                        break;
                    case 4: //pickdrop pra n ter que ficar minerando enquanto to testando
                        clean();
                        jogo.pickDrop();

                        break;
                    case 5: // salvar inventario no arquivo json
                        clean();
                        persisManager.salvaInventarioAtual();

                        break;
                    case 6:
                        clean();
                        persisManager.carregaInventario();

                        break;


                    case 0: //out
                        Console.WriteLine("""

                                Ok, até a proxima! Volte logo!

                            """);
                        break;

                    default:
                        Console.WriteLine("""

                                Não entendi, Digite novamente algo valido!

                            """);
                        break;

                }//switch


                Console.WriteLine("============================================================");
                
            } //while

        } //main
    } //classe
}