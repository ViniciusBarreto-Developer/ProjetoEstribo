using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Pags_Perfil_EdicaoEspacoEsportivo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.Redirect("../Erro.aspx");
        }

        Pej_Pessoa_Juridica pej = (Pej_Pessoa_Juridica)Session["usuario"];
        Ofe_Oferece ofe = new Ofe_Oferece();

        if (!IsPostBack)
        {
            ofe.Pej_codigo = pej;

            DataSet ds = Ofe_OfereceBD.SelectNaoOferecidos(ofe);
            int qtd = ds.Tables[0].Rows.Count;

            if (qtd > 0)
            {
                cardVazio.Visible = false;
                rptCard.DataSource = ds;
                rptCard.DataBind();
            }
            else
            {
                cardVazio.Visible = true;
                cardCheio.Visible = false;
            }

            DataSet ds2 = Ofe_OfereceBD.SelectOferecidos(ofe);
            int qtd2 = ds2.Tables[0].Rows.Count;

            if (qtd2 > 0)
            {
                PesquisaVazia.Visible = false;
                rptCard2.DataSource = ds2;
                rptCard2.DataBind();
            }
            else
            {
                PesquisaVazia.Visible = true;
                PesquisaCheia.Visible = false;
            }

        }
    }

    protected void BtnRemover_Click(object sender, EventArgs e)
    {
        Button btn = (sender as Button);

        Pej_Pessoa_Juridica pej = (Pej_Pessoa_Juridica)Session["usuario"];
        Esp_Esportes esp = new Esp_Esportes();
        Ofe_Oferece ofe = new Ofe_Oferece();

        ofe.Pej_codigo = pej;
        esp.Esp_codigo = Convert.ToInt32(btn.CommandArgument.ToString());
        ofe.Esp_codigo = esp;

        switch (Ofe_OfereceBD.Delete(ofe))
        {
            case 0:
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
                break;
            case -2:
                break;
        }

    }


    protected void BtnAdicionar_Click(object sender, EventArgs e)
    {
        Button btn = (sender as Button);

        Pej_Pessoa_Juridica pej = (Pej_Pessoa_Juridica)Session["usuario"];
        Esp_Esportes esp = new Esp_Esportes();
        Ofe_Oferece ofe = new Ofe_Oferece();

        ofe.Pej_codigo = pej;
        esp.Esp_codigo = Convert.ToInt32(btn.CommandArgument.ToString());
        ofe.Esp_codigo = esp;

        switch (Ofe_OfereceBD.Insert(ofe))
        {
            case 0:
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
                break;
            case -2:
                break;
        }
    }
}