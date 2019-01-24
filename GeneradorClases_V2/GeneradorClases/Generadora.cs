using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GeneradorClases
{
    public class Generadora
    {
        DataTable dtTabla;
        DataTable dtReferencias;
        Definicion defTabla;
        String sRealTableName;
        String sAppNameSpace;
        String sTableName;
        String sNameSpace;
        String sRuta;
        String sLanguageType;
        String sDataBase;
        private String[] CaracteresSobrantes = new String[6];
        private Generadora() { }

        public Generadora(String sTableName, String sRuta, String sLanguageType, String sAppNameSpace, String sDataBase)
        {
            this.dtTabla = null;
            this.dtReferencias = null;
            this.sRealTableName = sTableName;
            this.sDataBase = sDataBase;
            this.sAppNameSpace = sAppNameSpace != "" ? sAppNameSpace + "." : "";
            this.sTableName = (sTableName.Substring(0, 2).ToUpper() == "TB" ? sTableName.Substring(2, sTableName.Length - 2) : sTableName);
            this.sRuta = sRuta;
            this.sLanguageType = sLanguageType;

            CaracteresSobrantes[0] = ",";
            CaracteresSobrantes[1] = "AND";
            CaracteresSobrantes[2] = "&&";
            CaracteresSobrantes[3] = "&"; 
            CaracteresSobrantes[4] = "OR";
            CaracteresSobrantes[5] = "+\"&\"";
        }

        public bool Generar(DataTable dt, String[] sColumnsPrimary, DataTable dtReferencias)
        {
            this.dtTabla = dt;
            this.dtReferencias = dtReferencias;
            //Contruye la definicion a partir de un DataTable
            ConstruirDefinicionTabla(sColumnsPrimary);
            String sContenido = "";
            //Creamos la carpeta para la entidad
            try
            {
                Archivo.createFolder(sRuta, sTableName);
                sRuta += "/" + sTableName;

                //Procedimiento Alamcenado
                sContenido = AbrirPlantilla(@"StoredProcedure.sql");
                sContenido = GenerarArchivo(sContenido);
                Archivo.createFile(sRuta, sTableName + ".sql", sContenido);

                //Reglas de negocio
                sContenido = AbrirPlantilla(@"ReglasNegocio." + sLanguageType);
                sNameSpace = sAppNameSpace + "ReglasNegocio";
                sContenido = GenerarArchivo(sContenido);
                Archivo.createFolder(sRuta, "ReglaNegocio");
                Archivo.createFile(sRuta + @"\ReglaNegocio", sTableName + "." + sLanguageType, sContenido);

                //Datos
                sContenido = AbrirPlantilla(@"Datos." + sLanguageType);
                sNameSpace = sAppNameSpace + "Datos";
                sContenido = GenerarArchivo(sContenido);
                Archivo.createFolder(sRuta, "Datos");
                Archivo.createFile(sRuta + @"\Datos", sTableName + "." + sLanguageType, sContenido);

                //Objetos
                sContenido = AbrirPlantilla(@"Objetos." + sLanguageType);
                sNameSpace = sAppNameSpace + "Objetos";
                sContenido = GenerarArchivo(sContenido);
                Archivo.createFolder(sRuta, "Objetos");
                Archivo.createFile(sRuta + @"\Objetos", sTableName + "." + sLanguageType, sContenido);

                //Vistas
                //Markup
                sContenido = AbrirPlantilla(@"Vista.aspx");
                sNameSpace = sAppNameSpace + "Vista";
                sContenido = GenerarArchivo(sContenido);
                Archivo.createFolder(sRuta, "Vista");
                Archivo.createFile(sRuta + @"\Vista", sTableName + ".aspx", sContenido);
                //Code behind
                sContenido = AbrirPlantilla(@"Vista.aspx.cs");
                sNameSpace = sAppNameSpace + "Vista";
                sContenido = GenerarArchivo(sContenido);
                Archivo.createFolder(sRuta, "Vista");
                Archivo.createFile(sRuta + @"\Vista", sTableName + ".aspx.cs", sContenido);
                // Designer
                sContenido = AbrirPlantilla(@"Vista.aspx.designer.cs");
                sNameSpace = sAppNameSpace + "Vista";
                sContenido = GenerarArchivo(sContenido);
                Archivo.createFolder(sRuta, "Vista");
                Archivo.createFile(sRuta + @"\Vista", sTableName + ".aspx.designer.cs", sContenido);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        private String GenerarArchivo(String sContenido)
        {
            CrearCampos(ref sContenido);
            CrearReferencias(ref sContenido);
            CrearPrimaryKeys(ref sContenido);

            sContenido = sContenido.Replace("<RealTableName>", sRealTableName);
            sContenido = sContenido.Replace("<TableName>", sTableName);
            sContenido = sContenido.Replace("<Namespace>", sNameSpace);
            sContenido = sContenido.Replace("<DataBase>", "[" + sDataBase.ToUpper() + "]");

            return sContenido;
        }

        private void CrearCampos(ref String sContenido)
        {
            String[,] sCamposRepeticiones = null;
            int nCantidadRepeticiones = 0;
            //Buscamos la cantidad de repeticiones
            for (int i = 0; i < sContenido.Length; i++)
            {
                if (sContenido.IndexOf("<Fields>", i) > 0)
                {
                    nCantidadRepeticiones++;
                    i = sContenido.IndexOf("<Fields>", i) + 1;
                }
                else
                {
                    break;
                }
            }

            //Existen repeticiones para los campos
            if (nCantidadRepeticiones > 0)
            {
                sCamposRepeticiones = new String[nCantidadRepeticiones, 2];
                int nInicio = 0;
                for (int i = 0; i < nCantidadRepeticiones; i++)
                {
                    nInicio = sContenido.IndexOf("<Fields>", nInicio);
                    int nTamano = sContenido.IndexOf("</Fields>", nInicio + 1);
                    if (nInicio < 0) break;//Ya reemplazo todo de un solo tiro, no es necesario que siga
                    nTamano -= nInicio; //  (Fin - Inicio) = Tamaño 
                    sCamposRepeticiones[i, 0] = sContenido.Substring(nInicio, nTamano + "</Fields>".Length);
                    sCamposRepeticiones[i, 1] = sCamposRepeticiones[i, 0].Replace("<Fields>", "");
                    sCamposRepeticiones[i, 1] = sCamposRepeticiones[i, 1].Replace("</Fields>", "");
                    //Realizamos la repeticion por cada uno de los campos
                    String sPlantilla = sCamposRepeticiones[i, 1];
                    sCamposRepeticiones[i, 1] = "";
                    foreach (FilaDefinicion fila in defTabla.Filas)
                    {

                        sCamposRepeticiones[i, 1] += setInformacionFila(fila, sPlantilla);

                    }

                    sCamposRepeticiones[i, 1] = EliminarUltimoCaracterSobrante(sCamposRepeticiones[i, 1]);
                    //Reemplazamos las repeticiones en el contenido
                    sContenido = sContenido.Replace(sCamposRepeticiones[i, 0], sCamposRepeticiones[i, 1]);
                }
            }
        }

        private void CrearPrimaryKeys(ref String sContenido)
        {
            String[,] sCamposRepeticiones = null;
            int nCantidadRepeticiones = 0;
            //Buscamos la cantidad de repeticiones
            for (int i = 0; i < sContenido.Length; i++)
            {
                if (sContenido.IndexOf("<PrimaryKeys>", i) > 0)
                {
                    nCantidadRepeticiones++;
                    i = sContenido.IndexOf("<PrimaryKeys>", i) + 1;
                }
                else
                {
                    break;
                }
            }

            //Existen repeticiones para los campos
            if (nCantidadRepeticiones > 0)
            {
                sCamposRepeticiones = new String[nCantidadRepeticiones, 2];
                int nInicio = 0;
                for (int i = 0; i < nCantidadRepeticiones; i++)
                {
                    nInicio = sContenido.IndexOf("<PrimaryKeys>", nInicio);
                    int nTamano = sContenido.IndexOf("</PrimaryKeys>", nInicio + 1);
                    if (nInicio < 0) break;//Ya reemplazo todo de un solo tiro, no es necesario que siga
                    nTamano -= nInicio; //  (Fin - Inicio) = Tamaño 
                    sCamposRepeticiones[i, 0] = sContenido.Substring(nInicio, nTamano + "</PrimaryKeys>".Length);
                    sCamposRepeticiones[i, 1] = sCamposRepeticiones[i, 0].Replace("<PrimaryKeys>", "");
                    sCamposRepeticiones[i, 1] = sCamposRepeticiones[i, 1].Replace("</PrimaryKeys>", "");
                    //Realizamos la repeticion por cada uno de las referencias
                    String sPlantilla = sCamposRepeticiones[i, 1];
                    sCamposRepeticiones[i, 1] = "";
                    foreach (FilaDefinicion primaryKey in defTabla.Filas.FindAll(pk => pk.ClavePrimaria == true))
                    {
                        sCamposRepeticiones[i, 1] = setInformacionFila(primaryKey, sPlantilla);
                    }
                    // Busca si al final tiene una coma que sobra                    
                    sCamposRepeticiones[i, 1] = EliminarUltimoCaracterSobrante(sCamposRepeticiones[i, 1]);

                    //Reemplazamos las repeticiones en el contenido
                    sContenido = sContenido.Replace(sCamposRepeticiones[i, 0], sCamposRepeticiones[i, 1]);
                }
            }
        }
        private string setInformacionFila(FilaDefinicion fila, string texto)
        {

            texto = texto.Replace("<FieldName>", fila.NombreCampo);
            texto = texto.Replace("<FieldDbType>", fila.TipoBD);
            texto = texto.Replace("<FieldType>", fila.TipoPrimitivo);
            texto = texto.Replace("<FieldPrecision>", (fila.Tamano != -1 ? "(" + fila.Tamano.ToString() : ""));
            texto = texto.Replace("<FieldPrecision2>", (fila.Tamano != -1 ? "," + fila.Tamano.ToString() : ""));
            texto = texto.Replace("<FieldScale>", (fila.Escala != -1 ? "," + fila.Escala.ToString() : "") + (fila.Tamano != -1 ? ")" : ""));


           texto = texto.Replace("<ControlByDataType>", fila.Control);
           texto = texto.Replace("<PrefixControl>", fila.ControlPrefijo);
           texto = texto.Replace("<AtributesControl>", fila.ControlAtributos);
           texto = texto.Replace("<ControlPropValue>", fila.ControlPropiedadDato);
           texto = texto.Replace("<DefaultValue>", fila.ValorPorDefecto);
           return texto;
        }
        private void CrearReferencias(ref String sContenido)
        {
            String[,] sCamposRepeticiones = null;
            int nCantidadRepeticiones = 0;
            //Buscamos la cantidad de repeticiones
            for (int i = 0; i < sContenido.Length; i++)
            {
                if (sContenido.IndexOf("<ForeignKeys>", i) > 0)
                {
                    nCantidadRepeticiones++;
                    i = sContenido.IndexOf("<ForeignKeys>", i) + 1;
                }
                else
                {
                    break;
                }
            }

            //Existen repeticiones para los campos
            if (nCantidadRepeticiones > 0)
            {
                sCamposRepeticiones = new String[nCantidadRepeticiones, 2];
                int nInicio = 0;
                for (int i = 0; i < nCantidadRepeticiones; i++)
                {
                    nInicio = sContenido.IndexOf("<ForeignKeys>", nInicio);
                    int nTamano = sContenido.IndexOf("</ForeignKeys>", nInicio + 1);
                    if (nInicio < 0) break;//Ya reemplazo todo de un solo tiro, no es necesario que siga
                    nTamano -= nInicio; //  (Fin - Inicio) = Tamaño 
                    sCamposRepeticiones[i, 0] = sContenido.Substring(nInicio, nTamano + "</ForeignKeys>".Length);
                    sCamposRepeticiones[i, 1] = sCamposRepeticiones[i, 0].Replace("<ForeignKeys>", "");
                    sCamposRepeticiones[i, 1] = sCamposRepeticiones[i, 1].Replace("</ForeignKeys>", "");
                    //Realizamos la repeticion por cada uno de las referencias
                    String sPlantilla = sCamposRepeticiones[i, 1];
                    sCamposRepeticiones[i, 1] = "";
                    foreach (ReferenciaDefinicion referencia in defTabla.Referencias)
                    {
                        sCamposRepeticiones[i, 1] += sPlantilla.Replace("<ParentTable>", referencia.TablaPadre);
                        sCamposRepeticiones[i, 1] = sCamposRepeticiones[i, 1].Replace("<ParentColumn>", referencia.ColumnaPadre);
                        sCamposRepeticiones[i, 1] = sCamposRepeticiones[i, 1].Replace("<ReferencedTable>", referencia.TablaReferenciada);
                        sCamposRepeticiones[i, 1] = sCamposRepeticiones[i, 1].Replace("<ReferencedColumn>", referencia.ColumnaReferenciada);
                    }
                    //Reemplazamos las repeticiones en el contenido
                    sContenido = sContenido.Replace(sCamposRepeticiones[i, 0], sCamposRepeticiones[i, 1]);
                }
            }
        }

        public string EliminarUltimoCaracterSobrante(String Cadena)
        {
            for (int i = 0; i < CaracteresSobrantes.Length; i++)
            {
                if (Cadena.LastIndexOf(CaracteresSobrantes[i] + "\r") > 0)
                {
                    Cadena = Cadena.Remove(Cadena.LastIndexOf(CaracteresSobrantes[i] + "\r"));
                }
            }
            return Cadena;
        }
        private void ConstruirDefinicionTabla(String[] sColumnsPrimary)
        {
            defTabla = new Definicion();
            FilaDefinicion fd = null;
            for (int i = 0; i < dtTabla.Rows.Count; i++)
            {
                fd = new FilaDefinicion();
                fd.NombreCampo = dtTabla.Rows[i]["COLUMN_NAME"].ToString();
                fd.TipoBD = dtTabla.Rows[i]["DATA_TYPE"].ToString().Substring(0, 1).ToUpper() + dtTabla.Rows[i]["DATA_TYPE"].ToString().Substring(1, dtTabla.Rows[i]["DATA_TYPE"].ToString().Length - 1).ToLower();
                if ((fd.TipoBD.ToLower() == "numeric" || fd.TipoBD.ToLower() == "decimal") || ((dtTabla.Rows[i]["CHARACTER_MAXIMUM_LENGTH"] != DBNull.Value && Convert.ToDouble(dtTabla.Rows[i]["CHARACTER_MAXIMUM_LENGTH"]) > 0) && (fd.TipoBD.ToLower() != "bit" && fd.TipoBD.ToLower() != "int" && fd.TipoBD.ToLower() != "datetime")))
                {
                    fd.Tamano = Convert.ToInt32(dtTabla.Rows[i]["CHARACTER_MAXIMUM_LENGTH"] != DBNull.Value && dtTabla.Rows[i]["CHARACTER_MAXIMUM_LENGTH"].ToString() != "0" ? dtTabla.Rows[i]["CHARACTER_MAXIMUM_LENGTH"] : (dtTabla.Rows[i]["NUMERIC_PRECISION"] != DBNull.Value ? dtTabla.Rows[i]["NUMERIC_PRECISION"] : -1));
                    fd.Escala = Convert.ToInt32(dtTabla.Rows[i]["NUMERIC_SCALE"] != DBNull.Value && dtTabla.Rows[i]["NUMERIC_SCALE"].ToString() != "0" ? dtTabla.Rows[i]["NUMERIC_SCALE"] : -1);
                }
                else
                {
                    fd.Tamano = -1;
                    fd.Escala = -1;
                }
                fd.ClavePrimaria = Convert.ToBoolean(dtTabla.Rows[i]["IS_PRIMARY_KEY"]);
                fd.ClaveForanea = Convert.ToBoolean(dtTabla.Rows[i]["IS_FOREIGN_KEY"]);
                fd.IsNotNull = !Convert.ToBoolean(dtTabla.Rows[i]["IS_NULLABLE"]);

                setOpcionesSegunTipoDato(ref fd);

                defTabla.Filas.Add(fd);
            }

            //Si la tabla no tiene primary key definida se establece por defecto la primer columna como primary key
            if (!defTabla.Filas.Exists(pk => pk.ClavePrimaria == true))
            {
                defTabla.Filas.ToArray()[0].ClavePrimaria = true;
            }

            ReferenciaDefinicion rd = null;
            for (int i = 0; i < dtReferencias.Rows.Count; i++)
            {
                rd = new ReferenciaDefinicion();
                rd.TablaPadre = dtReferencias.Rows[i]["parentTable"].ToString();
                rd.ColumnaPadre = dtReferencias.Rows[i]["parentColumn"].ToString();
                rd.TablaReferenciada = dtReferencias.Rows[i]["referencedTable"].ToString();
                rd.ColumnaReferenciada = dtReferencias.Rows[i]["referencedColumn"].ToString();

                defTabla.Referencias.Add(rd);
            }
        }

        private void setOpcionesSegunTipoDato(ref FilaDefinicion fila)
        {
            String TamanoMinimo;
            String TamanoMaximo;
            String atributos;
            
            switch (fila.TipoBD.ToLower())
            {
               


                case "bit":
                    fila.TipoPrimitivo = "Boolean";
                    fila.Control = "CheckBox";
                    fila.ControlPrefijo = "chk";
                    fila.ControlPropiedadDato = "Checked";
                    fila.ValorPorDefecto = "False";
                    break;
                case "varchar":
                    fila.TipoPrimitivo = "String";

                    fila.Control = "TextBox";
                    fila.ControlPrefijo = "txt";
                    fila.ControlPropiedadDato = "Text";
                    TamanoMinimo = fila.IsNotNull ? "1" : "0";
                    TamanoMaximo = fila.Tamano == -1 ? "50" : fila.Tamano.ToString();
                    atributos = " MaxLength=\"" + TamanoMaximo.ToString() + "\" "
                                     + " title=\"Ingrese el/la " + fila.NombreCampo + " (" + TamanoMaximo + " digitos max).\" ";
                    if (fila.IsNotNull)
                        atributos += " required=\"required\"";
                    atributos += " pattern=\"[0-9A-Za-z\\ñ\\Ñ]{" + TamanoMinimo + "," + TamanoMaximo + "}\" ";
                    fila.ControlAtributos = atributos;
                    fila.ValorPorDefecto = "";
                    break;

                case "int":
                    fila.TipoPrimitivo = "Int32";

                    if (fila.ClaveForanea)
                    {
                        fila.Control = "DropDownList";
                        fila.ControlPrefijo = "ddl";
                        fila.ControlPropiedadDato = "SelectedValue";
                    }
                    else
                    {
                        fila.Control = "TextBox";
                        fila.ControlPrefijo = "txt";
                        fila.ControlPropiedadDato = "Text";

                        TamanoMinimo = fila.IsNotNull ? "1" : "0";
                        TamanoMaximo = fila.Tamano == -1 ? "50" : fila.Tamano.ToString();
                        atributos = " MaxLength=\"" + TamanoMaximo.ToString() + "\" "
                                         + " title=\"Ingrese el/la " + fila.NombreCampo + " (" + TamanoMaximo + " digitos max).\" ";
                        if (fila.IsNotNull)
                            atributos += " required=\"required\"";
                        atributos += " pattern=\"[0-9]{" + TamanoMinimo + "," + TamanoMaximo + "}\" ";
                        fila.ControlAtributos = atributos;
                    }
                    fila.ValorPorDefecto = "-1";
                    break;

                case "datetime":
                    fila.TipoPrimitivo = "DateTime";

                    fila.Control = "TextBox";
                    fila.ControlPrefijo = "txt";
                    fila.ControlPropiedadDato = "Text";
                    atributos = " title=\"Ingrese el/la " + fila.NombreCampo + ".";
                    atributos += " TextMode=\"Date\" ";
                    if (fila.IsNotNull)
                        atributos += " required=\"required\"";
                    fila.ControlAtributos = atributos;
                    fila.ValorPorDefecto = "";
                    break;

                case "smalldatetime":
                    fila.TipoPrimitivo = "DateTime";

                    fila.Control = "TextBox";
                    fila.ControlPrefijo = "txt";
                    fila.ControlPropiedadDato = "Text";
                    TamanoMinimo = fila.IsNotNull ? "1" : "0";
                    TamanoMaximo = fila.Tamano == -1 ? "50" : fila.Tamano.ToString();
                    atributos = " MaxLength=\"" + TamanoMaximo.ToString() + "\" "
                                     + " title=\"Ingrese el/la " + fila.NombreCampo + " (" + TamanoMaximo + " digitos max).\" ";
                    if (fila.IsNotNull)
                        atributos += " required=\"required\"";
                    atributos += " pattern=\"[0-9]{" + TamanoMinimo + "," + TamanoMaximo + "}\" ";
                    fila.ControlAtributos = atributos;
                    fila.ValorPorDefecto = "";
                    break;
                
                case "date":
                    fila.TipoPrimitivo = "DateTime";

                    fila.Control = "TextBox";
                    fila.ControlPrefijo = "txt";
                    fila.ControlPropiedadDato = "Text";
                    atributos = " title=\"Ingrese el/la " + fila.NombreCampo + ".";
                    atributos += " TextMode=\"Date\" ";
                    if (fila.IsNotNull)
                        atributos += " required=\"required\"";
                    fila.ControlAtributos = atributos;
                    fila.ValorPorDefecto = "";
                    break;
                case "time":
                    fila.TipoPrimitivo = "DateTime";

                    fila.Control = "TextBox";
                    fila.ControlPrefijo = "txt";
                    fila.ControlPropiedadDato = "Text";
                    atributos = " title=\"Ingrese el/la " + fila.NombreCampo + ".";
                    atributos += " TextMode=\"Date\" ";
                    if (fila.IsNotNull)
                        atributos += " required=\"required\"";
                    fila.ControlAtributos = atributos;
                    fila.ValorPorDefecto = "";
                    break;
                case "timestamp":
                    fila.TipoPrimitivo = "Int32";

                    fila.Control = "TextBox";
                    fila.ControlPrefijo = "txt";
                    fila.ControlPropiedadDato = "Text";
                    TamanoMinimo = fila.IsNotNull ? "1" : "0";
                    TamanoMaximo = fila.Tamano == -1 ? "50" : fila.Tamano.ToString();
                    atributos = " MaxLength=\"" + TamanoMaximo.ToString() + "\" "
                                     + " title=\"Ingrese el/la " + fila.NombreCampo + " (" + TamanoMaximo + " digitos max).\" ";
                    if (fila.IsNotNull)
                        atributos += " required=\"required\"";
                    atributos += " pattern=\"[0-9A-Za-z\\ñ\\Ñ]{" + TamanoMinimo + "," + TamanoMaximo + "}\" ";
                    fila.ControlAtributos = atributos;
                    fila.ValorPorDefecto = "";
                    break;


                case "tinyint":
                    fila.TipoPrimitivo = "Int16";

                    fila.Control = "TextBox";
                    fila.ControlPrefijo = "txt";
                    fila.ControlPropiedadDato = "Text";
                    TamanoMinimo = fila.IsNotNull ? "1" : "0";
                    TamanoMaximo = fila.Tamano == -1 ? "50" : fila.Tamano.ToString();
                    atributos = " MaxLength=\"" + TamanoMaximo.ToString() + "\" "
                                     + " title=\"Ingrese el/la " + fila.NombreCampo + " (" + TamanoMaximo + " digitos max).\" ";
                    if (fila.IsNotNull)
                        atributos += " required=\"required\"";
                    atributos += " pattern=\"[0-9]{" + TamanoMinimo + "," + TamanoMaximo + "}\" ";
                    fila.ControlAtributos = atributos;
                    fila.ValorPorDefecto = "-1";
                    break;
                case "smallint":
                    fila.TipoPrimitivo = "Int16";

                    fila.Control = "TextBox";
                    fila.ControlPrefijo = "txt";
                    fila.ControlPropiedadDato = "Text";
                    TamanoMinimo = fila.IsNotNull ? "1" : "0";
                    TamanoMaximo = fila.Tamano == -1 ? "50" : fila.Tamano.ToString();
                    atributos = " MaxLength=\"" + TamanoMaximo.ToString() + "\" "
                                     + " title=\"Ingrese el/la " + fila.NombreCampo + " (" + TamanoMaximo + " digitos max).\" ";
                    if (fila.IsNotNull)
                        atributos += " required=\"required\"";
                    atributos += " pattern=\"[0-9]{" + TamanoMinimo + "," + TamanoMaximo + "}\" ";
                    fila.ControlAtributos = atributos;
                    fila.ValorPorDefecto = "-1";
                    break;
               
                case "bigint":
                    fila.TipoPrimitivo = "Int64";

                    fila.Control = "TextBox";
                    fila.ControlPrefijo = "txt";
                    fila.ControlPropiedadDato = "Text";
                    TamanoMinimo = fila.IsNotNull ? "1" : "0";
                    TamanoMaximo = fila.Tamano == -1 ? "50" : fila.Tamano.ToString();
                    atributos = " MaxLength=\"" + TamanoMaximo.ToString() + "\" "
                                     + " title=\"Ingrese el/la " + fila.NombreCampo + " (" + TamanoMaximo + " digitos max).\" ";
                    if (fila.IsNotNull)
                        atributos += " required=\"required\"";
                    atributos += " pattern=\"[0-9]{" + TamanoMinimo + "," + TamanoMaximo + "}\" ";
                    fila.ControlAtributos = atributos;
                    fila.ValorPorDefecto = "-1";
                    break;

                case "float":
                    fila.TipoPrimitivo = "Double";

                    fila.Control = "TextBox";
                    fila.ControlPrefijo = "txt";
                    fila.ControlPropiedadDato = "Text";
                    TamanoMinimo = fila.IsNotNull ? "1" : "0";
                    TamanoMaximo = fila.Tamano == -1 ? "50" : fila.Tamano.ToString();
                    atributos = " MaxLength=\"" + TamanoMaximo.ToString() + "\" "
                                     + " title=\"Ingrese el/la " + fila.NombreCampo + " (" + TamanoMaximo + " digitos max).\" ";
                    if (fila.IsNotNull)
                        atributos += " required=\"required\"";
                    atributos += " pattern=\"[0-9]{" + TamanoMinimo + "," + TamanoMaximo + "}\" ";
                    fila.ControlAtributos = atributos;
                    fila.ValorPorDefecto = "-1";
                    break;
                case "decimal":
                    fila.TipoPrimitivo = "Decimal";

                    fila.Control = "TextBox";
                    fila.ControlPrefijo = "txt";
                    fila.ControlPropiedadDato = "Text";
                    TamanoMinimo = fila.IsNotNull ? "1" : "0";
                    TamanoMaximo = fila.Tamano == -1 ? "50" : fila.Tamano.ToString();
                    atributos = " MaxLength=\"" + TamanoMaximo.ToString() + "\" "
                                     + " title=\"Ingrese el/la " + fila.NombreCampo + " (" + TamanoMaximo + " digitos max).\" ";
                    if (fila.IsNotNull)
                        atributos += " required=\"required\"";
                    atributos += " pattern=\"[0-9]{" + TamanoMinimo + "," + TamanoMaximo + "}\" ";
                    fila.ControlAtributos = atributos;
                    fila.ValorPorDefecto = "-1";
                    break;
                case "numeric":
                    fila.TipoPrimitivo = "Decimal";

                    fila.Control = "TextBox";
                    fila.ControlPrefijo = "txt";
                    fila.ControlPropiedadDato = "Text";
                    TamanoMinimo = fila.IsNotNull ? "1" : "0";
                    TamanoMaximo = fila.Tamano == -1 ? "50" : fila.Tamano.ToString();
                    atributos = " MaxLength=\"" + TamanoMaximo.ToString() + "\" "
                                     + " title=\"Ingrese el/la " + fila.NombreCampo + " (" + TamanoMaximo + " digitos max).\" ";
                    if (fila.IsNotNull)
                        atributos += " required=\"required\"";
                    atributos += " pattern=\"[0-9]{" + TamanoMinimo + "," + TamanoMaximo + "}\" ";
                    fila.ControlAtributos = atributos;
                    fila.ValorPorDefecto = "-1";
                    break;


                case "real":
                    fila.TipoPrimitivo = "Int32";

                    fila.Control = "TextBox";
                    fila.ControlPrefijo = "txt";
                    fila.ControlPropiedadDato = "Text";
                    TamanoMinimo = fila.IsNotNull ? "1" : "0";
                    TamanoMaximo = fila.Tamano == -1 ? "50" : fila.Tamano.ToString();
                    atributos = " MaxLength=\"" + TamanoMaximo.ToString() + "\" "
                                     + " title=\"Ingrese el/la " + fila.NombreCampo + " (" + TamanoMaximo + " digitos max).\" ";
                    if (fila.IsNotNull)
                        atributos += " required=\"required\"";
                    atributos += " pattern=\"[0-9]{" + TamanoMinimo + "," + TamanoMaximo + "}\" ";
                    fila.ControlAtributos = atributos;
                    fila.ValorPorDefecto = "-1";
                    break;
                case "money":
                    fila.TipoPrimitivo = "Decimal";

                    fila.Control = "TextBox";
                    fila.ControlPrefijo = "txt";
                    fila.ControlPropiedadDato = "Text";
                    TamanoMinimo = fila.IsNotNull ? "1" : "0";
                    TamanoMaximo = fila.Tamano == -1 ? "50" : fila.Tamano.ToString();
                    atributos = " MaxLength=\"" + TamanoMaximo.ToString() + "\" "
                                     + " title=\"Ingrese el/la " + fila.NombreCampo + " (" + TamanoMaximo + " digitos max).\" ";
                    if (fila.IsNotNull)
                        atributos += " required=\"required\"";
                    atributos += " pattern=\"[0-9]{" + TamanoMinimo + "," + TamanoMaximo + "}\" ";
                    fila.ControlAtributos = atributos;
                    fila.ValorPorDefecto = "-1";
                    break;

                case "smallmoney":
                    fila.TipoPrimitivo = "Decimal";

                    fila.Control = "TextBox";
                    fila.ControlPrefijo = "txt";
                    fila.ControlPropiedadDato = "Text";
                    TamanoMinimo = fila.IsNotNull ? "1" : "0";
                    TamanoMaximo = fila.Tamano == -1 ? "50" : fila.Tamano.ToString();
                    atributos = " MaxLength=\"" + TamanoMaximo.ToString() + "\" "
                                     + " title=\"Ingrese el/la " + fila.NombreCampo + " (" + TamanoMaximo + " digitos max).\" ";
                    if (fila.IsNotNull)
                        atributos += " required=\"required\"";
                    atributos += " pattern=\"[0-9]{" + TamanoMinimo + "," + TamanoMaximo + "}\" ";
                    fila.ControlAtributos = atributos;
                    fila.ValorPorDefecto = "-1";
                    break;


                case "ntext":
                    fila.TipoPrimitivo = "String";

                    fila.Control = "TextBox";
                    fila.ControlPrefijo = "txt";
                    fila.ControlPropiedadDato = "Text";
                    TamanoMinimo = fila.IsNotNull ? "1" : "0";
                    TamanoMaximo = fila.Tamano == -1 ? "50" : fila.Tamano.ToString();
                    atributos = " MaxLength=\"" + TamanoMaximo.ToString() + "\" "
                                     + " title=\"Ingrese el/la " + fila.NombreCampo + " (" + TamanoMaximo + " digitos max).\" ";
                    if (fila.IsNotNull)
                        atributos += " required=\"required\"";
                    atributos += " pattern=\"[0-9]{" + TamanoMinimo + "," + TamanoMaximo + "}\" ";
                    fila.ControlAtributos = atributos;
                    fila.ValorPorDefecto = "";
                    break;
                case "text":
                    fila.TipoPrimitivo = "String";

                    fila.Control = "TextBox";
                    fila.ControlPrefijo = "txt";
                    fila.ControlPropiedadDato = "Text";
                    TamanoMinimo = fila.IsNotNull ? "1" : "0";
                    TamanoMaximo = fila.Tamano == -1 ? "50" : fila.Tamano.ToString();
                    atributos = " MaxLength=\"" + TamanoMaximo.ToString() + "\" "
                                     + " title=\"Ingrese el/la " + fila.NombreCampo + " (" + TamanoMaximo + " digitos max).\" ";
                    if (fila.IsNotNull)
                        atributos += " required=\"required\"";
                    atributos += " pattern=\"[0-9A-Za-z\\ñ\\Ñ]{" + TamanoMinimo + "," + TamanoMaximo + "}\" ";
                    fila.ControlAtributos = atributos;
                    fila.ValorPorDefecto = "";
                    break;
                
                case "char":
                    fila.TipoPrimitivo = "String";

                    fila.Control = "TextBox";
                    fila.ControlPrefijo = "txt";
                    fila.ControlPropiedadDato = "Text";
                    TamanoMinimo = fila.IsNotNull ? "1" : "0";
                    TamanoMaximo = fila.Tamano == -1 ? "50" : fila.Tamano.ToString();
                    atributos = " MaxLength=\"" + TamanoMaximo.ToString() + "\" "
                                     + " title=\"Ingrese el/la " + fila.NombreCampo + " (" + TamanoMaximo + " digitos max).\" ";
                    if (fila.IsNotNull)
                        atributos += " required=\"required\"";
                    atributos += " pattern=\"[0-9A-Za-z\\ñ\\Ñ]{" + TamanoMinimo + "," + TamanoMaximo + "}\" ";
                    fila.ControlAtributos = atributos;
                    fila.ValorPorDefecto = "";
                    break;
                case "nvarchar":
                    fila.TipoPrimitivo = "String";

                    fila.Control = "TextBox";
                    fila.ControlPrefijo = "txt";
                    fila.ControlPropiedadDato = "Text";
                    TamanoMinimo = fila.IsNotNull ? "1" : "0";
                    TamanoMaximo = fila.Tamano == -1 ? "50" : fila.Tamano.ToString();
                    atributos = " MaxLength=\"" + TamanoMaximo.ToString() + "\" "
                                     + " title=\"Ingrese el/la " + fila.NombreCampo + " (" + TamanoMaximo + " digitos max).\" ";
                    if (fila.IsNotNull)
                        atributos += " required=\"required\"";
                    atributos += " pattern=\"[0-9A-Za-z\\ñ\\Ñ]{" + TamanoMinimo + "," + TamanoMaximo + "}\" ";
                    fila.ControlAtributos = atributos;
                    fila.ValorPorDefecto = "";
                    break;
                case "nchar":
                    fila.TipoPrimitivo = "String";

                    fila.Control = "TextBox";
                    fila.ControlPrefijo = "txt";
                    fila.ControlPropiedadDato = "Text";
                    TamanoMinimo = fila.IsNotNull ? "1" : "0";
                    TamanoMaximo = fila.Tamano == -1 ? "50" : fila.Tamano.ToString();
                    atributos = " MaxLength=\"" + TamanoMaximo.ToString() + "\" "
                                     + " title=\"Ingrese el/la " + fila.NombreCampo + " (" + TamanoMaximo + " digitos max).\" ";
                    if (fila.IsNotNull)
                        atributos += " required=\"required\"";
                    atributos += " pattern=\"[0-9A-Za-z\\ñ\\Ñ]{" + TamanoMinimo + "," + TamanoMaximo + "}\" ";
                    fila.ControlAtributos = atributos;
                    fila.ValorPorDefecto = "";
                    break;

                case "varbinary":
                    fila.TipoPrimitivo = "Int32";

                    fila.Control = "TextBox";
                    fila.ControlPrefijo = "txt";
                    fila.ControlPropiedadDato = "Text";
                    TamanoMinimo = fila.IsNotNull ? "1" : "0";
                    TamanoMaximo = fila.Tamano == -1 ? "50" : fila.Tamano.ToString();
                    atributos = " MaxLength=\"" + TamanoMaximo.ToString() + "\" "
                                     + " title=\"Ingrese el/la " + fila.NombreCampo + " (" + TamanoMaximo + " digitos max).\" ";
                    if (fila.IsNotNull)
                        atributos += " required=\"required\"";
                    atributos += " pattern=\"[0-9A-Za-z\\ñ\\Ñ]{" + TamanoMinimo + "," + TamanoMaximo + "}\" ";
                    fila.ControlAtributos = atributos;
                    fila.ValorPorDefecto = "";
                    break;

                case "binary":
                    fila.TipoPrimitivo = "Int32";

                    fila.Control = "TextBox";
                    fila.ControlPrefijo = "txt";
                    fila.ControlPropiedadDato = "Text";
                    TamanoMinimo = fila.IsNotNull ? "1" : "0";
                    TamanoMaximo = fila.Tamano == -1 ? "50" : fila.Tamano.ToString();
                    atributos = " MaxLength=\"" + TamanoMaximo.ToString() + "\" "
                                     + " title=\"Ingrese el/la " + fila.NombreCampo + " (" + TamanoMaximo + " digitos max).\" ";
                    if (fila.IsNotNull)
                        atributos += " required=\"required\"";
                    atributos += " pattern=\"[0-9A-Za-z\\ñ\\Ñ]{" + TamanoMinimo + "," + TamanoMaximo + "}\" ";
                    fila.ControlAtributos = atributos;
                    fila.ValorPorDefecto = "";
                    break;

                case "xml":
                    fila.TipoPrimitivo = "String";

                    fila.Control = "TextBox";
                    fila.ControlPrefijo = "txt";
                    fila.ControlPropiedadDato = "Text";
                    TamanoMinimo = fila.IsNotNull ? "1" : "0";
                    TamanoMaximo = fila.Tamano == -1 ? "50" : fila.Tamano.ToString();
                    atributos = " MaxLength=\"" + TamanoMaximo.ToString() + "\" "
                                     + " title=\"Ingrese el/la " + fila.NombreCampo + " (" + TamanoMaximo + " digitos max).\" ";
                    if (fila.IsNotNull)
                        atributos += " required=\"required\"";
                    atributos += " pattern=\"[0-9A-Za-z\\ñ\\Ñ]{" + TamanoMinimo + "," + TamanoMaximo + "}\" ";
                    fila.ControlAtributos = atributos;
                    fila.ValorPorDefecto = "";
                    break;
            }
            if (fila.ClavePrimaria)
                fila.ControlAtributos += " Visible=\"False\"";
        }

        private string AbrirPlantilla(string sNombrePlantilla)
        {
            return Archivo.readFile(".", sNombrePlantilla);
        }

        protected class Definicion
        {
            private string sNombreTabla;
            public List<FilaDefinicion> Filas;
            public List<ReferenciaDefinicion> Referencias;
            //private int nFilas;
            //private int nReferencias;
            public Definicion()
            {
                sNombreTabla = "";
                Filas = new List<FilaDefinicion>();
                //nFilas = 0;
                Referencias = new List<ReferenciaDefinicion>();
                //nReferencias = 0;
            }

            //public void AgregarFila(FilaDefinicion fd)
            //{
            //    if (Filas == null)
            //    {
            //        nFilas++;
            //        Filas = new FilaDefinicion[nFilas];
            //        Filas[nFilas - 1] = fd;
            //    }
            //    else
            //    {
            //        nFilas++;
            //        FilaDefinicion[] aux = Filas;
            //        Filas = new FilaDefinicion[nFilas];
            //        for (int i = 0; i < aux.Length; i++)
            //        {
            //            Filas[i] = aux[i];
            //        }
            //        Filas[nFilas - 1] = fd;
            //    }
            //}

            //public FilaDefinicion obtenerFila(string sNombreFila)
            //{
            //    FilaDefinicion fd = null;
            //    for (int i = 0; i < Filas.Length; i++)
            //    {
            //        if (Filas[i].NombreCampo == sNombreFila)
            //        {
            //            fd = Filas[i];
            //            break;
            //        }
            //    }
            //    return fd;
            //}

            //public FilaDefinicion obtenerFila(int nIndiceFila)
            //{
            //    return Filas[nIndiceFila];
            //}

            //public int TamanoFilas
            //{
            //    get { return nFilas; }
            //    set { nFilas = value; }
            //}

            // Referencias
            //public void AgregarReferencia(ReferenciaDefinicion rd)
            //{
            //    if (Referencias == null)
            //    {
            //        nReferencias++;
            //        Referencias = new ReferenciaDefinicion[nReferencias];
            //        Referencias[nReferencias - 1] = rd;
            //    }
            //    else
            //    {
            //        nReferencias++;
            //        ReferenciaDefinicion[] aux = Referencias;
            //        Referencias = new ReferenciaDefinicion[nReferencias];
            //        for (int i = 0; i < aux.Length; i++)
            //        {
            //            Referencias[i] = aux[i];
            //        }
            //        Referencias[nReferencias - 1] = rd;
            //    }
            //}
            //public ReferenciaDefinicion obtenerReferencia(int nIndiceReferencia)
            //{
            //    return Referencias[nIndiceReferencia];
            //}

            //public int TamanoReferencia
            //{
            //    get { return nReferencias; }
            //    set { nReferencias = value; }
            //}
        }

        public class FilaDefinicion
        {
            private string sNombreCampo;
            private string sTipoBD;
            private string sTipoPrimitivo;
            private int nTamano;
            private int nEscala;
            private bool bClavePrimaria;
            private bool bClaveForanea;
            private string sValorPorDefecto;
            private bool bIsNotNull;

            private String _Control;
            private String _ControlPrefijo;
            private String _ControlAtributos = "";
            private String _ControlPropiedadDato;

            public String ControlPropiedadDato
            {
                get { return _ControlPropiedadDato; }
                set { _ControlPropiedadDato = value; }
            }
            public String ControlAtributos
            {
                get { return _ControlAtributos; }
                set { _ControlAtributos = value; }
            }
            public String ControlPrefijo
            {
                get { return _ControlPrefijo; }
                set { _ControlPrefijo = value; }
            }
            public String Control
            {
                get { return _Control; }
                set { _Control = value; }
            }





            public bool IsNotNull
            {
                get { return bIsNotNull; }
                set { bIsNotNull = value; }
            }
            public string NombreCampo
            {
                get { return sNombreCampo; }
                set { sNombreCampo = value; }
            }
            public string TipoBD
            {
                get { return sTipoBD; }
                set { sTipoBD = value; }
            }
            public string TipoPrimitivo
            {
                get { return sTipoPrimitivo; }
                set { sTipoPrimitivo = value; }
            }
            public int Tamano
            {
                get { return nTamano; }
                set { nTamano = value; }
            }
            public int Escala
            {
                get { return nEscala; }
                set { nEscala = value; }
            }
            public bool ClavePrimaria
            {
                get { return bClavePrimaria; }
                set { bClavePrimaria = value; }
            }
            public bool ClaveForanea
            {
                get { return bClaveForanea; }
                set { bClaveForanea = value; }
            }
            public string ValorPorDefecto
            {
                get { return sValorPorDefecto; }
                set { sValorPorDefecto = value; }
            }

            public FilaDefinicion()
            {
            }
        }
        protected class ReferenciaDefinicion
        {
            // ToDo: Tener en cuenta el tipo de dato de las foreign key, por el momento se asumen que son de tipo enteras.
            private string sTablaPadre;
            private string sColumnaPadre;
            private string sTablaReferenciada;
            private string sColumnaReferenciada;


            public string TablaPadre
            {
                get { return sTablaPadre; }
                set { sTablaPadre = value; }
            }
            public string ColumnaPadre
            {
                get { return sColumnaPadre; }
                set { sColumnaPadre = value; }
            }
            public string TablaReferenciada
            {
                get { return sTablaReferenciada; }
                set { sTablaReferenciada = value; }
            }
            public string ColumnaReferenciada
            {
                get { return sColumnaReferenciada; }
                set { sColumnaReferenciada = value; }
            }



            public ReferenciaDefinicion()
            {
            }
        }

    }
}
