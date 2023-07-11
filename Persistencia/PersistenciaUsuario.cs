using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    internal class PersistenciaUsuario : IPersistenciaUsuario
    {
        private static PersistenciaUsuario _miInstancia;
        private PersistenciaUsuario() { }
        public static PersistenciaUsuario GetInstancia()
        {
            if (_miInstancia == null)
                _miInstancia = new PersistenciaUsuario();
            return (_miInstancia);
        }

        public Usuario Login(string _Usuario, string _Password)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand _comando = new SqlCommand("login", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            Usuario U = null;

            try
            {
                if (string.IsNullOrEmpty(_Usuario.ToString()))
                    throw new Exception("Ingrese usuario.");
                else
                    _comando.Parameters.AddWithValue("@usuario", _Usuario);

                if (string.IsNullOrEmpty(_Password.ToString()))
                    throw new Exception("Ingrese contraseña.");
                else
                {
                    _comando.Parameters.AddWithValue("@pass", _Password);
                }

                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();

                if (_lector.HasRows)
                {
                    _lector.Read();
                    int usuId = (int)_lector["UsuId"];
                    string usuClaveAcceso = (string)_lector["UsuClaveAcceso"].ToString().Trim();
                    string usuNombre = (string)_lector["UsuNombre"].ToString().Trim();
                    string usuPass = (string)_lector["UsuPass"].ToString().Trim();
                    bool usuActivo = (bool)_lector["UsuActivo"];

                    if ((usuClaveAcceso == _Usuario) && (usuPass == _Password))
                    {
                        U = new Usuario((int)_lector["UsuId"], (string)_lector["UsuClaveAcceso"].ToString().Trim(), (string)_lector["UsuPass"].ToString().Trim(),
                            (string)_lector["UsuNombre"].ToString().Trim(), (bool)_lector["UsuActivo"]);
                    }
                    else
                        U = null;
                }
                else
                {
                    _lector.Close();
                    throw new Exception("Usuario o contraseña incorrecto.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
            return U;
        }
    }
}
