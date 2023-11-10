using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tareaRecuperacion
{
    public partial class Contact : Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext("");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {
                limpiarCarjas();
                var clientes = from cliente in db.CLIENTES
                               select new
                               {
                                   ID = cliente.CODIGO_CLIENTE,
                                   Nombres = cliente.NOMBRE1 + cliente.NOMBRE2
                               };


                dropDownListClientes.DataSource = clientes;
                dropDownListClientes.DataTextField = "Nombres"; // Nombre del campo a mostrar
                dropDownListClientes.DataValueField = "ID";
                dropDownListClientes.DataBind();

                cargaDatos();
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = int.Parse(TxtCodigo.Text);
                int codigoCliente = int.Parse(dropDownListClientes.SelectedValue);
                string fecha = DateTime.Now.ToString("yyyy-MM-dd");
                decimal monto = decimal.Parse(TxtMonto.Text);

                
                    var st = new CREDITOS
                    {
                        CODIGO_CREDITO = codigo,
                        CODIGO_CLIENTE = codigoCliente,
                        FECHA = fecha,
                        MONTO = monto,
                        ESTADO = "Activo"

                    };
                    db.CREDITOS.InsertOnSubmit(st);
                    db.SubmitChanges();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Ingreso de datos');", true);
                    cargaDatos();
                    limpiarCarjas();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('" + ex.Message.ToString() + "');", true);
            }

        }


        void cargaDatos()
        {
            var query = from credito in db.CREDITOS where credito.ESTADO == "ACTIVO" select credito;
            VistaVenta.DataSource = query;
            VistaVenta.DataBind();
        }

        void limpiarCarjas()
        {
            this.TxtCodigo.Text = "";
            this.TxtFecha.Text = "";
            this.TxtMonto.Text = "";
            TxtCodigo.Focus();
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            string codigoClienteSeleccionado = dropDownListClientes.SelectedValue;
            int codigoCliente = int.Parse(codigoClienteSeleccionado.ToString());
            if (codigoClienteSeleccionado != string.Empty)
            {
                var stBuscar = from credito in db.CREDITOS where credito.CODIGO_CLIENTE == codigoCliente && credito.ESTADO == "ACTIVO" select credito;
                VistaVenta.DataSource = stBuscar;
                VistaVenta.DataBind();
            }
        }
    }
}