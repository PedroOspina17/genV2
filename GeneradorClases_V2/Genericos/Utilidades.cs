using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace Utils
{
    public class Generico
    {

        public static List<T> CrearDTO<T>(DataTable dt) where T : class
        {
            List<T> listDTO = null;
            try
            {
                if (dt.Rows.Count > 0)
                {
                    listDTO = new List<T>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listDTO.Add(CrearDTO<T>(dr));
                    }
                     
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listDTO;
        }

        public static T CrearDTO<T>(DataRow dr) where T : class
        {
            T DTO = new T();
            try
            {
                
                    PropertyInfo[] Properties = DTO.GetType().GetProperties();
                    foreach (PropertyInfo property in Properties)
                    {
                        try
                        {
                            property.SetValue(DTO, dr[property.Name], null);
                        }
                        catch (Exception){}
                        
                    }
					DTO.CrearReferencias();
                
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            return DTO;
        }

        
        
    }
}
