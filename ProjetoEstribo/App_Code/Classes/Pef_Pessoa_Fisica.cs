using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Descrição resumida de Pef_Pessoa_Fisica
/// </summary>
public class Pef_Pessoa_Fisica
{
    private int pef_codigo;
    private long pef_cpf;
    private string pef_nome;
    private string pef_email;
    private string pef_senha;
    private string pef_genero;
    private string pef_foto_perfil;
    private string pef_data_nascimento;
    private End_Endereco end_cep;

    public int Pef_codigo
    {
        get
        {
            return pef_codigo;
        }

        set
        {
            pef_codigo = value;
        }
    }

    public long Pef_cpf
    {
        get
        {
            return pef_cpf;
        }

        set
        {
            pef_cpf = value;
        }
    }

    public string Pef_nome
    {
        get
        {
            return pef_nome;
        }

        set
        {
            pef_nome = value;
        }
    }

    public string Pef_email
    {
        get
        {
            return pef_email;
        }

        set
        {
            pef_email = value;
        }
    }

    public string Pef_senha
    {
        get
        {
            return pef_senha;
        }

        set
        {
            pef_senha = value;
        }
    }

    public string Pef_genero
    {
        get
        {
            return pef_genero;
        }

        set
        {
            pef_genero = value;
        }
    }

    public string Pef_foto_perfil
    {
        get
        {
            return pef_foto_perfil;
        }

        set
        {
            pef_foto_perfil = value;
        }
    }

    public string Pef_data_nascimento
    {
        get
        {
            return pef_data_nascimento;
        }

        set
        {
            pef_data_nascimento = value;
        }
    }

    public global::End_Endereco End_cep
    {
        get
        {
            return end_cep;
        }

        set
        {
            end_cep = value;
        }
    }
}