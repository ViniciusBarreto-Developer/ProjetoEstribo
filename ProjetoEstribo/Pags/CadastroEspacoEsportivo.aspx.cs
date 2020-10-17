using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pags_CadastroEspacoEsportivo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#myModal').modal('show');</script>", false);

    }

    protected void BtnCadastrar_Click(object sender, EventArgs e)
    {
        Pej_Pessoa_Juridica pej = new Pej_Pessoa_Juridica();

        pej.Pej_razao_social = txtNomeEmpresa.Text;
        pej.Pej_nome_ficticio = txtNomeFantasia.Text;
        pej.Pej_cnpj = Convert.ToInt64(txtCNPJ.Text);
        pej.Pej_email = txtEmail.Text;
        pej.Pej_senha = Pej_Pessoa_JuridicaBD.PWD(txtSenha.Text);

        End_Endereco end = new End_Endereco();

        end.End_cep = Convert.ToInt32(cep.Text);
        pej.End_cep = end;

        switch (Pej_Pessoa_JuridicaBD.Insert(pej))
        {
            case 0:
                Response.Redirect("LoginEspacoEsportivo.aspx");
                break;
            case -2:
                ltl.Text = "<p class='text-danger'> Não foi possível efeturar o cadastro!!!</p>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#myModal').modal('show');</script>", false);
                break;
        }
    }
}