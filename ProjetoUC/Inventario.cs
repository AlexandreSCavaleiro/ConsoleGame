﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoUC.Model;

namespace ProjetoUC
{
    class Inventario
    {

        private Inventario()
        {
            slots = new List<Slot>();

        }
        static private Inventario instance;
        static public Inventario Instance => instance ?? (instance = new Inventario());


        public List<Slot> slots;

        public void add(Drop drop)
        {
            bool tem = false;
            foreach (var slot in slots)
            {
                if (slot.Drop.nome == drop.nome) 
                {
                    slot.Quantidade++;
                    tem = true;
                    break;
                }
                
            }
            if (!tem || slots.Count < 1)
            { 
                Slot item = new Slot(drop,1);
                slots.Add(item);
            }
            
        }

        public void addAsSLot(Slot drop)
        {
            bool tem = false;
            foreach (var slot in slots)
            {
                if (slot.Drop.nome == drop.Drop.nome)
                {
                    slot.Quantidade += drop.Quantidade;
                    tem = true;
                    break;
                }

            }
            if (!tem || slots.Count < 1)
            {
                Slot item = drop;
                slots.Add(item);
            }
        }

        public double totalPontos() //retorna a soma total de pontos dos itens no inventario
        {
            double total = 0;

            if (slots.Count > 0)
                foreach (var item in slots)
                {
                    total += (item.Drop.valor * item.Quantidade);
                }
            return total;

        }
        public void organizeInv()
        {
            slots.Sort((a, b) => b.Drop.valor.CompareTo(a.Drop.valor));
        }

        public void showInv() //exibir todos os drops no inventário
        {
            organizeInv();
            if (slots.Count > 0)
            {
                foreach (var item in slots)
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

        public void setInvTo(List<Slot> lista)
        {
            slots.Clear();
            foreach (var item in lista)
            {
                slots.Add(item);
            }
        }
        
        
   
    }
}
