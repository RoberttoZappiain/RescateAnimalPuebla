using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class GestionarEstatus : System.Web.UI.Page
    {
        private readonly EstatusAnimalNegocio _estatusNegocio = new EstatusAnimalNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            gvEstatus.DataSource = _estatusNegocio.ListarEstatus();
            gvEstatus.DataBind();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            hfEstatusID.Value = "0"; // Reinicia el ID a 0 para indicar que es un nuevo registro
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                string descripcion = txtDescripcion.Text;
                int estatusID = Convert.ToInt32(hfEstatusID.Value);

                if (estatusID == 0) // Si el ID es 0, es un nuevo registro
                {
                    _estatusNegocio.InsertarEstatus(nombre, descripcion);
                    MostrarAlerta("¡Estatus creado con éxito!");
                }
                else // Si el ID es diferente de 0, es una actualización
                {
                    _estatusNegocio.EditarEstatus(estatusID, nombre, descripcion);
                    MostrarAlerta("¡Estatus actualizado con éxito!");
                }

                LimpiarFormulario();
                CargarDatos(); // Refresca la tabla
            }
            catch (Exception ex)
            {
                MostrarAlerta($"Error: {ex.Message}");
            }
        }

        protected void gvEstatus_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int estatusID = Convert.ToInt32(e.CommandArgument);
                DataTable dt = _estatusNegocio.ObtenerEstatusPorID(estatusID);

                if (dt.Rows.Count > 0)
                {
                    hfEstatusID.Value = dt.Rows[0]["EstatusID"].ToString();
                    txtNombre.Text = dt.Rows[0]["Nombre"].ToString();
                    txtDescripcion.Text = dt.Rows[0]["Descripcion"].ToString();
                }
            }
            else if (e.CommandName == "Eliminar")
            {
                try
                {
                    int estatusID = Convert.ToInt32(e.CommandArgument);
                    _estatusNegocio.EliminarEstatus(estatusID);
                    CargarDatos();
                    MostrarAlerta("Estatus eliminado con éxito.");
                }
                catch (Exception ex)
                {
                    MostrarAlerta($"Error al eliminar: {ex.Message}");
                }
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void MostrarAlerta(string mensaje)
        {
            string script = $"alert('{mensaje}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "Alert", script, true);
        }
    }
}