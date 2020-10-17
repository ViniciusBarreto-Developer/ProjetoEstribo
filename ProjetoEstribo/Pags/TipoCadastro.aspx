<%@ Page Title="" Language="C#" MasterPageFile="~/Pags/MasterPage.master" AutoEventWireup="true" CodeFile="TipoCadastro.aspx.cs" Inherits="Pags_TipoCadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/TipodeUsuarios.css" rel="stylesheet" />
    <main>
        <div class="container">
            <div class="row">
                <table class="col-12">
                    <tr>
                        <td>
                            <a href="CadastroEsportista.aspx">
                                <div class="col-6, botaousuarios">
                                    <img class="imgtamanho" src="../img/Atleta.jpg" />
                                    <h3>Esportista</h3>
                                </div>
                            </a>
                        </td>
                        <td>
                            <a href="CadastroEspacoEsportivo.aspx">
                                <div class="col-6, botaousuarios">
                                    <img class="imgtamanho" src="../img/Quadradetenis.jpg" />
                                    <h3>Espaço Esportivo</h3>
                                </div>
                            </a>
                        </td>
                    </tr>
                </table>

            </div>
        </div>
        <div class="text-center">
            <nav class="margins">
                <div>
                    <ul style="list-style-type: none">
                        <li>
                            <a style="text-decoration: none" class="botaoVoltar" href="Principal.aspx">Voltar</a>
                        </li>
                    </ul>
                </div>
            </nav>
        </div>
    </main>
</asp:Content>

