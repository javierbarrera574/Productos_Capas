using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;


namespace Datos
{

    public class DatosConexion
    {

        protected SqlConnection conexion;
        protected string cadenaConexion = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL;Connect Timeout = 50";


         public DatosConexion()
         { 

              conexion = new SqlConnection(cadenaConexion);
              
         }


        #region Metodos
        public void AbrirConexion()
        {
             
            try
            {

                if (conexion.State == ConnectionState.Broken || conexion.State == ConnectionState.Closed)
                    conexion.Close();
            }
            catch(Exception e)
            { 
                 
                 throw new Exception(" Error al tratar de abrir la conexion", e);

            }

        }

        public void CerrarConexion()
        { 
             
             try
             {

                  if (conexion.State == ConnectionState.Open)
                    conexion.Close();

             }
              catch (Exception e)
             {

                  throw new Exception("Error al tratar de cerrar la conexion", e);

             }

        }
        #endregion


    }

}
