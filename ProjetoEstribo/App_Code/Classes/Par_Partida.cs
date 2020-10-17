using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Par_Partida
/// </summary>
public class Par_Partida
{
    private int par_codigo;
    private string par_nome;
    private string par_nome_local;
    private string par_data;
    private string par_horario_inicio;
    private string par_horario_termino;
    private int par_idade_minima;
    private int par_idade_maxima;
    private string par_genero_permitido;
    private int par_numero_integrantes;
    private double par_preco;
    private string par_tipo_espaco;
    private Boolean par_ativo;
    private Pef_Pessoa_Fisica pef_codigo_adm;
    private Pej_Pessoa_Juridica pej_codigo;
    private End_Endereco end_cep;
    private Esp_Esportes esp_codigo;

    public int Par_codigo
    {
        get
        {
            return par_codigo;
        }

        set
        {
            par_codigo = value;
        }
    }

    public string Par_nome
    {
        get
        {
            return par_nome;
        }

        set
        {
            par_nome = value;
        }
    }

    public string Par_nome_local
    {
        get
        {
            return par_nome_local;
        }

        set
        {
            par_nome_local = value;
        }
    }

    public string Par_data
    {
        get
        {
            return par_data;
        }

        set
        {
            par_data = value;
        }
    }

    public string Par_horario_inicio
    {
        get
        {
            return par_horario_inicio;
        }

        set
        {
            par_horario_inicio = value;
        }
    }

    public string Par_horario_termino
    {
        get
        {
            return par_horario_termino;
        }

        set
        {
            par_horario_termino = value;
        }
    }

    public int Par_idade_minima
    {
        get
        {
            return par_idade_minima;
        }

        set
        {
            par_idade_minima = value;
        }
    }

    public int Par_idade_maxima
    {
        get
        {
            return par_idade_maxima;
        }

        set
        {
            par_idade_maxima = value;
        }
    }

    public string Par_genero_permitido
    {
        get
        {
            return par_genero_permitido;
        }

        set
        {
            par_genero_permitido = value;
        }
    }

    public int Par_numero_integrantes
    {
        get
        {
            return par_numero_integrantes;
        }

        set
        {
            par_numero_integrantes = value;
        }
    }

    public double Par_preco
    {
        get
        {
            return par_preco;
        }

        set
        {
            par_preco = value;
        }
    }

    public string Par_tipo_espaco
    {
        get
        {
            return par_tipo_espaco;
        }

        set
        {
            par_tipo_espaco = value;
        }
    }

    public bool Par_ativo
    {
        get
        {
            return par_ativo;
        }

        set
        {
            par_ativo = value;
        }
    }

    public global::Pef_Pessoa_Fisica Pef_codigo_adm
    {
        get
        {
            return pef_codigo_adm;
        }

        set
        {
            pef_codigo_adm = value;
        }
    }

    public global::Pej_Pessoa_Juridica Pej_codigo
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

    public global::Esp_Esportes Esp_codigo
    {
        get
        {
            return esp_codigo;
        }

        set
        {
            esp_codigo = value;
        }
    }
}