using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUC
{
    class SlotInventario
    {
        public Drop Drop { get; set; }
        public int Quantidade { get; set; }

        public SlotInventario(Drop drop, int quantidade)
        {
            Drop = drop;
            Quantidade = quantidade;
        }

    }
}
