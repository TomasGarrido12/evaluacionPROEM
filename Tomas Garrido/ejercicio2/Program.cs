using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio2
{
    class Program
    {
        //2. Una empresa de viajes le solicita ingresar que continente le gustaría visitar y la cantidad de días , la oferta dice que por día se cobra $100 , que se puede pagar de todas las maneras:

        //    a.Crear un método que valide continentes: recibe un continente y retorna true si se trata de un continente válido(América, Asia, Europa, Africa, Oceanía).
        //    Crear un método que valide forma de pago: recibe la forma de pago y retorna true si se trata de una forma de pago válido(Débito, Crédito, Efectivo, Mercado Pago, Cheque, Leliq)

        //    b.Si es América tiene un 15% de descuento y si además paga por débito se le agrega un 10% más de descuento

        //    c.Si es África u Oceanía tiene un 30% de descuento y si además paga por mercadoPago o efectivo se le agrega un 15% más de descuento

        //    d. Si es Europa tiene un 20% de descuento y si además paga por débito se le agrega un 15% , por mercadoPago un 10% y cualquier otro medio 5%

        //    e.cualquier otro continente tiene un recargo del 20%

        //    f.en cualquier continente , si paga con cheque, se recarga un 15% de impuesto al cheque


        static void Main(string[] args)
        {
            ListarGrillaDtos();

            string destino = IngresarContinente("Por favor ingrese su destino, las opciones son : \n-America \n-Asia \n-Europa \n-Africa \n-Ocenia ");

            string medioPago = IngresarMedioPago("Ingresar el medio de pago, las opciones son: \n-Debito \n-Credito \n-Efectivo \n-Mercado Pago \n-Cheque \n-Leliq \n-Otro");

            int cantDias = IngresarDias("Ingresar la cantidad de dias: ");

            int precio = 100;

            double precioFinalDos = CalcularPrecio(destino, cantDias, precio, medioPago);

            Console.WriteLine("El precio final es: {0} pesos", precioFinalDos);

            Console.ReadKey();
        }
        static string IngresarContinente(string dato)
        {
            Console.WriteLine(dato);
            return Console.ReadLine();
        }

        static bool ValidarContinente(string destino)
        {
            bool flag;
            destino.ToLower();

                if (destino == "america" || destino == "asia" || destino == "europa" || destino == "africa" || destino == "oceania")
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            return flag;
        }
        static int IngresarDias(string datoAux)
        {
            Console.WriteLine(datoAux);
            return int.Parse(Console.ReadLine());
        }
        static string IngresarMedioPago(string datoAuxx)
        {
            Console.WriteLine(datoAuxx);
            return Console.ReadLine();
        }

        static bool ValidarMedioDePago(string medioPago)
        {
            bool flag;
            medioPago.ToLower();

            if (medioPago == "debito" || medioPago == "credito" || medioPago == "efectivo" || medioPago == "mercado pago" || medioPago == "cheque" || medioPago == "leliq" || medioPago == "otro")
            {
                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }

        static double CalcularPrecio(string destino, int cantDias, int precio, string medioPago)
        {
            int precioNeto = cantDias * precio;
            double precioFinal = 0;

            if (ValidarContinente(destino) && ValidarMedioDePago(medioPago))
            {
                switch (destino)
                {
                    case "america":
                        switch (medioPago)
                        {
                            case "debito":
                                precioFinal = precioNeto - (precioNeto * 0.25);
                                break;

                            case "cheque":
                                precioFinal = precioNeto + (precioNeto * 0.15);
                                break;

                            default:
                                precioFinal = precioNeto - (precioNeto * 0.15);
                                break;
                        }
                        break;

                    case "asia":
                        switch (medioPago)
                        {
                            case "cheque":
                                precioFinal = precioNeto + (precioNeto * 0.15);
                                break;

                            default:
                                precioFinal = precioNeto + (precioNeto * 0.2);
                                break;
                               
                        }
                        break;

                    case "europa":
                        switch (medioPago)
                        {
                            case "debito":
                                precioFinal = precioNeto - (precioNeto * 0.35);
                                break;

                            case "mercado pago":
                                precioFinal = precioNeto - (precioNeto * 0.30);
                                break;

                            case "cheque":
                                precioFinal = precioNeto + (precioNeto * 0.15);
                                break;

                            default:
                                precioFinal = precioNeto - (precioNeto * 0.25);
                                break;
                        }
                        break;

                    case "africa":
                    case "oceania":
                        switch (medioPago)
                        {
                            case "efectivo":
                            case "mercado pago":
                                precioFinal = precioNeto - (precioNeto * 0.45);
                                break;

                            case "cheque":
                                precioFinal = precioNeto + (precioNeto * 0.15);
                                break;

                            default:
                                precioFinal = precioNeto - (precioNeto * 0.30);
                                break;
                        }
                        break;
           
                }
                
            }
            else
            {
                Console.WriteLine("Datos incorrectos, intente nuevamente");
            
            }
            return precioFinal;
        }

        static void ListarGrillaDtos()
        {
            Console.WriteLine("Grilla de descuentos: \n-América tiene un 15% de descuento y si además paga por débito se le agrega un 10% más de descuento \n-Europa tiene un 20% de descuento y si además paga por débito se le agrega un 15% , por mercadoPago un 10% y cualquier otro medio 5% \n-Cualquier otro continente tiene un recargo del 20% \n-En cualquier continente , si paga con cheque, se recarga un 15% de impuesto al cheque");
            Console.WriteLine("---------------------------------------------------------------------------------------");
        }
    }
      
}
