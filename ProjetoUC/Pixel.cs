using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUC
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
            Console.ForegroundColor = this.cor; 
            Console.Write(this.icone);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
