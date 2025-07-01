using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProjetoUC
{
    class Program
    {
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

        public static async Task Main()
        {
            Jogo jogo = new Jogo();
            Map map = new Map();   
            Persistence persisManager = new Persistence();
        
            ConsoleKey op = ConsoleKey.D0;
            bool jogando = true;

            exibirMenu();
            

            while (jogando)
            {

                Console.Write("- Selecione uma opção: ");

                op = Console.ReadKey(true).Key;

                switch (op)
                {
                    //1. inicia mineração
                    case ConsoleKey.NumPad1: 
                    case ConsoleKey.D1:

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

                    //2. total de pontos
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2: //total de pontos no inventario
                        clean();
                        Console.WriteLine($"""

                            Voce tem {Inv.totalPontos()} pontos.

                        """);

                        break;

                    //3. mostrar inventário
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3: //mostrar inventário
                        clean();
                        Console.WriteLine("""
                                Seu inventário no momento: 

                            """);
                        Inv.showInv();
                        
                        break;

                    //4. pickdrop antes da mineração pTESTE somente
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4: //pickdrop pra n ter que ficar minerando enquanto to testando
                        clean();
                        Console.WriteLine("    Você foi minerar e encontrou");
                        jogo.pickDrop();
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

        } //main
    } //classe
}