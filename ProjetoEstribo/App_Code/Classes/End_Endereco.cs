using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de End_Endereco
/// </summary>
public class End_Endereco
{
    private int end_cep;
    private string end_uf;
    private string end_cidade;
    private string end_bairro;
    private string end_rua;

    public int End_cep
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

    public string End_uf
    {
        get
        {
            return end_uf;
        }

        set
        {
            end_uf = value;
        }
    }

    public string End_cidade
    {
        get
        {
            return end_cidade;
        }

        set
        {
            end_cidade = value;
        }
    }

    public string End_bairro
    {
        get
        {
            return end_bairro;
        }

        set
        {
            end_bairro = value;
        }
    }

    public string End_rua
    {
        get
        {
            return end_rua;
        }

        set
        {
            end_rua = value;
        }
    }
}