using System;
using System.Collections.Generic;

namespace Trim2_Recuperacion
{
    class Alumno
    {

        //Atributos de la clase Alumno: (***No se realizará ninguna validación***)
        public int Id = 0;
        //id: número entero
        public string Nombre="";
        //nombre: cadena de caracteres
        List<Asignatura> listAsignatura = new List<Asignatura>();
		//lisAsignaturas: Lista de tipo Asignatura

        public Alumno(int id = 0, string nombre = "")
        {
            this.Id = id;
            this.Nombre = nombre;
        }



        /// <summary>
        /// Solicitar los datos de las asignaturas del alumno
        /// </summary>
        public void IntroducirAsignaturas()
        {

            Console.WriteLine("A continuación se solicitarán las asignaturas del alumno {0}-{1}...\n", Id, Nombre);
            Console.WriteLine("\n\nPresione una tecla para continuar...");
            Console.ReadKey();

            do
            {

                Console.Clear();

                string idAsignatura = IntroducirIdAsignatura();
                string nombreAsignatura = IntroducirNombreAsignatura();

                //TODO Crear un objeto de tipo Asignatura con los datos anteriores...
                Asignatura asig = new Asignatura(idAsignatura, nombreAsignatura);

                asig.SolicitarNotas();

                //TODO Insertar la asignatura en la lista de asignaturas...

                listAsignatura.Add(asig);



            } while (PreguntaIntroducirOtraAsignatura());

        }

        /// <summary>
        /// Preguntar si desea introducir otra asignatura para el alumno
        /// </summary>
        /// <returns>True/False indicando si quiere o no introducir otra asignatura</returns>
        public bool PreguntaIntroducirOtraAsignatura()
        {
            string confirmacion;
            Console.WriteLine("¿Quiere introducir otra asignatura para el alumno?");
            do
            {
                confirmacion = Console.ReadLine();

                if (confirmacion != "Si" && confirmacion != "si" && confirmacion != "No" && confirmacion != "no")
                {
                    Console.WriteLine("La respuesta debe de ser Si/No");
                }


            } while (confirmacion != "Si" && confirmacion != "si" && confirmacion != "No" && confirmacion != "no");

            if (confirmacion == "Si" || confirmacion == "si")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Solicitar el nombre de la asignatura.
        /// </summary>
        /// <returns>Nombre válido para una asignatura</returns>
        public string IntroducirNombreAsignatura()
        {
            string nombre;

            do
            {

                Console.Write("> Introduzca el nombre de la asignatura: ");
                nombre = Console.ReadLine().Trim().ToUpper();

            } while (!ValidarNombreAsignatura(nombre));

            return nombre;
        }

        /// <summary>
        /// Solicitar el id de la asignatura.
        /// </summary>
        /// <returns>Id válido para una asignatura</returns>
        public string IntroducirIdAsignatura()
        {
            string id;

            do
            {

                Console.Write("> Introduzca el id de la asignatura: ");
                id = Console.ReadLine().Trim().ToUpper();

            } while (!ValidarIdAsignatura(id));

            return id;




        }

        /// <summary>
        /// Comprobar que el nombre de la asignatura tiene entre 5 y 30 caracteres.
        /// </summary>
        /// <param name="nombre">Valor introducido para el nombre de la asignatura</param>
        /// <returns>True/False indicando si el nombre de la asignatura es válido</returns>
        public bool ValidarNombreAsignatura(string nombre)
        {
            if (nombre.Length < 5 || nombre.Length > 30)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("***ERROR: El nombre de la asignatura debe ser una cadena de caracteres entre 5 y 30 posiciones.\n");
                Console.ResetColor();

                return false;
            }

            return true;
        }

        /// <summary>
        /// Comprobar que el id de la asignatura tiene el formato AANNN, donde A es una letra (A-Z) y N es un número (0-9)
        /// </summary>
        /// <param name="id">Valor introducido para el id de la asignatura</param>
        /// <returns>True/False indicando si el id de la asignatura es válido</returns>
        public bool ValidarIdAsignatura(string id)
        {
            //TODO Validar primero que el id tiene 5 posiciones...
            if (id.Length !=5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("***ERROR: El id de la asignatura debe ser una cadena de caracteres de 5 posiciones.\n");
                Console.ResetColor();

                return false;
            }

            //TODO Validar que tiene el formato AANNN, es decir dos letras (A-Z) y tres números (0-9)
            //Recordad las funciones Char.IsLetter y Char.IsNumber
            if (char.IsLetter(id[0]) && char.IsLetter(id[1]) && char.IsNumber(id[2]) && char.IsNumber(id[3]) && char.IsNumber(id[4]))
            {
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("***ERROR: El id de la asignatura debe tener el formato AANNN, siendo A una letra (A-Z) y N un número (0-9).\n");
                Console.ResetColor();

                return false;
            }
        }

        /// <summary>
        /// Mostrar por consola la información completa del alumno
        /// </summary>
        public void MostrarInfo()
        {
            Console.WriteLine("{0} - {1}", this.Id, this.Nombre);

            //TODO Si el alumno no tiene asignaturas aún...
            if (listAsignatura.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n\t***NO EXISTEN ASIGNATURAS EN EL SISTEMA***");
                Console.ResetColor();
            }
            else
            {
                foreach (var asignatura in listAsignatura)
                {
                    Console.WriteLine(asignatura.GetInfo());
                }
            }

            //TODO Si el alumno tiene asignaturas, mostrar la info de cada asignatura con un bucle y llamando a GetInfo de la asignatura...
            Console.WriteLine();
        }

    }
}
