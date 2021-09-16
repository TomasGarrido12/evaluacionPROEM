using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio3
{
    class Program
    {
        //Realizar el algoritmo que permita el ingreso de 10 bolsas de alimento para mascotas, con los kilos(validar entre 0 y 500) , sabor validar(carne vegetales pollo) e informar por consola:
        //a.El promedio de los kilos totales.
        //b.La bolsa más liviana y su sabor
        //c.La cantidad de bolsas sabor carne y el promedio de kilos de sabor carne
        static void Main(string[] args)
        {
            int contadorKilos = 0;
            int sumaKilos = 0;            
            int minKilos = int.MaxValue;
            int contadorKilosCarne = 0;
            int sumaCarne = 0;
            string saborLiviano = "";

            for (int i = 0; i < 10; i++)
            {
                int cantKilos = IngresarKilos("Por favor ingrese la cantidad de kilos (entre 0 y 500)");
                string tipoSabor = IngresarSabor("Por favor ingrese el sabor (carne, vegetales o pollo)");

                if (ValidarDatos(cantKilos, tipoSabor))
                {
                    contadorKilos++;
                    sumaKilos += cantKilos;

                    if (cantKilos < minKilos)
                    {
                        minKilos = cantKilos;
                        saborLiviano = tipoSabor;
                    }
                    if (tipoSabor == "carne")
                    {
                        contadorKilosCarne++;
                        sumaCarne += cantKilos;
                    }
                }
            }              
                                                   
            float promedioKilos = (float) sumaKilos / contadorKilos;
            float promedioKilosCarne = (float) sumaCarne / contadorKilosCarne;

            Console.WriteLine("-El promedio de los kilos totales es {0} \n-La bolsa más liviana es de {1} kilos y su sabor es {2} \n-La cantidad de bolsas sabor carne es {3} y el promedio de kilos de sabor carne es {4}", promedioKilos, minKilos, saborLiviano, contadorKilosCarne, promedioKilosCarne);
            Console.ReadKey();
        }

        static int IngresarKilos(string dato)
        {
            Console.WriteLine(dato);
            return int.Parse(Console.ReadLine());
        }
        static string IngresarSabor(string datox)
        {
            Console.WriteLine(datox);
            return Console.ReadLine();
        }
        static bool ValidarDatos(int cantKilos, string tipoSabor)
        {
            bool flag;
            if ((cantKilos > 0 && cantKilos <= 500) && tipoSabor == "carne" || tipoSabor == "vegetales" || tipoSabor == "pollo")
            {
                flag = true;
            }
            else
            {
                Console.WriteLine("Datos incorrectos, intente devuelta");
                flag = false;
            }
            return flag;
        }
    }
}
