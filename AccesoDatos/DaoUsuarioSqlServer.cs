using System;
using System.Collections.Generic;
using System.Data;
using TiendaVirtual.Entidades;

namespace TiendaVirtual.AccesoDatos
{
    public class DaoUsuarioSqlServer : IDaoUsuario
    {
        private const string SQL_INSERT = "INSERT INTO usuarios (Nick, Contra) VALUES (@Nick, @Pass)";

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

                    int numRegistrosModificados = comInsert.ExecuteNonQuery();

                    if (numRegistrosModificados != 1)
                        throw new AccesoDatosException("Número de registros insertados: " +
                            numRegistrosModificados);
                }
            }
            catch (Exception e)
            {
                throw new AccesoDatosException("No se ha podido realizar el alta", e);
            }
        }

        public void Baja(IUsuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Baja(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
