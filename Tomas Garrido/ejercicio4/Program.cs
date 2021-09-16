using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio4
{
    class Program
    {
        //Realizar el algoritmo que permita iterar el ingreso de dos datos de un vehiculo, un color(rojo verde o amarillo) y un valor entre 0 y 10000 hasta que el usuario quiera e informar al terminar el ingreso por consola:
                //a.La cantidad de rojos
                //b.La cantidad de rojos con precio mayor a 5000
                //c.La cantidad de vehículos con precio inferior a 5000
                //d.El promedio de todos los vehículos ingresados.
                //e.El más caro y su color.
        static void Main(string[] args)
        {

            Calcular();
            Console.ReadKey();

        }
        static string IngregarColor(string dato)
        {
            Console.WriteLine(dato);
            return Console.ReadLine();
        }
        static int IngresarPrecio(string dato)
        {
            Console.WriteLine(dato);
            return int.Parse(Console.ReadLine());
        }
        static bool ValidarDatos(string colorAuto, int precioAuto)
        {
            bool flag;
            if (colorAuto == "rojo" || colorAuto == "verde" || colorAuto == "amarillo" && (precioAuto > 0 && precioAuto <= 10000))
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
        static void Calcular()
        {
            string respuesta;
            int sumaAutos = 0;
            int contadorRojos = 0;
            int contadorPrecioBarato = 0;
            int contadorPrecioCaro = 0;
            int precioMax = int.MinValue;
            string colorAux = "";
            do
            {
                string colorAuto = IngregarColor("Por favor ingrese el color del auto (rojo, verde o amarillo)");
                colorAuto = colorAuto.ToLower().Trim();
                int precioAuto = IngresarPrecio("Por favor ingrese el precio del auto (entre 0 y 10000)");
                
                if (ValidarDatos(colorAuto, precioAuto))
                {
                    sumaAutos += precioAuto; //Acumulador de los precios ingresados
                    if (colorAuto == "rojo")
                    {
                        contadorRojos++; //Contador de autos rojos solamente

                        if (precioAuto>5000)
                        {
                            contadorPrecioCaro++; //contador de autos rojos con un precio mayor a 5000
                        }                        
                    }
                    if (precioAuto <5000)
                    {
                        contadorPrecioBarato++; //cotador de autos con un precio menor a 5000
                    }
                    if (precioMax < precioAuto)
                    {
                        precioMax = precioAuto; //para buscar el precio maximo y el color que le corresponde
                        colorAux = colorAuto;
                    }
                }
                Console.WriteLine("Desea seguir? Si/No");
                respuesta = Console.ReadLine();
                respuesta = respuesta.ToLower();
                
            } while (respuesta == "si");

            float promedioAutos = (float) sumaAutos / (contadorRojos + contadorPrecioBarato+ contadorPrecioCaro);

            Console.WriteLine("-La cantidad de rojos es {0} \n-La cantidad de rojos con precio mayor a 5000 es {1} \n-La cantidad de vehículos con precio inferior a 5000 {2} \n-El promedio de todos los vehículos ingresados es {3} \n-El más caro es {4} y su color es {5}", contadorRojos, contadorPrecioCaro, contadorPrecioBarato, promedioAutos, precioMax, colorAux);
        }
    }
}
