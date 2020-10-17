using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pags_CadastroEsportista : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }

    protected void BtnCadastrar_Click(object sender, EventArgs e)
    {
        Pef_Pessoa_Fisica pef = new Pef_Pessoa_Fisica();

        pef.Pef_cpf = Convert.ToInt64(txtCPF.Text);
        pef.Pef_nome = txtNome.Text;
        pef.Pef_email = txtEmail.Text;
        pef.Pef_senha = Pef_Pessoa_FisicaBD.PWD(txtSenha.Text);
        pef.Pef_data_nascimento = txtDataNascimento.Text;
        pef.Pef_genero = ddlGenero.SelectedValue;

        End_Endereco end = new End_Endereco();

        end.End_cep = Convert.ToInt32(cep.Text);
        pef.End_cep = end;

        switch (Pef_Pessoa_FisicaBD.Insert(pef))
        {
            case 0:
                Response.Redirect("LoginEsportista.aspx");
                break;
            case -2:
                break;
        }
    }
}