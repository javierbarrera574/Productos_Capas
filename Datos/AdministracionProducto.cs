using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Linq.Expressions;


namespace Datos
{

    public class AdministracionProducto: DatosConexion
    {
         
          public int abmProductos(string accion, Productos objProducto)
          {

                int resultado = -1; //Controlar que se realice la operacion con exito
                string orden = string.Empty; // Para guardar consulta sql
                

                if( accion == " Alta") // Para agregar un producto nuevo
                {

                      orden = " insert into Productos values (" + objProducto.Codigo + ", ' "  + objProducto.Descripcion + "  ' ,  " + objProducto.Stock + "); "; 
                }
                if(accion == " Modificar") // Para modificar el producto existente
                {

                        orden = " update Productos set descripcion = ' " + objProducto.Descripcion + "  ', stock = " + objProducto.Stock + " where codigo = " + objProducto.Codigo + ";  ";


                }
                if(accion == " Baja")
                { 
                     
                       
                }


                  SqlCommand cmd = new SqlCommand(orden, conexion);

                
                  
                 try
                 {

                       AbrirConexion();
                       resultado = cmd.ExecuteNonQuery();

                 }
                 catch( Exception e)
                 {

                         throw new Exception(" Error de guardar/borrar o modificar Productos", e);
                         
                 }
                 finally
                 {

                      CerrarConexion();
                      cmd.Dispose();
                      
                 }
                 return resultado;

                  
          }

        public DataSet listadoProductos(string cual) // Para 1 o todos los datos segun el codigo
        {

             string orden = string.Empty;


             orden = " select * from Productos; ";
            //Instancia
             SqlCommand cmd = new SqlCommand(orden, conexion);
             DataSet Data_Set = new DataSet();
             SqlDataAdapter DataAdapter = new SqlDataAdapter();






              if ( cual != " Todos" )
              { 
                       
                    orden = " select * from Productos where Codigo = " +  int.Parse(cual) +  "; ";
              }

        

              else
              {
                      try
                      {
                            AbrirConexion();
                            cmd.ExecuteNonQuery();
                            DataAdapter.SelectCommand = cmd;
                            DataAdapter.Fill(Data_Set);

                      }
                      catch
                      { 
                            
                            throw new Exception(" Error al listar profesionales");
                             
                      }
                      finally
                      {

                            CerrarConexion();
                            cmd.Dispose();
                            
                      }
                      


              }

            return Data_Set;


        }


    }

}
