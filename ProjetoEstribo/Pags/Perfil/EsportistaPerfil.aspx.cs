using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class pg_Perfil_EsportistaPerfil : System.Web.UI.Page
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
            CarregarDDL();

            //PESQUISA DEFAULT 
            DataSet dsCidade = Pef_Pessoa_FisicaBD.GetCidade(pef);
            string cidade = Convert.ToString(dsCidade.Tables[0].Rows[0]["end_cidade"]);
            DataSet ds2 = Par_PartidasBD.PesquisaDefault(cidade, pef);
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

            //PARTIDAS PARTICIPANDO
            DataSet ds = Par_PartidasBD.Select(pef.Pef_codigo);
            int qtd = ds.Tables[0].Rows.Count;
            try
            {
                int par_codigo = Convert.ToInt32(ds.Tables[0].Rows[0]["par_codigo"]);
                if (qtd > 0 && par_codigo != 0)
                {
                    cardVazio.Visible = false;
                    rptCard.DataSource = ds;
                    rptCard.DataBind();
                }

            }
            catch (Exception ex)
            {

            }

        }
        // NOME -- DATA -- GENERO
        ltlNome.Text = "<h3 class='nomePerfil'>" + pef.Pef_nome + "</h3>";
        ltlIdade.Text = "<h5>" + getIdade(pef.Pef_data_nascimento) + "</h45>";
        ltlGenero.Text = "<h5>" + pef.Pef_genero + "<h5>";

        

        //FOTO DE PERFIL
        DataSet ds3 = Pef_Pessoa_FisicaBD.Select(pef);
        int qtd3 = ds3.Tables[0].Rows.Count;

        if (qtd3 > 0)
        {
            RptImage.DataSource = ds3;
            RptImage.DataBind();
        }
        else
        {
        }

        //ESPORTES PRATICADOS
        Pra_Pratica pra = new Pra_Pratica();
        pra.Pef_codigo = pef;
        DataSet ds4 = Pra_PraticaBD.SelectPraticados(pra);
        int qtd4 = ds4.Tables[0].Rows.Count;

        if (qtd4 > 0)
        {
            espVazio.Visible = false;
            RptEsporte.DataSource = ds4;
            RptEsporte.DataBind();
        }
        else
        {
            espVazio.Visible = true;
        }

        //MODAL DE ATUALIZAÇÃO DA FOTO DE PERFIL
        DataSet ds5 = Pef_Pessoa_FisicaBD.Select(pef);
        int qtd5 = ds5.Tables[0].Rows.Count;

        if (qtd5 > 0)
        {
            RptImageEdit.DataSource = ds5;
            RptImageEdit.DataBind();
        }
        else
        {
        }

    }
    protected int getIdade(string data)
    {
        string anoStr = "";
        string mesStr = "";
        string diaStr = "";
        char[] charData = data.ToCharArray();

        for (int i = 0; i < 4; i++)
        {
            anoStr += charData[i];
        }
        for (int i = 5; i < 7; i++)
        {
            mesStr += charData[i];
        }
        for (int i = 8; i < 10; i++)
        {
            diaStr += charData[i];
        }

        int ano = Convert.ToInt32(anoStr);
        int mes = Convert.ToInt32(mesStr);
        int dia = Convert.ToInt32(diaStr);

        DateTime agora = DateTime.Today;
        string anoAgr = "";
        string mesAgr = "";
        string diaAgr = "";

        char[] charDataAgora = agora.ToString("").ToCharArray();

        for (int i = 6; i < 10; i++)
        {
            anoAgr += charDataAgora[i];
        }
        for (int i = 3; i < 5; i++)
        {
            mesAgr += charDataAgora[i];
        }
        for (int i = 0; i < 2; i++)
        {
            diaAgr += charDataAgora[i];
        }

        int anoAgrInt = Convert.ToInt32(anoAgr);
        int mesAgrInt = Convert.ToInt32(mesAgr);
        int diaAgrInt = Convert.ToInt32(diaAgr);

        if (diaAgrInt > dia)
        {
            if (mesAgrInt >= mes)
            {
                return anoAgrInt - ano;
            }
        }

        return (anoAgrInt - ano - 1);
    }

    protected void BtnCriar_Click(object sender, EventArgs e)
    {
        Esp_Esportes esp = new Esp_Esportes();
        Par_Partida par = new Par_Partida();

        esp.Esp_codigo = Convert.ToInt32(ddlEsporte.SelectedValue);
        par.Esp_codigo = esp;
        par.Par_nome = txtNomePartida.Text;
        par.Par_nome_local = txtLocal.Text;
        par.Par_data = txtData.Text;

        par.Par_tipo_espaco = ddlTipoLocal.SelectedValue;
        par.Par_preco = Convert.ToDouble(txtValor.Text);
        par.Par_horario_inicio = txtInicio.Text;
        par.Par_horario_termino = txtFim.Text;
        par.Par_genero_permitido = ddlGenero.SelectedValue;
        par.Par_numero_integrantes = Convert.ToInt32(txtNumeroParticipantes.Text);
        par.Par_idade_minima = Convert.ToInt32(txtIdadeMinima.Text);
        par.Par_idade_maxima = Convert.ToInt32(txtIdadeMaxima.Text);
        par.Par_ativo = true;

        End_Endereco end = new End_Endereco();
        end.End_cep = Convert.ToInt32(cep.Text);
        par.End_cep = end;

        Pef_Pessoa_Fisica pef = (Pef_Pessoa_Fisica)Session["usuario"];
        par.Pef_codigo_adm = pef;

        //Gpe_Grupo_Pessoas gpe = new Gpe_Grupo_Pessoas();
        //gpe.Pef_codigo = pef;

        switch (Par_PartidasBD.Insert(par))
        {
            case 0:                
                DataSet dsParCodigo = Par_PartidasBD.SelectUltimaPartidaCriada(pef);
                Gpe_Grupo_PessoasBD.Insert(Convert.ToInt32(dsParCodigo.Tables[0].Rows[0]["par_codigo"]), pef.Pef_codigo);
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
                break;
            case -2:
                Response.Redirect("QuemSomos.aspx");
                break;
        }

    }

    private void CarregarDDL()
    {
        DataSet ds = Esp_EsporteBD.SelectAll();
        ddlEsporte.DataSource = ds;
        ddlEsporte.DataTextField = "esp_nome";
        ddlEsporte.DataValueField = "esp_codigo";
        ddlEsporte.DataBind();
        ddlEsporte.Items.Insert(0, "Selecione um item");

    }
    private void CarregarDDLEdit()
    {
        DataSet ds = Esp_EsporteBD.SelectAll();
        ddlEsporteEdit.DataSource = ds;
        ddlEsporteEdit.DataTextField = "esp_nome";
        ddlEsporteEdit.DataValueField = "esp_codigo";
        ddlEsporteEdit.DataBind();
        ddlEsporteEdit.Items.Insert(0, "Selecione um item");
    }

    protected void rptCard2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "VerMais")
        {
            Button btn = (Button)e.Item.FindControl("BtnVerMais");
            DataSet ds = Par_PartidasBD.SelectVerMais(Convert.ToInt32(btn.CommandArgument));

            ltlParCodigo.Text = Convert.ToString(ds.Tables[0].Rows[0]["par_codigo"]);
            ltlEsportePP.Text = Convert.ToString(ds.Tables[0].Rows[0]["esp_nome"]);
            ltlNomePartidaPP.Text = Convert.ToString(ds.Tables[0].Rows[0]["par_nome"]);
            ltlLocalPP.Text = Convert.ToString(ds.Tables[0].Rows[0]["par_nome_local"]);
            ltlDataPP.Text = Convert.ToString(ds.Tables[0].Rows[0]["par_data"]);
            ltlInicioPP.Text = Convert.ToString(ds.Tables[0].Rows[0]["par_horario_inicio"]);
            ltlFimPP.Text = Convert.ToString(ds.Tables[0].Rows[0]["par_horario_termino"]);
            ltlIdadeMinimaPP.Text = Convert.ToString(ds.Tables[0].Rows[0]["par_idade_minima"]);
            ltlIdadeMaximaPP.Text = Convert.ToString(ds.Tables[0].Rows[0]["par_idade_maxima"]);
            ltlGeneroPP.Text = Convert.ToString(ds.Tables[0].Rows[0]["par_genero_permitido"]);
            string numIntegrantes = Convert.ToString(ds.Tables[0].Rows[0]["par_numero_integrantes"]);
            ltlPrecoPP.Text = Convert.ToString(ds.Tables[0].Rows[0]["par_preco"]);
            ltlTipoEspacoPP.Text = Convert.ToString(ds.Tables[0].Rows[0]["par_tipo_espaco"]);
            ltlCepPP.Text = Convert.ToString(ds.Tables[0].Rows[0]["end_cep"]);
            ltlUfPP.Text = Convert.ToString(ds.Tables[0].Rows[0]["end_uf"]);
            ltlCidadePP.Text = Convert.ToString(ds.Tables[0].Rows[0]["end_cidade"]);
            ltlBairroPP.Text = Convert.ToString(ds.Tables[0].Rows[0]["end_bairro"]);
            ltlRuaPP.Text = Convert.ToString(ds.Tables[0].Rows[0]["end_rua"]);            

            DataSet ds2 = Gpe_Grupo_PessoasBD.Select(ltlParCodigo.Text);
            int qtd = ds2.Tables[0].Rows.Count;

            if (qtd > 0)
            {
                RptIntegrantes2.DataSource = ds2;
                RptIntegrantes2.DataBind();
            }
            else
            {
            }

            ltlNumParticipantesAtual.Text = "<i class='fas fa-user - friends'></i> " + Convert.ToString(qtd) + " / " + numIntegrantes;

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "verMais", "$('#verMais').modal('show')", true);
            lblScript.Text = @"<script> $(document).ready(function(){$('#verMais').modal('show')})</script>";

        }
    }



    protected void BtnEntrar_Click(object sender, EventArgs e)
    {
        Pef_Pessoa_Fisica pef = (Pef_Pessoa_Fisica)Session["usuario"];

        switch (Gpe_Grupo_PessoasBD.Insert(Convert.ToInt32(ltlParCodigo.Text), pef.Pef_codigo))
        {
            case 0:
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
                break;
            case -2:
                Response.Redirect("QuemSomos.aspx");
                break;
        }
    }

    protected void rptCard_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "VerMais1")
        {
            Button btn = (Button)e.Item.FindControl("BtnVerMais1");
            DataSet ds = Par_PartidasBD.SelectVerMais(Convert.ToInt32(btn.CommandArgument));
            Pef_Pessoa_Fisica pef = (Pef_Pessoa_Fisica)Session["usuario"];

            ltlParCodigo1.Text = Convert.ToString(ds.Tables[0].Rows[0]["par_codigo"]);            
            ltlEsporte1.Text = Convert.ToString(ds.Tables[0].Rows[0]["esp_nome"]);
            ltlNomePartida1.Text = Convert.ToString(ds.Tables[0].Rows[0]["par_nome"]);
            ltlLocal1.Text = Convert.ToString(ds.Tables[0].Rows[0]["par_nome_local"]);
            ltlData1.Text = Convert.ToString(ds.Tables[0].Rows[0]["par_data"]);
            ltlInicio1.Text = Convert.ToString(ds.Tables[0].Rows[0]["par_horario_inicio"]);
            ltlTermino1.Text = Convert.ToString(ds.Tables[0].Rows[0]["par_horario_termino"]);
            ltlIdadeMinima1.Text = Convert.ToString(ds.Tables[0].Rows[0]["par_idade_minima"]);
            ltlIdadeMaxima1.Text = Convert.ToString(ds.Tables[0].Rows[0]["par_idade_maxima"]);
            ltlGenero1.Text = Convert.ToString(ds.Tables[0].Rows[0]["par_genero_permitido"]);
            string numIntegrantes = Convert.ToString(ds.Tables[0].Rows[0]["par_numero_integrantes"]);
            ltlNumeroIntegrantes1.Text = Convert.ToString(ds.Tables[0].Rows[0]["par_numero_integrantes"]);
            ltlPreco1.Text = Convert.ToString(ds.Tables[0].Rows[0]["par_preco"]);
            ltlTipoEspaco1.Text = Convert.ToString(ds.Tables[0].Rows[0]["par_tipo_espaco"]);
            ltlCep1.Text = Convert.ToString(ds.Tables[0].Rows[0]["end_cep"]);
            ltlUf1.Text = Convert.ToString(ds.Tables[0].Rows[0]["end_uf"]);
            ltlCidade1.Text = Convert.ToString(ds.Tables[0].Rows[0]["end_cidade"]);
            ltlBairro1.Text = Convert.ToString(ds.Tables[0].Rows[0]["end_bairro"]);
            ltlRua1.Text = Convert.ToString(ds.Tables[0].Rows[0]["end_rua"]);

            if(Convert.ToInt32(ds.Tables[0].Rows[0]["pef_codigo_adm"]) == pef.Pef_codigo)
            {
                BtnEditar.Visible = true;
            }
            else
            {
                BtnEditar.Visible = false;
            }

            DataSet ds2 = Gpe_Grupo_PessoasBD.Select(ltlParCodigo1.Text);
            int qtd = ds2.Tables[0].Rows.Count;

            if (qtd > 0)
            {
                RptIntegrantes.DataSource = ds2;
                RptIntegrantes.DataBind();
            }
            else
            {
            }

            ltlNumParticipantesAtual2.Text = "<i class='fas fa-user - friends'></i> " + Convert.ToString(qtd) + " / " + numIntegrantes;

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "verMais", "$('#verMais1').modal('show')", true);
            lblScript.Text = @"<script> $(document).ready(function(){$('#verMais1').modal('show')})</script>";
        }
    }

    protected void BtnSair_Click(object sender, EventArgs e)
    {
        Pef_Pessoa_Fisica pef = (Pef_Pessoa_Fisica)Session["usuario"];

        switch (Gpe_Grupo_PessoasBD.Delete(Convert.ToInt32(ltlParCodigo1.Text), pef.Pef_codigo))
        {
            case 0:
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
                break;
            case -2:
                Response.Redirect("QuemSomos.aspx");
                break;
        }
    }

    protected void BtnEditar_Click(object sender, EventArgs e)
    {
        DataSet ds = Par_PartidasBD.SelectEspCodigo(Convert.ToInt32(ltlParCodigo1.Text));

        ddlEsporteEdit.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["esp_codigo"]);

        txtNomePartidaEdit.Text = ltlNomePartida1.Text;
        txtLocalEdit.Text = ltlLocal1.Text;
        txtDataEdit.Text = ltlData1.Text;
        txtInicioEdit.Text = ltlInicio1.Text;
        txtFimEdit.Text = ltlTermino1.Text;
        txtIdadeMinimaEdit.Text = ltlIdadeMinima1.Text;
        txtIdadeMaximaEdit.Text = ltlIdadeMaxima1.Text;
        ddlGeneroEdit.Text = ltlGenero1.Text;
        txtNumeroParticipantesEdit.Text = ltlNumeroIntegrantes1.Text;
        txtPrecoEdit.Text = ltlPreco1.Text;
        ddlTipoEspacoEdit.Text = ltlTipoEspaco1.Text;
        cepEdit.Text = ltlCep1.Text;
        ufEdit.Text = ltlUf1.Text;
        cidadeEdit.Text = ltlCidade1.Text;
        bairroEdit.Text = ltlBairro1.Text;
        ruaEdit.Text = ltlRua1.Text;

        CarregarDDLEdit();

        //ScriptManager.RegisterStartupScript(this, this.GetType(), "verMais", "$('#verMais').modal('show')", true);
        lblScript.Text = @"<script> $(document).ready(function(){$('#editarPartida').modal('show')})</script>";
    }

    protected void BtnCancelar_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }

    protected void BtnSalvar_Click(object sender, EventArgs e)
    {
        Par_Partida par = new Par_Partida();
        Esp_Esportes esp = new Esp_Esportes();
        End_Endereco end = new End_Endereco();

        esp.Esp_codigo = Convert.ToInt32(ddlEsporteEdit.SelectedValue);
        par.Esp_codigo = esp;

        par.Par_codigo = Convert.ToInt32(ltlParCodigo1.Text);
        par.Par_nome = txtNomePartidaEdit.Text;
        par.Par_nome_local = txtLocalEdit.Text;
        par.Par_data = txtDataEdit.Text;
        par.Par_horario_inicio = txtInicioEdit.Text;
        par.Par_horario_termino = txtFimEdit.Text;
        par.Par_idade_minima = Convert.ToInt32(txtIdadeMinimaEdit.Text);
        par.Par_idade_maxima = Convert.ToInt32(txtIdadeMaximaEdit.Text);
        par.Par_genero_permitido = ddlGeneroEdit.SelectedValue;
        par.Par_numero_integrantes = Convert.ToInt32(txtNumeroParticipantesEdit.Text);
        par.Par_preco = Convert.ToDouble(txtPrecoEdit.Text);
        par.Par_tipo_espaco = ddlTipoEspacoEdit.SelectedValue;

        end.End_cep = Convert.ToInt32(ltlCep1.Text);
        par.End_cep = end;

        switch (Par_PartidasBD.Update(par))
        {
            case 0:
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
                break;
            case -2:
                Response.Redirect("QuemSomos.aspx");
                break;
        }
    }

    protected void BtnPesquisar_Click(object sender, EventArgs e)
    {
        Pef_Pessoa_Fisica pef = (Pef_Pessoa_Fisica)Session["usuario"];
        DataSet ds2 = Par_PartidasBD.PesquisaPartida(txtEsporte.Text, txtCidade.Text, pef);
        int qtd = ds2.Tables[0].Rows.Count;


        if (qtd > 0)
        {
            rptCard2.DataSource = ds2;
            rptCard2.DataBind();
            txtCidade.Text = "";
            txtEsporte.Text = "";
            PesquisaVazia.Visible = false;
            PesquisaCheia.Visible = true;
        }
        else
        {
            PesquisaCheia.Visible = false;
            PesquisaVazia.Visible = true;
            txtCidade.Text = "";
            txtEsporte.Text = "";
        }
    }
    public Int64 GerarID()
    {
        try
        {
            DateTime data = new DateTime();
            data = DateTime.Now;
            string s = data.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
            return Convert.ToInt64(s);
        }
        catch (Exception erro)
        {

            throw;
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string foto = "";
        if (FileUploadControl.PostedFile.ContentLength < 8388608)
        {
            try
            {
                if (FileUploadControl.HasFile)
                {
                    try
                    {
                        //Aqui ele vai filtrar pelo tipo de arquivo
                        if (FileUploadControl.PostedFile.ContentType == "image/jpeg" ||
                            FileUploadControl.PostedFile.ContentType == "image/png" ||
                            FileUploadControl.PostedFile.ContentType == "image/gif" ||
                            FileUploadControl.PostedFile.ContentType == "image/bmp")
                        {
                            try
                            {

                                //Obtem o  HttpFileCollection
                                HttpFileCollection hfc = Request.Files;
                                for (int i = 0; i < hfc.Count; i++)
                                {
                                    HttpPostedFile hpf = hfc[i];
                                    if (hpf.ContentLength > 0)
                                    {
                                        //Pega o nome do arquivo
                                        string nome = System.IO.Path.GetFileName(hpf.FileName);
                                        //Pega a extensão do arquivo
                                        string extensao = Path.GetExtension(hpf.FileName);
                                        //Gera nome novo do Arquivo numericamente
                                        string filename = string.Format("{0:00000000000000}", GerarID());
                                        //Caminho a onde será salvo
                                        hpf.SaveAs(Server.MapPath("~/uploads/fotos/") + filename + i
                                        + extensao);

                                        //Prefixo p/ img pequena
                                        var prefixoP = "-p";
                                        //Prefixo p/ img grande
                                        var prefixoG = "-g";

                                        //pega o arquivo já carregado
                                        string pth = Server.MapPath("~/uploads/fotos/")
                                        + filename + i + extensao;
                                        foto = filename + "0" + extensao;

                                        //Redefine altura e largura da imagem e Salva o arquivo + prefixo
                                        Redefinir.resizeImageAndSave(pth, 70, 53, prefixoP);
                                        Redefinir.resizeImageAndSave(pth, 500, 331, prefixoG);
                                    }

                                }
                            }
                            catch (Exception ex)
                            {

                            }
                            // Mensagem se tudo ocorreu bem
                            StatusLabel.Text = "Todas imagens carregadas com sucesso!";

                            Pef_Pessoa_Fisica pef = (Pef_Pessoa_Fisica)Session["usuario"];

                            pef.Pef_foto_perfil = foto;
                            switch (Pef_Pessoa_FisicaBD.UpdateFoto(pef))
                            {
                                case 0:
                                    break;
                                case -2:
                                    break;
                            }
                            Page.Response.Redirect(Page.Request.Url.ToString(), true);

                        }
                        else
                        {
                            // Mensagem notifica que é permitido carregar apenas 
                            // as imagens definida la em cima.
                            StatusLabel.Text = "É permitido carregar apenas imagens!";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Mensagem notifica quando ocorre erros
                        StatusLabel.Text = "O arquivo não pôde ser carregado.  O seguinte erro ocorreu: " + ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                // Mensagem notifica quando ocorre erros
                StatusLabel.Text = "O arquivo não pôde ser carregado.  O seguinte erro ocorreu: " + ex.Message;
            }
        }
        else
        {
            // Mensagem notifica quando imagem é superior a 8 MB
            StatusLabel.Text = "Não é permitido carregar mais do que 8 MB";
        }
    }
}