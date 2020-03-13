using System;   
using System.Collections.Generic;
using System.Linq;

namespace JosephusProblem
{

    /*
    n = 77
    biggest power of 2 = 64 --6
    77-64 = 13
    biggest power of 2 = 8  --3
    biggest power of 2 = 4  --2
    biggest power of 2 = 1  --0
    64+8+4+1 = 77

    (binary)
    2pow6 2pow5 2pow4 2pow3 2pow2 2pow1 2pow0
    1     0     0     1     1     0     1     = 77
    if we put the last (1) on the first position we find the winner
    0 0 0 1 1 0 1 1 = 27 is the winner

    77 = 64 + (8+4+1)
    64 (2powa) + 13 (l)
    2powa + l
    if n = 2powa + l 
    where l < 2a
    then w(n) = 2l + 1
    
    w(77) 13 * 2 + 1 = 27 is the winner
    ------------------------------------------------------------------------------------------
    n = 41
    biggest power of 2 = 32 --5
    biggest power of 2 = 8  --3
    biggest power of 2 = 1  --0
    W(41) = 2 * 9 + 1 = 19 is the winner

    (binnary)
    41 = 2pow5 2pow4 2pow3 2pow2 2pow1 2pow0
         1     0     1     0     0     1    = 41
    if we put the last (1) on the first position we find the winner
    0 1 0 0 1 1 = 19 is the winner
    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("n= ");
            int n = GetN();
            List<int> circle = GetCircle(n);

            //eliminating every "killJump"st person,
            int killJump = 2;
            //k
            int numberOfSurvivals = 1;

            int safePosition = Josephus(n, killJump, numberOfSurvivals-1, circle);
            Console.Write("Winner: {0}", safePosition);
            Console.ReadKey();
        }

        static int Josephus(int n, int killJump, int numberOfSurvivals, List<int> circle)
        {
            int killIdx = 0;
            Console.WriteLine("Order:");
            while (circle.Count-1 > numberOfSurvivals)
            {
                killIdx = (killIdx + killJump - 1) % circle.Count;
                Console.Write(circle.ElementAt(killIdx) + " ");
                circle.RemoveAt(killIdx);
            }
            Console.WriteLine();
            return circle.ElementAt(0);
        }

        static int GetN() {
            int n = -1;
            try
            {
                n = Convert.ToInt32(Console.ReadLine());
                if (n < 0) throw new Exception();
            }
            catch (Exception) {
                Console.WriteLine("n must be a positive number");
                GetN();
            }
            return n;
        }

        static List<int> GetCircle(int n) {
            var circle = new List<int>();
            for (int i = 0; i < n; i++) {
                circle.Add(i+1);
            }
            return circle;
        }

    }
}
