using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pags_LoginEsportista : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        DataSet ds = Pef_Pessoa_FisicaBD.SelectLogin(LoginID.Text, Pef_Pessoa_FisicaBD.PWD(SenhaID.Text));
        int qtd = ds.Tables[0].Rows.Count;
        if (qtd == 1)
        {
            Pef_Pessoa_Fisica pef = new Pef_Pessoa_Fisica();
            pef.Pef_codigo = Convert.ToInt32(ds.Tables[0].Rows[0]["pef_codigo"].ToString());
            pef.Pef_cpf = Convert.ToInt64(ds.Tables[0].Rows[0]["pef_cpf"].ToString());
            pef.Pef_nome = ds.Tables[0].Rows[0]["pef_nome"].ToString();
            pef.Pef_email = ds.Tables[0].Rows[0]["pef_email"].ToString();
            pef.Pef_genero = ds.Tables[0].Rows[0]["pef_genero"].ToString();
            pef.Pef_data_nascimento = ds.Tables[0].Rows[0]["pef_data_nascimento"].ToString();
            End_Endereco end = new End_Endereco();
            end.End_cep = Convert.ToInt32(ds.Tables[0].Rows[0]["end_cep"].ToString());
            pef.End_cep = end;

            Session["usuario"] = pef;

            Response.Redirect("Perfil/EsportistaPerfil.aspx");
        }
        else
        {
            Response.Redirect("Principal.aspx");
        }
    }
}