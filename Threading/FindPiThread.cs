/* Name: Enrique Tejeda
 * Date: 10/26/2020
 * Filename: FindPiThread.cs
 * Description: Class has a function that keeps a track of how many darts have landed in the target. Constructor sets everything to default when the object is created in Program.cs
 */

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
                double x = random.NextDouble();
                double y = random.NextDouble();
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
