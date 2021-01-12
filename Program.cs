using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arregloEnteros = { 5, 5, 2, 3, 4, 5, 5, 6, 7, 2 };
            int[] arregloAscendente = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] arrayToCompress = { 54, 400, 400, 400, 43, 43, 154, 4, 4, 4, 200, 7, 392 };
            int entero = 10;
            ContainRepeatNumber(arregloEnteros);
            FindNumber(arregloEnteros, entero);
            FindNumber(arregloAscendente, entero);
            CompressArray(arrayToCompress);
        }
        /// <summary>
        /// Metodo que indica si hay numeros repetidos en un array
        /// </summary>
        /// <param name="array"> array de enteros</param>
        /// <returns>verdadero o falso</returns>
        public static bool ContainRepeatNumber(Array array)
        {

            foreach (int i in array)
            {
                int cont = 0;
                foreach (int p in array)
                {
                    if (i == p)
                    {
                        cont++;
                        if (cont > 1)
                        {
                            Console.WriteLine("El arreglo contiene numeros repetidos");
                            Console.ReadLine();
                            return true;
                        }
                    }
                }
            }
            Console.WriteLine("No hay numeros repetidos");
            Console.ReadLine();
            return false;
        }
        /// <summary>
        /// Metodo que indica en que posicion se encuentra un numero.
        /// </summary>
        /// <param name="array">array de enteros</param>
        /// <param name="entero">int</param>
        /// <returns>int</returns>
        public static int FindNumber(Array array, int entero)
        {
            int cont = 0;
            foreach (int i in array)
            {
                cont++;
                if (entero == i)
                {
                    Console.WriteLine("El numero esta en la posicion: " + cont);
                    Console.ReadLine();
                    return i;
                }
            }
            Console.WriteLine("No se encontro el numero en el arreglo");
            Console.ReadLine();
            return -1;
        }
        /// <summary>
        /// Metodo compresor de Array
        /// </summary>
        /// <param name="listaEnteros"> Array de enteros </param>
        /// <returns> Lista de enteros </returns>
        public static List<int> CompressArray(int[] listaEnteros)
        {
            List<int> resultado = new List<int>();
            int cont = 1;
            bool flag = false;
            for (int i = 0; i < listaEnteros.Count(); i++)
            {
                if (i + 1 < listaEnteros.Count() && listaEnteros[i] == listaEnteros[i+1])
                {
                    cont++;
                    flag = true;
                }
                else
                {
                    if (flag)
                    {
                        if(1 < cont && cont < 63)
                        {
                            resultado.Add(cont + 192);
                            cont = 1;
                            resultado.Add(listaEnteros[i]);
                        }                        
                    }
                    else
                    {
                        if (listaEnteros[i] < 192)
                        {
                            resultado.Add(listaEnteros[i]);
                        }
                        else
                        {
                            resultado.Add(listaEnteros[i] + 192);
                        }
                    }
                    flag = false;
                }
            }            
            return resultado;
        }
    }
}             