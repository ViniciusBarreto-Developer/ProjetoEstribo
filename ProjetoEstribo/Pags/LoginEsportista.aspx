<%@ Page Title="" Language="C#" MasterPageFile="~/Pags/MasterPage.master" AutoEventWireup="true" CodeFile="LoginEsportista.aspx.cs" Inherits="Pags_LoginEsportista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../css/Login.css" rel="stylesheet" />
    <main>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="mesaCentral">
                        <img class="col-12, imgLogin" src="../img/Atleta.jpg" />
                        <div class="col-12, entradaLogin">
                            <asp:TextBox ID="LoginID" ClientIDMode="Static" required="required" placeholder="Login" Width="30%" CssClass="textbox text-center" runat="server" BackColor="" />
                        </div>
                        <div class="col-12, entradaLogin">
                            <asp:TextBox ID="SenhaID" ClientIDMode="Static" required="required" placeholder="Senha" type="password" Width="30%" CssClass="textbox text-center" runat="server" BackColor="" />
                        </div>
                        <div class="col-12">
                            <nav>
                                <ul style="list-style-type: none">
                                    <li>
                                        <a class="esquecisenha" href="CadastroEsportista.aspx">Nao tem cadastro? Crie uma conta na ESTRIBO!</a>
                                    </li>
                                    <li>
                                        <a class="esquecisenha" href="RecuperacaoSenha.aspx">Esqueceu sua senha?</a>
                                    </li>                                    
                                </ul>
                            </nav>
                        </div>
                        <div class="margens">
                            <table class="col-12">
                                <tr>
                                    <td class="col-6, text-center">
                                        <nav>
                                            <ul style="list-style-type: none">
                                                <li>
                                                    <a style="text-decoration: none" class="botaoPadrao" href="TipoLogin.aspx">Voltar</a>
                                                </li>
                                            </ul>
                                        </nav>
                                    </td>
                                    <td class="col-6, text-center">
                                        <asp:LinkButton runat="server" CssClass="botaoPadrao" Text="Login" ID="BtnLogin" OnClick="BtnLogin_Click"/>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

