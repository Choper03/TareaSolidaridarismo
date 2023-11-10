using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tareaRecuperacion
{
    public partial class About : Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext("");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {
                limpiarCarjas();
                var clientes = from credito in db.CREDITOS
                               select new
                               {
                                   ID = credito.CODIGO_CREDITO,
                                   Nombres = credito.CODIGO_CLIENTE
                               };


                dropDownListCreditos.DataSource = clientes;
                dropDownListCreditos.DataTextField = "Nombres"; // Nombre del campo a mostrar
                dropDownListCreditos.DataValueField = "ID";
                dropDownListCreditos.DataBind();

                cargaDatos();
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = int.Parse(TxtCodigo.Text);
                int codigoCredito = int.Parse(dropDownListCreditos.SelectedValue);
                string fecha = DateTime.Now.ToString("yyyy-MM-dd");
                decimal monto = decimal.Parse(TxtMonto.Text);


                var st = new ABONOS
                {
                    CODIGO_MONTO = codigo,
                    CODIGO_CREDITO = codigoCredito,
                    FECHA = fecha,
                    ABONO = monto,

                };
                db.ABONOS.InsertOnSubmit(st);
                db.SubmitChanges();

                var creditocliente = (from credito in db.CREDITOS where credito.CODIGO_CREDITO == codigoCredito select credito).First();
                creditocliente.MONTO = creditocliente.MONTO - monto;
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
            var query = from abono in db.ABONOS select abono;
            VistaVenta.DataSource = query;
            VistaVenta.DataBind();
        }

        void limpiarCarjas()
        {
            this.TxtCodigo.Text = "";
            this.TxtFecha.Text = "";
            this.TxtMonto.Text = "";
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            string codigoCreditoSeleccionado = dropDownListCreditos.SelectedValue;
            int codigoCredito = int.Parse(codigoCreditoSeleccionado.ToString());
            if (codigoCreditoSeleccionado != string.Empty)
            {
                var stBuscar = from abono in db.ABONOS where abono.CODIGO_CREDITO == codigoCredito select abono;
                VistaVenta.DataSource = stBuscar;
                VistaVenta.DataBind();
            }
        }
    }
}