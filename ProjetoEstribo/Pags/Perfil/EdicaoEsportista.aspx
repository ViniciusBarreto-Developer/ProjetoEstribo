<%@ Page Title="" Language="C#" MasterPageFile="~/Pags/Perfil/MasterPerfil.master" AutoEventWireup="true" CodeFile="EdicaoEsportista.aspx.cs" Inherits="Pags_Perfil_EdicaoEsportista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../css/PerfilEspaco.css" rel="stylesheet" />
    <link href="../../css/PerfilEsportista.css" rel="stylesheet" />
    <link href="../../css/Login.css" rel="stylesheet" />

    <main class="container">
        <div class="row">            
            <div class="col-12">
                <br />
                <br />
                <h3 class="text-center">Adicione os esportes que você pratica ou tem interesse!</h3>
                <br />
                <br />
                <table class="margemBaixo">
                    <tr>
                        <td>
                            <section>
                                <div>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <h4 class="nomeOutros">Todos os Esportes:</h4>
                                            </td>
                                        </tr>
                                    </table>
                                    <div data-spy="scroll" data-target="#navbarVertical" data-offset="0" class="TodosEventos">
                                        <div runat="server" id="cardCheio">
                                            <div class="container">
                                                <div class="row">
                                                    <asp:Repeater runat="server" ID="rptCard">
                                                        <itemtemplate>
                                                                    <div class="col-3">
                                                                        <div class="MargemEventos">
                                                                            <div class="eventosDesc">
                                                                                <h5 class="nomeEvento"></h5>
                                                                                <h6 class="nomeEvento">ESPORTE:  <%#Eval("esp_nome") %> </h6>
                                                                            </div>
                                                                        </div>
                                                                        <div class="text-center">
                                                                            <div class="text-center">
                                                                                <div class="text-center">
                                                                                    <asp:Button runat="server" ID="BtnAdicionar"
                                                                                        CommandArgument='<%#Eval("esp_codigo")%>' OnClick="BtnAdicionar_Click"
                                                                                        Style="text-decoration: none" CssClass="botaoAdd" Text="Adicionar"></asp:Button>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </itemtemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                            <table style="width: 100%;" class="Eventos">
                                                <tr>
                                                    <td>
                                                        <div class="row">
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <!-- CARD QUANDO NÃO SOBRA NENHUM ESPORTE -->
                                        <div class="row">
                                            <div runat="server" class="col-12" id="cardVazio">
                                                <div class="MargemEventos">
                                                    <div class="eventosDesc">
                                                        <h5 class="nomeEvento text-center">VOCÊ ADICIONOU TODOS OS ESPORTES DISPONÍVEIS!! :)</h5>
                                                        <h6></h6>
                                                        <h6 class="nomeEvento"></h6>

                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td>
                                                                    <h5 class="text-center"></h5>
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
                                                <h4 class="nomeOutros">Meus Esportes:</h4>
                                            </td>
                                        </tr>
                                    </table>
                                    <div data-spy="scroll" data-target="#navbarVertical" data-offset="0" class="TodosEventos">
                                        <div runat="server" id="PesquisaCheia">
                                            <table style="width: 100%;" class="Eventos">
                                                <tr>
                                                    <td>
                                                        <div class="row">
                                                            <asp:Repeater runat="server" ID="rptCard2">
                                                                <itemtemplate>
                                                                    <div class="col-3">
                                                                        <div class="MargemEventos">
                                                                            <div class="eventosDesc">
                                                                                <h5 class="nomeEvento"></h5>
                                                                                <h6 class="nomeEvento">ESPORTE:  <%#Eval("esp_nome") %> </h6>
                                                                            </div>
                                                                        </div>
                                                                        <div class="text-center">
                                                                            <asp:Button runat="server" ID="BtnRemover" Text="Remover" OnClick="BtnRemover_Click"
                                                                                CommandArgument='<%#Eval("esp_codigo") %>'
                                                                                Style="text-decoration: none" CssClass="botaoAdd"></asp:Button>
                                                                        </div>
                                                                    </div>
                                                                </itemtemplate>
                                                            </asp:Repeater>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <!--CARD QUANDO O ESPORTISTA NÃO CADASTROU NENHUM ESPORTE-->
                                        <div class="row">
                                            <div runat="server" class="col-12" id="PesquisaVazia">
                                                <div class="MargemEventos">
                                                    <div class="eventosDesc">
                                                        <h5 class="nomeEvento text-center">INFELIZMENTE NÃO ENCONTRAMOS NADA :(</h5>
                                                        <h6></h6>
                                                        <h6 class="nomeEvento"></h6>

                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td>
                                                                    <h5 class="text-center">ADICIONE UM ESPORTE ;) </h5>
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
                            <div class="margens">
                                <table class="col-12">
                                    <tr>
                                        <td class="col-6, text-center">
                                            <asp:LinkButton runat="server" href="EsportistaPerfil.aspx" CssClass="botaoPadrao" Text="Concluir" ID="BtnLogin" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <script src="../../Scripts/jquery-3.0.0.min.js"></script>
        <script src="../../Scripts/bootstrap.min.js"></script>
    </main>
</asp:Content>

