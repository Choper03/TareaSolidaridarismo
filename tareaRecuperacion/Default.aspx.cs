using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tareaRecuperacion
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargaDatos();
            }

        }

        DataClasses1DataContext db = new DataClasses1DataContext("");
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = int.Parse(TxtCodigo.Text);
                string nombre1 = TxtNombre1.Text;
                string nombre2 = TxtNombre2.Text;
                string apellido1 = TxtApellido1.Text;
                string apellido2 = TxtApellido2.Text;
                string dpi = TxtDpi.Text;
                string nit = TxtNit.Text;
                string direccion = TxtDireccion.Text;
                string telefono = TxtTelefono.Text;
                string salario = TxtSalario.Text;
                string estado = TxtEstado.Text;

                var st = new CLIENTES
                {
                    CODIGO_CLIENTE = codigo,
                    NOMBRE1 = nombre1,
                    NOMBRE2 = nombre2,
                    APELLIDO1 = apellido1,
                    APELLIDO2 = apellido2,
                    DPI = dpi,
                    NIT = nit,
                    DIRECCION = direccion,
                    TELEFONO = telefono,
                    SALARIO = salario,
                    ESTADO = estado
                };

                db.CLIENTES.InsertOnSubmit(st);
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


        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = int.Parse(TxtCodigo.Text);
                string nombre1 = TxtNombre1.Text;
                string nombre2 = TxtNombre2.Text;
                string apellido1 = TxtApellido1.Text;
                string apellido2 = TxtApellido2.Text;
                string dpi = TxtDpi.Text;
                string nit = TxtNit.Text;
                string direccion = TxtDireccion.Text;
                string telefono = TxtTelefono.Text;
                string salario = TxtSalario.Text;
                string estado = TxtEstado.Text;

                var stupdate = (from cliente in db.CLIENTES where cliente.CODIGO_CLIENTE == codigo select cliente).First();
                stupdate.NOMBRE1 = nombre1;
                stupdate.NOMBRE2 = nombre2;
                stupdate.APELLIDO1 = apellido1;
                stupdate.APELLIDO2 = apellido2;
                stupdate.DPI = dpi;
                stupdate.NIT = nit;
                stupdate.DIRECCION = direccion;
                stupdate.TELEFONO = telefono;
                stupdate.SALARIO = salario;
                stupdate.ESTADO = estado;
                db.SubmitChanges();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Actualizado los datos');", true);

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
            var query = from cliente in db.CLIENTES select cliente;
            VistaCliente.DataSource = query;
            VistaCliente.DataBind();
        }

        void limpiarCarjas()
        {
            this.TxtCodigo.Text = "";
            this.TxtNombre1.Text = "";
            this.TxtApellido1.Text = "";
            this.TxtNombre2.Text = "";
            this.TxtApellido2.Text = "";
            this.TxtDpi.Text = "";
            this.TxtNit.Text = "";
            this.TxtDireccion.Text = "";
            this.TxtTelefono.Text = "";
            this.TxtSalario.Text = "";
            this.TxtEstado.Text = "";
            TxtCodigo.Focus();
        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            int rowind = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            CheckBox cd = (CheckBox)VistaCliente.Rows[rowind].FindControl("chk");
            if (cd.Checked == true)
            {
                TxtCodigo.Text = VistaCliente.Rows[rowind].Cells[1].Text;
                TxtNombre1.Text = VistaCliente.Rows[rowind].Cells[2].Text;
                TxtNombre2.Text = VistaCliente.Rows[rowind].Cells[3].Text;
                TxtApellido1.Text = VistaCliente.Rows[rowind].Cells[4].Text;
                TxtApellido2.Text = VistaCliente.Rows[rowind].Cells[5].Text;
                TxtDpi.Text = VistaCliente.Rows[rowind].Cells[6].Text;
                TxtNit.Text = VistaCliente.Rows[rowind].Cells[7].Text;
                TxtDireccion.Text = VistaCliente.Rows[rowind].Cells[8].Text;
                TxtTelefono.Text = VistaCliente.Rows[rowind].Cells[9].Text;
                TxtSalario.Text = VistaCliente.Rows[rowind].Cells[10].Text;
                TxtEstado.Text = VistaCliente.Rows[rowind].Cells[11].Text;
            }
            else
            {
                this.TxtCodigo.Text = "";
                this.TxtNombre1.Text = "";
                this.TxtApellido1.Text = "";
                this.TxtNombre2.Text = "";
                this.TxtApellido2.Text = "";
                this.TxtDpi.Text = "";
                this.TxtNit.Text = "";
                this.TxtDireccion.Text = "";
                this.TxtTelefono.Text = "";
                this.TxtSalario.Text = "";
                this.TxtEstado.Text = "";
                TxtCodigo.Focus();
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = int.Parse(TxtCodigo.Text);


                var stEliminar = (from cliente in db.CLIENTES where cliente.CODIGO_CLIENTE == codigo select cliente).First();
                db.CLIENTES.DeleteOnSubmit(stEliminar);
                db.SubmitChanges();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Eliminados los datos');", true);

                cargaDatos();
                limpiarCarjas();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('" + ex.Message.ToString() + "');", true);
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (TxtCodigo.Text != string.Empty)
            {
                var stBuscar = from cliente in db.CLIENTES where cliente.CODIGO_CLIENTE == int.Parse(TxtCodigo.Text) select cliente;
                VistaCliente.DataSource = stBuscar;
                VistaCliente.DataBind();
            }
        }
    }
}