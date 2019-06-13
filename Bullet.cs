using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiveBomb
{
    class Bullet
    {
        public int X;
        public int Y;
        public int Angle;
        public Bitmap Image;  

        const int MOVE_RATE = 14;

        public void Move()
        {
            double angleRadians = (Math.PI * (Angle) / 180.0);
            X = (int)((double)X + (Math.Cos(angleRadians) * MOVE_RATE)); // allow the bullet to move on a set gradient provided by its starting position
            Y = (int)((double)Y + (Math.Sin(angleRadians) * MOVE_RATE)); // allow the bullet to move on a set gradient povided by its starting position
        }
    }
}
