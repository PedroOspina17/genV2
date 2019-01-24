using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace GeneradorClases
{
    class Archivos
    {

        private String directorioTrabajo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="directorioTrabajo">Directorio en el que se va a trabajar</param>
        public Archivos(String directorioTrabajo)
        {
            this.directorioTrabajo = directorioTrabajo;
        }

        private Archivos()
        {
            this.directorioTrabajo = "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="folder">Carpeta que se desea crear en el directorio activo especificado</param>
        public void createFolder(String folder)
        {
            string sfolder = Path.Combine(this.directorioTrabajo, folder);
            Directory.CreateDirectory(sfolder);
        }

        /// <summary>
        /// Función para crear un archivo
        /// </summary>
        /// <param name="folder">Carpeta en la que se va a crear el archivo (Se tiene en cuenta el directorio activo)</param>
        /// <param name="fileName">Nombre del archivo a crear</param>
        /// <param name="contenido">Contenido del arhivo a crear</param>
        public void createFile(String folder, String fileName, String contenido)
        {
            String sRuta;
            String sfolder = Path.Combine(this.directorioTrabajo, folder);
            sRuta = Path.Combine(sfolder, fileName);
            if (!File.Exists(sRuta))
            {
                using (StreamWriter outFile = new StreamWriter(sRuta, false, Encoding.UTF8))
                {
                    outFile.Write(contenido);
                }
            }
        }

        /// <summary>
        /// Función para leer un archivo (como texto).
        /// </summary>
        /// <param name="ruta">Ruta en la que se encuentra el arvhivo (No se tiene en cuenta la carpeta de trabajo).</param>
        /// <param name="fileName">Nombre del archivo</param>
        /// <returns>Retorna el contenido del archivo</returns>
        public string readFile(String ruta, String fileName)
        {
            String sRuta;
            ruta = ruta == "." ? Path.GetFullPath(".") + "\\Plantillas" : ruta;
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

        /// <summary>
        /// Función para leer un archivo tipo XML.
        /// </summary>
        /// <param name="ruta">Ruta en la que se encuentra el arvhivo (No se tiene en cuenta la carpeta de trabajo).</param>
        /// <param name="fileName">Nombre del archivo</param>
        /// <returns>Retorna un documento tipo [XmlDocument]</returns>
        public XmlDocument readXMLFile(String ruta, String fileName)
        {
            String sRuta;
            ruta = ruta == "." ? Path.GetFullPath(".") + "\\Plantillas" : ruta;
            sRuta = Path.Combine(ruta, fileName);
            if (File.Exists(sRuta))
            {
                XmlDocument XmlDoc = new XmlDocument();
                XmlDoc.Load(sRuta);
                return XmlDoc;
            }
            return null;
        }

        public XmlDocument readXMLFile(String sContenido)
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.InnerXml = sContenido;
            return XmlDoc;
        }

        /// <summary>
        /// Inidica el directorio sobre el cual se va a trabajar
        /// </summary>
        /// <param name="directorioTrabajo">Directorio sobre el que se va a trabajar</param>
        public void setWorkDirectory(String directorioTrabajo)
        {
            this.directorioTrabajo = directorioTrabajo;
        }

        /// <summary>
        /// Asignar una ruta adicional al directorio de trabajo
        /// </summary>
        /// <param name="sRuta">Carpeta sobre la cual se va a trabajar</param>
        public void addToWorkDirectory(String sRuta)
        {
            this.directorioTrabajo = Path.Combine(this.directorioTrabajo, sRuta);
        }

    }
}
