using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Pra_Pratica
/// </summary>
public class Pra_Pratica
{
    private Boolean pra_ativo;
    private Esp_Esportes esp_codigo;
    private Pef_Pessoa_Fisica pef_codigo;

    public bool Pra_ativo
    {
        get
        {
            return pra_ativo;
        }

        set
        {
            pra_ativo = value;
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