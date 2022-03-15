using System;

namespace DIO
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, nota, quociente, resto;

            n = int.Parse(Console.ReadLine());
            Console.WriteLine(n);

            resto = n;

            nota = 100;
            
            while( nota > 0)
            {
                quociente = resto / nota;
                Console.WriteLine($"{quociente} nota(s) de R$ {nota},00");
                resto = resto % nota;

                if( nota == 50)
                { 
                    nota -= 30;
                }
                else if( nota == 5)
                { 
                    nota -= 3;
                }
                else
                { 
                    nota /= 2;
                }
                
            } 
                                                   
        }
    }
}