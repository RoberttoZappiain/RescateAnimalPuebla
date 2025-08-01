using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class _Default : Page
    {
        private readonly AnimalNegocio _animalNegocio = new AnimalNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCatalogo();
            }
        }

        private void CargarCatalogo()
        {
            // Llamamos al nuevo método que consulta la Vista
            repeaterAnimales.DataSource = _animalNegocio.ListarDisponiblesParaAdopcion();
            repeaterAnimales.DataBind();
        }
    }
}