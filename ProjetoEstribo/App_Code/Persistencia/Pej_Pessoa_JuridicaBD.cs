using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using System.Text;
using System.IO;
using System.Security.Cryptography;
public class Pej_Pessoa_JuridicaBD
{
    public static DataSet Select(Pej_Pessoa_Juridica pej)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataDadapter;

        objConnection = Mapped.Connection();
        string sql = "select * from pej_pessoa_juridica where pej_codigo = ?pej_codigo ;";
        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?pej_codigo", pej.Pej_codigo));

        objDataDadapter = Mapped.Adapter(objCommand);
        objDataDadapter.Fill(ds);

        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;

    }
    public static int Insert(Pej_Pessoa_Juridica juridica)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = " insert into pej_pessoa_juridica(pej_foto_perfil, pej_cnpj, pej_nome_ficticio, pej_razao_social, pej_email, pej_senha, end_cep)";
            sql += " values ('../../img/EspacoEsportivo.jpg', ?pej_cnpj, ?pej_nome_ficticio, ?pej_razao_social, ?pej_email, ?pej_senha, ?end_cep);";

            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            objCommand.Parameters.Add(Mapped.Parameter("?pej_cnpj", juridica.Pej_cnpj));
            objCommand.Parameters.Add(Mapped.Parameter("?pej_nome_ficticio", juridica.Pej_nome_ficticio));
            objCommand.Parameters.Add(Mapped.Parameter("?pej_razao_social", juridica.Pej_razao_social));
            objCommand.Parameters.Add(Mapped.Parameter("?pej_email", juridica.Pej_email));
            objCommand.Parameters.Add(Mapped.Parameter("?pej_senha", juridica.Pej_senha));
            // FK
            objCommand.Parameters.Add(Mapped.Parameter("?end_cep", juridica.End_cep.End_cep));

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
    public static int UpdateFoto(Pej_Pessoa_Juridica pej)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = "update pej_pessoa_juridica set pej_foto_perfil = ?pej_foto_perfil where pej_codigo = ?pej_codigo ;";

            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            objCommand.Parameters.Add(Mapped.Parameter("?pej_codigo", pej.Pej_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?pej_foto_perfil", pej.Pej_foto_perfil));

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
    public static int Update(Pej_Pessoa_Juridica juridica)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = "update pej_pessoa_juridica set pej_nome_ficticio = ?pej_nome_ficticio , pej_razao_social =  ?pej_razao_social , ";
            sql += "pej_email = ?pej_email , pej_senha = ?pej_senha , end_cep = ?end_cep ";
            sql += "where pej_codigo = ?pej_codigo ;";

            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            objCommand.Parameters.Add(Mapped.Parameter("?pej_nome_ficticio", juridica.Pej_nome_ficticio));
            objCommand.Parameters.Add(Mapped.Parameter("?pej_razao_social", juridica.Pej_razao_social));
            objCommand.Parameters.Add(Mapped.Parameter("?pej_email", juridica.Pej_email));
            objCommand.Parameters.Add(Mapped.Parameter("?pej_senha", juridica.Pej_senha));
            // FK
            objCommand.Parameters.Add(Mapped.Parameter("?end_cep", juridica.End_cep.End_cep));
            objCommand.Parameters.Add(Mapped.Parameter("?pej_codigo", juridica.Pej_codigo));

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
    public static string PWD(string senha)
    {
        UnicodeEncoding UE = new UnicodeEncoding();
        byte[] HashValue, MessageBytes = UE.GetBytes(senha);
        SHA512Managed SHhash = new SHA512Managed();
        string strHex = "";

        HashValue = SHhash.ComputeHash(MessageBytes);
        foreach (byte b in HashValue)
        {
            strHex += String.Format("{0:x2}", b);
        }
        return strHex;
    }


    public static DataSet SelectLogin(string cnpj, string pwd)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataDadapter;

        objConnection = Mapped.Connection();
        string sql = "select * from pej_pessoa_juridica where pej_cnpj = ?pej_cnpj and pej_senha = ?pej_senha";
        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?pej_cnpj", cnpj));
        objCommand.Parameters.Add(Mapped.Parameter("?pej_senha", pwd));

        objDataDadapter = Mapped.Adapter(objCommand);
        objDataDadapter.Fill(ds);

        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;

    }
    public static DataSet GetEndereco(int cep)
    {
        DataSet ds2 = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataDadapter;

        objConnection = Mapped.Connection();
        string sql = "select end_cidade, end_uf from end_endereco where end_cep = ?end_cep";

        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?end_cep", cep));

        objDataDadapter = Mapped.Adapter(objCommand);
        objDataDadapter.Fill(ds2);

        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds2;
    }

}