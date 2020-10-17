<%@ Page Title="" Language="C#" MasterPageFile="~/Pags/MasterPage.master" AutoEventWireup="true" CodeFile="Erro.aspx.cs" Inherits="Pags_Erro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../css/Erro.css" rel="stylesheet" />
    <main>
        <div class="container">
            <div class="col-12, text-center">
                <img class="logoArea" src="../img/Estribo%20menor.png" />
            </div>
            <div class="col-12, text-center">
                <div class="expirada">
                    <h1>😕 Sua Sessão foi expirada 😕</h1>
                    <p>Faça o login novamente!</p>
                </div>
                <div class="botao">
                    <a class="botaoPadrao" href="TipoLogin.aspx">Login</a>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

