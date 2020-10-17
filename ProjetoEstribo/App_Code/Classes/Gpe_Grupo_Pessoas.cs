using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Gpe_Grupo_Pessoas
/// </summary>
public class Gpe_Grupo_Pessoas
{
    private Boolean gpe_ativo;
    private Par_Partida par_codigo;
    private Pef_Pessoa_Fisica pef_codigo;

    public bool Gpe_ativo
    {
        get
        {
            return gpe_ativo;
        }

        set
        {
            gpe_ativo = value;
        }
    }

    public global::Par_Partida Par_codigo
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