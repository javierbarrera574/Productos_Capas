using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using Entidades;


namespace Negocio
{
     
    public class NegocioProductos
    {

        //Instanciamos 
         AdministracionProducto DatosObjProducto = new AdministracionProducto();


        #region Metodos
        public int ambProductos(string accion, Productos objProducto)
        {

            return DatosObjProducto.abmProductos(accion, objProducto); //Conexion con la base de datos

        }
        #endregion



        public DataSet listadoProducto(string cual)
        {

            return DatosObjProducto.listadoProductos(cual);

        }


    }


}
