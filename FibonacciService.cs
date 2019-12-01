using System;
using System.Collections.Generic;
using System.Text;

namespace Fibonacci
{
    public class FibonacciService : IFibonacciService
    {
        public double Evaluate(int seqNumber)
        {
            var fibs = new double[seqNumber + 1];
            double F(int n)
            {
                if (n <= 1) return n;
                if (fibs[n] > 0)
                    return fibs[n];
                fibs[n] = F(n - 1) + F(n - 2);
                return fibs[n];
            }

            return F(seqNumber);
        }
    }
}
