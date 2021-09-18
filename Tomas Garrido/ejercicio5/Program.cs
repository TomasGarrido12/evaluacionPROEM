using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio5
{
    class Program
    {
        //Realizar el algoritmo que permita ingresar el nombre de un estudiante, la edad (validar) , el sexo(validar) y la nota del final(validar) hasta que el usuario quiera e
        //informar al terminar el ingreso por consola:
                //a.La cantidad de varones aprobados
                //b.El promedio de notas de los menores de edad
                //c.El promedio de las notas de los adolescentes
                //d.El promedio de notas de los mayores.
                //e.El promedio de notas por sexo.
        static void Main(string[] args)
        {
            Calcular();
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
        static void Calcular()
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

            do
            {

                string nombreEstudiante = IngresarNombre("Ingrese el nombre del estudiante:");
                int edadEstudiante = IngresarEdad("Ingrese la edad del estudiante (entre 12 y 80)");
                char sexoEstudiante = IngresarSexo("Ingrese el sexo del estudiante (f/m)");
                sexoEstudiante = char.ToLower(sexoEstudiante);
                int notaFinal = IngresarNota("Ingrese la nota final del alumno (entre 0 y 10)");

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
                respuesta = respuesta.ToLower();
            } while (respuesta == "si");

            
            float promedioNotasMenores = (float) (sumaNotasVaronesMenores + sumaNotasMujeresMenores) / (contMujeresMenores + contVaronesMenores);
            float promedioNotasAdolescentes = (float)(sumaVaronesNotasAdolescentes + contMujeresAdolescentes) / (contMujeresAdolescentes+contVaronesAdolescentes);
            float promedioNotasMayores = (float)(sumaNotasVaronesMayores + sumaNotasMujeresMayores) / (contMujeresMayores + contVaronesMayores);
            float promedioVarones = (float)(sumaNotasVaronesMenores + sumaVaronesNotasAdolescentes + sumaNotasVaronesMayores) / (contVaronesMenores + contVaronesAdolescentes + contVaronesMayores);
            float promedioMujeres = (float)(sumaNotasMujeresMenores + contMujeresAdolescentes + sumaNotasMujeresMayores) / (contMujeresMenores + contMujeresAdolescentes + contMujeresMayores);

            Console.WriteLine("-La cantidad de varones aprobados es {0} \n-El promedio de notas de los menores de edad es {1}\n-El promedio de notas de los adolescentes es {2}\n-El promedio de notas de los mayores es {3}\n-El promedio de las notas de los varones es {4}\n-El promedio de las notas de las mujeres es {5}", contVaronesAprob, promedioNotasMenores, promedioNotasAdolescentes, promedioNotasMayores, promedioVarones, promedioMujeres);
        }
    }
}
