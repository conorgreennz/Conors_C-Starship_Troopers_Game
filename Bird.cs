using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiveBomb
{
    class Bird
    {
        public int X;
        public int Y;
        public int SpawnX;
        public int SpawnY;
        public int Angle;
        public int SpawnAngle;
        public Bitmap Image;

        public int MoveRate = 5;

        // code example taken from: https://stackoverflow.com/questions/23997966/move-a-rectangle-using-angles
        public void Move()
        {
            double angleRadians = (Math.PI * (Angle) / 180.0);
            X = (int)((double)X - (Math.Cos(angleRadians) * MoveRate)); // allow the bird to move on a set gradient provided by its starting position
            Y = (int)((double)Y - (Math.Sin(angleRadians) * MoveRate)); // allow the bird to move on a set gradient povided by its starting position
        }

    }
}
