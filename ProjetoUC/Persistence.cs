using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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

        public void salvaInventarioAtual() //salva no arquivo json
        {
            var InvJson = JsonSerializer.Serialize(Inv.inventario); //serializa o inventario como um json
            
            File.WriteAllText(path, InvJson); //escreve no arquivo

            //confirma o save
            Console.WriteLine("""
                    
                    Inventário salvo!

                """);

            //Console.WriteLine(InvJson);
        }

        public void carregaInventario() //carrega do arquivo json
        {
            var jString = File.ReadAllText(path); //le o testo e carrega na var jString
            var InvJson = JsonSerializer.Deserialize<List<SlotInventario>>(jString); // DEserializa o json em uma variavel 

            Inv.setInvTo(InvJson); //copia a lista para o inventario SUBSTITUI o que estava lá

            //confirma o carregamento
            Console.WriteLine("""
                    
                    Inventário carregado!

                """);

            //Console.WriteLine(InvJson);
        }

    }
}
