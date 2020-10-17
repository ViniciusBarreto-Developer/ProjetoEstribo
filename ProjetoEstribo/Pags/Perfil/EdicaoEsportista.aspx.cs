using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Pags_Perfil_EdicaoEsportista : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.Redirect("../Erro.aspx");
        }

        Pef_Pessoa_Fisica pef = (Pef_Pessoa_Fisica)Session["usuario"];
        Pra_Pratica pra = new Pra_Pratica();

        if (!IsPostBack)
        {


            pra.Pef_codigo = pef;

            DataSet ds = Pra_PraticaBD.SelectNaoPraticados(pra);
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

            DataSet ds2 = Pra_PraticaBD.SelectPraticados(pra);
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

        Pef_Pessoa_Fisica pef = (Pef_Pessoa_Fisica)Session["usuario"];
        Esp_Esportes esp = new Esp_Esportes();
        Pra_Pratica pra = new Pra_Pratica();

        pra.Pef_codigo = pef;
        esp.Esp_codigo = Convert.ToInt32(btn.CommandArgument.ToString());
        pra.Esp_codigo = esp;

        switch (Pra_PraticaBD.Delete(pra))
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

        Pef_Pessoa_Fisica pef = (Pef_Pessoa_Fisica)Session["usuario"];
        Esp_Esportes esp = new Esp_Esportes();
        Pra_Pratica pra = new Pra_Pratica();

        pra.Pef_codigo = pef;
        esp.Esp_codigo = Convert.ToInt32(btn.CommandArgument.ToString());
        pra.Esp_codigo = esp;

        switch (Pra_PraticaBD.Insert(pra))
        {
            case 0:
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
                break;
            case -2:
                break;
        }
    }
}