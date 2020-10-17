using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class Eve_EventosBD
{
    public static DataSet Select(Eve_Eventos eve)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataDadapter;

        objConnection = Mapped.Connection();
        string sql = "select * from eve_eventos where eve_codigo = ?eve_codigo ;";

        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?eve_codigo", eve.Eve_codigo));

        objDataDadapter = Mapped.Adapter(objCommand);
        objDataDadapter.Fill(ds);

        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;

    }
    public static DataSet SelectEsporte(int eve_codigo)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataDadapter;

        objConnection = Mapped.Connection();
        string sql = "select esp_nome, esp.esp_codigo from esp_esportes esp left join eve_eventos eve ";
        sql += "on esp.esp_codigo = eve.esp_codigo where eve_codigo = ?eve_codigo ;";

        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?eve_codigo", eve_codigo));

        objDataDadapter = Mapped.Adapter(objCommand);
        objDataDadapter.Fill(ds);

        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;

    }
    public static DataSet SelectEventosLocal(Pej_Pessoa_Juridica pej)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataDadapter;

        objConnection = Mapped.Connection();
        string sql = "select eve_codigo, esp_nome, end_rua, end_bairro, end_uf, end_cidade, eve_nome, ";
        sql += "eve_horario_inicio, eve_horario_termino, eve_data, pej_nome_ficticio from eve_eventos eve ";
        sql += "left join esp_esportes esp on esp.esp_codigo = eve.esp_codigo ";
        sql += "left join pej_pessoa_juridica pej on pej.pej_codigo = eve.pej_codigo ";
        sql += "left join end_endereco en on en.end_cep = pej.end_cep where pej.pej_codigo = ?pej_codigo and eve.eve_ativo = true ";

        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?pej_codigo", pej.Pej_codigo));

        objDataDadapter = Mapped.Adapter(objCommand);
        objDataDadapter.Fill(ds);

        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;

    }

    public static DataSet SelectHistoricoEventos(Pej_Pessoa_Juridica pej)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataDadapter;

        objConnection = Mapped.Connection();
        string sql = "select eve_codigo, esp_nome, end_rua, end_bairro, end_uf, end_cidade, eve_nome, ";
        sql += "eve_horario_inicio, eve_horario_termino, eve_data, pej_nome_ficticio from eve_eventos eve ";
        sql += "left join esp_esportes esp on esp.esp_codigo = eve.esp_codigo ";
        sql += "left join pej_pessoa_juridica pej on pej.pej_codigo = eve.pej_codigo ";
        sql += "left join end_endereco en on en.end_cep = pej.end_cep where pej.pej_codigo = ?pej_codigo and eve.eve_ativo = false ";

        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?pej_codigo", pej.Pej_codigo));

        objDataDadapter = Mapped.Adapter(objCommand);
        objDataDadapter.Fill(ds);

        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;

    }

    public static int Insert(Eve_Eventos eve)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = "insert into eve_eventos (eve_nome, eve_data, eve_horario_inicio, eve_horario_termino, ";
            sql += "eve_idade_minima, eve_idade_maxima, eve_genero_permitido, eve_numero_integrantes, eve_preco, ";
            sql += "eve_entidade, eve_ativo, eve_status, eve_descricao, pej_codigo, esp_codigo) ";
            sql += "values (?eve_nome, ?eve_data, ?eve_horario_inicio, ?eve_horario_termino, ?eve_idade_minima, ";
            sql += "?eve_idade_maxima, ?eve_genero_permitido, ?eve_numero_integrantes, ?eve_preco, ?eve_entidade, ";
            sql += "?eve_ativo, ?eve_status, ?eve_descricao, ?pej_codigo, ?esp_codigo);";

            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            objCommand.Parameters.Add(Mapped.Parameter("?eve_nome", eve.Eve_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?eve_data", eve.Eve_data));
            objCommand.Parameters.Add(Mapped.Parameter("?eve_horario_inicio", eve.Eve_horario_inicio));
            objCommand.Parameters.Add(Mapped.Parameter("?eve_horario_termino", eve.Eve_horario_termino));
            objCommand.Parameters.Add(Mapped.Parameter("?eve_idade_minima", eve.Eve_idade_minima));
            objCommand.Parameters.Add(Mapped.Parameter("?eve_idade_maxima", eve.Eve_idade_maxima));
            objCommand.Parameters.Add(Mapped.Parameter("?eve_genero_permitido", eve.Eve_genero_permitido));
            objCommand.Parameters.Add(Mapped.Parameter("?eve_numero_integrantes", eve.Eve_numero_integrantes));
            objCommand.Parameters.Add(Mapped.Parameter("?eve_preco", eve.Eve_preco));
            objCommand.Parameters.Add(Mapped.Parameter("?eve_entidade", eve.Eve_entidade));
            objCommand.Parameters.Add(Mapped.Parameter("?eve_ativo", eve.Eve_ativo));
            objCommand.Parameters.Add(Mapped.Parameter("?eve_status", eve.Eve_status));
            objCommand.Parameters.Add(Mapped.Parameter("?eve_descricao", eve.Eve_descricao));

            // FK
            objCommand.Parameters.Add(Mapped.Parameter("?pej_codigo", eve.Pej_codigo.Pej_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?esp_codigo", eve.Esp_codigo.Esp_codigo));

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

    public static int Delete(Eve_Eventos eve)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;
            string sql = "delete from eve_eventos where eve_codigo = ?eve_codigo ;";

            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            objCommand.Parameters.Add(Mapped.Parameter("?eve_codigo", eve.Eve_codigo));

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
    public static int Update(Eve_Eventos eve)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = "update eve_eventos set eve_nome = ?eve_nome , eve_data = ?eve_data , ";
            sql += "eve_horario_inicio = ?eve_horario_inicio , eve_horario_termino = ?eve_horario_termino , ";
            sql += "eve_idade_minima = ?eve_idade_minima , eve_idade_maxima = ?eve_idade_maxima , ";
            sql += "eve_genero_permitido = ?eve_genero_permitido , eve_numero_integrantes = ?eve_numero_integrantes , ";
            sql += "eve_preco = ?eve_preco , eve_entidade = ?eve_entidade , eve_descricao = ?eve_descricao , ";
            sql += "eve_ativo = ?eve_ativo , eve_status = ?eve_status , esp_codigo = ?esp_codigo  where eve_codigo = ?eve_codigo ;";

            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            objCommand.Parameters.Add(Mapped.Parameter("?eve_nome", eve.Eve_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?eve_data", eve.Eve_data));
            objCommand.Parameters.Add(Mapped.Parameter("?eve_horario_inicio", eve.Eve_horario_inicio));
            objCommand.Parameters.Add(Mapped.Parameter("?eve_horario_termino", eve.Eve_horario_termino));
            objCommand.Parameters.Add(Mapped.Parameter("?eve_idade_minima", eve.Eve_idade_minima));
            objCommand.Parameters.Add(Mapped.Parameter("?eve_idade_maxima", eve.Eve_idade_maxima));
            objCommand.Parameters.Add(Mapped.Parameter("?eve_genero_permitido", eve.Eve_genero_permitido));
            objCommand.Parameters.Add(Mapped.Parameter("?eve_numero_integrantes", eve.Eve_numero_integrantes));
            objCommand.Parameters.Add(Mapped.Parameter("?eve_preco", eve.Eve_preco));
            objCommand.Parameters.Add(Mapped.Parameter("?eve_entidade", eve.Eve_entidade));
            objCommand.Parameters.Add(Mapped.Parameter("?eve_descricao", eve.Eve_descricao));
            objCommand.Parameters.Add(Mapped.Parameter("?eve_ativo", eve.Eve_ativo));
            objCommand.Parameters.Add(Mapped.Parameter("?eve_status", eve.Eve_status));
            objCommand.Parameters.Add(Mapped.Parameter("?esp_codigo", eve.Esp_codigo.Esp_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?eve_codigo", eve.Eve_codigo));

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