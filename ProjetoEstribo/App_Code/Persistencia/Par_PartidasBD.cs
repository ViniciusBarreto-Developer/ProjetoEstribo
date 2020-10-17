using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class Par_PartidasBD
{
    public static DataSet Select(int pef_codigo)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataDadapter;

        objConnection = Mapped.Connection();
        string sql = "select par_codigo, pef_codigo_adm , esp_nome, end_cidade, end_uf, end_rua, end_bairro, ";
        sql += "par_nome, par_horario_inicio, par_data, par_nome_local from pef_pessoa_fisica pef ";
        sql += "left join par_partidas par on par.pef_codigo_adm = pef.pef_codigo ";
        sql += "left join end_endereco en on en.end_cep = par.end_cep ";
        sql += "left join esp_esportes esp on esp.esp_codigo = par.esp_codigo where ";
        sql += "par.par_codigo in (select par_codigo from gpe_grupo_pessoas where pef_codigo = ?pef_codigo );";
        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?pef_codigo", pef_codigo));


        objDataDadapter = Mapped.Adapter(objCommand);
        objDataDadapter.Fill(ds);

        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    public static DataSet SelectEspCodigo(int par_codigo)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataDadapter;

        objConnection = Mapped.Connection();
        string sql = "select esp_codigo from par_partidas where par_codigo = ?par_codigo ";

        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?par_codigo", par_codigo));


        objDataDadapter = Mapped.Adapter(objCommand);
        objDataDadapter.Fill(ds);

        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    public static DataSet SelectVerMais(int par_codigo)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataDadapter;

        objConnection = Mapped.Connection();
        string sql = "select par_codigo, pef_codigo_adm, par_nome, par_nome_local, par_data, par_horario_inicio, ";
        sql += "par_horario_termino, par_idade_minima, par_idade_maxima, ";
        sql += "par_genero_permitido, par_numero_integrantes, par_preco, par_tipo_espaco, ";
        sql += "en.end_cep, par.esp_codigo, esp_nome, end_uf, end_cidade, end_bairro, ";
        sql += "end_rua from par_partidas par left join end_endereco en on en.end_cep = par.end_cep ";
        sql += "left join esp_esportes esp on esp.esp_codigo = par.esp_codigo where par_codigo = ?par_codigo;";
        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?par_codigo", par_codigo));


        objDataDadapter = Mapped.Adapter(objCommand);
        objDataDadapter.Fill(ds);

        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    public static DataSet PesquisaPartida(string esporte, string cidade, Pef_Pessoa_Fisica pef)
    {
        DataSet ds2 = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataDadapter;

        objConnection = Mapped.Connection();
        string sql = "select par_codigo, pef_codigo_adm , esp_nome, end_cidade, end_uf, end_rua, end_bairro, ";
        sql += "par_nome, par_horario_inicio, par_data, par_nome_local from pef_pessoa_fisica pef ";
        sql += "left join par_partidas par on par.pef_codigo_adm = pef.pef_codigo ";
        sql += "left join end_endereco en on en.end_cep = par.end_cep ";
        sql += "left join esp_esportes esp on esp.esp_codigo = par.esp_codigo ";
        sql += "where en.end_cidade = ?end_cidade and esp.esp_nome = ?esp_nome and ";
        sql += "par_codigo not in (select par_codigo from gpe_grupo_pessoas where pef_codigo = ?pef_codigo );";
        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?end_cidade", cidade));
        objCommand.Parameters.Add(Mapped.Parameter("?esp_nome", esporte));
        objCommand.Parameters.Add(Mapped.Parameter("?pef_codigo", pef.Pef_codigo));

        objDataDadapter = Mapped.Adapter(objCommand);
        objDataDadapter.Fill(ds2);

        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds2;
    }
    public static DataSet PesquisaDefault(string cidade, Pef_Pessoa_Fisica pef)
    {
        DataSet ds2 = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataDadapter;

        objConnection = Mapped.Connection();
        string sql = "select par_codigo, pef_codigo_adm , esp_nome, end_cidade, end_uf, end_rua, end_bairro, ";
        sql += "par_nome, par_horario_inicio, par_data, par_nome_local from pef_pessoa_fisica pef ";
        sql += "left join par_partidas par on par.pef_codigo_adm = pef.pef_codigo ";
        sql += "left join end_endereco en on en.end_cep = par.end_cep ";
        sql += "left join esp_esportes esp on esp.esp_codigo = par.esp_codigo ";
        sql += "where en.end_cidade = ?end_cidade and ";
        sql += "par_codigo not in (select par_codigo from gpe_grupo_pessoas where pef_codigo = ?pef_codigo );";
        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?end_cidade", cidade));
        objCommand.Parameters.Add(Mapped.Parameter("?pef_codigo", pef.Pef_codigo));

        objDataDadapter = Mapped.Adapter(objCommand);
        objDataDadapter.Fill(ds2);

        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds2;
    }

    public static int Insert(Par_Partida par)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = "insert into par_partidas (par_nome, par_nome_local, par_data, par_horario_inicio, par_horario_termino, par_idade_minima, par_idade_maxima, ";
            sql += "par_genero_permitido, par_numero_integrantes, par_preco, par_tipo_espaco, par_ativo, pef_codigo_adm, pej_codigo, end_cep, esp_codigo) ";
            sql += "values ( ?par_nome, ?par_nome_local, ?par_data, ?par_horario_inicio, ?par_horario_termino, ?par_idade_minima, ?par_idade_maxima,";
            sql += " ?par_genero_permitido, ?par_numero_integrantes, ?par_preco, ?par_tipo_espaco, ?par_ativo, ?pef_codigo_adm, null, ?end_cep, ?esp_codigo);";

            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            objCommand.Parameters.Add(Mapped.Parameter("?par_nome", par.Par_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?par_nome_local", par.Par_nome_local));
            objCommand.Parameters.Add(Mapped.Parameter("?par_data", par.Par_data));
            objCommand.Parameters.Add(Mapped.Parameter("?par_horario_inicio", par.Par_horario_inicio));
            objCommand.Parameters.Add(Mapped.Parameter("?par_horario_termino", par.Par_horario_termino));
            objCommand.Parameters.Add(Mapped.Parameter("?par_idade_minima", par.Par_idade_minima));
            objCommand.Parameters.Add(Mapped.Parameter("?par_idade_maxima", par.Par_idade_maxima));
            objCommand.Parameters.Add(Mapped.Parameter("?par_genero_permitido", par.Par_genero_permitido));
            objCommand.Parameters.Add(Mapped.Parameter("?par_numero_integrantes", par.Par_numero_integrantes));
            objCommand.Parameters.Add(Mapped.Parameter("?par_preco", par.Par_preco));
            objCommand.Parameters.Add(Mapped.Parameter("?par_tipo_espaco", par.Par_tipo_espaco));
            objCommand.Parameters.Add(Mapped.Parameter("?par_ativo", par.Par_ativo));
            // FK
            objCommand.Parameters.Add(Mapped.Parameter("?pef_codigo_adm", par.Pef_codigo_adm.Pef_codigo));            
            //objCommand.Parameters.Add(Mapped.Parameter("?pej_codigo", par.Pej_codigo.Pej_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?end_cep", par.End_cep.End_cep));            
            objCommand.Parameters.Add(Mapped.Parameter("?esp_codigo", par.Esp_codigo.Esp_codigo));

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
    public static int Update(Par_Partida par)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = "update par_partidas par left join end_endereco en on en.end_cep = par.end_cep ";
            sql += "left join esp_esportes esp on esp.esp_codigo = par.esp_codigo ";
            sql += "set par_nome = ?par_nome , par_nome_local = ?par_nome_local, par_data = ?par_data, ";
            sql += "par_horario_inicio = ?par_horario_inicio, par_horario_termino = ?par_horario_termino, ";
            sql += "par_idade_minima = ?par_idade_minima, par_idade_maxima = ?par_idade_maxima, ";
            sql += "par_genero_permitido = ?par_genero_permitido, par_numero_integrantes = ?par_numero_integrantes, ";
            sql += "par_preco = ?par_preco, par_tipo_espaco = ?par_tipo_espaco, en.end_cep= ?end_cep , par.esp_codigo= ?esp_codigo where par_codigo = ?par_codigo ;";

            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            objCommand.Parameters.Add(Mapped.Parameter("?par_codigo", par.Par_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?par_nome", par.Par_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?par_nome_local", par.Par_nome_local));
            objCommand.Parameters.Add(Mapped.Parameter("?par_data", par.Par_data));
            objCommand.Parameters.Add(Mapped.Parameter("?par_horario_inicio", par.Par_horario_inicio));
            objCommand.Parameters.Add(Mapped.Parameter("?par_horario_termino", par.Par_horario_termino));
            objCommand.Parameters.Add(Mapped.Parameter("?par_idade_minima", par.Par_idade_minima));
            objCommand.Parameters.Add(Mapped.Parameter("?par_idade_maxima", par.Par_idade_maxima));
            objCommand.Parameters.Add(Mapped.Parameter("?par_genero_permitido", par.Par_genero_permitido));
            objCommand.Parameters.Add(Mapped.Parameter("?par_numero_integrantes", par.Par_numero_integrantes));
            objCommand.Parameters.Add(Mapped.Parameter("?par_preco", par.Par_preco));
            objCommand.Parameters.Add(Mapped.Parameter("?par_tipo_espaco", par.Par_tipo_espaco));
            // FK
            objCommand.Parameters.Add(Mapped.Parameter("?end_cep", par.End_cep.End_cep));
            objCommand.Parameters.Add(Mapped.Parameter("?esp_codigo", par.Esp_codigo.Esp_codigo));

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
    public static int Delete(Par_Partida par)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;
            string sql = "delete from par_partidas where par_codigo = '?par_codigo';";

            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            objCommand.Parameters.Add(Mapped.Parameter("?par_codigo", par.Par_codigo));
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
    public static DataSet SelectUltimaPartidaCriada(Pef_Pessoa_Fisica pef)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataDadapter;

        objConnection = Mapped.Connection();
        string sql = "select par_codigo from par_partidas where pef_codigo_adm = ?pef_codigo order by par_codigo desc;";
     
        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?pef_codigo", pef.Pef_codigo));


        objDataDadapter = Mapped.Adapter(objCommand);
        objDataDadapter.Fill(ds);

        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

}