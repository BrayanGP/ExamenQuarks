using System;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Desea terminar el programa s/n");
            string res =Console.ReadLine().ToUpper();
           while(res!="S")
            { 

                Console.WriteLine("QUe decea realizar?");
                Console.WriteLine("1 - calcular el numero mayor");
                Console.WriteLine("2 - factorial");
                Console.WriteLine("3 - area de un triangulo");
                Console.WriteLine("4 - Terminar programa");
                int datos = Convert.ToInt32(Console.ReadLine());
                switch (datos) {
                    case 1:
                        Console.WriteLine("numero 1");
                        int n1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("numero 2");
                        int n2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("numero 3");
                        int n3 = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine(calcularMayor(n1, n2, n3));
                        break;
                    case 2:
                        Console.WriteLine("ingresa cantidad de numero");
                        int n = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine(factorial(n));
                        break;
                    case 3:
                        Console.WriteLine("Base: ");
                        decimal b = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Altura: ");
                        decimal h = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine(AreaTriangulo(b, h));
                        break;
                    case 4:
                        res = "S";
                        break;
                }
               
            }
            
        }

        public static int calcularMayor(int n1,int n2,int n3)
        {
            if (n1>n2 && n1>n3) 
                return n1;
            else if(n2>n3 && n2 > n1)
                return n2;
            else
                return n3;
        }

       

        public static int factorial(int numero)
        {
            int cont = 0;
            int factorial = 1;
            while (numero != cont)
            {
                factorial += factorial * cont;
                cont++;
            }
            return factorial;
        }

        public static decimal AreaTriangulo(decimal b, decimal h) => (b * h) / 2;

        
    }
}
