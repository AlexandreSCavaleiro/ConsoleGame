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
        /**
         *      Serializar a lista
         *   var jString = JsonSerializer.Serialize(Inv.inventario);
         * 
         *      Deserializar a lista
         *   var djString = JsonSerializer.Deserialize<List<SlotInventario>>(jString);
         * 
         *

        // Caminho específico para caminho documentos
        public static readonly string caminhoDocumentos = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "ConsoleGame", "SaveFile.json");


        */

        string path = "save/savefile.txt";

        public Persistence() 
        {
            if (!File.Exists(path))
            {
                Directory.CreateDirectory("save/");
                File.WriteAllText(path, "[]");
            }
            //Console.WriteLine("arquivo criado");


        }

        public void salvaInventarioAtual() //op 5 no menu POR TESTE
        {
            var InvJson = JsonSerializer.Serialize(Inv.inventario);
            
            File.WriteAllText(path, InvJson);

            Console.WriteLine("""
                    
                    Inventário salvo!

                """);

            //Console.WriteLine(InvJson);
        }


        public void carregaInventario() 
        {
            var jString = File.ReadAllText(path);
            var InvJson = JsonSerializer.Deserialize<List<SlotInventario>>(jString);

            Inv.setInvTo(InvJson);

            //Console.WriteLine(InvJson);
            Console.WriteLine("""
                    
                    Inventário carregado!

                """);
   
        }

    }
}
