using System;
using System.Collections.Generic;

namespace Codewars
{
    public class RemovedNumbers 
    {
        /*
        A friend of mine takes a sequence of numbers from 1 to n (where n > 0).
        Within that sequence, he chooses two numbers, a and b.
        He says that the product of a and b should be equal to the sum of all numbers in the sequence, 
        excluding a and b.
        Given a number n, could you tell me the numbers he excluded from the sequence?
         */
        public static List<long[]> removNb(long n) {            
            var totalSum = n*(n+1)/2;
            var result = new List<long[]>();

            //Better way is => b = (totalSum - a)/(a+1)

            long a = n/2;
            long b = n - 1;
            long current = 0; 
            while(a < n && b > n/2)
            {
                current = a*(b+1) + b;

                if(current > totalSum)
                {                    
                    b--;                    
                }
                if(current < totalSum)
                {
                    a++;
                }
        
                if(current == totalSum){
                    result.Add(new long[]{a,b});                                      
                    a++;
                    b--;
                }
            }
                       
            return result;
        }
    }
}