using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiveBomb
{

    public class Ship
    {
        public int X;
        public int Y;
        public int Angle;

        public int ShipMoveRate = 7;


        public void MoveLeft()
        {
            X -= ShipMoveRate;
        }
        public void MoveRight()
        {
            X += ShipMoveRate;
        }
        public void MoveUp()
        {
            Y -= ShipMoveRate;
        }
        public void MoveDown()
        {
            Y += ShipMoveRate;
        }
        public void RotateLeft()
        {
            Angle -= ShipMoveRate;
        }
        public void RotateRight()
        {
            Angle += ShipMoveRate;
        }
       

        // make sure the ship does not leave the borders of the game panels x axis 
        // if it does bounce it back in
        // make sure the ship does not leave the borders of the game panels Y axis 
        // if it does bounce it back in 
        }
    }

