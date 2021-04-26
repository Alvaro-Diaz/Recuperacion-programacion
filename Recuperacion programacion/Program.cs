using System;

namespace Trim2_Recuperacion
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Creamos tres alumnos...\n");

            //TODO Crear tres alumnos...al1, al2 y al3
            Alumno al1 = new Alumno(1, "Maria");
            Alumno al2 = new Alumno(4, "David");
            Alumno al3 = new Alumno(3, "Isabel");
            //El constructor creado debe tener los argumentos id y nombre

            Console.WriteLine("Modificamos el nombre de la primera alumna...\n");

            //TODO Modificar el nombre del primer alumno
            al1.Nombre = "Rosario";

            Console.WriteLine("Modificamos el id del segundo alumno...\n");

            al2.Id = 12;

            al3.IntroducirAsignaturas();

            Console.Clear();
            Console.WriteLine("Mostramos la información de los alumnos:\n");

            al1.MostrarInfo();

            al2.MostrarInfo();

            al3.MostrarInfo();

        }
    }
}
