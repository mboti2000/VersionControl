using Factory.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Entities
{
    public class Present : Toy
    {
       public SolidBrush Box { get; private set; }
       public SolidBrush Ribbon { get; private set; }
        public Present(Color box,Color ribbon) {
           Box = new SolidBrush(box);
           Ribbon = new SolidBrush(ribbon);
        }

        protected override void DrawImage(Graphics g)
        {
           g.FillRectangle(Box, 0, 0, Width, Height);
           g.FillRectangle(Ribbon, 20, 0, Width/5, Height);
           g.FillRectangle(Ribbon, 0, 20, Width, Height/5);
        }
    }
}
