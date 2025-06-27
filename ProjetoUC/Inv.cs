using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUC
{
    static class Inv
    {
        public static List<SlotInventario> inventario = new List<SlotInventario>() ;

        public static void add(Drop drop)
        {
            bool tem = false;
            foreach (var slot in inventario)
            {
                if (slot.Drop.nome == drop.nome) 
                {
                    slot.Quantidade++;
                    tem = true;
                    break;
                }
                
            }
            if (!tem || inventario.Count < 1)
            { 
                SlotInventario item = new SlotInventario(drop,1);
                inventario.Add(item);
            }
            
        }

        public static void addAsSLot(SlotInventario drop)
        {
            bool tem = false;
            foreach (var slot in inventario)
            {
                if (slot.Drop.nome == drop.Drop.nome)
                {
                    slot.Quantidade += drop.Quantidade;
                    tem = true;
                    break;
                }

            }
            if (!tem || inventario.Count < 1)
            {
                SlotInventario item = drop;
                inventario.Add(item);
            }
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
        public static void organizeInv()
        {
            inventario.Sort((a, b) => b.Drop.valor.CompareTo(a.Drop.valor));
        }

        public static void showInv() //exibir todos os drops no inventário
        {
            organizeInv();
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

        public static void setInvTo(List<SlotInventario> lista)
        {
            inventario.Clear();
            foreach (var item in lista)
            {
                inventario.Add(item);
            }
        }
        
        
   
    }
}
