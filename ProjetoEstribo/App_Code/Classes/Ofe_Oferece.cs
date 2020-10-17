using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Ofe_Oferece
/// </summary>
public class Ofe_Oferece
{
    private Boolean ofe_ativo;
    private Esp_Esportes esp_codigo;
    private Pej_Pessoa_Juridica pej_codigo;

    public bool Ofe_ativo
    {
        get
        {
            return ofe_ativo;
        }

        set
        {
            ofe_ativo = value;
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
}