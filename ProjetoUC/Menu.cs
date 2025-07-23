using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoUC.Model;

namespace ProjetoUC
{
    class Menu
    {
        // instancia de singleton
        private Menu()
        {
           
        }
        static private Menu instance;
        static public Menu Instance => instance ?? (instance = new Menu());

        // Função que exibe o menu na tela
        public static void exibirMenu()
        {
            Console.WriteLine("""
                 =========================== Menu ===========================
                
                    1. Iniciar mineração.
                    2. Meus pontos.
                    3. Ver meu inventário.

                    8. Salvar.
                    9. Carregar.

                    ESC. Sair.

                 ============================================================
                 """);
        }

        // Função qua mantem o menu no topo do console
        public static void clean()
        {
            Console.Clear();
            exibirMenu();
            //Console.WriteLine("============================================================");
        }

        public void startMenu()
        {
            ConsoleKey op;
            bool jogando = true;
            exibirMenu();

            while (jogando)
            {

                GameManager GM = GameManager.Instance;
                Persistence persisManager = new Persistence();
                

                Console.Write("- Selecione uma opção: ");

                op = Console.ReadKey(true).Key;

                switch (op)
                {
                    //1. inicia mineração
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:

                        clean();
                        Map map = Map.Instance;
                        
                        //map.iniciarMapa();
                        clean();
                        Console.WriteLine("""
                                Voltando a superficie.....
                                Seu inventário depois da mineração: 
                            """);
                        Jogador.Instance.inventario.showInv();

                        break;

                    //2. total de pontos
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2: //total de pontos no inventario
                        clean();
                        Console.WriteLine($"""

                                Voce tem {Jogador.Instance.inventario.totalPontos()} pontos
                            
                            """);

                        break;

                    //3. mostrar inventário
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3: //mostrar inventário
                        clean();
                        Console.WriteLine("""
                                Seu inventário no momento: 

                            """);
                        Jogador.Instance.inventario.showInv();

                        break;

                    //4. pickdrop antes da mineração pTESTE somente
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4: //pickdrop pra n ter que ficar minerando enquanto to testando
                        clean();
                        Console.WriteLine("    Você foi minerar e encontrou");
                        GM.pickDrop();
                        break;


                    //8. salva inventario
                    case ConsoleKey.NumPad8:
                    case ConsoleKey.D8: // salvar inventario no arquivo json
                        clean();
                        persisManager.NovoInventário();

                        break;

                    //9. carregar inventario
                    case ConsoleKey.NumPad9:
                    case ConsoleKey.D9:
                        clean();
                        persisManager.carregaInventario();
                        break;


                    case ConsoleKey.Escape: //out
                        Console.WriteLine("""

                                Ok, até a proxima! Volte logo!

                            """);
                        jogando = false;
                        break;

                    default:
                        Console.WriteLine("""

                                Não entendi, Digite novamente algo valido!

                            """);
                        break;

                }//switch

                Console.WriteLine("============================================================");

            } //while
        }


    }
}
