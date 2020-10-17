using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Pej_Pessoa_Juridica
/// </summary>
public class Pej_Pessoa_Juridica
{
    private int pej_codigo;
    private long pej_cnpj;
    private string pej_nome_ficticio;
    private string pej_razao_social;
    private string pej_email;
    private string pej_senha;
    private string pej_horario_funcionamento;
    private string pej_foto_perfil;
    private End_Endereco end_cep;

    public int Pej_codigo
    {
        get
        {
            return pej_codigo;
        }

        set
        {
            pej_codigo = value;
        }
    }

    public long Pej_cnpj
    {
        get
        {
            return pej_cnpj;
        }

        set
        {
            pej_cnpj = value;
        }
    }

    public string Pej_nome_ficticio
    {
        get
        {
            return pej_nome_ficticio;
        }

        set
        {
            pej_nome_ficticio = value;
        }
    }

    public string Pej_razao_social
    {
        get
        {
            return pej_razao_social;
        }

        set
        {
            pej_razao_social = value;
        }
    }

    public string Pej_email
    {
        get
        {
            return pej_email;
        }

        set
        {
            pej_email = value;
        }
    }

    public string Pej_senha
    {
        get
        {
            return pej_senha;
        }

        set
        {
            pej_senha = value;
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

    public string Pej_horario_funcionamento
    {
        get
        {
            return pej_horario_funcionamento;
        }

        set
        {
            pej_horario_funcionamento = value;
        }
    }

    public string Pej_foto_perfil
    {
        get
        {
            return pej_foto_perfil;
        }

        set
        {
            pej_foto_perfil = value;
        }
    }
}