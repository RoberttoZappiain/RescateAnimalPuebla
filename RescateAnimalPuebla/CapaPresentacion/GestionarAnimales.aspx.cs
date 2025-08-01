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
    public partial class GestionarAnimales : System.Web.UI.Page
    {
        private readonly AnimalNegocio _animalNegocio = new AnimalNegocio();
        private readonly AsociacionNegocio _asociacionNegocio = new AsociacionNegocio();
        private readonly EstatusAnimalNegocio _estatusNegocio = new EstatusAnimalNegocio();

       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAnimales();
                CargarDropDowns();
            }
        }

        private void CargarAnimales()
        {
            gvAnimales.DataSource = _animalNegocio.ListarAnimales();
            gvAnimales.DataBind();
        }

        private void CargarDropDowns()
        {
            // Cargar Asociaciones
            ddlAsociacion.DataSource = _asociacionNegocio.ListarAsociaciones();
            ddlAsociacion.DataTextField = "Nombre";
            ddlAsociacion.DataValueField = "AsociacionID";
            ddlAsociacion.DataBind();
            ddlAsociacion.Items.Insert(0, new ListItem("-- Seleccione Asociación --", "0"));

            // Cargar Estatus
            ddlEstatus.DataSource = _estatusNegocio.ListarEstatus();
            ddlEstatus.DataTextField = "Nombre";
            ddlEstatus.DataValueField = "EstatusID";
            ddlEstatus.DataBind();
            ddlEstatus.Items.Insert(0, new ListItem("-- Seleccione Estatus --", "0"));
        }

        private void LimpiarFormulario()
        {
            txtNombreComun.Text = string.Empty;
            txtEspecieCientifica.Text = string.Empty;
            txtHistoriaRescate.Text = string.Empty;
            ddlAsociacion.ClearSelection();
            ddlEstatus.ClearSelection();
            hfAnimalID.Value = "0";
            hfRutaFotoActual.Value = string.Empty;
            imgAnimalPreview.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int animalID = Convert.ToInt32(hfAnimalID.Value);
                string nombreComun = txtNombreComun.Text;
                string especieCientifica = txtEspecieCientifica.Text;
                string historia = txtHistoriaRescate.Text;
                int asociacionID = Convert.ToInt32(ddlAsociacion.SelectedValue);
                int estatusID = Convert.ToInt32(ddlEstatus.SelectedValue);
                string rutaFoto = hfRutaFotoActual.Value;

                if (fuFotoAnimal.HasFile)
                {
                    string nombreArchivo = Guid.NewGuid().ToString() + Path.GetExtension(fuFotoAnimal.FileName);
                    string rutaGuardado = Server.MapPath("~/Imagenes/Animales/") + nombreArchivo;
                    fuFotoAnimal.SaveAs(rutaGuardado);
                    rutaFoto = nombreArchivo;
                }

                if (animalID == 0) // Nuevo
                {
                    _animalNegocio.InsertarAnimal(nombreComun, especieCientifica, historia, rutaFoto, asociacionID, estatusID);
                    MostrarAlerta("¡Animal registrado con éxito!");
                }
                else // Actualización
                {
                    _animalNegocio.EditarAnimal(animalID, nombreComun, especieCientifica, historia, rutaFoto, asociacionID, estatusID);
                    MostrarAlerta("¡Animal actualizado con éxito!");
                }

                LimpiarFormulario();
                CargarAnimales();
            }
            catch (Exception ex)
            {
                MostrarAlerta($"Error: {ex.Message}");
            }
        }

        protected void gvAnimales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int animalID = Convert.ToInt32(e.CommandArgument);
                DataTable dt = _animalNegocio.ObtenerAnimalPorID(animalID);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    hfAnimalID.Value = row["AnimalID"].ToString();
                    txtNombreComun.Text = row["NombreComun"].ToString();
                    txtEspecieCientifica.Text = row["EspecieCientifica"].ToString();
                    txtHistoriaRescate.Text = row["HistoriaRescate"].ToString();
                    ddlAsociacion.SelectedValue = row["AsociacionID"].ToString();
                    ddlEstatus.SelectedValue = row["EstatusID"].ToString();
                    hfRutaFotoActual.Value = row["RutaFoto"].ToString();

                    if (!string.IsNullOrEmpty(hfRutaFotoActual.Value))
                    {
                        imgAnimalPreview.ImageUrl = "~/Imagenes/Animales/" + hfRutaFotoActual.Value;
                        imgAnimalPreview.Visible = true;
                    }
                    else
                    {
                        imgAnimalPreview.Visible = false;
                    }
                }
            }
            else if (e.CommandName == "Eliminar")
            {
                try
                {
                    int animalID = Convert.ToInt32(e.CommandArgument);
                    _animalNegocio.EliminarAnimal(animalID);
                    CargarAnimales();
                    MostrarAlerta("Animal eliminado con éxito.");
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