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

        public void NovoInventário() //SUBSTITUI o arquivo json pelo inventário atual
        {
            Console.WriteLine("""
                    ESSA FUNÇÃO DELETA O ARQUIVO ANTERIOR !
                    TEM CERTEZA QUE QUER SUBSTITUIR O ARQUIVO?

                            S. SIM      
                        QUALQUER TECLA. NAO

                """);

            var tecla = Console.ReadKey(true).Key;


            if (tecla == ConsoleKey.S) {
                var InvJson = JsonSerializer.Serialize(Inv.inventario); //serializa o inventario como um json

                File.WriteAllText(path, InvJson); //escreve no arquivo

                //confirma o save
                Console.WriteLine("""
                        
                    Inventário SUBSTÍTUIDO!

                    """);
            }
            else
            {
                Console.WriteLine("""
                            
                            Operação Cancelada!

                        """);
            }

            //Console.WriteLine(InvJson);
        }

        public void carregaInventario() //carrega do arquivo json
        {
            Console.WriteLine("""
                    ESSA FUNÇÃO SUBSTITUI O INVENTÁRIO QUE VOCÊ ESTÁ !
                    TEM CERTEZA QUE QUER SUBSTITUIR O INVENTÁRIO?

                            S. SIM      N.NAO

                """);

            var tecla = Console.ReadKey(true).Key;

            if (tecla == ConsoleKey.S)
            {
                var jString = File.ReadAllText(path); //le o testo e carrega na var jString
                var InvJson = JsonSerializer.Deserialize<List<SlotInventario>>(jString); // DEserializa o json em uma variavel 

                Inv.setInvTo(InvJson); //copia a lista para o inventario SUBSTITUI o que estava lá

                //confirma o carregamento
                Console.WriteLine("""
                    
                    Inventário carregado!

                """);
            }
            else
            {
                Console.WriteLine("""
                    
                        Operação Cancelada!
                     
                    """);
            }

                    //Console.WriteLine(InvJson);

        }
    }
}
