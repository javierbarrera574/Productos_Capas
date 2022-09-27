using System;
using System.Data;
using System.Windows.Forms;
using Entidades;
using Negocio;




namespace Producto
{

    public partial class FormProducto : Form
    {


        //Instanciamos
        Productos NuevoProducto; //Declaramos
        Productos ProductoExigente;
        NegocioProductos objNegProducto = new NegocioProductos();


        bool nuevo = true;
        int fila;


        public FormProducto()
        {
            InitializeComponent();
            CrearDgv();
            LlenarDgv();

        }



        private void LlenarDgv()
        {

            dgvProducto.Rows.Clear();
            DataSet ds = new DataSet();
            ds = objNegProducto.listadoProductos(" Todos");

            if( ds.Tables[0].Rows.Count > 0 )
            {

                foreach(DataRow dr in ds.Tables[0].Rows)
                {

                    dgvProducto.Rows.Add(dr[0].ToString(), dr[1], dr[2].ToString());
                }
                else
                {

                    MessageBox.Show(" No hay productos cargados en el sistema");

                }

            }

        }



        private void CrearDgv()
        {

             dgvProducto.Columns.Add("0", " Codigo");
            dgvProducto.Columns.Add("1", " Descripcion");
            dgvProducto.Columns.Add("2", " Stock");


            dgvProducto.Columns[0].Width = 100;
            dgvProducto.Columns[1].Width = 300;
            dgvProducto.Columns[2].Width = 60;


        }




        private void btnCargar_Click(object sender, EventArgs e)
        {

            int nGrabados = -1;

            //Instanciamos utilizando el constructor de parametros
            NuevoProducto = new Productos(int.Parse(txtCodigo.Text), txtDescripcion.Text);
            lblCodigoMovimiento.Text = NuevoProducto.Codigo.ToString();
            lblDescripcion.Text = NuevoProducto.Descripcion;
            lblStockMovimiento.Text = " Hay" + NuevoProducto.Stock.ToString() + " Unidades";
            MessageBox.Show(" Producto instanciado");


            nGrabados = objNegProducto.abmProductos(" Alta", NuevoProducto);


            if(nGrabados == -1)
            {

                MessageBox.Show(" No se pudo grabar el producto en el sistema");
            }
            else
            {

                lblCodigoMovimiento.Text = NuevoProducto.Codigo.ToString();
                lblDescripcionMovimiento.Text = NuevoProducto.Descripcion;
                lblStockMovimiento.Text = " Hay" + NuevoProducto.Stock.ToString() + " Unidades";


                tbcCargaProductos.SelectedTab = tbpMovimientoProducto;


                //Llevar Producto al dgv(NuevoProducto)
                nuevo = true;
                LlenarDgv();


            }

        }




        private void btnAceptar_Click(object sender, EventArgs e)
        {

             if(rdbIngreso.Checked == true) //Esta seleccionando al ingreso
             {

                ProductoExigente.Ingreso(int.Parse(tbpMovimientoProducto.Text));

             }
             if(rdbEgreso.Checked == true )
             {

                ProductoExigente.Salida(int.Parse(tbpMovimientoProducto.Text));

             }



            int nResultado = -1;

            nResultado = objNegProducto.ambProductos(" Modificar", ProductoExigente);


            if(nResultado != -1)
            {

                LlenarDgv();

            }
            else
            {

                MessageBox.Show(" Error", " Se produjo un  error al intentar modificar el producto");

            }

        }




        private void dgvProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            ProductoExigente = new Productos(Convert.ToInt32(dgvProducto.CurrentRow.Cells[0].Value), dgvProducto.CurrentRow.Cells[1].Value.ToString(), Convert.ToInt32(dgvProducto.CurrentRow.Cells[2].Value));


            // Creo DataSet
            DataSet ds = new DataSet();


            ds = objNegProducto.listadoProducto(ProductoExigente.Codigo.ToString()); //Busco un producto en particular


            if(ds.Tables[0].Rows.Count > 0)
            {

                Ds_a_Controles(ds);

            }



            private void Ds_a_Controles(DataSet dataSet)
            { 

                  lblCodigoMovimiento.Text = ds.Tables[0].Rows[0][" Codigo"].ToString();
                lblDescripcionMovimiento.Text = ds.Tables[0].Rows[0][" Descripcion"].ToString();
                lblStockMovimiento.Text = " Hay" + ds.Tables[0].Rows[0][" Stock"].ToString() + " Unidades";


            }



        }



        void LlevarProductoAlDgv(Productos Prod)
        {

            dgvProducto.Rows.Add(Prod.Codigo.ToString(), Prod.Descripcion, Prod.Stock.ToString());
            fila = (dgvProducto.Rows.Count - 1);

        }



        void LlevarProductoAlDgv(Productos Prod, int lugar)
        { 
             
             dgvProducto[0, lugar].Value = Prod.Codigo.ToString();
            dgvProducto[1, lugar].Value= Prod.Descripcion.ToString();
            dgvProducto[2, lugar].Value = Prod.Stock.ToString();


        }

        private void FormProducto_Load(object sender, EventArgs e)
        {

        }
    }

}
