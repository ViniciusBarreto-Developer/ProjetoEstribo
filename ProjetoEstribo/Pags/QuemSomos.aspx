<%@ Page Title="" Language="C#" MasterPageFile="~/Pags/MasterPage.master" AutoEventWireup="true" CodeFile="QuemSomos.aspx.cs" Inherits="Pags_QuemSomos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../css/QuemSomos.css" rel="stylesheet" />
    <main>
        <section>
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <table style="width: 100%;" class="MesasDadosEstribo">
                            <tr>
                                <td style="width: 33%;" class="ContDados">
                                    <div class="BordaDados">
                                        <div>
                                            <h3 class="NomeDados">O Que</h3>
                                        </div>
                                        <div>
                                            <p>
                                                A Estribo é um site que permite a todos tipos de pessoas que desejam praticar esportes  em conjunto encontrar pessoas incríveis com interesses em 
                                                comum para montar sua equipe.
                                                Podendo, também, encontrar espaços esportivos perfeitos para sua partida.
                                            </p>
                                        </div>
                                    </div>
                                </td>
                                <td style="width: 33%;" class="ContDados">
                                    <div class="BordaDados">
                                        <div>
                                            <h3 class="NomeDados">Como</h3>
                                        </div>
                                        <div>
                                            <p>
                                                Ao se cadastrar o esportista poderá criar suas próprias partidas definindo esporte, local, data... e assim convidar pessoas para participar  e ou aguardar que interessados ingressem em sua partida. 
                                               Igualmente podendo ingressar e receber o convite de partidas criadas por outros esportistas
                                            </p>
                                        </div>
                                    </div>
                                </td>
                                <td style="width: 33%;" class="ContDados">
                                    <div class="BordaDados">
                                        <div>
                                            <h3 class="NomeDados">PorQuê</h3>
                                        </div>
                                        <div>
                                            <p>
                                                Acreditamos no poder do contato humano e da motivação que exercemos sobre os outros,
                                                sobretudo em exercitar-se para conquistar uma boa qualidade de vida, e por isso a Estribo contribui na saúde física e mental para uma vida saudável 
                                                e cheia de aventuras.
                                            </p>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <table style="width: 100%;">
                            <tr class="FundoImg">
                                <td style="width: 70%;">
                                    <div class="TextoSobreNos">
                                        <p>
                                            Estribos são verdadeiras escadas com degraus alternados que servem para serem fixadas em algum dispositivo de apoio numa escalada, em geral utiliza-se um par que vai sendo alternado na progressão entre pontos de apoio na rocha. Muito utilizado em conquistas e vias de escalada em progressão artificial. 
                                            Por isso aqui na Estribo você nunca está sozinho, sempre com apoio que precisa para praticar esportes e ter uma vida cheia de aventuras.
                                        </p>
                                    </div>
                                </td>
                                <td style="width: 30%;">
                                    <img src="../../img/Estribo%20menor.png" />
                                </td>
                            </tr>
                        </table>
                        <div class="Contatenos">
                            <h3 class="textoContate">Contate-nos</h3>
                            <p>Clique em enviar para ser redirecionado ao seu e-mail e nos enviar uma mensagem.</p>
                            <nav>
                                <ul class="text-center" style="list-style-type: none">
                                    <li>
                                        <img class="IcoAviao" src="../../img/icones/aviao.png" />
                                        <a style="text-decoration: none" class="botaoPadrao" href="#.aspx">Enviar</a>
                                    </li>
                                </ul>
                            </nav>
                        </div>
                        <div style="width: 100%;">
                            <h3 style="font-weight: bold;">Equipe</h3>
                            <br />
                            <table>
                                <tr>
                                    <td class="text-center">
                                        <img class="ImgEquipe" style="width: 60%;" src="../../img/Equipe/Thales.png" />
                                        <h5 style="font-weight: bold;">@Thales</h5>
                                    </td>
                                    <td class="text-center">
                                        <img class="ImgEquipe" style="width: 60%;" src="../../img/Equipe/Isa.png" />
                                        <h5 style="font-weight: bold;">@Isabelly</h5>
                                    </td>
                                    <td class="text-center">
                                        <img class="ImgEquipe" style="width: 60%" src="../../img/Equipe/Olba.png" />
                                        <h5 style="font-weight: bold;">@Violba</h5>
                                    </td>
                                    <td class="text-center">
                                        <img class="ImgEquipe" style="width: 60%" src="../../img/Equipe/Marcilio.png" />
                                        <h5 style="font-weight: bold;">@Marcílio</h5>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </main>
</asp:Content>

