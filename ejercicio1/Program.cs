using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class Program
    {
        static int cnt = 0;
        static void Main(string[] args)
        {
            //experimento
            string[] nombres = new string[0];
            int[] numeros = new int[0];

            int op = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("::::::::AGENDA DE CONTACTOS UPN 2026::::::::::");
                Console.WriteLine("1. Registrar nuevo contacto");
                Console.WriteLine("2. Ver conctactos");
                Console.WriteLine("3. Buscar conctacto");
                Console.WriteLine("4. Actualizar contacto");
                Console.WriteLine("5. Eliminar contacto");
                Console.WriteLine("6. Ordenar contactos");
                Console.WriteLine("0. Salir");
                Console.Write("Ingrese una opcion: ");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 0:
                        Console.WriteLine("No vuelvas!!!");
                        break;
                    case 1:
                        RegistrarContacto(ref nombres, ref numeros);
                        break;
                    case 2:
                        MostrarContactos(nombres, numeros);
                        break;
                    case 3:
                        BuscarContacto(nombres, numeros);
                        break;
                    case 4:
                        ActualizarContacto(nombres, numeros);
                        break;
                    case 5:
                        EliminarContacto(ref nombres, ref numeros);
                        break;
                    case 6:
                        OrdenamientoBurbuja(nombres, numeros);
                        break;

                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }

                Console.ReadKey();
            } while (op != 0);//! = 
        }

        private static void OrdenamientoBurbuja(string[] nombres, int[] numeros)
        {
            Console.WriteLine("----ORDENAMIENTO DE CONTACTOS----");
            Console.WriteLine("Ordenar por nombres(x) │ Ordenar por numeros(y): ");
            char o = char.Parse(Console.ReadLine());

            if (o == 'x')
            {
                //por implementar
            }
            else
            {
                for (int j = 0; j < cnt - 1; j++)
                {

                    for (int i = 0; i < cnt - 1; i++)
                    {
                        //i es el numero mayor pase al final
                        //i es un numero menos pase al inicio
                        //CompareTD
                        //
                        if (numeros[i].CompareTo(numeros[i + 1]) > 0)
                        {
                            // Intercambiar elementos
                            int aux = numeros[i];
                            numeros[i] = numeros[i + 1];
                            numeros[i + 1] = aux;

                            //la misma accion pero para arreglo de nombres
                            string aux2 = nombres[i];
                            nombres[i] = nombres[i + 1];
                            nombres[i + 1] = aux2;
                        }
                    }
                }
            }
        }

        private static void EliminarContacto(ref string[] nombres, ref int[] numeros)
        {
            string buscar;
            Console.WriteLine("----ELIMINAR CONTACTO----");
            Console.Write("Ingresa un nombre: ");
            buscar = Console.ReadLine();

            for (int i = 0; i < cnt; i++)
            {
                if (nombres[i].ToLower() == buscar.ToLower())
                {
                    Console.WriteLine($"-Contacto eliminado: {nombres[i]} ({numeros[i]})");
                    // Proceso de eliminacion
                    //i es el elemento que quiero eliminar
                    for (int j = i; j < cnt - 1; j++)
                    {
                        nombres[j] = nombres[j + 1];
                        numeros[j] = numeros[j + 1];
                    }
                    Array.Resize(ref nombres, cnt - 1);
                    Array.Resize(ref numeros, cnt - 1);

                    cnt--;
                    return;
                }
            }
            Console.WriteLine("No esta registrado el contacto");
        }

        private static void ActualizarContacto(string[] nombres, int[] numeros)
        {
            string buscar;
            Console.WriteLine("----ACTUALIZAR CONTACTO----");
            Console.Write("Ingresa un nombre: ");
            buscar = Console.ReadLine();

            for (int i = 0; i < cnt; i++)
            {
                if (nombres[i].ToLower() == buscar.ToLower())
                {
                    Console.WriteLine($"-Contacto: {nombres[i]} ({numeros[i]})");
                    Console.Write("Ingrese el nuevo nombre: ");
                    nombres[i] = Console.ReadLine();
                    Console.Write("Ingrese el nuevo numero: ");
                    numeros[i] = int.Parse(Console.ReadLine());
                    return;
                }
            }
            Console.WriteLine("No esta registrado el contacto");
        }

        private static void MostrarContactos(string[] nombres, int[] numeros)
        {
            for (int i = 0; i < cnt; i++)
            {
                Console.WriteLine($"-Contacto: {nombres[i]} ({numeros[i]})");
            }
        }
        private static void BuscarContacto(string[] nombres, int[] numeros)
        {
            string buscar;
            Console.WriteLine("----BUSQUEDA DE CONTACTO----");
            Console.Write("Ingresa un nombre: ");
            buscar = Console.ReadLine();

            for (int i = 0; i < cnt; i++)
            {
                if (nombres[i].ToLower() == buscar.ToLower())
                {
                    Console.WriteLine($"-Contacto: {nombres[i]} ({numeros[i]})");
                    return;
                }
            }
            Console.WriteLine("No esta registrado el contacto");
        }

        private static void RegistrarContacto(ref string[] nombres, ref int[] numeros)
        {
            Array.Resize(ref nombres, cnt + 1);
            Array.Resize(ref numeros, cnt + 1);

            Console.WriteLine("---NUEVO CONTACTO---");
            Console.Write("Ingrese nombre de su contacto: ");
            nombres[cnt] = Console.ReadLine();

            Console.Write("Ingrese numero de su contacto:  ");
            numeros[cnt] = int.Parse(Console.ReadLine());

            Console.WriteLine($"-Contacto registrado: {nombres[cnt]} ({numeros[cnt]})");
            cnt++;
        }
    }
}
