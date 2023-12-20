using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace Examen_3_Eduardo_Espinoza
{
    public partial class Encuesta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarPartidos();
            }
        }
        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }
        protected void LlenarPartidos()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(" SELECT numero, nombre from partido"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            DDLPartido.DataSource = dt;

                            DDLPartido.DataTextField = dt.Columns["nombre"].ToString();
                            DDLPartido.DataValueField = dt.Columns["numero"].ToString();
                            DDLPartido.DataBind();
                        }
                    }
                }
            }
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            int resultado = Clases.ClsEncuesta.AgregarEncuesta(TxtNombre.Text, DateTime.Parse(TxtNacimiento.Text), TextCorreo.Text, int.Parse(DDLPartido.SelectedValue));

            if (resultado > 0)
            {
                alertas("Gracias por realizar la encuesta");
                TxtNombre.Text = string.Empty;
                TxtNacimiento.Text = string.Empty;
                TextCorreo.Text = string.Empty;
                
            }
            else
            {
                alertas("Error al realizar la encuesta");

            }
        }
    }
}