using Cinemex.Cartelera.Business;
using Cinemex.Cartelera.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CargarEstrenos();
            CargarRating();
            CargarPeliculas();
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }

    private void CargarPeliculas()
    {
        List<EntPelicula> lst = new BusPelicula().Obtener();
        LiteralControl literal = new LiteralControl();
        literal.Text = "";

        foreach (EntPelicula ent in lst)
        {
            literal.Text += "<div class=\"col-sm-4\">";
            literal.Text += " <div class=\"panel panel-info\">";
            literal.Text += "  <div class=\"panel-heading\" style=\"height: 200px; overflow: hidden;\">";
            literal.Text += "   <a href=\"Altas.aspx?id=" + ent.id + "\"><img class=\"img-responsive\" src=\"" + ent.fotoPortada + "\" /></a>";
            literal.Text += "  </div>";
            literal.Text += "  <div class=\"panel-body\" style=\"height: 200px; overflow:hidden;\">";
            literal.Text += "   <div class=\"row\">";
            literal.Text += "    <div class=\"col-xs-4\">";
            literal.Text += "     <img class=\"img-responsive\" src=\"" + ent.fotoMini + "\" />";
            literal.Text += "    </div>";
            literal.Text += "    <div class=\"col-xs-8\">";
            literal.Text += "        Nombre: " + ent.nombre;
            literal.Text += "        <br />";
            literal.Text += "        Año: " + ent.anio;
            literal.Text += "        <br />";
            literal.Text += "        Genero: " + ent.generoId;
            literal.Text += "        <br />";
            literal.Text += "        Clasificaciòn:" + ent.clasificacionId;
            literal.Text += "        <br />";
            literal.Text += "    </div>";
            literal.Text += "   </div>";
            literal.Text += "   sipnosis:" + ent.sinopsis;
            literal.Text += " </div>";
            literal.Text += " <div class=\"panel-footer\">";
            literal.Text += " <iframe style=\"margin: auto;\" class=\"img-responsive\" src=\"" + ent.video + "\" frameborder=\"0\" allowfullscreen></iframe>";
            literal.Text += " </div>";
            literal.Text += " </div>";
            literal.Text += "</div>";

        }
        PhPeliculas.Controls.Add(literal);
    }

    private void CargarRating()
    {
        List<EntPelicula> lst = new BusPelicula().Obtener().Take(6).OrderBy(x => x.fechaAlta).ToList();
        LiteralControl literal = new LiteralControl();
        literal.Text = "";
        int contador = 0;
        foreach (EntPelicula ent in lst)
        {
            literal = new LiteralControl();
            if (contador == 0)
                literal.Text += "<li data-target=\"#myCarousel\" data-slide-to=\"" + contador + "\" class=\"active\"></li>";
            else
                literal.Text += "<li data-target=\"#myCarousel\" data-slide-to=\"" + contador + "\"></li>";

            phTres.Controls.Add(literal);

            literal = new LiteralControl();
            if (contador == 0)
                literal.Text += "<div class=\"item active\">";
            else
                literal.Text += "<div class=\"item\">";

            literal.Text += " <img src=\"" + ent.fotoPortada + "\" alt=\"Chania\">";
            literal.Text += " <div class=\"carousel-caption\">";
            literal.Text += "  <h3>" + ent.nombre + "</h3>";
            literal.Text += "  <p>" + ent.sinopsis.Substring(0, 10) + "</p>";
            literal.Text += " </div>";
            literal.Text += "</div>";
            phCuatro.Controls.Add(literal);
            contador++;
        }




    }

    private void CargarEstrenos()
    {
        //List<EntPelicula> ls = new List<EntPelicula>();
        //BusPelicula obj = new BusPelicula();
        //ls = obj.ObtenerEstrenos();
        List<EntPelicula> lst = new BusPelicula().Obtener().OrderByDescending(x => x.fechaAlta).Take(4).ToList();
        LiteralControl literal = new LiteralControl();
        literal.Text = "";
        int contador = 0;
        foreach (EntPelicula ent in lst)
        {
            literal = new LiteralControl();
            if (contador == 0)
                literal.Text += "<li data-target=\"#myCarousel\" data-slide-to=\"" + contador + "\" class=\"active\"></li>";
            else
                literal.Text += "<li data-target=\"#myCarousel\" data-slide-to=\"" + contador + "\"></li>";

            phUno.Controls.Add(literal);

            literal = new LiteralControl();
            if (contador == 0)
                literal.Text += "<div class=\"item active\">";
            else
                literal.Text += "<div class=\"item\">";

            literal.Text += " <img src=\"" + ent.fotoPortada + "\" alt=\"Chania\">";
            literal.Text += " <div class=\"carousel-caption\">";
            literal.Text += "  <h3>" + ent.nombre + "</h3>";
            literal.Text += "  <p>" + ent.sinopsis.Substring(0, 10) + "</p>";
            literal.Text += " </div>";
            literal.Text += "</div>";
            phDos.Controls.Add(literal);
            contador++;
        }
    }

    private void MostrarMensaje(string mensaje)
    {
        mensaje = mensaje.Replace("'", "").Replace("\r", "").Replace("\n", "");
        string alerta = "alert('" + mensaje + "');";
        ScriptManager.RegisterStartupScript(this, GetType(), "", alerta, true);
    }
}