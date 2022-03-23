using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Apple
    {
        public char simbol = '$';
        public int score = 0;
        private Random rand=new Random();
        private int[] posApple_x_y=new int[2];
        public void generate_X_Y()
        {
            posApple_x_y[0] = rand.Next(0,50);
            posApple_x_y[1] = rand.Next(0, 20);
        }
        public int AppleGetX { get { return posApple_x_y[0]; } }
        public int AppleGetY { get { return posApple_x_y[1]; } }



    }
}
