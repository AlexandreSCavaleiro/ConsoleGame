using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public Drop pickDrop() //Seleciona um drop dentro dos vetores 
        {
            int chance = rand.Next(0, 100); //gera uma chance de drop
            int iddrop;

            Drop drop;

            if (chance < this.raridadeJoia) // se a chance de drop for maior q a raridade da joia
            {
                iddrop = rand.Next(0, mineriosList.Count); //escolhe uma das joias escolhendo um indice aleatorio
                drop = mineriosList[iddrop];

                //exibe
                Console.WriteLine($"""
                        Você foi minerar e encontrou
                        Um Minerio: {drop.nome} Você ganhou: +{drop.valor}

                    """);
                inventario.Add(drop); //adiciona no inventário
            }
            else // se a chance for menor q a da raridade da joia, faz a mesma coisa mas com o vetor de minérios.
            {
                iddrop = rand.Next(0, joiasList.Count);
                drop = joiasList[iddrop];
                Console.WriteLine($"""
                        Você foi minerar e encontrou
                        Uma Jóia Rara: {drop.nome} Você ganhou: +{drop.valor}

                    """);
                inventario.Add(drop);
            }

            //drop.show();

            return drop; //retorna o drop
        }

        public double totalPontos() //retorna a soma total de pontos dos itens no inventario
        {
            double total = 0;

            if (inventario.Count > 0)
                foreach (var item in inventario)
                {
                    total += item.valor;
                }
            return total;

        }

        public void showInv() //usa o metodo .show() de drop para exibir todos os drops no inventário
        {
            if (inventario.Count > 0)
            {
                foreach (var item in inventario)
                {
                    item.show();
                }
            }
            else {
                Console.WriteLine("""
                    
                    Seu inventário ainda está vazio!

                """);
            }
        }

    }
}
