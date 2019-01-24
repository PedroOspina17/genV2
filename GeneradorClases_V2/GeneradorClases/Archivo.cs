using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GeneradorClases
{
    class Archivo
    {
        private Archivo()
        {
        }

        /// <summary>
        /// Crea una carpeta en un directorio especificado.
        /// </summary>
        /// <param name="Directorio">Directorio donde se creará la carpeta</param>
        /// <param name="sfolder">Nombre de la carpeta a crear</param>
        public static void createFolder(String Directorio, String sfolder)
        {
            sfolder = Path.Combine(Directorio, sfolder);
            Directory.CreateDirectory(sfolder);
        }

        /// <summary>
        /// Crea un archivo en el directorio especificado.
        /// </summary>
        /// <param name="sDirectorio">Directorio en donde se creará el archivo</param>
        /// <param name="sFileName">Nombre del archivo que se va a crear</param>
        /// <param name="sContenido">Contenido del arhivo a crear</param>
        public static void createFile(String sDirectorio, String sFileName, String sContenido)
        {
            String sRuta;
            sRuta = Path.Combine(sDirectorio, sFileName);
            if (!File.Exists(sRuta))
            {
                using (StreamWriter outFile = new StreamWriter(sRuta, false, Encoding.UTF8))
                {
                    outFile.Write(sContenido);
                }

            }
        }

        /// <summary>
        /// Abre y devuelve el contenido de un archivo especificado.
        /// </summary>
        /// <param name="ruta">Directorio donde está el archivo que se va a abrir</param>
        /// <param name="fileName">Nombre del archivo</param>
        /// <returns>Contenido del archivo abierto</returns>
        public static string readFile(String ruta, String fileName)
        {
            String sRuta;
            //ruta = ruta == "." ? Path.GetFullPath(".") + "\\Plantillas" : ruta;
            ruta = ruta == "." ? Path.GetFullPath(".") + "\\Plantillas V3.0" : ruta;
            sRuta = Path.Combine(ruta, fileName);
            if (File.Exists(sRuta))
            {
                using (StreamReader inputFile = new StreamReader(sRuta, Encoding.UTF8))
                {
                    return inputFile.ReadToEnd();
                }
            }
            return "";
        }
    }
}
