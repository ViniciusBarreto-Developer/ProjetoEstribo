using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pags_Perfil_EditarDadosEspacoEsportivo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.Redirect("../Erro.aspx");
        }
        Pej_Pessoa_Juridica pej = (Pej_Pessoa_Juridica)Session["usuario"];

        if (!IsPostBack)
        {
            txtNomeEmpresa.Text = pej.Pej_razao_social;
            txtNomeFantasia.Text = pej.Pej_nome_ficticio;
            txtCNPJ.Text = Convert.ToString(pej.Pej_cnpj);
            txtEmail.Text = pej.Pej_email;
            txtSenha.Text = "1234";

            End_Endereco end = new End_Endereco();
            cep.Text = Convert.ToString(pej.End_cep.End_cep);
        }
    }

    protected void BtnSalvar_Click(object sender, EventArgs e)
    {
        Pej_Pessoa_Juridica pej = (Pej_Pessoa_Juridica)Session["usuario"];

        pej.Pej_razao_social = txtNomeEmpresa.Text;
        pej.Pej_nome_ficticio = txtNomeFantasia.Text;
        pej.Pej_cnpj = Convert.ToInt64(txtCNPJ.Text);
        pej.Pej_email = txtEmail.Text;
        pej.Pej_senha = Pef_Pessoa_FisicaBD.PWD(txtSenha.Text);

        End_Endereco end = new End_Endereco();
        end.End_cep = pej.End_cep.End_cep;
        pej.End_cep = end;

        switch (Pej_Pessoa_JuridicaBD.Update(pej))
        {
            case 0:
                Page.Response.Redirect("EspacoPerfil.aspx");
                break;
            case -2:
                Response.Redirect("QuemSomos.aspx");
                break;
        }
    }
}