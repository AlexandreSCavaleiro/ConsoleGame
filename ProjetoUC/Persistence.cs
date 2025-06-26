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
         **/

        // Caminho específico para caminho documentos
        public static readonly string caminhoDocumentos = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "ConsoleGame", "SaveFile.json");

        string path = "save/savefile.txt";

        public Persistence() 
        {
            Directory.CreateDirectory("save/");
            File.WriteAllText(path, "[]");
            Console.WriteLine("arquivo criado");
        }

        public void Teste() //op 5 no menu POR TESTE
        {
            var InvJson = JsonSerializer.Serialize(Inv.inventario);
            Console.WriteLine(InvJson);
            Console.WriteLine();

            File.WriteAllText(path, InvJson);
            /*
            var djString = JsonSerializer.Deserialize<List<SlotInventario>>(jString);
            Console.WriteLine(djString);
            Console.WriteLine();
            Console.WriteLine(JsonSerializer.Serialize(djString));
            Console.WriteLine();
            */
        }

    }
}
