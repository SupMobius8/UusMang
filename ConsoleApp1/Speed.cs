using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Kiirus
    {
        public int speed;
        public int snSpeed;

        public Kiirus(int speed)
        {
            this.speed = speed;
        }
        public void diffSet(int speed)
        {
            switch (speed)
            {
                case 1:
                    snSpeed = 150;
                    break;
                case 2:
                    snSpeed = 50;
                    break;
            }

        }
    }
}