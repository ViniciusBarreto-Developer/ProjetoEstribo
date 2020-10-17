using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Fot_Fotos
/// </summary>
public class Fot_Fotos
{
    private int fot_codigo;
    private string fot_foto;
    private Pej_Pessoa_Juridica pej_codigo;

    public int Fot_codigo
    {
        get
        {
            return fot_codigo;
        }

        set
        {
            fot_codigo = value;
        }
    }

    public string Fot_foto
    {
        get
        {
            return fot_foto;
        }

        set
        {
            fot_foto = value;
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