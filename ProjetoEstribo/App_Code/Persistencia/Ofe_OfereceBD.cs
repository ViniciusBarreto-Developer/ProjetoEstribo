using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Descrição resumida de Ofe_OfereceBD
/// </summary>
public class Ofe_OfereceBD
{
    public static DataSet SelectOferecidos(Ofe_Oferece ofe)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataDadapter;

        objConnection = Mapped.Connection();
        string sql = "select esp_nome, esp_logo, ofe.esp_codigo from ofe_oferece ofe inner join ";
        sql += "esp_esportes esp on esp.esp_codigo = ofe.esp_codigo where pej_codigo = ?pej_codigo ;";

        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?pej_codigo", ofe.Pej_codigo.Pej_codigo));


        objDataDadapter = Mapped.Adapter(objCommand);
        objDataDadapter.Fill(ds);

        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    public static DataSet SelectNaoOferecidos(Ofe_Oferece ofe)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataDadapter;

        objConnection = Mapped.Connection();
        string sql = "select esp_nome, esp_codigo from esp_esportes where esp_codigo";
        sql += " not in (select esp_codigo from ofe_oferece where pej_codigo = ?pej_codigo );";

        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?pej_codigo", ofe.Pej_codigo.Pej_codigo));


        objDataDadapter = Mapped.Adapter(objCommand);
        objDataDadapter.Fill(ds);

        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    public static int Insert(Ofe_Oferece ofe)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = "INSERT INTO OFE_OFERECE (PEJ_CODIGO, ESP_CODIGO, OFE_ATIVO) VALUES ( ?pej_codigo, ?esp_codigo, true);";

            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            objCommand.Parameters.Add(Mapped.Parameter("?pej_codigo", ofe.Pej_codigo.Pej_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?esp_codigo", ofe.Esp_codigo.Esp_codigo));

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
    public static int Delete(Ofe_Oferece ofe)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = "DELETE FROM OFE_OFERECE WHERE PEJ_CODIGO = ?pej_codigo AND ESP_CODIGO = ?esp_codigo ;";

            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            objCommand.Parameters.Add(Mapped.Parameter("?pej_codigo", ofe.Pej_codigo.Pej_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?esp_codigo", ofe.Esp_codigo.Esp_codigo));

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