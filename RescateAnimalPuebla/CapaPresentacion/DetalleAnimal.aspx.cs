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
    public partial class DetalleAnimal : System.Web.UI.Page
    {
        private readonly AnimalNegocio _animalNegocio = new AnimalNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verificamos si se pasó un ID en la URL
                if (Request.QueryString["id"] != null)
                {
                    int animalID;
                    // Intentamos convertir el ID a un número para seguridad
                    if (int.TryParse(Request.QueryString["id"], out animalID))
                    {
                        CargarDetalles(animalID);
                    }
                    else
                    {
                        // Si el ID no es un número válido, redirigimos
                        Response.Redirect("Default.aspx");
                    }
                }
                else
                {
                    // Si no hay ID, redirigimos
                    Response.Redirect("Default.aspx");
                }
            }
        }

        private void CargarDetalles(int animalID)
        {
            DataTable dt = _animalNegocio.ObtenerAnimalPorID(animalID);

            // Verificamos si se encontró el animal
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                // Poblamos los controles con la información de la base de datos
                ltlNombreAnimal.Text = row["NombreComun"].ToString();
                ltlEspecie.Text = row["EspecieCientifica"].ToString();
                ltlRefugio.Text = row["NombreAsociacion"].ToString();
                ltlEstatus.Text = row["NombreEstatus"].ToString();
                ltlHistoria.Text = row["HistoriaRescate"].ToString();

                if (!string.IsNullOrEmpty(row["RutaFoto"].ToString()))
                {
                    imgAnimal.ImageUrl = "~/Imagenes/Animales/" + row["RutaFoto"].ToString();
                }
            }
            else
            {
                // Si no se encontró un animal con ese ID, redirigimos
                Response.Redirect("Default.aspx");
            }
        }
    }
}