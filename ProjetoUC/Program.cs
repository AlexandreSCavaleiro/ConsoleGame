using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUC
{
    class Program
    {

        public static void Main()
        {
            Console.WriteLine("""
                 =================  MENU  =================
                
                    1. Iniciar mineração.
                    2. Meus pontos.
                    3. Ver meu inventário.

                    0. Sair.

                 ==========================================
                 """);

            Console.Write("- Selecione uma opção: ");

            int op = Convert.ToInt32(Console.ReadLine());

            switch (op) {

                case 1: //1. Iniciar mineração.
                    //TODO start mapping.
                    Console.WriteLine("mapa");
                    break;
            }

        }
    }
}