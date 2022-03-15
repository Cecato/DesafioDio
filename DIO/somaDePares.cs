using System;

namespace DIO
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int sum, i;

            while( x != 0)
            {
                sum = x;
                
                if(x % 2 != 0)
                {
                    sum++;
                    x++;
                }

                for( i = 1; i < 5; i++)
                {
                    x += 2;
                    sum += x;
                }

                Console.WriteLine(sum);

                x = int.Parse(Console.ReadLine());
            }
           
        }
    }
}