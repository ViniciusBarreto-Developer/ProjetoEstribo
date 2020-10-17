using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Ami_Amizade
/// </summary>
public class Ami_Amizade
{
    private int ami_codigo;
    private Boolean ami_ativo;
    private DateTime ami_data_inicio;
    private DateTime ami_data_termino;
    private Pef_Pessoa_Fisica pef_codigo_amigo;
    private Pef_Pessoa_Fisica pef_codigo;

    public int Ami_codigo
    {
        get
        {
            return ami_codigo;
        }

        set
        {
            ami_codigo = value;
        }
    }

    public bool Ami_ativo
    {
        get
        {
            return ami_ativo;
        }

        set
        {
            ami_ativo = value;
        }
    }

    public DateTime Ami_data_inicio
    {
        get
        {
            return ami_data_inicio;
        }

        set
        {
            ami_data_inicio = value;
        }
    }

    public DateTime Ami_data_termino
    {
        get
        {
            return ami_data_termino;
        }

        set
        {
            ami_data_termino = value;
        }
    }

    public global::Pef_Pessoa_Fisica Pef_codigo_amigo
    {
        get
        {
            return pef_codigo_amigo;
        }

        set
        {
            pef_codigo_amigo = value;
        }
    }

    public global::Pef_Pessoa_Fisica Pef_codigo
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
}