<%@ Page Title="" Language="C#" MasterPageFile="~/Pags/Perfil/MasterPerfil.master" AutoEventWireup="true" CodeFile="EditarDadosEsportista.aspx.cs" Inherits="Pags_Perfil_EditarDadosEsportista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../../css/CadastroUsuarios.css" rel="stylesheet" />
    <main>
        <section class="SecaoCadastro">
            <div class="container">
                <div class="row">
                    <div class="col-7">
                        <asp:Label CssClass="CadastroInfos" runat="server">Nome Completo: </asp:Label>
                        <asp:TextBox ID="txtNome" ClientIDMode="Static" required="required" Width="65%" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-5">
                        <asp:Label CssClass="CadastroInfos" runat="server">Senha: </asp:Label>
                        <asp:TextBox ID="txtSenha" ClientIDMode="Static" required="required" type="password" Width="80%" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-12">&nbsp</div>
                    <div class="col-7">
                        <asp:Label CssClass="CadastroInfos" runat="server">Email: </asp:Label>
                        <asp:TextBox ID="txtEmail" ClientIDMode="Static" required="required" Width="84%" type="email" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-5">
                        <asp:Label CssClass="CadastroInfos" runat="server">CPF: </asp:Label>
                        <asp:TextBox ID="txtCPF" ClientIDMode="Static" required="required" type="number" Width="85%" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-12">&nbsp</div>
                    <div class="col-7">
                        <asp:Label CssClass="CadastroInfos" runat="server">Data de Nascimento: </asp:Label>
                        <asp:TextBox ID="txtDataNascimento" ClientIDMode="Static" required="required" type="date" Width="40%" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-5">
                        <asp:Label CssClass="CadastroInfos" runat="server">Gênero</asp:Label>
                        <asp:DropDownList ID="ddlGenero" runat="server" ClientIDMode="Static" repeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="Masculino">Masculino</asp:ListItem>
                            <asp:ListItem Value="Feminino">Feminino</asp:ListItem>
                            <asp:ListItem Value="Outro">Outro</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-12">&nbsp</div>
                    <hr style="width: 80%;">
                    <div class="col-4">
                        <asp:Label CssClass="CadastroInfos" runat="server">CEP: </asp:Label>
                        <asp:TextBox ID="cep" ClientIDMode="Static" Width="70%" runat="server" onblur="pesquisacep(this.value);"></asp:TextBox>
                    </div>
                    <div class="col-5">
                        <asp:Label CssClass="CadastroInfos" runat="server">Cidade: </asp:Label>
                        <asp:TextBox ID="cidade" ClientIDMode="Static" Width="70%" runat="server" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-3">
                        <asp:Label CssClass="CadastroInfos" runat="server">UF: </asp:Label>
                        <asp:TextBox ID="uf" ClientIDMode="Static" Width="70%" runat="server" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-12">&nbsp</div>
                    <div class="col-4">
                        <asp:Label CssClass="CadastroInfos" Width="20%" runat="server">Bairro: </asp:Label>
                        <asp:TextBox ID="bairro" ClientIDMode="Static" Width="70%" runat="server" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-8">
                        <asp:Label CssClass="CadastroInfos" runat="server">Rua: </asp:Label>
                        <asp:TextBox ID="rua" ClientIDMode="Static" Width="70%" runat="server" Enabled="false"></asp:TextBox>
                    </div>
                </div>
            </div>
        </section>
        <div class="espacobaixo">
            <section class="container">
                <div class="row">
                    <div class="col-6">
                        <div>
                            <nav class="text-center">
                                <ul style="list-style-type: none">
                                    <li>
                                        <a style="text-decoration: none" class="botaoEnviar" href="EsportistaPerfil.aspx">Cancelar</a>
                                    </li>
                                </ul>
                            </nav>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="text-center">
                            <asp:LinkButton runat="server" CssClass="botaoEnviar" OnClick="BtnSalvar_Click" ID="BtnSalvar" Text="Salvar" />
                        </div>
                    </div>
                </div>
            </section>
        </div>

        <div class="row mt-5">
            <div class="col-12">
                <asp:Literal runat="server" ID="ltl"></asp:Literal>
            </div>

        </div>
        <!-- Adicionando Javascript -->
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
        <script src="../Scripts/jquery-3.5.1.min.js"></script>
        <script src="../Scripts/bootstrap.min.js"></script>
    </main>
</asp:Content>

