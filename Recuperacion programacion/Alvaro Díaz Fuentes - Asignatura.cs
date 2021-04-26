using System;

namespace Trim2_Recuperacion
{
    class Asignatura
    {
        //Atributos de la clase Asignatura: (***Las validaciones de los datos se realizarán en la clase Alumno***)
        string Id;
        //id: AANNN, donde A = letra (A-Z) y N = número (0-9)
        string nombre;
        //nombre: cadena de caracteres entre 5 y 30 posiciones
        double[] notas;
        //notas: array de tipo double
        double notaMedia = 0;
		

        public Asignatura(string id, string nombre)
        {
            this.Id = id;
            this.nombre = nombre;

			
            this.notas = new double[10];
        }


        /// <summary>
        /// Solicitar por consola las notas de las 10 actividades de la asignatura.
        /// </summary>
        public void SolicitarNotas()
        {
            int cont=1;

            Console.WriteLine("\n> A continuación se solicitarán las notas de las 10 actividades de la asignatura {0}...\n", nombre);

            for (int i = 0; i < 10; i++)
            {
                do
                {
                    Console.WriteLine("Introduzca la nota para la actividad " + cont);
                    if (!double.TryParse(Console.ReadLine().Replace(".",","), out notas[i]))
                    {
                    notas[i] = -1;
                    }

                    if (notas[i] < 0 || notas[i] > 10)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El numero debe de estar en el rango de entre 0 y 10");
                        Console.ResetColor();
                    }
                    
                } while (notas[i] < 0 || notas[i] > 10);

                notas[i] = Math.Round(notas[i], 2);

                cont++;
                notaMedia = notaMedia + notas[i];
            }
            notaMedia = notaMedia / 10;

            notaMedia = Math.Round(notaMedia, 2);



        }

        /// <summary>
        /// Información de la asignatura.
        /// </summary>
        /// <returns>string con la información de la asignatura</returns>
        public string GetInfo()
        {
            string infoAsignatura = "";

            infoAsignatura +="\n\t" + Id + " - " + nombre + ":"+"\n";
            infoAsignatura += "\t";
            for (int i = 0; i < 10; i++)
            {
                infoAsignatura += notas[i] + "          ";
            }
            infoAsignatura += "\n\t" + "NOTA MEDIA = " + notaMedia + "\n";

            return infoAsignatura;
        }

    }
}