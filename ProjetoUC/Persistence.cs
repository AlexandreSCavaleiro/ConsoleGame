using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ProjetoUC.Model;

namespace ProjetoUC
{
    class Persistence
    {
        GameManager GM = GameManager.Instance;
        string path = "save/savefile.txt"; //caminho padrao relativo ao .exe do jogo

        public Persistence() //ao criar o obj
        {
            if (!File.Exists(path)) //checa a existencia do arquivo e cria vazio se nao existir
            {
                Directory.CreateDirectory("save/");
                File.WriteAllText(path, "[]");
            }
            //Console.WriteLine("arquivo criado");


        }

        //SUBSTITUI o arquivo json pelo inventário atual // 8.SAVE
        public void NovoInventário() 
        {
            Console.WriteLine("""
                    ESSA FUNÇÃO DELETA O ARQUIVO ANTERIOR !
                    TEM CERTEZA QUE QUER SUBSTITUIR O ARQUIVO?

                            S. SIM      
                        QUALQUER TECLA. NAO
                ============================================================
                """);

            var tecla = Console.ReadKey(true).Key;


            if (tecla == ConsoleKey.S) {
                var InvJson = JsonSerializer.Serialize(GM.player.inventario.slots); //serializa o inventario como um json

                //Console.WriteLine(InvJson);

                File.WriteAllText(path, InvJson); //escreve no arquivo

                //confirma o save
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("""
                        
                    Inventário SUBSTÍTUIDO!

                    """);
            }
            else
            {
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("""
                            
                            Operação Cancelada!

                        """);
            }
            Console.ReadKey(true);
            Console.Clear();
            //Console.WriteLine(InvJson);
        }

        //carrega do arquivo json no inventario // 9.LOAD
        public void carregaInventario() 
        {
            Console.WriteLine("""
                    ESSA FUNÇÃO SUBSTITUI O INVENTÁRIO QUE VOCÊ ESTÁ !
                    TEM CERTEZA QUE QUER SUBSTITUIR O INVENTÁRIO?

                            S. SIM      N.NAO
                ============================================================
                """);

            var tecla = Console.ReadKey(true).Key;

            if (tecla == ConsoleKey.S)
            {
                var jString = File.ReadAllText(path); //le o testo e carrega na var jString
                var InvJson = JsonSerializer.Deserialize<List<Slot>>(jString); // DEserializa o json em uma variavel 

                GM.player.inventario.setInvTo(InvJson); //copia a lista para o inventario SUBSTITUI o que estava lá

                //confirma o carregamento
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("""
                    
                    Inventário carregado!

                """);
            }
            else
            {
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("""
                    
                        Operação Cancelada!
                     
                    """);
            }
            Console.ReadKey(true);
            Console.Clear();
            //Console.WriteLine(InvJson);

        }
    }
}
