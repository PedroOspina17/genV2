using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Xml;

namespace GeneradorClases
{
    class Utilidades
    {

        /// <summary>
        /// Genera archivo a partir de un DataTable, nombre de la clase y namespace
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sClass"></param>
        /// <param name="sNamespace"></param>
        public static void GenerarArchivo(DataTable dt, string sClass, string sNamespace, string sRutaGenerar)
        {
            Archivos files = new Archivos(sRutaGenerar);
            string sPlantilla = "";
            string[] sRepeticiones;
            int nRepeticiones = 0;

            //Primero leemos la plantilla
            sPlantilla = files.readFile(AppDomain.CurrentDomain.BaseDirectory, "Clase.txt");
            sPlantilla = sPlantilla.Replace("<namespace>", sNamespace);
            sPlantilla = sPlantilla.Replace("<class>", sClass);

            int i = 1;
            int j=0;
            //Buscamos las repeticiones
            while (i < sPlantilla.Length && sPlantilla.IndexOf("<repeat>", i) > 0)
            {
                nRepeticiones++;
                i=sPlantilla.IndexOf("<repeat>", i)+1;
            }
            i = 1;
            sRepeticiones = new string[nRepeticiones];
            while (i < sPlantilla.Length && sPlantilla.IndexOf("<repeat>", i) > 0)
            {
                sRepeticiones[j] = sPlantilla.Substring(sPlantilla.IndexOf("<repeat>", i), sPlantilla.IndexOf("</repeat>", i) - sPlantilla.IndexOf("<repeat>", i) + "</repeat>".Length);
                sRepeticiones[j] = sRepeticiones[j].Replace("<repeat>","");
                sRepeticiones[j] = sRepeticiones[j].Replace("</repeat>","");
                j++;
                i=sPlantilla.IndexOf("</repeat>", i)+1;
            }

            //reemplazamos los repetitivos
            string sAux;
            for (i = 0; i < nRepeticiones; i++)
            {
                sAux ="";
                //atributos
                for (j = 0; j < dt.Rows.Count; j++)
                {
                    sAux += sRepeticiones[i].Replace("<tipoDato>", dt.Rows[j]["tipoDato"].ToString());
                    sAux = sAux.Replace("<atributo>", dt.Rows[j]["NombreAtributo"].ToString());
                    sAux = sAux.Replace("<Atributo>", dt.Rows[j]["NombreAtributo"].ToString().Substring(0, 1).ToUpper() + dt.Rows[j]["NombreAtributo"].ToString().Substring(1));
                    sAux += "  ";
                }
                sPlantilla = sPlantilla.Replace(sRepeticiones[i], sAux);
            }
            sPlantilla = sPlantilla.Replace("<repeat>", "").Replace("</repeat>", "");
            files.createFile("", sClass + ".cs", sPlantilla);
        }

        /// <summary>
        /// Carga el contenido de un XML formateandolo en un DataTable
        /// </summary>
        /// <param name="sXML">Documento XML</param>
        /// <returns></returns>
        public static DataTable CargarXMLDataTable(string sXML)
        {
             Archivos files = new Archivos("");
            DataTable dt = null;
            XmlDocument xd = files.readXMLFile(sXML);

            return dt;
        }

    }
}
