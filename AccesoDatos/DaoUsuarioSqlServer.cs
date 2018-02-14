using System;
using System.Collections.Generic;
using System.Data;
using TiendaVirtual.Entidades;

namespace TiendaVirtual.AccesoDatos
{
    public class DaoUsuarioSqlServer : IDaoUsuario
    {
        private const string SQL_INSERT = "INSERT INTO usuarios (Nick, Contra) VALUES (@Nick, @Pass)";
        private const string SQL_DELETE = "DELETE FROM usuarios WHERE Id=@Id";
        private const string SQL_UPDATE = "UPDATE usuarios SET Nick=@Nick,Contra=@Pass WHERE Id=@Id";

        private string connectionString;

        public DaoUsuarioSqlServer(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Alta(IUsuario usuario)
        {
            try
            {
                using (IDbConnection con = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    //"Zona declarativa"
                    con.Open();

                    IDbCommand comInsert = con.CreateCommand();

                    comInsert.CommandText = SQL_INSERT;

                    IDbDataParameter parNick = comInsert.CreateParameter();
                    parNick.ParameterName = "Nick";
                    parNick.DbType = DbType.String;

                    IDbDataParameter parPassword = comInsert.CreateParameter();
                    parPassword.ParameterName = "Pass";
                    parPassword.DbType = DbType.String;

                    comInsert.Parameters.Add(parNick);
                    comInsert.Parameters.Add(parPassword);

                    //"Zona concreta"
                    parNick.Value = usuario.Nick;
                    parPassword.Value = usuario.Password;

                    int numRegistrosInsertados = comInsert.ExecuteNonQuery();

                    if (numRegistrosInsertados != 1)
                        throw new AccesoDatosException("Número de registros insertados: " +
                            numRegistrosInsertados);
                }
            }
            catch (Exception e)
            {
                throw new AccesoDatosException("No se ha podido realizar el alta", e);
            }
        }

        public void Baja(IUsuario usuario)
        {
            Baja(usuario.Id);
        }

        public void Baja(int id)
        {
            try
            {
                using (IDbConnection con = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    //"Zona declarativa"
                    con.Open();

                    IDbCommand comDelete = con.CreateCommand();

                    comDelete.CommandText = SQL_DELETE;

                    IDbDataParameter parId = comDelete.CreateParameter();
                    parId.ParameterName = "Id";
                    parId.DbType = DbType.Int32;

                    comDelete.Parameters.Add(parId);

                    //"Zona concreta"
                    parId.Value = id;

                    int numRegistrosBorrados = comDelete.ExecuteNonQuery();

                    if (numRegistrosBorrados != 1)
                        throw new AccesoDatosException("Número de registros borrados: " +
                            numRegistrosBorrados);
                }
            }
            catch (Exception e)
            {
                throw new AccesoDatosException("No se ha podido realizar el borrado", e);
            }
        }

        public IUsuario BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IUsuario BuscarPorNick(string nick)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IUsuario> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public void Modificacion(IUsuario usuario)
        {
            try
            {
                using (IDbConnection con = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    //"Zona declarativa"
                    con.Open();

                    IDbCommand comUpdate = con.CreateCommand();

                    comUpdate.CommandText = SQL_UPDATE;

                    IDbDataParameter parId = comUpdate.CreateParameter();
                    parId.ParameterName = "Id";
                    parId.DbType = DbType.Int32;

                    IDbDataParameter parNick = comUpdate.CreateParameter();
                    parNick.ParameterName = "Nick";
                    parNick.DbType = DbType.String;

                    IDbDataParameter parPassword = comUpdate.CreateParameter();
                    parPassword.ParameterName = "Pass";
                    parPassword.DbType = DbType.String;

                    comUpdate.Parameters.Add(parId);
                    comUpdate.Parameters.Add(parNick);
                    comUpdate.Parameters.Add(parPassword);

                    //"Zona concreta"
                    parId.Value = usuario.Id;
                    parNick.Value = usuario.Nick;
                    parPassword.Value = usuario.Password;

                    int numRegistrosModificados = comUpdate.ExecuteNonQuery();

                    if (numRegistrosModificados != 1)
                        throw new AccesoDatosException("Número de registros modificados: " +
                            numRegistrosModificados);
                }
            }
            catch (Exception e)
            {
                throw new AccesoDatosException("No se ha podido realizar la modificación", e);
            }
        }
    }
}
