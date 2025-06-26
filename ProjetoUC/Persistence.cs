using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjetoUC
{
    internal class Persistence
    {
        /**
         *      Serializar a lista
         *   var jString = JsonSerializer.Serialize(Inv.inventario);
         * 
         *      Deserializar a lista
         *   var djString = JsonSerializer.Deserialize<List<SlotInventario>>(jString);
         * 
         **/

        public void Teste() //op 5 no menu POR TESTE
        {
            var jString = JsonSerializer.Serialize(Inv.inventario);
            Console.WriteLine(jString);

            Console.WriteLine();

            var djString = JsonSerializer.Deserialize<List<SlotInventario>>(jString);
            Console.WriteLine(djString);

            Console.WriteLine();

            Console.WriteLine(JsonSerializer.Serialize(djString));

            Console.WriteLine();
        }

    }
}
