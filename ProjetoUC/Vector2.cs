using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUC
{
    public class Vector2
    {
        //attr
        public int x, y;
        
        //constructor
        public Vector2(int x, int y)
        {
            this.x = x; 
            this.y = y;
        }

        //funcoes de movimento
        public int Up => this.y -= 1;
        public int Down => this.y += 1;
        public int Left => this.x -= 1;
        public int Rigth => this.x += 1;

    }
}
