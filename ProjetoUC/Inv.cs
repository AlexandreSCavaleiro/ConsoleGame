using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUC
{
    static class Inv
    {
        public static List<Drop> inventario = new List<Drop>();

        public static void add(Drop drop)
        {
            inventario.Add(drop);
        }

        public static double totalPontos() //retorna a soma total de pontos dos itens no inventario
        {
            double total = 0;

            if (inventario.Count > 0)
                foreach (var item in inventario)
                {
                    total += item.valor;
                }
            return total;

        }

        public static void showInv() //usa o metodo .show() de drop para exibir todos os drops no inventário
        {
            if (inventario.Count > 0)
            {
                foreach (var item in inventario)
                {
                    item.show();
                }
            }

            else
            {
                Console.WriteLine("""
                    
                    Seu inventário ainda está vazio!

                """);
            }
        }
    }
}
