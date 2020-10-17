using System;
using System.Data;
using System.Text;
using System.IO;
using System.Security.Cryptography;

public class Pef_Pessoa_FisicaBD
{
    public static int Insert(Pef_Pessoa_Fisica fisica)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = " insert into pef_pessoa_fisica(pef_foto_perfil, pef_cpf, pef_nome, pef_email, pef_senha, pef_genero, pef_data_nascimento, end_cep)";
            sql += " values ('../../img/Esportista.jpg', ?pef_cpf, ?pef_nome, ?pef_email, ?pef_senha, ?pef_genero, ?pef_data_nascimento, ?end_cep);";

            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            objCommand.Parameters.Add(Mapped.Parameter("?pef_cpf", fisica.Pef_cpf));
            objCommand.Parameters.Add(Mapped.Parameter("?pef_nome", fisica.Pef_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?pef_email", fisica.Pef_email));
            objCommand.Parameters.Add(Mapped.Parameter("?pef_senha", fisica.Pef_senha));
            objCommand.Parameters.Add(Mapped.Parameter("?pef_genero", fisica.Pef_genero));
            objCommand.Parameters.Add(Mapped.Parameter("?pef_data_nascimento", fisica.Pef_data_nascimento));
            // FK
            objCommand.Parameters.Add(Mapped.Parameter("?end_cep", fisica.End_cep.End_cep));

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
    public static int Update(Pef_Pessoa_Fisica fisica)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = "update pef_pessoa_fisica set pef_nome = ?pef_nome , pef_email = ?pef_email , ";
            sql += "pef_senha = ?pef_senha , pef_genero = ?pef_genero , pef_data_nascimento = ?pef_data_nascimento , ";
            sql += "end_cep = ?end_cep where pef_codigo = ?pef_codigo ; ";
            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            objCommand.Parameters.Add(Mapped.Parameter("?pef_nome", fisica.Pef_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?pef_email", fisica.Pef_email));
            objCommand.Parameters.Add(Mapped.Parameter("?pef_senha", fisica.Pef_senha));
            objCommand.Parameters.Add(Mapped.Parameter("?pef_genero", fisica.Pef_genero));
            objCommand.Parameters.Add(Mapped.Parameter("?pef_data_nascimento", fisica.Pef_data_nascimento));

            objCommand.Parameters.Add(Mapped.Parameter("?end_cep", fisica.End_cep.End_cep));
            objCommand.Parameters.Add(Mapped.Parameter("?pef_codigo", fisica.Pef_codigo));
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
    public static int UpdateFoto(Pef_Pessoa_Fisica fisica)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = "update pef_pessoa_fisica set pef_foto_perfil = ?pef_foto_perfil where pef_codigo = ?pef_codigo ;";

            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            objCommand.Parameters.Add(Mapped.Parameter("?pef_codigo", fisica.Pef_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?pef_foto_perfil", fisica.Pef_foto_perfil));

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


    public static DataSet SelectLogin(string email, string pwd)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataDadapter;

        objConnection = Mapped.Connection();
        string sql = "select * from pef_pessoa_fisica where pef_email = ?pef_email and pef_senha = ?pef_senha";
        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?pef_email", email));
        objCommand.Parameters.Add(Mapped.Parameter("?pef_senha", pwd));

        objDataDadapter = Mapped.Adapter(objCommand);
        objDataDadapter.Fill(ds);

        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;

    }
    public static DataSet Select(Pef_Pessoa_Fisica pef)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataDadapter;

        objConnection = Mapped.Connection();
        string sql = "select * from pef_pessoa_fisica where pef_codigo = ?pef_codigo ;";
        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?pef_codigo", pef.Pef_codigo));

        objDataDadapter = Mapped.Adapter(objCommand);
        objDataDadapter.Fill(ds);

        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;

    }
    public static int RegistroFoto(Pef_Pessoa_Fisica fisica)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConnection;
            IDbCommand objCommand;

            string sql = "update pef_pessoa_fisica set pef_foto_perfil = '?pef_foto_perfil' where pef_codigo = '?pef_codigo';";

            objConnection = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConnection);

            objCommand.Parameters.Add(Mapped.Parameter("?pef_foto_perfil", fisica.Pef_foto_perfil));
            objCommand.Parameters.Add(Mapped.Parameter("?pef_codigo", fisica.Pef_codigo));

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
    public static DataSet GetCidade(Pef_Pessoa_Fisica pef)
    {
        DataSet ds2 = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataDadapter;

        objConnection = Mapped.Connection();
        string sql = "select end_cidade from end_endereco where end_cep = ?end_cep";

        objCommand = Mapped.Command(sql, objConnection);

        objCommand.Parameters.Add(Mapped.Parameter("?end_cep", pef.End_cep.End_cep));

        objDataDadapter = Mapped.Adapter(objCommand);
        objDataDadapter.Fill(ds2);

        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds2;
    }

}