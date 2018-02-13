using System;
using System.Collections.Generic;
using System.Data;
using TiendaVirtual.Entidades;

namespace TiendaVirtual.AccesoDatos
{
    public class DaoUsuarioSqlServer : IDaoUsuario
    {
        private string connectionString = @"Data Source=PC-JAVIERLETE\SQLEXPRESS12;
                    Initial Catalog=tiendavirtual;Integrated Security=True";

        public void Alta(IUsuario usuario)
        {
            using (IDbConnection con = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                //"Zona declarativa"
                con.Open();

                IDbCommand comInsert = con.CreateCommand();

                comInsert.CommandText = 
                    "INSERT INTO usuarios (Nick, Password) VALUES (@Nick, @Password)";

                IDbDataParameter parNick = comInsert.CreateParameter();
                parNick.ParameterName = "Nick";
                parNick.DbType = DbType.String;

                IDbDataParameter parPassword = comInsert.CreateParameter();
                parPassword.ParameterName = "Password";
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
