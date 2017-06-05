using System;

namespace Codewars
{
    public class Number
    {
        public int DigitalRoot(long n)
        {
            //With getting the actual digits.            
            long digitalRoot = 0;
            long currentNumber = n;
            while(currentNumber > 0) {
                var digit = currentNumber % 10;
                currentNumber /= 10;
                digitalRoot += digit;     
            }

            if(digitalRoot > 10)
                digitalRoot = DigitalRoot(digitalRoot);

            return (int)digitalRoot;
        }
    }
}