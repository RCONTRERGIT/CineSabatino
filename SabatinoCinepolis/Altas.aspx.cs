using Cinemex.Cartelera.Business;
using Cinemex.Cartelera.Business.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Altas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                CargarDDLClas();
                CargarDDLGene();
                CargarDDLAnio();
                int id = Convert.ToInt32(Request.QueryString["id"]);
                if (id != 0)
                {
                    btnActualizar.Visible = true;
                    btnAgregar.Visible = false;
                    EntPelicula ent = new BusPelicula().Obtener(id);
                    //ViewState["ID"] = ent.id;
                    //Session["ID"] = ent.id;
                    hfId.Value = ent.id.ToString();
                    hfMini.Value = ent.fotoMini;
                    hfPort.Value = ent.fotoPortada;
                    imgFotoPort.ImageUrl = ent.fotoPortada;
                    imgFotoMini.ImageUrl = ent.fotoMini;
                    ifVideo.Src = ent.video;
                    txtNomb.Text = ent.nombre;
                    txtProd.Text = ent.productor;
                    txtSino.Text = ent.sinopsis;
                    txtVide.Text = ent.video;
                    chkEsta.Checked = ent.estatus;
                    ddlCLas.SelectedValue = ent.clasificacionId.ToString();
                    ddlGene.SelectedValue = ent.generoId.ToString();
                    ddlAnio.SelectedValue = ent.anio.ToString();
                }
                else
                {
                    btnAgregar.Visible = true;
                    btnActualizar.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            Title = ex.Message;
        }
    }

    private void CargarDDLAnio()
    {
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
    }

    private void CargarDDLGene()
    {
        ddlGene.DataSource = new BusCatalogos().ObtenerGeneros();
        ddlGene.DataTextField = "nombre";
        ddlGene.DataValueField = "id";
        ddlGene.DataBind();
    }

    private void CargarDDLClas()
    {
        ddlCLas.DataSource = new BusCatalogos().ObtenerClasi();
        ddlCLas.DataTextField = "nombre";
        ddlCLas.DataValueField = "id";
        ddlCLas.DataBind();
    }
    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        try
        {
            EntPelicula ent = new EntPelicula();
            ent.id = Convert.ToInt32(hfId.Value);
            string ruta = Server.MapPath(@"content\img\");

            if (fuFotoMini.HasFile)
            {
                fuFotoMini.SaveAs(ruta + fuFotoMini.FileName);
                ent.fotoMini = "content\\img\\" + fuFotoMini.FileName;
                File.Delete(Server.MapPath(hfMini.Value));
                ent.fotoMini = hfMini.Value;
            }
            else { ent.fotoMini = hfMini.Value; }

            if (fuFotoPort.HasFile)
            {
                fuFotoPort.SaveAs(ruta + fuFotoPort.FileName);
                ent.fotoPortada = "content\\img\\" + fuFotoPort.FileName;
                if (ent.fotoPortada != hfPort.Value)
                    File.Delete(Server.MapPath(hfPort.Value));
            }
            else { ent.fotoPortada = hfPort.Value; }


            ent.nombre = txtNomb.Text;
            ent.productor = txtProd.Text;
            ent.sinopsis = txtSino.Text;
            ent.anio = Convert.ToInt32(ddlAnio.SelectedValue);
            ent.clasificacionId = Convert.ToInt32(ddlCLas.SelectedValue);
            ent.generoId = Convert.ToInt32(ddlGene.SelectedValue);
            ent.estatus = chkEsta.Checked;
            ent.video = txtVide.Text;
            ent.fechaAlta = DateTime.Now;
            new BusPelicula().Actualizar(ent);
            Response.Redirect("Default.aspx");
        }



        catch (Exception ex)
        {
            Title = ex.Message;
        }


    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            EntPelicula ent = new EntPelicula();

            if (fuFotoMini.HasFile && fuFotoPort.HasFile)
            {
                string ruta = Server.MapPath(@"content\img\");
                int fileSize = fuFotoPort.PostedFile.ContentLength;
                string extension = System.IO.Path.GetExtension(fuFotoPort.FileName);
                MemoryStream str = new MemoryStream(fuFotoPort.FileBytes);
                System.Drawing.Image bmp = System.Drawing.Image.FromStream(str);
                int ancho = bmp.Width;
                int alto = bmp.Height;

                if ((extension == ".jpg" || extension == ".jpeg") && (ancho <= 1200 || alto <= 800))
                {
                    fuFotoPort.SaveAs(ruta + fuFotoPort.FileName);
                    fuFotoMini.SaveAs(ruta + fuFotoMini.FileName);
                    ent.fotoPortada = "content\\img\\" + fuFotoPort.FileName;
                    ent.fotoMini = "content\\img\\" + fuFotoMini.FileName;
                    ent.nombre = txtNomb.Text;
                    ent.productor = txtProd.Text;
                    ent.sinopsis = txtSino.Text;
                    ent.anio = Convert.ToInt32(ddlAnio.SelectedValue);
                    ent.clasificacionId = Convert.ToInt32(ddlCLas.SelectedValue);
                    ent.generoId = Convert.ToInt32(ddlGene.SelectedValue);
                    ent.estatus = chkEsta.Checked;
                    ent.video = txtVide.Text;
                    ent.fechaAlta = DateTime.Now;
                    new BusPelicula().Insertar(ent);
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Title = "No se pudo insertar la pelicula";
                }
            }
        }
        catch (Exception ex)
        {
            Title = ex.Message;
        }
    }
    protected void fuFotoPort_Load(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            Title = ex.Message;
        }


    }
    protected void txtVide_TextChanged(object sender, EventArgs e)
    {
        try
        {
            ifVideo.Src = txtVide.Text;
        }
        catch (Exception ex)
        {
            Title = ex.Message;
        }
    }
}