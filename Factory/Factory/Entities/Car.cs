using Factory.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Entities
{
    public class Car : Toy
    {
        protected override void DrawImage(Graphics g)
        {
            Image car = Image.FromFile("Images/car.png");
            g.DrawImage(car, new Rectangle(0, 0, Width, Height));
        }
    }
}
