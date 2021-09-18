using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            Validar(edadEstudiante, sexoEstudiante, notaFinal);
            string mensajeFinal = Calcular(edadEstudiante, sexoEstudiante, notaFinal);
            Console.ReadKey();
        }
        static string IngresarNombre(string dato)
        {
            Console.WriteLine(dato);
            return Console.ReadLine();
        }
        static int IngresarEdad(string dato)
        {
            Console.WriteLine(dato);
            return int.Parse(Console.ReadLine());
        }
        static char IngresarSexo(string dato)
        {
            Console.WriteLine(dato);
            return char.Parse(Console.ReadLine());
        }
        static int IngresarNota(string dato)
        {
            Console.WriteLine(dato);
            return int.Parse(Console.ReadLine());
        }
        static bool Validar(int edadEstudiante, char sexoEstudiante, int notaFinal)
        {
            bool flag;
            if ((edadEstudiante >= 12 && edadEstudiante <= 70) && (sexoEstudiante == 'f' || sexoEstudiante == 'm') && (notaFinal >= 0 && notaFinal <= 10))
            {
                flag = true;
            }
            else
            {
                Console.WriteLine("Datos incorrectos intente devuelta");
                flag = false;
            }
            return flag;
        }
        static void Calcular(int edadEstudiante, char sexoEstudiante, int notaFinal)
        {
            string respuesta = "";
            int contVaronesAprob = 0;
            int contVaronesMenores = 0;
            int sumaNotasVaronesMenores = 0;
            int contVaronesAdolescentes = 0;
            int sumaVaronesNotasAdolescentes = 0;
            int contVaronesMayores = 0;
            int sumaNotasVaronesMayores = 0;
            int contMujeresAprob = 0;
            int contMujeresMenores = 0;
            int sumaNotasMujeresMenores = 0;
            int contMujeresAdolescentes = 0;
            int sumaMujeresNotasAdolescentes = 0;
            int contMujeresMayores = 0;
            int sumaNotasMujeresMayores = 0;
            int contNotas = 0;

            do
            {              
                string nombreEstudiante = IngresarNombre("Ingrese el nombre del estudiante:");
                do
                {
                    edadEstudiante = IngresarEdad("Ingrese la edad del estudiante (entre 12 y 80)");
                } while (!(Validar(edadEstudiante,sexoEstudiante,notaFinal)));
                do
                {
                    sexoEstudiante = IngresarSexo("Ingrese el sexo del estudiante (f/m)");
                    char.ToLower(sexoEstudiante);
                } while (!(Validar(edadEstudiante, sexoEstudiante, notaFinal)));
                do
                {
                    notaFinal = IngresarNota("Ingrese la nota final del alumno (entre 0 y 10)");
                } while (!(Validar(edadEstudiante, sexoEstudiante, notaFinal)));
                              
                if (Validar(edadEstudiante, sexoEstudiante, notaFinal)) //Si se validan todos los datos empiezo a calcular los valores solicitados
                {
                    if (sexoEstudiante == 'm')
                    {
                        if (notaFinal >= 4) //Se aprueba con una nota de 4 pero en condicion de regular
                        {
                            contVaronesAprob++;
                        }
                        if (edadEstudiante <= 15)
                        {
                            contVaronesMenores++;
                            sumaNotasVaronesMenores += notaFinal;
                        }
                        else if (edadEstudiante > 15 && edadEstudiante < 18)
                        {
                            contVaronesAdolescentes++;
                            sumaVaronesNotasAdolescentes += notaFinal;
                        }
                        else if (edadEstudiante >= 18)
                        {
                            contVaronesMayores++;
                            sumaNotasVaronesMayores += notaFinal;
                        }
                    }
                    else
                    {
                        if (notaFinal >= 4)
                        {
                            contMujeresAprob++;
                        }
                        if (edadEstudiante <= 15)
                        {
                            contMujeresMenores++;
                            sumaNotasMujeresMenores += notaFinal;
                        }
                        else if (edadEstudiante > 15 && edadEstudiante < 18)
                        {
                            contMujeresAdolescentes++;
                            sumaMujeresNotasAdolescentes += notaFinal;
                        }
                        else if (edadEstudiante >= 18)
                        {
                            contMujeresMayores++;
                            sumaNotasMujeresMayores += notaFinal;
                        }
                    }

                }


                Console.WriteLine("Desea continuar?:");
                respuesta = Console.ReadLine();
            } while (respuesta == "si");


            float promedioNotasMenores = (float)(sumaNotasVaronesMenores + sumaNotasMujeresMenores) / (contMujeresMenores + contVaronesMenores);
            Console.WriteLine("La cant de varones aprobados es {0} \n-El promedio de notas de los menores de edad es {1}", contVaronesAprob, promedioNotasMenores);
        }
    }
}
