using System;
using System.Collections.Generic;
using System.Text;

namespace Threading
{
    class FindPiThread
    {
        Random random;
        int darts;
        int dartsLanded;
        public int dartsLandedAccessor => dartsLanded;
        public FindPiThread(int darts)
        {
            this.darts = darts;
            dartsLanded = 0;
            random = new Random();
        }

        public void throwDarts()
        {
            for(int i = 0; i < darts; i++)
            {
                double x = random.Next(0, 1);
                double y = random.Next(0, 1);
                x *= x;
                y *= y;
                double hypotenuse = Math.Sqrt(x + y);
                if (hypotenuse <= 1)
                {
                    dartsLanded += 1;
                }
            }    
        }
    }
}
