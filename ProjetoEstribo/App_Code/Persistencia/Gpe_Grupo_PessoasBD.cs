using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;    

/// <summary>
/// Descrição resumida de Gpe_Grupo_PessoasBD
/// </summary>
public class Gpe_Grupo_PessoasBD
{
    public static DataSet Select(string par_codigo)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataDadapter;

        objConnection = Mapped.Connection();
        string sql = "select pef.pef_foto_perfil, pef.pef_codigo, pef.pef_nome from gpe_grupo_pessoas gpe inner join pef_pessoa_fisica pef ";
        sql += "on pef.pef_codigo = gpe.pef_codigo where gpe.par_codigo =  ?par_codigo ;";

        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?par_codigo", par_codigo));

        objDataDadapter = Mapped.Adapter(objCommand);
        objDataDadapter.Fill(ds);

        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    public static int Insert(int par_codigo, int pef_codigo)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = "insert into gpe_grupo_pessoas (gpe_ativo, par_codigo, pef_codigo) ";
            sql += "values (true, ?par_codigo, ?pef_codigo);";

            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            //objCommand.Parameters.Add(Mapped.Parameter("?gpe_ativo", gpe.Gpe_ativo));
            // FK
            objCommand.Parameters.Add(Mapped.Parameter("?par_codigo", par_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?pef_codigo", pef_codigo));

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
    public static int Delete(int par_codigo, int pef_codigo)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;
            string sql = "delete from gpe_grupo_pessoas where pef_codigo = ?pef_codigo and par_codigo = ?par_codigo ;";

            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);
            
            objCommand.Parameters.Add(Mapped.Parameter("?pef_codigo", pef_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?par_codigo", par_codigo));

            objCommand.ExecuteNonQuery();
            objConnection.Close();
            objCommand.Dispose();
            objConnection.Dispose();
        }
        catch (Exception ex)
        {
            retorno = -2;
        }
        return retorno;
    }

}