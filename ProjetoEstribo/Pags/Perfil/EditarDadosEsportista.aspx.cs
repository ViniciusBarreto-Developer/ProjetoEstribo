using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pags_Perfil_EditarDadosEsportista : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.Redirect("../Erro.aspx");
        }
        Pef_Pessoa_Fisica pef = (Pef_Pessoa_Fisica)Session["usuario"];

        if (!IsPostBack)
        {
            txtNome.Text = pef.Pef_nome;
            txtSenha.Text = "1234";
            txtEmail.Text = pef.Pef_email;
            txtCPF.Text = Convert.ToString(pef.Pef_cpf);
            txtDataNascimento.Text = pef.Pef_data_nascimento;
            ddlGenero.SelectedValue = pef.Pef_genero;

            End_Endereco end = new End_Endereco();
            cep.Text = Convert.ToString(pef.End_cep.End_cep);
        }

        

    }

    protected void BtnSalvar_Click(object sender, EventArgs e)
    {
        Pef_Pessoa_Fisica pef = (Pef_Pessoa_Fisica)Session["usuario"];

        pef.Pef_nome = txtNome.Text;
        pef.Pef_senha = Pef_Pessoa_FisicaBD.PWD(txtSenha.Text);
        pef.Pef_email = txtEmail.Text;
        pef.Pef_cpf = Convert.ToInt64(txtCPF.Text);
        pef.Pef_data_nascimento = txtDataNascimento.Text;
        pef.Pef_genero = ddlGenero.SelectedValue;

        End_Endereco end = new End_Endereco();
        end.End_cep = pef.End_cep.End_cep;
        pef.End_cep = end;

        switch (Pef_Pessoa_FisicaBD.Update(pef))
        {
            case 0:
                Page.Response.Redirect("EsportistaPerfil.aspx");
                break;
            case -2:
                Response.Redirect("QuemSomos.aspx");
                break;
        }
    }
}