using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUC
{
    public class Drop
    {
        public String nome { get; set; }
        public int id { get; set; }
        public int valor { get; set; }

        public Drop(string nome, int id, int valor)
        {
            this.nome = nome;
            this.id = id;
            this.valor = valor;
        }

        public void showAll()
        {
            Console.WriteLine($"""
                    [{nome} | {id} | {valor}]
                """);
        }

        public void show()
        {
            Console.WriteLine($"""
                {nome} | +{valor}
                """);
        }

        public String toString()
        {
            string retorno = $"{nome} | {id} | {valor}";

            return retorno;
        }
    }
}
