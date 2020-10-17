using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Esp_Esportes
/// </summary>
public class Esp_Esportes
{
    private int esp_codigo;
    private string esp_nome;
    private string esp_logo;

    public int Esp_codigo
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

    public string Esp_nome
    {
        get
        {
            return esp_nome;
        }

        set
        {
            esp_nome = value;
        }
    }

    public string Esp_logo
    {
        get
        {
            return esp_logo;
        }

        set
        {
            esp_logo = value;
        }
    }
}