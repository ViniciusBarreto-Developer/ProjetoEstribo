<%@ Page Title="" Language="C#" MasterPageFile="~/Pags/Perfil/MasterEspaco.master" AutoEventWireup="true" CodeFile="EspacoPerfil.aspx.cs" Inherits="Pags_Perfil_EspacoPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../css/PerfilEspaco.css" rel="stylesheet" />
    <link href="../../css/gallery.min.css" rel="stylesheet" />
    <link href="../../css/gallery.theme.css" rel="stylesheet" />

    <main class="container">
        <div class="row" style="background-image: url('../../img/Barra de fundo_ESTRIBO2.jpg'); background-repeat: no-repeat;">
            <div class="col-4">
                <div>
                    <table class="text-center">
                        <tr>
                            <td>
                                <asp:Repeater runat="server" ID="RptImage">
                                    <ItemTemplate>
                                        <a href="#" data-toggle="modal" data-target="#editarFotoPerfil">
                                            <img id="bigImage" class="imgPerfil" src="../../uploads/fotos/<%#Eval("pej_foto_perfil")%>"
                                                onmouseover="AlterarImagem()"
                                                onmouseout="ImagemOriginal('../../uploads/fotos/<%#Eval("pej_foto_perfil")%>')" /></a>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="ltlNome" runat="server"></asp:Literal>
                                <asp:Literal ID="ltlEnd" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-4">
                <div class="EspacoPraticas">
                    <div style="width: 100%;">
                        <a href="EdicaoEspacoEsportivo.aspx" style="text-decoration: none; color: inherit;">
                            <h4 class="nomeOutros">Espaço para Praticar <i class="far fa-edit"></i></h4>
                        </a>
                    </div>
                    <table style="width: 100%;" class="margemTables">
                        <tr class="text-center">
                            <asp:Repeater runat="server" ID="RptEsporte">
                                <ItemTemplate>
                                    <td class="iconesEsportes">
                                        <img style="width: 50%;" src="<%#Eval("esp_logo") %>" title="<%#Eval("esp_nome") %>" />
                                    </td>
                                </ItemTemplate>
                            </asp:Repeater>
                            <!-- QUANDO O LOCAL NÃO TEM ESPORTES CADASTRADOS -->
                            <td>
                                <div runat="server" id="espVazio">
                                    <div class="eventosDesc">
                                        <h5 class="nomeEvento, text-center">Adicione os esportes que seu Local oferece!
                                            <a href="EdicaoEspacoEsportivo.aspx" style="text-decoration: none; color: inherit;" class="nomeOutros">+
                                            </a>
                                        </h5>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="EspacoContatenos">
                    <h4 class="nomeOutros">Contate-nos</h4>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 8%;">
                                <img class="iconeContato" src="../../img/icones/insta.png" />
                            </td>
                            <td style="width: 70%;">
                                <h5>@EsportivoVilla</h5>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td style="width: 8%;">
                                <img class="iconeContato" src="../../img/icones/face.png" />
                            </td>
                            <td style="width: 70%;">
                                <h5>Centro Esportivo Villa</h5>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td style="width: 8%;">
                                <img class="iconeContato" src="../../img/icones/zap.png" />
                            </td>
                            <td style="width: 70%;">
                                <h5>(12) 98888-8888</h5>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td style="width: 8%;">
                                <img class="iconeContato" src="../../img/icones/tel.png" />
                            </td>
                            <td style="width: 70%;">
                                <h5>(12) 3131-3131</h5>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td style="width: 8%;">
                                <img class="iconeContato" src="../../img/icones/email.png" />
                            </td>
                            <td style="width: 70%;">
                                <h5>centroesportivo@gmail.com</h5>
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <div class="espacoCheckin">
                        <h4 class="nomeOutros">Check-in</h4>
                    </div>
                    <table class="margemTables">
                        <tr>
                            <td>
                                <table>
                                    <tr class="text-center">
                                        <td>
                                            <img class="imgAmigos" src="../../img/ImagensPerfil/profile-group-icon_34379.png" />
                                        </td>
                                        <td>
                                            <img class="imgAmigos" src="../../img/ImagensPerfil/2.png" />
                                        </td>
                                        <td>
                                            <img class="imgAmigos" src="../../img/ImagensPerfil/3.png" />
                                        </td>
                                    </tr>
                                    <tr class="text-center">
                                        <td>
                                            <img class="imgAmigos" src="../../img/ImagensPerfil/4.png" />
                                        </td>
                                        <td>
                                            <img class="imgAmigos" src="../../img/ImagensPerfil/5.png" />
                                        </td>
                                        <td>
                                            <img class="imgAmigos" src="../../img/ImagensPerfil/6.png" />
                                        </td>
                                    </tr>
                                    <tr class="text-center">
                                        <td>
                                            <img class="imgAmigos" src="../../img/ImagensPerfil/7.png" />
                                        </td>
                                        <td>
                                            <img class="imgAmigos" src="../../img/ImagensPerfil/8.png" />
                                        </td>
                                        <td>
                                            <img class="imgAmigos" src="../../img/ImagensPerfil/9.png" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="HorarioFuncionamento">
                    <div>
                    </div>
                    <div>
                        <div class="HorarioMargem">
                            <h4 class="nomeOutros">Horário de Funcionamento</h4>
                        </div>
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 100%;">
                                    <br />
                                    <h5>Segunda a Sexta: 06:00h a 18:00h</h5>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <h5>Sábado a Domingo: 07:00h a 20:00h</h5>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                    <h5>Feriados: Sujeito a Alterações</h5>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div class="col-8">
                <section>
                    <div class="galeria">
                        <h4 class="nomeOutros">Galeria</h4>
                        <div class="gallery autoplay items-3">
                            <div id="item-1" class="control-operator"></div>
                            <div id="item-2" class="control-operator"></div>
                            <div id="item-3" class="control-operator"></div>
                            <div id="item-4" class="control-operator"></div>

                            <figure class="item">
                                <h1>
                                    <img style="width: 100%;" src="../../img/EspacoEsportivoImg/Basquete.jpeg" />
                                </h1>
                            </figure>

                            <figure class="item">
                                <h1>
                                    <img style="width: 100%;" src="../../img/EspacoEsportivoImg/Corrida.jpg" />
                                </h1>
                            </figure>

                            <figure class="item">
                                <h1>
                                    <img style="width: 100%;" src="../../img/EspacoEsportivoImg/Futebol.jpeg" />
                                </h1>
                            </figure>
                            <figure class="item">
                                <h1>
                                    <img style="width: 100%;" src="../../img/EspacoEsportivoImg/Piscina.jpeg" />
                                </h1>
                            </figure>

                            <div class="controls">
                                <a href="#item-1" class="control-button">.</a>
                                <a href="#item-2" class="control-button">.</a>
                                <a href="#item-3" class="control-button">.</a>
                                <a href="#item-4" class="control-button">.</a>
                            </div>
                        </div>
                    </div>
                    <!-- EVENTOS DO LOCAL -->
                    <div class="meusEventos">
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 65%;">
                                        <h4 class="nomeOutros">Meus Eventos</h4>
                                    </td>
                                    <td style="width: 35%;">
                                        <nav class="margins">
                                            <div>
                                                <ul style="list-style-type: none">
                                                    <li>
                                                        <a style="text-decoration: none" href="#" class="botaoPadrao" data-toggle="modal" data-target="#criarEvento">Criar Evento</a>
                                                    </li>
                                                </ul>
                                            </div>
                                        </nav>
                                    </td>
                                </tr>
                            </table>
                            <div data-spy="scroll" data-target="#navbarVertical" data-offset="0" class="TodosEventos">
                                <div runat="server" id="cardCheio">
                                    <table style="width: 100%;" class="Eventos">
                                        <tr>
                                            <td>
                                                <div class="row">
                                                    <asp:Repeater runat="server" ID="rptCard" OnItemCommand="rptCard_ItemCommand">
                                                        <ItemTemplate>
                                                            <div class="col-6">
                                                                <div class="MargemEventos">
                                                                    <div class="eventosDesc">
                                                                        <h5 class="nomeEvento"><%#Eval("esp_nome") %> - <%#Eval("eve_nome") %></h5>
                                                                        <h6>Local: <%#Eval("pej_nome_ficticio") %></h6>
                                                                        <h6 class="nomeEvento"><%#Eval("end_rua") %>, <%#Eval("end_bairro") %> | <%#Eval("end_cidade") %> <%#Eval("end_uf") %></h6>

                                                                        <table style="width: 100%;">
                                                                            <tr>
                                                                                <td>
                                                                                    <h5>Dia: <%#Eval("eve_data") %></h5>
                                                                                </td>
                                                                                <td>
                                                                                    <h5>Horário: <%#Eval("eve_horario_inicio") %></h5>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                                <div class="text-center">
                                                                    <asp:Button runat="server" ID="BtnVerMais" Text="Ver Mais+" CommandName="VerMais" UseSubmitBehavior="false"
                                                                        CommandArgument='<%#Eval("eve_codigo") %>'
                                                                        Style="text-decoration: none" CssClass="botaoVerMais"
                                                                        data-toggle="modal" data-target="#verEvento"></asp:Button>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <!-- CARD QUANDO O LOCAL ESPORTIVO NÃO TEM EVENTOS CRIADOS -->
                                <div class="row">
                                    <div runat="server" class="col-12" id="cardVazio">
                                        <div class="MargemEventos">
                                            <div class="eventosDesc">
                                                <h5 class="nomeEvento text-center">PARECE QUE VOCÊ NÃO CRIOU NENHUM EVENTO :(</h5>
                                                <h6></h6>
                                                <h6 class="nomeEvento"></h6>

                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td>
                                                            <h5 class="text-center">CRIE UM EVENTO PARA VOCÊ !  </h5>
                                                        </td>
                                                        <td>
                                                            <h5></h5>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- HISTÓRICO DE EVENTOS -->
                    <div class="meusEventos">
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 65%;">
                                        <h4 class="nomeOutros">Histórico de Eventos</h4>
                                    </td>
                                </tr>
                            </table>
                            <div data-spy="scroll" data-target="#navbarVertical" data-offset="0" class="TodosEventos">
                                <div runat="server" id="historicoCheio">
                                    <table style="width: 100%;" class="Eventos">
                                        <tr>
                                            <td>
                                                <div class="row">
                                                    <asp:Repeater runat="server" ID="RptHistorico" OnItemCommand="RptHistorico_ItemCommand">
                                                        <ItemTemplate>
                                                            <div class="col-6">
                                                                <div class="MargemEventos">
                                                                    <div class="eventosDesc">
                                                                        <h5 class="nomeEvento"><%#Eval("esp_nome") %> - <%#Eval("eve_nome") %></h5>
                                                                        <h6>Local: <%#Eval("pej_nome_ficticio") %></h6>
                                                                        <h6 class="nomeEvento"><%#Eval("end_rua") %>, <%#Eval("end_bairro") %> | <%#Eval("end_cidade") %> <%#Eval("end_uf") %></h6>

                                                                        <table style="width: 100%;">
                                                                            <tr>
                                                                                <td>
                                                                                    <h5>Dia: <%#Eval("eve_data") %></h5>
                                                                                </td>
                                                                                <td>
                                                                                    <h5>Horário: <%#Eval("eve_horario_inicio") %></h5>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                                <div class="text-center">
                                                                    <asp:Button runat="server" ID="BtnHistoricoVM" Text="Ver Mais+" CommandName="VerMais" UseSubmitBehavior="false"
                                                                        CommandArgument='<%#Eval("eve_codigo") %>'
                                                                        Style="text-decoration: none" CssClass="botaoVerMais"
                                                                        data-toggle="modal" data-target="#verEvento"></asp:Button>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <!-- CARD QUANDO O LOCAL ESPORTIVO NÃO TEM EVENTOS CRIADOS -->
                                <div class="row">
                                    <div runat="server" class="col-12" id="historicoVazio">
                                        <div class="MargemEventos">
                                            <div class="eventosDesc">
                                                <br />
                                                <br />
                                                <br />
                                                <h5 class="nomeEvento text-center">Seu histórico de eventos está vazio.</h5>
                                                <br />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>

        <!-- MODAL -->
        <!-- CRIAR EVENTO -->
        <div class="modal fade" id="criarEvento" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-dialog-centered modal-md " role="document">
                <div class="modal-content">

                    <div class="modal-header">
                        <h4 class="modal-title, nomeOutros">Criação de Evento</h4>
                        <button type="button" class="close" data-dismiss="modal">
                            <span>&times;</span>
                        </button>
                    </div>

                    <div class="modal-body">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-12">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Nome do Evento: </strong></asp:Label>
                                    <asp:TextBox ID="txtNomeEvento" ClientIDMode="Static" Width="73%" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Esporte: </strong></asp:Label>
                                    <asp:DropDownList ID="ddlEsporte" runat="server" ClientIDMode="Static" repeatDirection="Horizontal" Width="70%">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Nº de Participantes: </strong></asp:Label>
                                    <asp:TextBox ID="txtNumParticipantes" type="number" ClientIDMode="Static" Width="35%" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-5">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Data: </strong></asp:Label>
                                    <asp:TextBox ID="txtData" ClientIDMode="Static" step="1" type="date" Width="76%" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-7">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Horário: </strong></asp:Label>
                                    <asp:TextBox ID="txtInicio" type="time" ClientIDMode="Static" Width="35%" runat="server"></asp:TextBox>
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong> - </strong></asp:Label>
                                    <asp:TextBox ID="txtFim" type="time" ClientIDMode="Static" Width="35%" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-5">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Gênero: </strong></asp:Label>
                                    <asp:DropDownList ID="ddlGenero" runat="server" ClientIDMode="Static" repeatDirection="Horizontal" Width="60%">
                                        <asp:ListItem Selected="True" Value="Masculino">Masculino</asp:ListItem>
                                        <asp:ListItem Value="Feminino">Feminino</asp:ListItem>
                                        <asp:ListItem Value="Todos">Todos</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-7">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Idade Permitida: </strong></asp:Label>
                                    <asp:TextBox ID="txtIdadeMin" type="number" ClientIDMode="Static" Width="22%" runat="server"></asp:TextBox>
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>  até  </strong></asp:Label>
                                    <asp:TextBox ID="txtIdadeMax" type="number" ClientIDMode="Static" Width="22%" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-8">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Entidade: </strong></asp:Label>
                                    <asp:TextBox ID="txtEntidade" type="text" ClientIDMode="Static" Width="75%" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-4">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Valor: </strong></asp:Label>
                                    <asp:TextBox ID="txtValor" type="number" ClientIDMode="Static" Width="64%" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-12">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Status do Evento: </strong></asp:Label>
                                    <asp:DropDownList ID="ddlAtivo" runat="server" ClientIDMode="Static" repeatDirection="Horizontal" Width="73%">
                                        <asp:ListItem Selected="True" Value="Evento em fase inicial, inscrições em breve." Text="Evento em fase inicial, inscrições em breve."></asp:ListItem>
                                        <asp:ListItem Value="Recebendo inscrições." Text="Recebendo inscrições."></asp:ListItem>
                                        <asp:ListItem Value="Inscrições encerradas, Evento em andamento." Text="Inscrições encerradas, Evento em andamento."></asp:ListItem>
                                        <asp:ListItem Value="Concluido com sucesso!" Text="Concluido com sucesso!"></asp:ListItem>
                                        <asp:ListItem Value="Evento Cancelado :(" Text="Evento Cancelado :("></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-12">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Descrição: </strong></asp:Label>
                                </div>
                                <div class="col-12">
                                    <asp:TextBox ID="txtDescricao" TextMode="MultiLine" ClientIDMode="Static" Width="100%" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="modal-footer">
                        <asp:LinkButton runat="server" ID="btnCriar" CssClass="botaoPadrao" OnClick="BtnCriar_Click" Text="Criar"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <!-- MODAL -->
        <!-- VER EVENTO -->
        <div class="modal fade" id="verEvento" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-dialog-centered p-md-6" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <strong>
                            <asp:Literal runat="server" ID="ltlNomeEvento"></asp:Literal></strong>
                        <button type="button" class="close" data-dismiss="modal">
                            <span>&times;</span>
                        </button>
                    </div>

                    <div class="modal-body">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Esporte: </strong></asp:Label>
                                    <asp:Literal runat="server" ID="ltlEsporte"></asp:Literal>
                                </div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Data: </strong></asp:Label>
                                    <asp:Literal runat="server" ID="ltlData"></asp:Literal>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Horário: </strong></asp:Label>
                                    <asp:Literal runat="server" ID="ltlInicio"></asp:Literal>
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong> - </strong></asp:Label>
                                    <asp:Literal runat="server" ID="ltlTermino"></asp:Literal>
                                </div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Valor: </strong></asp:Label>
                                    <asp:Literal runat="server" ID="ltlPreco"></asp:Literal>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Gênero: </strong></asp:Label>
                                    <asp:Literal runat="server" ID="ltlGenero"></asp:Literal>
                                </div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Idade Permitida: </strong></asp:Label>
                                    <asp:Literal runat="server" ID="ltlMinima"></asp:Literal>
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong> - </strong></asp:Label>
                                    <asp:Literal runat="server" ID="ltlMaxima"></asp:Literal>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Nº de Participantes: </strong></asp:Label>
                                    <asp:Literal runat="server" ID="ltlNumeroIntegrantes"></asp:Literal>
                                </div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Entidade: </strong></asp:Label>
                                    <asp:Literal runat="server" ID="ltlEntidade"></asp:Literal>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-12">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Status do Evento: </strong></asp:Label>
                                    <asp:Literal runat="server" ID="ltlStatus"></asp:Literal>
                                    <asp:Literal runat="server" ID="ltlEveCodigo" Visible="false"></asp:Literal>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-12">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Descrição: </strong></asp:Label>
                                </div>
                                <div class="col-12">
                                    <asp:TextBox runat="server" TextMode="MultiLine" Width="100%" ID="ltlDescricao" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-12">&nbsp</div>
                            </div>
                        </div>
                    </div>

                    <div class="modal-footer">
                        <ul style="list-style-type: none">
                            <li>
                                <asp:LinkButton runat="server" ID="BtnEditar" CssClass="botaoPadrao" OnClick="BtnEditar_Click">Editar <i class="far fa-edit"></i></asp:LinkButton>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <!-- MODAL -->
        <!-- EDITAR EVENTO -->
        <div class="modal fade" id="editarEvento" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-dialog-centered modal-md " role="document">
                <div class="modal-content">

                    <div class="modal-header">
                        <h4 class="modal-title, nomeOutros">Edição de Evento</h4>
                        <button type="button" class="close" data-dismiss="modal">
                            <span>&times;</span>
                        </button>
                    </div>

                    <div class="modal-body">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-12">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Nome do Evento: </strong></asp:Label>
                                    <asp:TextBox ID="txtEventoEdit" ClientIDMode="Static" Width="73%" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Esporte: </strong></asp:Label>
                                    <asp:DropDownList ID="ddlEsporteEdit" runat="server" ClientIDMode="Static" repeatDirection="Horizontal" Width="70%">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Nº de Participantes: </strong></asp:Label>
                                    <asp:TextBox ID="txtNumeroIntegrantesEdit" type="number" ClientIDMode="Static" Width="35%" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-5">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Data: </strong></asp:Label>
                                    <asp:TextBox ID="txtDataEdit" ClientIDMode="Static" step="1" type="date" Width="76%" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-7">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Horário: </strong></asp:Label>
                                    <asp:TextBox ID="txtInicioEdit" type="time" ClientIDMode="Static" Width="35%" runat="server"></asp:TextBox>
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong> - </strong></asp:Label>
                                    <asp:TextBox ID="txtTerminoEdit" type="time" ClientIDMode="Static" Width="35%" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-5">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Gênero: </strong></asp:Label>
                                    <asp:DropDownList ID="ddlGeneroEdit" runat="server" ClientIDMode="Static" repeatDirection="Horizontal" Width="60%">
                                        <asp:ListItem Selected="True" Value="Masculino">Masculino</asp:ListItem>
                                        <asp:ListItem Value="Feminino">Feminino</asp:ListItem>
                                        <asp:ListItem Value="Todos">Todos</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-7">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Idade Permitida: </strong></asp:Label>
                                    <asp:TextBox ID="txtIdadeMinimaEdit" type="number" ClientIDMode="Static" Width="22%" runat="server"></asp:TextBox>
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>  até  </strong></asp:Label>
                                    <asp:TextBox ID="txtIdadeMaximaEdit" type="number" ClientIDMode="Static" Width="22%" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-8">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Entidade: </strong></asp:Label>
                                    <asp:TextBox ID="txtEntidadeEdit" type="text" ClientIDMode="Static" Width="75%" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-4">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Valor: </strong></asp:Label>
                                    <asp:TextBox ID="txtPrecoEdit" type="number" ClientIDMode="Static" Width="64%" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-12">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Status do Evento: </strong></asp:Label>
                                    <asp:DropDownList ID="ddlStatusEdit" runat="server" ClientIDMode="Static" repeatDirection="Horizontal" Width="73%">
                                        <asp:ListItem Selected="True" Value="Evento em fase inicial, inscrições em breve." Text="Evento em fase inicial, inscrições em breve."></asp:ListItem>
                                        <asp:ListItem Value="Recebendo inscrições." Text="Recebendo inscrições."></asp:ListItem>
                                        <asp:ListItem Value="Inscrições encerradas, Evento em andamento." Text="Inscrições encerradas, Evento em andamento."></asp:ListItem>
                                        <asp:ListItem Value="Concluido com sucesso!" Text="Concluido com sucesso!"></asp:ListItem>
                                        <asp:ListItem Value="Evento Cancelado :(" Text="Evento Cancelado :("></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-12">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Descrição: </strong></asp:Label>
                                </div>
                                <div class="col-12">
                                    <asp:TextBox ID="txtDescricaoEdit" TextMode="MultiLine" ClientIDMode="Static" Width="100%" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="modal-footer">
                        <asp:LinkButton runat="server" ID="BtnExcluir" CssClass="botaoPadrao" OnClick="BtnExcluir_Click" Text="Excluir"></asp:LinkButton>
                        <asp:LinkButton runat="server" ID="BtnSalvar" CssClass="botaoPadrao" OnClick="BtnSalvar_Click" Text="Salvar alteraçoes"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <!-- EDIÇÃO DA FOTO DE PERFIL -->
        <div class="modal fade" id="editarFotoPerfil" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-dialog-centered modal-l" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title, nomeOutros">Atualize sua foto de perfil</h4>
                        <button type="button" class="close" data-dismiss="modal">
                            <span>&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-12">
                                    <div class="text-center">
                                        <asp:Repeater runat="server" ID="RptImageEdit">
                                            <ItemTemplate>
                                                <img class="imgEdicao" src="../../uploads/fotos/<%#Eval("pej_foto_perfil")%>" />
                                                <h3></h3>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <div class="text-center">
                                        <asp:FileUpload ID="FileUploadControl" runat="server"
                                            class="multi" AllowMultiple="True" ValidationGroup="fotoEdit" />
                                        <br />
                                        <asp:Label runat="server" ID="StatusLabel" Text=""
                                            ForeColor="Red" ValidationGroup="fotoEdit" />
                                        <br />
                                        <asp:Button ID="btnUpload" runat="server" Text=" Carregar Fotos "
                                            OnClick="btnUpload_Click" CssClass="botaoAdd" ValidationGroup="fotoEdit" />
                                        <br />
                                        <br />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- JAVASCRIPT -->
        <script type="text/javascript">
            function AlterarImagem() {
                document.getElementById('bigImage').src = '../../img/NovaFoto.png';
            }
        </script>
        <script type="text/javascript">
            function ImagemOriginal(img) {
                document.getElementById('bigImage').src = img;
            }
        </script>
        <script src="../../Scripts/jquery-3.0.0.min.js"></script>
        <script src="../../Scripts/bootstrap.min.js"></script>
        <asp:Literal runat="server" ID="lblScript"></asp:Literal>
    </main>
</asp:Content>

