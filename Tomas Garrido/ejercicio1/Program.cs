using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio1
{
    //Pedir dos números por consola y mostrar el resultado:
    //a.Si son iguales muestro el cuadrado del número.
    //b.Si el primero es divisible por el segundo, los resto, de lo contrario muestro solo el resto.
    //c.si el resto es mayor a 3(tres ) informar por consola.
    class Program
    {
        static void Main(string[] args)
        {
            int numA = PedirNumero("Por favor ingrese un numero");
            int numB = PedirNumero("Por favor ingrese un numero");

            Console.WriteLine($"El resultado es: " + CalcularResultado(numA,numB));

            Console.ReadKey();
        }

        static int PedirNumero(string dato)
        {
            Console.WriteLine(dato);
            return int.Parse(Console.ReadLine());
        }

        static float CalcularResultado(int numA, int numB)
        {
            float resto;

            if (numA==numB)
            {
                return numA * numA;
            }
            else
            {
                if (numA % numB == 0)
                {
                    return numA - numB;
                }
                else
                {
                    resto =  numA%numB;

                    if (resto > 3)
                    {
                        return resto;
                    }
                    else
                    {
                        return numA % numB;
                    }
                }
            }
        }

    }
}
