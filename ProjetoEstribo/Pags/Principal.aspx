<%@ Page Title="" Language="C#" MasterPageFile="~/Pags/MasterPage.master" AutoEventWireup="true" CodeFile="Principal.aspx.cs" Inherits="Pags_Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main>
        <link href="../css/Entrar.css" rel="stylesheet" />
        <div class="fundoEsportes">
            <div class="container">
                <div class="row, blcbemvindo">
                    <div>
                        <div class="col-12">
                            <h1>Na Estribo você pratica esportes com pessoas incríveis 
                            </h1>
                            <h1 class="text2">Faça parte e vamos juntos
                            </h1>
                        </div>

                        <table class="col-12">
                            <tr>
                                <td class="col-6, text-center">
                                    <nav>
                                        <ul style="list-style-type: none">
                                            <li>
                                                <a style="text-decoration: none" class="botaoPadrao" href="TipoLogin.aspx">Login</a>
                                            </li>
                                        </ul>
                                    </nav>
                                </td>
                                <td class="col-6, text-center">
                                    <nav>
                                        <ul style="list-style-type: none">
                                            <li>
                                                <a style="text-decoration: none" class="botaoPadrao" href="TipoCadastro.aspx">Cadastrar</a>
                                            </li>
                                        </ul>
                                    </nav>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <table>
                        <tr>
                            <td class="espacamentos">
                                <h3>Ei, Esportista! </h3>
                                <p>
                                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                                Maecenas interdum molestie enim non molestie. In ut nisi vehicula,
                                maximus eros vel, malesuada mi. Sed quis quam tempor, eleifend purus nec,
                                ultrices neque. Cras efficitur ex ut tempor tincidunt. Maecenas vehicula neque massa.
                                Interdum et malesuada fames ac ante ipsum primis in faucibus. Nunc urna velit, pulvinar at tortor in,
                                rhoncus pellentesque lacus. Cras interdum tincidunt urna scelerisque pellentesque. Fusce aliquet pulvinar ligula.
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td class="espacamentos">
                                <h3>Ei, Espaço esportivo! </h3>
                                <p>
                                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                                Maecenas interdum molestie enim non molestie. In ut nisi vehicula,
                                maximus eros vel, malesuada mi. Sed quis quam tempor, eleifend purus nec,
                                ultrices neque. Cras efficitur ex ut tempor tincidunt. Maecenas vehicula neque massa.
                                Interdum et malesuada fames ac ante ipsum primis in faucibus. Nunc urna velit, pulvinar at tortor in,
                                rhoncus pellentesque lacus. Cras interdum tincidunt urna scelerisque pellentesque. Fusce aliquet pulvinar ligula.
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center" class="espacamentos">
                                <h3>Vamos Juntos!</h3>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

