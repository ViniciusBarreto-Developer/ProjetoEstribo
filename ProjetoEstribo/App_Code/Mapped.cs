using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Importar
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Descrição resumida de Mapped
/// </summary>
public class Mapped
{
   public static IDbConnection Connection()
    {
        MySqlConnection objConexao = new MySqlConnection(ConfigurationManager.AppSettings["strConexao"]);
        objConexao.Open();
        return objConexao;
    }

    public static IDbCommand Command(string query, IDbConnection objConexao)
    {
        IDbCommand command = objConexao.CreateCommand();
        command.CommandText = query;
        return command;
    }

    public static IDataAdapter Adapter(IDbCommand command)
    {
        IDbDataAdapter adap = new MySqlDataAdapter();
        adap.SelectCommand = command;
        return adap;
    }

    public static IDbDataParameter Parameter(string nomeDoParamentro, object valor)
    {
        return new MySqlParameter(nomeDoParamentro, valor);
    }
}