using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descrição resumida de Pra_PraticaBD
/// </summary>
public class Pra_PraticaBD
{
    public static DataSet SelectPraticados(Pra_Pratica pra)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataDadapter;

        objConnection = Mapped.Connection();
        string sql = "select esp_nome, esp_logo, pra.esp_codigo from pra_pratica pra inner join ";
        sql += "esp_esportes esp on esp.esp_codigo = pra.esp_codigo where pef_codigo = ?pef_codigo ;";

        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?pef_codigo", pra.Pef_codigo.Pef_codigo));


        objDataDadapter = Mapped.Adapter(objCommand);
        objDataDadapter.Fill(ds);

        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    public static DataSet SelectNaoPraticados(Pra_Pratica pra)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataDadapter;

        objConnection = Mapped.Connection();
        string sql = "select esp_nome, esp_logo, esp_codigo from esp_esportes where esp_codigo";
        sql += " not in (select esp_codigo from pra_pratica where pef_codigo = ?pef_codigo );";

        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?pef_codigo", pra.Pef_codigo.Pef_codigo));


        objDataDadapter = Mapped.Adapter(objCommand);
        objDataDadapter.Fill(ds);

        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    public static int Insert(Pra_Pratica pra)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = "INSERT INTO PRA_PRATICA (PEF_CODIGO, ESP_CODIGO, PRA_ATIVO) VALUES ( ?pef_codigo , ?esp_codigo , true );";

            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            objCommand.Parameters.Add(Mapped.Parameter("?pef_codigo", pra.Pef_codigo.Pef_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?esp_codigo", pra.Esp_codigo.Esp_codigo));

            objCommand.ExecuteNonQuery();

            objConnection.Close();
            objConnection.Dispose();
            objCommand.Dispose();

        }
        catch (Exception ex)
        {
            retorno = -2;
        }
        return retorno;

    }
    public static int Delete(Pra_Pratica pra)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = "DELETE FROM PRA_PRATICA WHERE PEF_CODIGO = ?pef_codigo AND ESP_CODIGO = ?esp_codigo ;";

            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            objCommand.Parameters.Add(Mapped.Parameter("?pef_codigo", pra.Pef_codigo.Pef_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?esp_codigo", pra.Esp_codigo.Esp_codigo));

            objCommand.ExecuteNonQuery();

            objConnection.Close();
            objConnection.Dispose();
            objCommand.Dispose();

        }
        catch (Exception ex)
        {
            retorno = -2;
        }
        return retorno;

    }
}