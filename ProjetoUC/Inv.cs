using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoUC.Model;

namespace ProjetoUC
{
    class Inv
    {

        private Inv()
        {
            inventario = new List<SlotInventario>();

        }
        static private Inv instance;
        static public Inv Instance => instance ?? (instance = new Inv());


        private List<SlotInventario> inventario;

        public void add(Drop drop)
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

        public void addAsSLot(SlotInventario drop)
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

        public double totalPontos() //retorna a soma total de pontos dos itens no inventario
        {
            double total = 0;

            if (inventario.Count > 0)
                foreach (var item in inventario)
                {
                    total += (item.Drop.valor * item.Quantidade);
                }
            return total;

        }
        public void organizeInv()
        {
            inventario.Sort((a, b) => b.Drop.valor.CompareTo(a.Drop.valor));
        }

        public void showInv() //exibir todos os drops no inventário
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

        public void setInvTo(List<SlotInventario> lista)
        {
            inventario.Clear();
            foreach (var item in lista)
            {
                inventario.Add(item);
            }
        }
        
        
   
    }
}
