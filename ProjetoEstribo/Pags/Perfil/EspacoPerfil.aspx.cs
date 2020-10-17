using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Pags_Perfil_EspacoPerfil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.Redirect("../Erro.aspx");
        }

        Pej_Pessoa_Juridica pej = (Pej_Pessoa_Juridica)Session["usuario"];

        //EVENTOS DO LOCAL
        try
        {
            DataSet ds = Eve_EventosBD.SelectEventosLocal(pej);
            int qtd = ds.Tables[0].Rows.Count;

            int eve_codigo = Convert.ToInt32(ds.Tables[0].Rows[0]["eve_codigo"]);
            if (qtd > 0 && eve_codigo != 0)
            {
                cardVazio.Visible = false;
                rptCard.DataSource = ds;
                rptCard.DataBind();
            }

        }
        catch (Exception ex)
        {

        }

        //HISTÓRICO DE EVENTOS 
        try
        {
            DataSet ds2 = Eve_EventosBD.SelectHistoricoEventos(pej);
            int qtd2 = ds2.Tables[0].Rows.Count;

            int eve_codigo2 = Convert.ToInt32(ds2.Tables[0].Rows[0]["eve_codigo"]);
            if (qtd2 > 0 && eve_codigo2 != 0)
            {
                historicoVazio.Visible = false;
                RptHistorico.DataSource = ds2;
                RptHistorico.DataBind();
            }

        }
        catch (Exception ex)
        {

        }

        if (!IsPostBack)
        {
            CarregarDDL();
            
        }

        DataSet dsEnd = Pej_Pessoa_JuridicaBD.GetEndereco(pej.End_cep.End_cep);
        string cidade = Convert.ToString(dsEnd.Tables[0].Rows[0]["end_cidade"]);
        string uf = Convert.ToString(dsEnd.Tables[0].Rows[0]["end_uf"]);

        ltlEnd.Text = "<h5>" + cidade + " - " + uf + "</h5>";
        ltlNome.Text = "<h3 class='nomePerfil'>" + pej.Pej_nome_ficticio + "</h3>";

        DataSet ds3 = Pej_Pessoa_JuridicaBD.Select(pej);
        int qtd3 = ds3.Tables[0].Rows.Count;

        if (qtd3 > 0)
        {
            RptImage.DataSource = ds3;
            RptImage.DataBind();
        }
        else
        {
        }

        //ESPORTES ADICIONADOS
        Ofe_Oferece ofe = new Ofe_Oferece();
        ofe.Pej_codigo = pej;
        DataSet ds4 = Ofe_OfereceBD.SelectOferecidos(ofe);
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
        DataSet ds5 = Pej_Pessoa_JuridicaBD.Select(pej);
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

    protected void BtnCriar_Click(object sender, EventArgs e)
    {
        Esp_Esportes esp = new Esp_Esportes();
        Eve_Eventos eve = new Eve_Eventos();

        esp.Esp_codigo = Convert.ToInt32(ddlEsporte.SelectedValue);
        eve.Esp_codigo = esp;

        eve.Eve_nome = txtNomeEvento.Text;
        eve.Eve_data = txtData.Text;
        eve.Eve_horario_inicio = txtInicio.Text;
        eve.Eve_horario_termino = txtFim.Text;
        eve.Eve_idade_minima = Convert.ToInt32(txtIdadeMin.Text);
        eve.Eve_idade_maxima = Convert.ToInt32(txtIdadeMax.Text);
        eve.Eve_genero_permitido = ddlGenero.SelectedValue;
        eve.Eve_numero_integrantes = Convert.ToInt32(txtNumParticipantes.Text);
        eve.Eve_preco = Convert.ToDouble(txtValor.Text);
        eve.Eve_entidade = txtEntidade.Text;
        eve.Eve_ativo = true;
        eve.Eve_descricao = txtDescricao.Text;
        eve.Eve_status = ddlAtivo.SelectedValue;

        Pej_Pessoa_Juridica pej = (Pej_Pessoa_Juridica)Session["usuario"];
        eve.Pej_codigo = pej;

        switch (Eve_EventosBD.Insert(eve))
        {
            case 0:
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
                break;
            case -2:
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

    protected void BtnSalvar_Click(object sender, EventArgs e)
    {
        Eve_Eventos eve = new Eve_Eventos();
        Esp_Esportes esp = new Esp_Esportes();

        esp.Esp_codigo = Convert.ToInt32(ddlEsporteEdit.SelectedValue);
        eve.Esp_codigo = esp;

        eve.Eve_codigo = Convert.ToInt32(ltlEveCodigo.Text);
        eve.Eve_nome = txtEventoEdit.Text;
        eve.Eve_data = txtDataEdit.Text;
        eve.Eve_horario_inicio = txtInicioEdit.Text;
        eve.Eve_horario_termino = txtTerminoEdit.Text;
        eve.Eve_preco = Convert.ToInt32(txtPrecoEdit.Text);
        eve.Eve_genero_permitido = ddlGeneroEdit.SelectedValue;
        eve.Eve_idade_minima = Convert.ToInt32(txtIdadeMinimaEdit.Text);
        eve.Eve_idade_maxima = Convert.ToInt32(txtIdadeMaximaEdit.Text);
        eve.Eve_numero_integrantes = Convert.ToInt32(txtNumeroIntegrantesEdit.Text);
        eve.Eve_entidade = txtEntidadeEdit.Text;
        eve.Eve_descricao = txtDescricaoEdit.Text;
        eve.Eve_status = ddlStatusEdit.SelectedValue;

        if(ddlStatusEdit.SelectedValue != "Evento Cancelado :(")
        {
            if(ddlStatusEdit.SelectedValue == "Concluido com sucesso!")
            {
                eve.Eve_ativo = false;

                switch (Eve_EventosBD.Update(eve))
                {
                    case 0:
                        Page.Response.Redirect(Page.Request.Url.ToString(), true);
                        break;
                    case -2:
                        break;
                }
            }
            else
            {
                eve.Eve_ativo = true;

                switch (Eve_EventosBD.Update(eve))
                {
                    case 0:
                        Page.Response.Redirect(Page.Request.Url.ToString(), true);
                        break;
                    case -2:
                        break;
                }
            }            
        }
        else
        {
            switch (Eve_EventosBD.Delete(eve))
            {
                case 0:
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    break;
                case -2:
                    break;
            }
        }        
        
    }

    protected void BtnExcluir_Click(object sender, EventArgs e)
    {
        Eve_Eventos eve = new Eve_Eventos();

        eve.Eve_codigo = Convert.ToInt32(ltlEveCodigo.Text);
        switch (Eve_EventosBD.Delete(eve))
        {
            case 0:
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
                break;
            case -2:
                break;
        }
    }

    protected void rptCard_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "VerMais")
        {
            Button btn = (Button)e.Item.FindControl("BtnVerMais");
            Eve_Eventos eve = new Eve_Eventos();
            eve.Eve_codigo = Convert.ToInt32(btn.CommandArgument);
            DataSet ds = Eve_EventosBD.Select(eve);
            DataSet ds2 = Eve_EventosBD.SelectEsporte(Convert.ToInt32(btn.CommandArgument));

            ltlNomeEvento.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_nome"]);
            ltlEsporte.Text = Convert.ToString(ds2.Tables[0].Rows[0]["esp_nome"]);
            ltlData.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_data"]);
            ltlInicio.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_horario_inicio"]);
            ltlTermino.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_horario_termino"]);
            ltlPreco.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_preco"]);
            ltlGenero.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_genero_permitido"]);
            ltlMinima.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_idade_minima"]);
            ltlMaxima.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_idade_maxima"]);
            ltlNumeroIntegrantes.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_numero_integrantes"]);
            ltlEntidade.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_entidade"]);
            ltlDescricao.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_descricao"]);
            ltlStatus.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_status"]);
            ltlEveCodigo.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_codigo"]);

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "verMais", "$('#verMais').modal('show')", true);
            lblScript.Text = @"<script> $(document).ready(function(){$('#verEvento').modal('show')})</script>";
        }
    }

    protected void BtnEditar_Click(object sender, EventArgs e)
    {
        DataSet ds = Eve_EventosBD.SelectEsporte(Convert.ToInt32(ltlEveCodigo.Text));
        
        txtEventoEdit.Text = ltlNomeEvento.Text;
        ddlEsporteEdit.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["esp_codigo"]);
        txtDataEdit.Text = ltlData.Text;
        txtInicioEdit.Text = ltlInicio.Text;
        txtTerminoEdit.Text = ltlTermino.Text;
        txtPrecoEdit.Text = ltlPreco.Text;
        ddlGeneroEdit.SelectedValue = ltlGenero.Text;
        txtIdadeMinimaEdit.Text = ltlMinima.Text;
        txtIdadeMaximaEdit.Text = ltlMaxima.Text;
        txtNumeroIntegrantesEdit.Text = ltlNumeroIntegrantes.Text;
        txtEntidadeEdit.Text = ltlEntidade.Text;
        txtDescricaoEdit.Text = ltlDescricao.Text;
        ddlStatusEdit.Text = ltlStatus.Text;

        CarregarDDLEdit();

        //ScriptManager.RegisterStartupScript(this, this.GetType(), "verMais", "$('#verMais').modal('show')", true);
        lblScript.Text = @"<script> $(document).ready(function(){$('#editarEvento').modal('show')})</script>";
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

    protected void RptHistorico_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "VerMais")
        {
            Button btn = (Button)e.Item.FindControl("BtnHistoricoVM");
            Eve_Eventos eve = new Eve_Eventos();
            eve.Eve_codigo = Convert.ToInt32(btn.CommandArgument);
            DataSet ds = Eve_EventosBD.Select(eve);
            DataSet ds2 = Eve_EventosBD.SelectEsporte(Convert.ToInt32(btn.CommandArgument));

            ltlNomeEvento.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_nome"]);
            ltlEsporte.Text = Convert.ToString(ds2.Tables[0].Rows[0]["esp_nome"]);
            ltlData.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_data"]);
            ltlInicio.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_horario_inicio"]);
            ltlTermino.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_horario_termino"]);
            ltlPreco.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_preco"]);
            ltlGenero.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_genero_permitido"]);
            ltlMinima.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_idade_minima"]);
            ltlMaxima.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_idade_maxima"]);
            ltlNumeroIntegrantes.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_numero_integrantes"]);
            ltlEntidade.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_entidade"]);
            ltlDescricao.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_descricao"]);
            ltlStatus.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_status"]);
            ltlEveCodigo.Text = Convert.ToString(ds.Tables[0].Rows[0]["eve_codigo"]);

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "verMais", "$('#verMais').modal('show')", true);
            lblScript.Text = @"<script> $(document).ready(function(){$('#verEvento').modal('show')})</script>";
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

                            Pej_Pessoa_Juridica pej = (Pej_Pessoa_Juridica)Session["usuario"];

                            pej.Pej_foto_perfil = foto;
                            switch (Pej_Pessoa_JuridicaBD.UpdateFoto(pej))
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