using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class GestionarAsociaciones : System.Web.UI.Page
    {
        private readonly AsociacionNegocio _asociacionNegocio = new AsociacionNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            gvAsociaciones.DataSource = _asociacionNegocio.ListarAsociaciones();
            gvAsociaciones.DataBind();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTipo.Text = string.Empty;
            txtMision.Text = string.Empty;
            hfAsociacionID.Value = "0";
            hfRutaLogoActual.Value = string.Empty;
            imgLogoPreview.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int asociacionID = Convert.ToInt32(hfAsociacionID.Value);
                string nombre = txtNombre.Text;
                string direccion = txtDireccion.Text;
                string tipo = txtTipo.Text;
                string mision = txtMision.Text;
                string rutaLogo = hfRutaLogoActual.Value; // Mantenemos el logo actual por si no se sube uno nuevo

                // Lógica para manejar la carga del archivo de imagen
                if (fuLogo.HasFile)
                {
                    // Generamos un nombre de archivo único para evitar conflictos
                    string nombreArchivo = Guid.NewGuid().ToString() + Path.GetExtension(fuLogo.FileName);
                    string rutaGuardado = Server.MapPath("~/Imagenes/Logos/") + nombreArchivo;
                    fuLogo.SaveAs(rutaGuardado);
                    rutaLogo = nombreArchivo; // Actualizamos la ruta con el nuevo archivo
                }

                if (asociacionID == 0) // Nuevo registro
                {
                    _asociacionNegocio.InsertarAsociacion(nombre, direccion, mision, tipo, rutaLogo);
                    MostrarAlerta("¡Asociación creada con éxito!");
                }
                else // Actualización
                {
                    _asociacionNegocio.EditarAsociacion(asociacionID, nombre, direccion, mision, tipo, rutaLogo);
                    MostrarAlerta("¡Asociación actualizada con éxito!");
                }

                LimpiarFormulario();
                CargarDatos();
            }
            catch (Exception ex)
            {
                MostrarAlerta($"Error: {ex.Message}");
            }
        }

        protected void gvAsociaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int asociacionID = Convert.ToInt32(e.CommandArgument);
                DataTable dt = _asociacionNegocio.ObtenerAsociacionPorID(asociacionID);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    hfAsociacionID.Value = row["AsociacionID"].ToString();
                    txtNombre.Text = row["Nombre"].ToString();
                    txtDireccion.Text = row["Direccion"].ToString();
                    txtTipo.Text = row["Tipo"].ToString();
                    txtMision.Text = row["Mision"].ToString();
                    hfRutaLogoActual.Value = row["RutaLogo"].ToString();

                    // Mostrar la previsualización del logo
                    if (!string.IsNullOrEmpty(hfRutaLogoActual.Value))
                    {
                        imgLogoPreview.ImageUrl = "~/Imagenes/Logos/" + hfRutaLogoActual.Value;
                        imgLogoPreview.Visible = true;
                    }
                    else
                    {
                        imgLogoPreview.Visible = false;
                    }
                }
            }
            else if (e.CommandName == "Eliminar")
            {
                try
                {
                    int asociacionID = Convert.ToInt32(e.CommandArgument);
                    _asociacionNegocio.EliminarAsociacion(asociacionID);
                    CargarDatos();
                    MostrarAlerta("Asociación eliminada con éxito.");
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
            string script = $"alert('{mensaje.Replace("'", "\\'")}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "Alert", script, true);
        }
    }







}