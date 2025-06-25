using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUC
{
    static class Inv
    {
        public static List<SlotInventario> inventario = new List<SlotInventario>();

        public static void add(Drop drop)
        {
            SlotInventario item = new SlotInventario(drop,1);
            inventario.Add(item);
        }

        public static double totalPontos() //retorna a soma total de pontos dos itens no inventario
        {
            double total = 0;

            if (inventario.Count > 0)
                foreach (var item in inventario)
                {
                    total += item.Drop.valor;
                }
            return total;

        }

        public static void showInv() //usa o metodo .show() de drop para exibir todos os drops no inventário
        {
            if (inventario.Count > 0)
            {
                foreach (var item in inventario)
                {
                    Console.WriteLine($"""
                            {item.Quantidade} x {item.Drop.nome} | +{item.Quantidade*item.Drop.valor}
                        """);
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
