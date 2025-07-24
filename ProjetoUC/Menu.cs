using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoUC.Model;

namespace ProjetoUC
{
    class Menu : MonoBehaviour
    {
        public ConsoleKey op;
        public Persistence persisManager;
        // instancia de singleton
        private Menu()
        {
            Run();
        }
        static private Menu instance;
        static public Menu Instance => instance ?? (instance = new Menu());

        
        public override void Update()
        {
            if (!GameManager.Instance.minerando)
            {
                lancaMenu();

            }
        }

        // Função que exibe o menu na tela
        public void exibirMenu()
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
        public void clean()
        {
            Console.Clear();
            //exibirMenu();
            //Console.WriteLine("============================================================");
        }

        public void lancaMenu()
        {
            Console.Clear();
            exibirMenu();

            GameManager GM = GameManager.Instance;

            Console.Write("- Selecione uma opção: ");

            op = Console.ReadKey(true).Key;

            switch (op)
            {
                //1. inicia mineração
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:

                    GM.minerando = true;
                    GM.mapa = new Map();

                    break;

                //2. total de pontos
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2: //total de pontos no inventario
                    //clean();
                    Console.WriteLine($"""

                            Voce tem {Jogador.Instance.inventario.totalPontos()} pontos
                            
                        """);

                    break;

                //3. mostrar inventário
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3: //mostrar inventário
                    //clean();
                    Console.WriteLine("""
                            Seu inventário no momento: 

                        """);
                    Jogador.Instance.inventario.showInv();

                    break;

                //4. pickdrop antes da mineração pTESTE somente
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4: //pickdrop pra n ter que ficar minerando enquanto to testando
                    //clean();
                    Console.WriteLine("    Você foi minerar e encontrou");
                    GameManager.Instance.pickDrop();
                    break;


                //8. salva inventario
                case ConsoleKey.NumPad8:
                case ConsoleKey.D8:

                    persisManager = new Persistence();
                    clean();
                    persisManager.NovoInventário();
                    break;

                //9. carregar inventario
                case ConsoleKey.NumPad9:
                case ConsoleKey.D9:

                    persisManager = new Persistence();
                    clean();
                    persisManager.carregaInventario();
                    break;


                case ConsoleKey.Escape: //out
                    Console.WriteLine("""

                            Ok, até a proxima! Volte logo!

                        """);
                    this.Stop();
                    GM.Stop();
                    break;

                default:
                    Console.WriteLine("""

                            Não entendi, Digite novamente algo valido!

                        """);
                    break;

            }//switch

            
            //Console.WriteLine("============================================================");

        }


    }
}
