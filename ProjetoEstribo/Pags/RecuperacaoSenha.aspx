<%@ Page Title="" Language="C#" MasterPageFile="~/Pags/MasterPage.master" AutoEventWireup="true" CodeFile="RecuperacaoSenha.aspx.cs" Inherits="Pags_RecuperacaoSenha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../css/CadastroUsuarios.css" rel="stylesheet" />
    <main>
        <section class="SecaoCadastro">
            <div class="container">
                <h3>Insira seu e-mail de cadastro que enviaremos um código de alteração.</h3>
                <div class="col-12">&nbsp</div>
                <div class="row">
                    <div class="col-6">
                        <asp:Label CssClass="CadastroInfos" runat="server">Email: </asp:Label>
                        <asp:TextBox ID="Email" ClientIDMode="Static" required="required" Width="85%" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-6">
                        <table class="alinha">
                            <tr>
                                <td class="col-6, text-center">
                                    <asp:LinkButton runat="server" CssClass="botaoEnviar" ID="teste1" Text="Enviar" />
                                    <!-- <nav>
                                        <ul style="list-style-type: none">
                                            <li>
                                                <a style="text-decoration: none" class="botaoPadraoP" href="EscolhaUsuarioLogin.aspx">Enviar</a>
                                            </li>
                                        </ul>
                                    </nav> -->
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="col-3">
                        <asp:Label CssClass="CadastroInfos" runat="server">Código: </asp:Label>
                        <asp:TextBox ID="Senha" ClientIDMode="Static" required="required" Width="60%" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-12">&nbsp</div>
                <div class="col-12">&nbsp</div>
                <div class="col-12">&nbsp</div>
                <div class="row">
                    <div class="col-6">
                        <asp:Label CssClass="CadastroInfos" runat="server">Nova Senha: </asp:Label>
                        <asp:TextBox ID="TextBox1" ClientIDMode="Static" required="required" Width="60%" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-6">
                    </div>
                    <div class="col-7">
                        <asp:Label CssClass="CadastroInfos" runat="server">Confirmar Senha: </asp:Label>
                        <asp:TextBox ID="TextBox2" ClientIDMode="Static" required="required" Width="50%" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
        </section>

        <div class="espacobaixo">
            <section class="container">
                <div class="row">
                    <table class="col-12">
                        <tr>
                            <td class="col-6, text-center">
                                <nav>
                                    <ul style="list-style-type: none">
                                        <li>
                                            <a style="text-decoration: none" class="botaoEnviar" href="TipoLogin.aspx">Cancelar</a>
                                        </li>
                                    </ul>
                                </nav>
                            </td>
                            <td class="col-6, text-center">
                                <nav>
                                    <ul style="list-style-type: none">
                                        <li>
                                            <asp:LinkButton runat="server" CssClass="botaoEnviar" ID="LinkButton2" Text="Enviar" />
                                        </li>
                                    </ul>
                                </nav>
                            </td>
                        </tr>
                    </table>
                </div>
            </section>
        </div>
    </main>
</asp:Content>

