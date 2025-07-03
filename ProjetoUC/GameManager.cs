using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoUC
{
    static class GameManager
    {
        static public List<Drop> mineriosList = new List<Drop>();
        static public List<Drop> joiasList = new List<Drop>();


        static Random rand = new Random();
        static int raridadeJoia = 85;

        static public void inicializar() 
        {
            //Função que preenche o campo nome do Jogador
            Console.WriteLine("""
                    
                    Olá Jogador, Bem vindo!
                    Escreva seu nome aseguir por favor.

                """);
            Console.Write("    > ");

            //TODO
            //entrada acertiva
            string nome = Console.ReadLine();
            if (nome.Count() > 0)
            {
                Jogador.nome = nome;
            }

            //TODO
            //atualmente, cria hardcodded as listas de itens
            //futuramente, a ideia é carregar de um Json
            mineriosList.Add(new Drop("Carvão", 1, 1));
            mineriosList.Add(new Drop("Cobre", 2, 2));
            mineriosList.Add(new Drop("Ferro", 3, 5));
            mineriosList.Add(new Drop("Ouro", 4, 10));

      
            joiasList.Add(new Drop("Esmeralda", 5, 30));
            joiasList.Add(new Drop("Safira", 6, 50));
            joiasList.Add(new Drop("Rubi", 7, 80));
            joiasList.Add(new Drop("Diamante", 8, 100));

        }

        static public Drop pickDrop() //Seleciona um drop dentro dos vetores 
        {
            int chance = rand.Next(0, 100); //gera uma chance de drop
            int iddrop;

            Drop drop;

            if (chance < raridadeJoia) // se a chance de drop for maior q a raridade da joia
            {
                iddrop = rand.Next(0, mineriosList.Count); //escolhe uma das joias escolhendo um indice aleatorio
                drop = mineriosList[iddrop];

                //exibe
                Console.WriteLine($"""
                        Um Minerio: {drop.nome} Você ganhou: +{drop.valor}

                    """);
                Inv.add(drop); //adiciona no inventário
            }
            else // se a chance for menor q a da raridade da joia, faz a mesma coisa mas com o vetor de minérios.
            {
                iddrop = rand.Next(0, joiasList.Count);
                drop = joiasList[iddrop];
                Console.WriteLine($"""
                        Uma Jóia Rara: {drop.nome} Você ganhou: +{drop.valor}

                    """);
                Inv.add(drop);
            }

            //drop.show();

            return drop; //retorna o drop
        }

    }
}
