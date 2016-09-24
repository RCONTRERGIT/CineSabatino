using Cinemex.Cartelera.Business;
using Cinemex.Cartelera.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                CargarGv(null);
            }
        }
        catch (Exception ex)
        {
            Title = ex.Message;
        }
    }

    private void CargarGv(int? fila)
    {
        gvPeliculas.DataSource = new BusPelicula().Obtener();
        gvPeliculas.DataBind();

        DropDownList ddlGenero = (DropDownList)gvPeliculas.FooterRow.FindControl("FTddlGenero");
        ddlGenero.DataSource = new BusCatalogos().ObtenerGeneros();
        ddlGenero.DataTextField = "nombre";
        ddlGenero.DataValueField = "id";
        ddlGenero.DataBind();

        DropDownList ddlClasi = (DropDownList)gvPeliculas.FooterRow.FindControl("FTddlClasi");
        ddlClasi.DataSource = new BusCatalogos().ObtenerClasi();
        ddlClasi.DataTextField = "nombre";
        ddlClasi.DataValueField = "id";
        ddlClasi.DataBind();

        DropDownList ddlAnio = (DropDownList)gvPeliculas.FooterRow.FindControl("FTddlAnio");

        List<EntGenero> lst = new List<EntGenero>();
        for (int i = DateTime.Now.Year + 1; i > DateTime.Now.Year - 49; i--)
        {
            EntGenero ent = new EntGenero();
            ent.id = i;
            lst.Add(ent);
        }
        ddlAnio.DataSource = lst;
        ddlAnio.DataValueField = "id";
        ddlAnio.DataTextField = "id";
        ddlAnio.DataBind();

        int contador = 0;
        foreach (GridViewRow r in gvPeliculas.Rows)
        {
            if (contador == fila)
            {
                contador++;
                continue;
            }
            else
            {
                Label lbl = (Label)gvPeliculas.Rows[contador].FindControl("ITlblSinopsis");
                lbl.Text = lbl.Text.Substring(0, 20);
                contador++;
            }
        }
    }
    protected void gvPeliculas_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvPeliculas.EditIndex = e.NewEditIndex;
            CargarGv(e.NewEditIndex);
        }
        catch (Exception ex)
        {
            Title = ex.Message;
        }
    }
    protected void gvPeliculas_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            Title = ex.Message;
        }
    }
    protected void gvPeliculas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gvPeliculas.EditIndex = -1;
            CargarGv(null);
        }
        catch (Exception ex)
        {
            Title = ex.Message;
        }
    }
    protected void gvPeliculas_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            Title = ex.Message;
        }
    }
    protected void FTlnkAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            EntPelicula ent = new EntPelicula();
            ent.nombre = ((TextBox)gvPeliculas.FooterRow.FindControl("FTtxtNombre")).Text;
            ent.sinopsis = ((TextBox)gvPeliculas.FooterRow.FindControl("FTtxtSinopsis")).Text;
            ent.generoId = Convert.ToInt32(((DropDownList)gvPeliculas.FooterRow.FindControl("FTddlGenero")).SelectedValue);
            ent.clasificacionId = Convert.ToInt32(((DropDownList)gvPeliculas.FooterRow.FindControl("FTddlClasi")).SelectedValue);
            FileUpload fuFotoMini = (FileUpload)gvPeliculas.FooterRow.FindControl("FTfuFotoMini");
            ent.fotoMini = "/content/img/" + fuFotoMini.FileName;

            FileUpload fuFotoPort = (FileUpload)gvPeliculas.FooterRow.FindControl("FTfuFotoPort");
            ent.fotoPortada = "/content/img/" + fuFotoPort.FileName;

            string ruta = Server.MapPath(@"content\img\");
            fuFotoMini.SaveAs(ruta + fuFotoMini.FileName);
            fuFotoPort.SaveAs(ruta + fuFotoPort.FileName);

            ent.anio = Convert.ToInt32(((DropDownList)gvPeliculas.FooterRow.FindControl("FTddlAnio")).SelectedValue);
            ent.fechaAlta = Convert.ToDateTime(((TextBox)gvPeliculas.FooterRow.FindControl("FTtxtFecha")).Text);
            ent.estatus = ((CheckBox)gvPeliculas.FooterRow.FindControl("FTchkEstatus")).Checked;
            ent.video = ((TextBox)gvPeliculas.FooterRow.FindControl("FTtxtVideo")).Text;
            ent.productor = ((TextBox)gvPeliculas.FooterRow.FindControl("FTtxtProductor")).Text;

            new BusPelicula().Insertar(ent);
            Response.Redirect(Request.CurrentExecutionFilePath);

        }
        catch (Exception ex)
        {
            Title = ex.Message;
        }
    }
}