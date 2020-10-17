using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Eve_Eventos
/// </summary>
public class Eve_Eventos
{
    private int eve_codigo;
    private string eve_nome;
    private string eve_data;
    private string eve_horario_inicio;
    private string eve_horario_termino;
    private int eve_idade_minima;
    private int eve_idade_maxima;
    private string eve_genero_permitido;
    private int eve_numero_integrantes;
    private double eve_preco;
    private string eve_entidade;
    private string eve_descricao;
    private string eve_status;
    private Boolean eve_ativo;
    private Pej_Pessoa_Juridica pej_codigo;
    private Esp_Esportes esp_codigo;

    public int Eve_codigo
    {
        get
        {
            return eve_codigo;
        }

        set
        {
            eve_codigo = value;
        }
    }

    public string Eve_nome
    {
        get
        {
            return eve_nome;
        }

        set
        {
            eve_nome = value;
        }
    }

    public string Eve_data
    {
        get
        {
            return eve_data;
        }

        set
        {
            eve_data = value;
        }
    }

    public string Eve_horario_inicio
    {
        get
        {
            return eve_horario_inicio;
        }

        set
        {
            eve_horario_inicio = value;
        }
    }

    public string Eve_horario_termino
    {
        get
        {
            return eve_horario_termino;
        }

        set
        {
            eve_horario_termino = value;
        }
    }

    public int Eve_idade_minima
    {
        get
        {
            return eve_idade_minima;
        }

        set
        {
            eve_idade_minima = value;
        }
    }

    public int Eve_idade_maxima
    {
        get
        {
            return eve_idade_maxima;
        }

        set
        {
            eve_idade_maxima = value;
        }
    }

    public string Eve_genero_permitido
    {
        get
        {
            return eve_genero_permitido;
        }

        set
        {
            eve_genero_permitido = value;
        }
    }

    public int Eve_numero_integrantes
    {
        get
        {
            return eve_numero_integrantes;
        }

        set
        {
            eve_numero_integrantes = value;
        }
    }

    public double Eve_preco
    {
        get
        {
            return eve_preco;
        }

        set
        {
            eve_preco = value;
        }
    }

    public string Eve_entidade
    {
        get
        {
            return eve_entidade;
        }

        set
        {
            eve_entidade = value;
        }
    }

    public string Eve_descricao
    {
        get
        {
            return eve_descricao;
        }

        set
        {
            eve_descricao = value;
        }
    }

    public string Eve_status
    {
        get
        {
            return eve_status;
        }

        set
        {
            eve_status = value;
        }
    }

    public bool Eve_ativo
    {
        get
        {
            return eve_ativo;
        }

        set
        {
            eve_ativo = value;
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