using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUC.Model
{
    class Pixel
    {
        private ConsoleColor cor;
        char icone;

        public Pixel(char icone, ConsoleColor cor)
        {

            this.cor = cor;
            this.icone = icone;
        }

        public void show()
        {
            Console.ForegroundColor = cor; 
            Console.Write(icone);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
