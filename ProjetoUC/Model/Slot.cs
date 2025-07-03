using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUC.Model
{
    class Slot
    {
        public Drop Drop { get; set; }
        public int Quantidade { get; set; }

        public Slot(Drop drop, int quantidade)
        {
            Drop = drop;
            Quantidade = quantidade;
        }

    }
}
