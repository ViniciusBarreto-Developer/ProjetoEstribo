<%@ Page Title="" Language="C#" MasterPageFile="~/Pags/Perfil/MasterPerfil.master" AutoEventWireup="true" CodeFile="EsportistaPerfil.aspx.cs" Inherits="pg_Perfil_EsportistaPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../css/PerfilEspaco.css" rel="stylesheet" />
    <link href="../../css/PerfilEsportista.css" rel="stylesheet" />
    
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
                                            <img id="bigImage" class="imgPerfil" src="../../uploads/fotos/<%#Eval("pef_foto_perfil")%>"
                                                onmouseover="AlterarImagem()"
                                                onmouseout="ImagemOriginal('../../uploads/fotos/<%#Eval("pef_foto_perfil")%>')" /></a>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal runat="server" ID="ltlNome"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="col-8">
            </div>
        </div>
        <div class="row">
            <div class="col-4">
                <table style="width: 100%;" class="margemTables">
                    <tr class="text-center">
                        <td>
                            <h4 class="nomeOutros">Idade</h4>
                            <asp:Literal runat="server" ID="ltlIdade"></asp:Literal>
                        </td>
                        <td>
                            <h4 class="nomeOutros">Gênero</h4>
                            <asp:Literal runat="server" ID="ltlGenero"></asp:Literal>
                        </td>
                    </tr>
                </table>
                <div>
                    <div style="width: 100%;">
                        <a href="EdicaoEsportista.aspx" style="text-decoration: none; color: inherit;">
                            <h4 class="nomeOutros">Esportes que pratico <i class="far fa-edit"></i></h4>
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
                            <!-- QUANDO O ESPORTISTA NÃO TEM ESPORTES CADASTRADOS -->
                            <td>
                                <div runat="server" id="espVazio">
                                    <div class="eventosDesc">
                                        <h5 class="nomeEvento, text-center">Adicione os esportes que você pratica ou tem interesse!
                                            <a href="EdicaoEsportista.aspx" style="text-decoration: none; color: inherit;" class="nomeOutros">+
                                            </a>
                                        </h5>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <table class="margemTables">
                    <tr>
                        <td>
                            <h4 class="nomeOutros">Amigos</h4>
                        </td>
                    </tr>
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
            <div class="col-8">
                <table class="margemBaixo">
                    <tr>
                        <td>
                            <section>

                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <h4 class="nomeOutros">Minhas Partidas</h4>
                                        </td>
                                        <td class="float-right">
                                            <asp:LinkButton runat="server" Text="Criar Partida" Style="text-decoration: none" href="#" CssClass="botaoPadrao" data-toggle="modal" data-target="#criarPartida"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                                <div>
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
                                                                                <h5 class="nomeEvento"><%#Eval("esp_nome") %> - <%#Eval("par_nome") %></h5>
                                                                                <h6>Local: <%#Eval("par_nome_local") %></h6>
                                                                                <h6 class="nomeEvento"><%#Eval("end_rua") %>, <%#Eval("end_bairro") %> | <%#Eval("end_cidade") %> <%#Eval("end_uf") %></h6>

                                                                                <table style="width: 100%;">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <h5>Dia: <%#Eval("par_data") %></h5>
                                                                                        </td>
                                                                                        <td>
                                                                                            <h5>Horário: <%#Eval("par_horario_inicio") %></h5>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                        </div>
                                                                        <div class="text-center">
                                                                            <div class="text-center">
                                                                                <asp:Button runat="server" ID="BtnVerMais1" Text="Ver Mais+" CommandName="VerMais1" UseSubmitBehavior="false"
                                                                                    CommandArgument='<%#Eval("par_codigo") %>'
                                                                                    Style="text-decoration: none" CssClass="botaoVerMais"
                                                                                    data-toggle="modal" data-target="#verMais"></asp:Button>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <!-- CARD QUANDO O ESPORTISTA NÃO ESTÁ PARTICIPANDO DE NENHUMA PARTIDA -->
                                        <div class="row">
                                            <div runat="server" class="col-12" id="cardVazio">
                                                <div class="MargemEventos">
                                                    <div class="eventosDesc">
                                                        <h5 class="nomeEvento, text-center">😭 Você não esta participando de nenhuma partida 😭</h5>
                                                        <h6></h6>
                                                        <h6 class="nomeEvento"></h6>

                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td class="text-center">
                                                                    <asp:LinkButton runat="server" Text="Criar Partida" Style="text-decoration: none" href="#" CssClass="botaoPadrao" data-toggle="modal" data-target="#criarPartida"></asp:LinkButton>
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
                            </section>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <section class="Propartidas">
                                <div>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <h4 class="nomeOutros">Partidas perto de você </h4>
                                            </td>
                                            <td class="float-right">
                                                <asp:TextBox ID="txtEsporte" ClientIDMode="Static" placeholder="Esporte" Width="80%" CssClass="textbox" runat="server" BackColor="" />
                                            </td>
                                            <td class="float-right">
                                                <asp:TextBox ID="txtCidade" ClientIDMode="Static" placeholder="Cidade" Width="80%" CssClass="textbox" runat="server" BackColor="" />
                                            </td>
                                            <td>
                                                <asp:LinkButton runat="server" AutoPostBack="false" Text="Pesquisar" Style="text-decoration: none" CssClass="botaoPesquisar" ID="BtnPesquisar" OnClick="BtnPesquisar_Click"><i class="fas fa-search-location"></i></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                    <div data-spy="scroll" data-target="#navbarVertical" data-offset="0" class="TodosEventos">
                                        <div runat="server" id="PesquisaCheia">
                                            <table style="width: 100%;" class="Eventos">
                                                <tr>
                                                    <td>
                                                        <div class="row">
                                                            <asp:Repeater runat="server" ID="rptCard2" OnItemCommand="rptCard2_ItemCommand">
                                                                <ItemTemplate>
                                                                    <div class="col-6">
                                                                        <div class="MargemEventos">
                                                                            <div class="eventosDesc">
                                                                                <h5 class="nomeEvento"><%#Eval("esp_nome") %> - <%#Eval("par_nome") %></h5>
                                                                                <h6>Local: <%#Eval("par_nome_local") %></h6>
                                                                                <h6 class="nomeEvento"><%#Eval("end_rua") %>, <%#Eval("end_bairro") %> | <%#Eval("end_cidade") %> <%#Eval("end_uf") %></h6>

                                                                                <table style="width: 100%;">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <h5>Dia: <%#Eval("par_data") %></h5>
                                                                                        </td>
                                                                                        <td>
                                                                                            <h5>Horário: <%#Eval("par_horario_inicio") %></h5>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                        </div>
                                                                        <div class="text-center">
                                                                            <asp:Button runat="server" ID="BtnVerMais" Text="Ver Mais+" CommandName="VerMais" UseSubmitBehavior="false"
                                                                                CommandArgument='<%#Eval("par_codigo") %>'
                                                                                Style="text-decoration: none" CssClass="botaoVerMais"
                                                                                data-toggle="modal" data-target="#verMais"></asp:Button>
                                                                        </div>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <!--QUANDO A PESQUISA NÃO ENCONTRA RESULTADO-->
                                        <div class="row">
                                            <div runat="server" class="col-12" id="PesquisaVazia">
                                                <div class="MargemEventos">
                                                    <div class="eventosDesc">
                                                        <h5 class="nomeEvento text-center">😭 Não encontramos nada nessa região 😭</h5>
                                                        <h6></h6>
                                                        <h6 class="nomeEvento"></h6>

                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td style="text-align: center;">
                                                                    <asp:LinkButton runat="server" Text="Criar Partida" Style="text-decoration: none" href="#" CssClass="botaoPadrao" data-toggle="modal" data-target="#criarPartida"></asp:LinkButton>
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
                            </section>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <!-- MODAL -->
        <!-- CRIAR PARTIDA -->
        <div class="modal fade" id="criarPartida" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-dialog-centered p-md-6" role="document">
                <div class="modal-content">

                    <div class="modal-header">
                        <h4 class="modal-title, nomeOutros">Criação de Partida</h4>
                        <button type="button" class="close" data-dismiss="modal">
                            <span>&times;</span>
                        </button>
                    </div>

                    <div class="modal-body">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-12">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Nome da Partida: </strong></asp:Label>
                                    <asp:TextBox ID="txtNomePartida" ClientIDMode="Static" Width="72%" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-8">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Esporte: </strong></asp:Label>
                                    <asp:DropDownList ID="ddlEsporte" runat="server" ClientIDMode="Static" repeatDirection="Horizontal" Width="75%">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-4">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Valor: </strong></asp:Label>
                                    <asp:TextBox ID="txtValor" type="$" ClientIDMode="Static" Width="60%" runat="server"></asp:TextBox>
                                    <asp:Literal runat="server" ID="ltlNumeroIntegrantes1" Visible="false"></asp:Literal>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-7">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Local: </strong></asp:Label>
                                    <asp:TextBox ID="txtLocal" ClientIDMode="Static" Width="82%" type="email" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-5">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Espaço: </strong></asp:Label>
                                    <asp:DropDownList ID="ddlTipoLocal" runat="server" Width="64%" ClientIDMode="Static" repeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="Privado">Privado</asp:ListItem>
                                        <asp:ListItem Value="Público">Público</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-7">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Horário: </strong></asp:Label>
                                    <asp:TextBox ID="txtInicio" type="time" ClientIDMode="Static" Width="35%" runat="server"></asp:TextBox>
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong> - </strong></asp:Label>
                                    <asp:TextBox ID="txtFim" type="time" ClientIDMode="Static" Width="35%" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-5">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Nº Participantes: </strong></asp:Label>
                                    <asp:TextBox ID="txtNumeroParticipantes" type="number" ClientIDMode="Static" Width="28%" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-5">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Gênero: </strong></asp:Label>
                                    <asp:DropDownList ID="ddlGenero" runat="server" Width="67%" ClientIDMode="Static" repeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="Masculino">Masculino</asp:ListItem>
                                        <asp:ListItem Value="Feminino">Feminino</asp:ListItem>
                                        <asp:ListItem Value="Todos">Todos</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-7">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Data: </strong></asp:Label>
                                    <asp:TextBox ID="txtData" ClientIDMode="Static" step="1" type="date" Width="80%" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-7">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Idade Permitida: </strong></asp:Label>
                                    <asp:TextBox ID="txtIdadeMinima" type="number" ClientIDMode="Static" Width="20%" runat="server"></asp:TextBox>
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong> até: </strong></asp:Label>
                                    <asp:TextBox ID="txtIdadeMaxima" type="number" ClientIDMode="Static" Width="20%" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-5">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Partida: </strong></asp:Label>
                                    <asp:DropDownList ID="ddlPartidaPrivacidade" runat="server" Width="63%" ClientIDMode="Static" repeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="Privada">Privada</asp:ListItem>
                                        <asp:ListItem Value="Pública">Pública</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-4">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>CEP: </strong></asp:Label>
                                    <asp:TextBox ID="cep" ClientIDMode="Static" Width="70%" runat="server" onblur="pesquisacep(this.value);"></asp:TextBox>
                                </div>
                                <div class="col-8">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Cidade: </strong></asp:Label>
                                    <asp:TextBox ID="cidade" ClientIDMode="Static" Width="60%" runat="server" Enabled="false"></asp:TextBox>
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong> - </strong></asp:Label>
                                    <asp:TextBox ID="uf" ClientIDMode="Static" Width="15%" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-5">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Bairro: </strong></asp:Label>
                                    <asp:TextBox ID="bairro" ClientIDMode="Static" Width="73%" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-7">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Rua: </strong></asp:Label>
                                    <asp:TextBox ID="rua" ClientIDMode="Static" Width="83%" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="modal-footer">
                        <asp:LinkButton runat="server" ID="BtnCriar" CssClass="btn-modal-criar" OnClick="BtnCriar_Click" Text="Criar Partida"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <!-- MODAL -->
        <!-- VER MAIS (PARTIDAS NÃO PARTICIPANDO)-->
        <div class="modal fade" id="verMais" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-dialog-centered p-md-6" role="document">
                <div class="modal-content">

                    <div class="modal-header">
                        <div class="modal-title, nomeOutros">
                            <div class="text-center">
                                <asp:Label CssClass="CadastroInfos" runat="server"></asp:Label>
                                <h3>
                                    <asp:Literal ID="ltlNomePartidaPP" ClientIDMode="Static" runat="server"></asp:Literal>
                                </h3>
                            </div>
                        </div>
                        <button type="button" class="close" data-dismiss="modal">
                            <span>&times;</span>
                        </button>
                    </div>

                    <div class="modal-body">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Esporte: </strong></asp:Label>
                                    <asp:Literal ID="ltlEsportePP" ClientIDMode="Static" runat="server"></asp:Literal>
                                </div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Gênero: </strong></asp:Label>
                                    <asp:Literal ID="ltlGeneroPP" ClientIDMode="Static" runat="server"></asp:Literal>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Idade: </strong></asp:Label>
                                    <asp:Literal ID="ltlIdadeMinimaPP" ClientIDMode="Static" runat="server"></asp:Literal>
                                    <asp:Label CssClass="CadastroInfos" runat="server"> - </asp:Label>
                                    <asp:Literal ID="ltlIdadeMaximaPP" ClientIDMode="Static" runat="server"></asp:Literal>
                                </div>
                                <div class="col-3">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>R$ </strong></asp:Label>
                                    <asp:Literal ID="ltlPrecoPP" ClientIDMode="Static" runat="server"></asp:Literal>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><i class="fas fa-calendar-day"></i></asp:Label>
                                    <asp:Literal ID="ltlDataPP" ClientIDMode="Static" runat="server"></asp:Literal>
                                </div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><i class="fas fa-clock"></i></asp:Label>
                                    <asp:Literal ID="ltlInicioPP" ClientIDMode="Static" runat="server"></asp:Literal>
                                    <asp:Label CssClass="CadastroInfos" runat="server"> às </asp:Label>
                                    <asp:Literal ID="ltlFimPP" ClientIDMode="Static" runat="server"></asp:Literal>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Local: </strong></asp:Label>
                                    <asp:Literal runat="server" ID="ltlLocalPP"></asp:Literal>
                                </div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Espaço: </strong></asp:Label>
                                    <asp:Literal ID="ltlTipoEspacoPP" ClientIDMode="Static" runat="server"></asp:Literal>
                                </div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Cidade: </strong></asp:Label>
                                    <asp:Literal ID="ltlCidadePP" ClientIDMode="Static" runat="server"></asp:Literal>
                                    <asp:Label CssClass="CadastroInfos" runat="server"> - </asp:Label>
                                    <asp:Literal ID="ltlUfPP" ClientIDMode="Static" runat="server"></asp:Literal>
                                </div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>CEP: </strong></asp:Label>
                                    <asp:Literal ID="ltlCepPP" ClientIDMode="Static" runat="server"></asp:Literal>
                                </div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Rua: </strong></asp:Label>
                                    <asp:Literal ID="ltlRuaPP" ClientIDMode="Static" runat="server"></asp:Literal>
                                    <asp:Literal ID="ltlParCodigo" ClientIDMode="Static" runat="server" Visible="false"></asp:Literal>
                                </div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Bairro: </strong></asp:Label>
                                    <asp:Literal ID="ltlBairroPP" ClientIDMode="Static" runat="server"></asp:Literal>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-5">
                                    <strong><asp:Literal ID="ltlNumParticipantesAtual" runat="server"></asp:Literal></strong>
                                </div>
                                <div class="col-7"></div>
                                <asp:Repeater runat="server" ID="RptIntegrantes2">
                                    <ItemTemplate>
                                        <div class="col-3">
                                            <img class="imgPerfil" src="../../uploads/fotos/<%#Eval("pef_foto_perfil")%>" />
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <div class="col-12">&nbsp</div>
                                <div class="col-9"></div>
                                <div class="col-3">
                                    <asp:LinkButton runat="server" ID="BtnEntrar" CssClass="btn-modal-criar" OnClick="BtnEntrar_Click" Text="Participar"></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- MODAL -->
        <!-- VER MAIS (PARTIDAS PARTICIPANDO)-->
        <div class="modal fade" id="verMais1" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-dialog-centered p-md-6" role="document">
                <div class="modal-content">

                    <div class="modal-header">
                        <div class="text-center">
                            <asp:Label CssClass="CadastroInfos" runat="server"></asp:Label>
                            <asp:Literal ID="ltlNomePartida1" ClientIDMode="Static" runat="server"></asp:Literal>
                        </div>

                        <button type="button" class="close" data-dismiss="modal">
                            <span>&times;</span>
                        </button>
                    </div>

                    <div class="modal-body">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Esporte: </strong></asp:Label>
                                    <asp:Literal ID="ltlEsporte1" ClientIDMode="Static" runat="server"></asp:Literal>
                                </div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Gênero: </strong></asp:Label>
                                    <asp:Literal ID="ltlGenero1" ClientIDMode="Static" runat="server"></asp:Literal>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Idade: </strong></asp:Label>
                                    <asp:Literal ID="ltlIdadeMinima1" ClientIDMode="Static" runat="server"></asp:Literal>
                                    <asp:Label CssClass="CadastroInfos" runat="server"> - </asp:Label>
                                    <asp:Literal ID="ltlIdadeMaxima1" ClientIDMode="Static" runat="server"></asp:Literal>
                                </div>                                
                                <div class="col-3">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Valor: </strong></asp:Label>
                                    <asp:Literal ID="ltlPreco1" ClientIDMode="Static" runat="server"></asp:Literal>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><i class="fas fa-calendar-day"></i></asp:Label>
                                    <asp:Literal ID="ltlData1" ClientIDMode="Static" runat="server"></asp:Literal>
                                </div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><i class="fas fa-clock"></i></asp:Label>
                                    <asp:Literal ID="ltlInicio1" ClientIDMode="Static" runat="server"></asp:Literal>
                                    <asp:Label CssClass="CadastroInfos" runat="server"> às </asp:Label>
                                    <asp:Literal ID="ltlTermino1" ClientIDMode="Static" runat="server"></asp:Literal>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Local: </strong></asp:Label>
                                    <asp:Literal runat="server" ID="ltlLocal1"></asp:Literal>
                                </div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Espaço: </strong></asp:Label>
                                    <asp:Literal ID="ltlTipoEspaco1" ClientIDMode="Static" runat="server"></asp:Literal>
                                </div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Cidade: </strong></asp:Label>
                                    <asp:Literal ID="ltlCidade1" ClientIDMode="Static" runat="server"></asp:Literal>
                                    <asp:Label CssClass="CadastroInfos" runat="server"> - </asp:Label>
                                    <asp:Literal ID="ltlUf1" ClientIDMode="Static" runat="server"></asp:Literal>
                                </div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>CEP: </strong></asp:Label>
                                    <asp:Literal ID="ltlCep1" ClientIDMode="Static" runat="server"></asp:Literal>
                                </div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Rua: </strong></asp:Label>
                                    <asp:Literal ID="ltlRua1" ClientIDMode="Static" runat="server"></asp:Literal>
                                    <asp:Literal ID="ltlParCodigo1" ClientIDMode="Static" runat="server" Visible="false"></asp:Literal>
                                </div>
                                <div class="col-6">
                                    <asp:Label CssClass="CadastroInfos" runat="server"><strong>Bairro: </strong></asp:Label>
                                    <asp:Literal ID="ltlBairro1" ClientIDMode="Static" runat="server"></asp:Literal>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-5">
                                    <strong><asp:Literal ID="ltlNumParticipantesAtual2" runat="server"></asp:Literal></strong>
                                </div>
                                <div class="col-7"></div>
                                <asp:Repeater runat="server" ID="RptIntegrantes">
                                    <ItemTemplate>
                                        <div class="col-3">
                                            <img class="imgPerfil" src="../../uploads/fotos/<%#Eval("pef_foto_perfil")%>" />
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <div class="col-12">&nbsp</div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-8">
                                    <asp:LinkButton runat="server" ID="BtnSair" CssClass="btn-modal-sair" OnClick="BtnSair_Click" Text="Sair"></asp:LinkButton>
                                </div>
                                <div class="col-4">
                                    <asp:LinkButton runat="server" ID="BtnEditar" CssClass="btn-modal-criar" OnClick="BtnEditar_Click">Editar <i class="far fa-edit"></i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- MODAL -->
        <!-- EDIÇÃO DE PARTIDA-->
        <div class="modal fade" id="editarPartida" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-dialog-centered p-md-6" role="document">
                <div class="modal-content">

                    <div class="modal-header">
                        <h4 class="modal-title, nomeOutros">Criação de Partida</h4>
                        <button type="button" class="close" data-dismiss="modal">
                            <span>&times;</span>
                        </button>
                    </div>

                    <div class="modal-body">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-12">
                                    <asp:Label CssClass="CadastroInfos" runat="server">Nome da Partida: </asp:Label>
                                    <asp:TextBox ID="txtNomePartidaEdit" ClientIDMode="Static" Width="72%" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-8">
                                    <asp:Label CssClass="CadastroInfos" runat="server">Esporte: </asp:Label>
                                    <asp:DropDownList ID="ddlEsporteEdit" runat="server" ClientIDMode="Static" repeatDirection="Horizontal" Width="75%">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-4">
                                    <asp:Label CssClass="CadastroInfos" runat="server">Preço: </asp:Label>
                                    <asp:TextBox ID="txtPrecoEdit" type="$" ClientIDMode="Static" Width="60%" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-7">
                                    <asp:Label CssClass="CadastroInfos" runat="server">Local: </asp:Label>
                                    <asp:TextBox ID="txtLocalEdit" ClientIDMode="Static" Width="82%" type="email" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-5">
                                    <asp:Label CssClass="CadastroInfos" runat="server">Espaço: </asp:Label>
                                    <asp:DropDownList ID="ddlTipoEspacoEdit" runat="server" Width="64%" ClientIDMode="Static" repeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="Privado">Privado</asp:ListItem>
                                        <asp:ListItem Value="Público">Público</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-7">
                                    <asp:Label CssClass="CadastroInfos" runat="server">Horário: </asp:Label>
                                    <asp:TextBox ID="txtInicioEdit" type="time" ClientIDMode="Static" Width="35%" runat="server"></asp:TextBox>
                                    <asp:Label CssClass="CadastroInfos" runat="server"> - </asp:Label>
                                    <asp:TextBox ID="txtFimEdit" type="time" ClientIDMode="Static" Width="35%" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-5">
                                    <asp:Label CssClass="CadastroInfos" runat="server">Nº Participantes: </asp:Label>
                                    <asp:TextBox ID="txtNumeroParticipantesEdit" type="number" ClientIDMode="Static" Width="28%" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-5">
                                    <asp:Label CssClass="CadastroInfos" runat="server">Gênero </asp:Label>
                                    <asp:DropDownList ID="ddlGeneroEdit" runat="server" Width="67%" ClientIDMode="Static" repeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="Masculino">Masculino</asp:ListItem>
                                        <asp:ListItem Value="Feminino">Feminino</asp:ListItem>
                                        <asp:ListItem Value="Todos">Todos</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-7">
                                    <asp:Label CssClass="CadastroInfos" runat="server">Data: </asp:Label>
                                    <asp:TextBox ID="txtDataEdit" ClientIDMode="Static" step="1" type="date" Width="80%" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-7">
                                    <asp:Label CssClass="CadastroInfos" runat="server">Idade Permitida: </asp:Label>
                                    <asp:TextBox ID="txtIdadeMinimaEdit" type="number" ClientIDMode="Static" Width="20%" runat="server"></asp:TextBox>
                                    <asp:Label CssClass="CadastroInfos" runat="server"> até: </asp:Label>
                                    <asp:TextBox ID="txtIdadeMaximaEdit" type="number" ClientIDMode="Static" Width="20%" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-5">
                                    <asp:Label CssClass="CadastroInfos" runat="server">Partida: </asp:Label>
                                    <asp:DropDownList ID="ddlPartidaPrivadicadeEdit" runat="server" Width="63%" ClientIDMode="Static" repeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="Privada">Privada</asp:ListItem>
                                        <asp:ListItem Value="Pública">Pública</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-4">
                                    <asp:Label CssClass="CadastroInfos" runat="server">CEP: </asp:Label>
                                    <asp:TextBox ID="cepEdit" ClientIDMode="Static" Width="70%" runat="server" onblur="pesquisacep(this.value);"></asp:TextBox>
                                </div>
                                <div class="col-8">
                                    <asp:Label CssClass="CadastroInfos" runat="server">Cidade: </asp:Label>
                                    <asp:TextBox ID="cidadeEdit" ClientIDMode="Static" Width="60%" runat="server" Enabled="false"></asp:TextBox>
                                    <asp:Label CssClass="CadastroInfos" runat="server"> - </asp:Label>
                                    <asp:TextBox ID="ufEdit" ClientIDMode="Static" Width="15%" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-5">
                                    <asp:Label CssClass="CadastroInfos" runat="server">Bairro: </asp:Label>
                                    <asp:TextBox ID="bairroEdit" ClientIDMode="Static" Width="73%" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-7">
                                    <asp:Label CssClass="CadastroInfos" runat="server">Rua: </asp:Label>
                                    <asp:TextBox ID="ruaEdit" ClientIDMode="Static" Width="83%" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-12">&nbsp</div>
                                <div class="col-7">
                                    <asp:LinkButton runat="server" ID="BtnCancelar" CssClass="btn-modal-sair" OnClick="BtnCancelar_Click" Text="Cancelar"></asp:LinkButton>
                                </div>
                                <div class="col-5">
                                    <asp:LinkButton runat="server" ID="BtnSalvar" CssClass="btn-modal-criar" OnClick="BtnSalvar_Click" Text="Salvar Alterações"></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>




                </div>
            </div>
        </div>
        <!-- MODAL -->

        <!-- EDIÇÃO DA FOTO DE PERFIL -->
        <div class="modal fade" id="editarFotoPerfil" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-dialog-centered p-md-6" role="document">
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
                                                <img class="imgEdicao" src="../../uploads/fotos/<%#Eval("pef_foto_perfil")%>" />
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
        <!-- Adicionando Javascript - API DE CEP 1 (CRIAR PARTIDA) -->
        <script type="text/javascript">

            function limpa_formulário_cep() {
                //Limpa valores do formulário de cep.
                document.getElementById('rua').value = ("");
                document.getElementById('bairro').value = ("");
                document.getElementById('cidade').value = ("");
                document.getElementById('uf').value = ("");
            }

            function meu_callback(conteudo) {
                if (!("erro" in conteudo)) {
                    //Atualiza os campos com os valores.
                    document.getElementById('rua').value = (conteudo.logradouro);
                    document.getElementById('bairro').value = (conteudo.bairro);
                    document.getElementById('cidade').value = (conteudo.localidade);
                    document.getElementById('uf').value = (conteudo.uf);
                } //end if.
                else {
                    //CEP não Encontrado.
                    limpa_formulário_cep();
                    alert("CEP não encontrado.");
                }
            }

            function pesquisacep(valor) {

                //Nova variável "cep" somente com dígitos.
                var cep = valor.replace(/\D/g, '');

                //Verifica se campo cep possui valor informado.
                if (cep != "") {

                    //Expressão regular para validar o CEP.
                    var validacep = /^[0-9]{8}$/;

                    //Valida o formato do CEP.
                    if (validacep.test(cep)) {

                        //Preenche os campos com "..." enquanto consulta webservice.
                        document.getElementById('rua').value = "...";
                        document.getElementById('bairro').value = "...";
                        document.getElementById('cidade').value = "...";
                        document.getElementById('uf').value = "...";

                        //Cria um elemento javascript.
                        var script = document.createElement('script');

                        //Sincroniza com o callback.
                        script.src = 'https://viacep.com.br/ws/' + cep + '/json/?callback=meu_callback';

                        //Insere script no documento e carrega o conteúdo.
                        document.body.appendChild(script);

                    } //end if.
                    else {
                        //cep é inválido.
                        limpa_formulário_cep();
                        alert("Formato de CEP inválido.");
                    }
                } //end if.
                else {
                    //cep sem valor, limpa formulário.
                    limpa_formulário_cep();
                }
            };

        </script>
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
        <%--<script type="text/javascript">
            function openModal() {
                $('#verMais1').modal({ show: true });
            }
        </script>--%>
        <%--<script>
            $(document).ready(function () {
                $('#verMais').modal({ show: true });
            })
        </script>--%>
        <script src="../../Scripts/jquery-3.0.0.min.js"></script>
        <script src="../../Scripts/bootstrap.min.js"></script>
        <asp:Literal runat="server" ID="lblScript"></asp:Literal>
    </main>
</asp:Content>

