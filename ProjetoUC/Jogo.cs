using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUC
{
    class Jogo
    {
        public List<Drop> mineriosList = new List<Drop>();
        public List<Drop> joiasList = new List<Drop>();
        public List<Drop> inventario = new List<Drop>();

        Random rand = new Random();
        int raridadeJoia = 85;

        public Jogo()
        {
            inicializar();
        }

        public void inicializar() 
        {
            /*
            * atualmente, cria hardcodded as listas de itens
            * futuramente, a ideia é carregar de um Json
            */

            Drop mine1 = new Drop("Carvão", 1, 1);
            Drop mine2 = new Drop("Cobre", 2, 2);
            Drop mine3 = new Drop("Ferro", 3, 5);
            Drop mine4 = new Drop("Ouro", 4, 10);
            mineriosList.Add(mine1);
            mineriosList.Add(mine2);
            mineriosList.Add(mine3);
            mineriosList.Add(mine4);

            Drop joia1 = new Drop("Esmeralda", 5, 30);
            Drop joia2 = new Drop("Safira", 6, 50);
            Drop joia3 = new Drop("Rubi", 7, 80);
            Drop joia4 = new Drop("Diamante", 8, 100);
            joiasList.Add(joia1);
            joiasList.Add(joia2);
            joiasList.Add(joia3);
            joiasList.Add(joia4);

        }

        public Drop pickDrop()
        {
            int chance = rand.Next(0, 100);
            int iddropJoia = rand.Next(0, joiasList.Count);
            int iddropMine = rand.Next(0, mineriosList.Count);

            Drop drop;

            if (chance < this.raridadeJoia)
            {
                drop = mineriosList[iddropMine];
                Console.WriteLine($"""
                        Você foi minerar e encontrou
                        Um Minerio: {drop.nome} Você ganhou: +{drop.valor}

                    """);
                inventario.Add(drop);
            }
            else
            {
                drop = joiasList[iddropJoia];
                Console.WriteLine($"""
                        Você foi minerar e encontrou
                        Uma Jóia Rara: {drop.nome} Você ganhou: +{drop.valor}

                    """);
                inventario.Add(drop);
            }

            //drop.show();

            return drop;
        }

        public double totalPontos()
        {
            double total = 0;

            if (inventario.Count > 0)
                foreach (var item in inventario)
                {
                    total += item.valor;
                }
            return total;

        }

        public void showInv()
        {
            foreach (var item in inventario)
            {
                item.show();
            }
        }

    }
}
