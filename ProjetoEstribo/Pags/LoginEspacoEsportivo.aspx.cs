using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pags_LoginEspacoEsportivo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        DataSet ds = Pej_Pessoa_JuridicaBD.SelectLogin(LoginID.Text, Pej_Pessoa_JuridicaBD.PWD(SenhaID.Text));
        int qtd = ds.Tables[0].Rows.Count;
        if (qtd == 1)
        {
            Pej_Pessoa_Juridica pej = new Pej_Pessoa_Juridica();
            pej.Pej_codigo = Convert.ToInt32(ds.Tables[0].Rows[0]["pej_codigo"].ToString());
            pej.Pej_cnpj = Convert.ToInt64(ds.Tables[0].Rows[0]["pej_cnpj"].ToString());
            pej.Pej_nome_ficticio = ds.Tables[0].Rows[0]["pej_nome_ficticio"].ToString();
            pej.Pej_razao_social = ds.Tables[0].Rows[0]["pej_razao_social"].ToString();
            pej.Pej_email = ds.Tables[0].Rows[0]["pej_email"].ToString();
            pej.Pej_horario_funcionamento = ds.Tables[0].Rows[0]["pej_horario_funcionamento"].ToString();
            
            End_Endereco end = new End_Endereco();
            end.End_cep = Convert.ToInt32(ds.Tables[0].Rows[0]["end_cep"].ToString());
            pej.End_cep = end;

            Session["usuario"] = pej;

            Response.Redirect("Perfil/EspacoPerfil.aspx");

        }
        else
        {
            Response.Redirect("Principal.aspx");
        }
    }
}