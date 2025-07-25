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
        
        // instancia de singleton
        private Menu()
        {
            Run();
        }
        static private Menu instance;
        static public Menu Instance => instance ??= new Menu();

        //attr
        public ConsoleKey op;
        public Persistence PersisM;

        public override void Draw()
        {
            exibirMenu();
        }

        public override void Update()
        {
            lancaMenu();
        }

        // Função que exibe o menu na tela
        public void exibirMenu()
        {
            Console.SetCursorPosition(0, 0);
            //Console.Clear();
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

        // Função que requisita a entrada do usuário
        public void lancaMenu()
        {
            if(!input) return;

            GameManager GM = GameManager.Instance;

            //Console.Write("- Selecione uma opção: ");

            op = Console.ReadKey(true).Key;

            Console.Clear();
            Console.SetCursorPosition(0,13);
            switch (op)
            {
                //1. inicia mineração
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    
                    GM.player.visible = true;
                    GM.player.input = true;

                    GM.mapa = new Map();
                    GM.mapa.visible = true;
                    GM.mapa.input = true;

                    GM.menu.visible = false;
                    GM.menu.input = false;

                    Console.Clear();
                    break;

                //2. total de pontos
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2: //total de pontos no inventario
                    Console.WriteLine($"""

                            Voce tem {GM.player.inventario.totalPontos()} pontos
                            
                        """);

                    break;

                //3. mostrar inventário
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    Console.WriteLine("""
                            Seu inventário no momento: 

                        """);
                    GM.player.inventario.showInv();

                    break;

                //4. pickdrop antes da mineração pTESTE somente
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4: //pickdrop pra n ter que ficar minerando enquanto to testando
                    Console.WriteLine("    Você foi minerar e encontrou");
                    GameManager.Instance.pickDrop();
                    break;


                //8. salva inventario
                case ConsoleKey.NumPad8:
                case ConsoleKey.D8:
                    PersisM = new Persistence();
                    PersisM.NovoInventário();
                    break;

                //9. carregar inventario
                case ConsoleKey.NumPad9:
                case ConsoleKey.D9:
                    PersisM = new Persistence();
                    PersisM.carregaInventario();
                    break;


                case ConsoleKey.Escape: //out
                    Console.WriteLine("""

                            Ok, até a proxima! Volte logo!

                        """);
                    //this.Stop();
                    //GM.Stop();
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
