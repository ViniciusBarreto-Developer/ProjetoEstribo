using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Con_Contatos
/// </summary>
public class Con_Contatos
{
    private int con_codigo;
    private string con_tipo;
    private string con_contato;
    private string con_logo;
    private Pej_Pessoa_Juridica pej_codigo;

    public int Con_codigo
    {
        get
        {
            return con_codigo;
        }

        set
        {
            con_codigo = value;
        }
    }

    public string Con_tipo
    {
        get
        {
            return con_tipo;
        }

        set
        {
            con_tipo = value;
        }
    }

    public string Con_contato
    {
        get
        {
            return con_contato;
        }

        set
        {
            con_contato = value;
        }
    }

    public string Con_logo
    {
        get
        {
            return con_logo;
        }

        set
        {
            con_logo = value;
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