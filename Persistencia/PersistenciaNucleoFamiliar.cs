using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PersistenciaNucleoFamiliar : IPersistenciaNucleoFamiliar
    {
        private static PersistenciaNucleoFamiliar _instancia = null;
        private PersistenciaNucleoFamiliar() { }
        public static PersistenciaNucleoFamiliar GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaNucleoFamiliar();
            return _instancia;
        }

        public bool AltaNucleoFamiliar(NucleoFamiliar nf, Usuario _usu)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("alta_nucleofamiliar", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SocId", nf.SocId);
            cmd.Parameters.AddWithValue("@NFCI", nf.NFCI);
            cmd.Parameters.AddWithValue("@NFPrimerApellido", nf.NFPrimerApellido);
            cmd.Parameters.AddWithValue("@NFSegundoApellido", nf.NFSegundoApellido);
            cmd.Parameters.AddWithValue("@NFPrimerNombre", nf.NFPrimerNombre);
            cmd.Parameters.AddWithValue("@NFSegundoNombre", nf.NFSegundoNombre);
            cmd.Parameters.AddWithValue("@NFFechaNacimiento", nf.NFFechaNacimiento);
            cmd.Parameters.AddWithValue("@NFTipoVinculo", nf.NfTipoVinculo); 
            cmd.Parameters.AddWithValue("@NFTel", nf.NFTel);
            cmd.Parameters.AddWithValue("@NFCelular", nf.NFCelular);
            cmd.Parameters.AddWithValue("@NFObservaciones", nf.NFobservaciones);
            cmd.Parameters.AddWithValue("@FecAlta", nf.FecAlta);
            cmd.Parameters.AddWithValue("@UsuIdAlta", nf.UsuIdAlta);
            //cmd.Parameters.Add("@SocId", SqlDbType.Int).Direction = ParameterDirection.Output;

            SqlParameter prmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            prmRetorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(prmRetorno);

            int resp = -1;
            int Id;
            bool respuesta = false;

            SqlTransaction tran = null;
            try
            {
                cnn.Open();
                tran = cnn.BeginTransaction();
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();

                resp = (int)cmd.Parameters["@Retorno"].Value;
                if (resp == -1)
                    throw new Exception("Existe socio con este documento.");
                else if (resp == -2)
                    throw new Exception("Problema al guardar el socio.");

                tran.Commit();
                respuesta = true;

                return respuesta;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<Socio> ListarSocios()
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand _comando = new SqlCommand("listar_socios_todos", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            List<Socio> _ListaSocios = null;

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();

                if (_lector.HasRows)
                {
                    _ListaSocios = new List<Socio>();
                    while (_lector.Read())
                    {
                        Socio s = null;
                        s = new Socio();
                        s.SocId = (int)_lector["SocId"];
                        s.SocCI = (int)_lector["SocCI"];
                        s.SocPrimerNombre = (string)_lector["SocPrimerNombre"];
                        s.SocPrimerApellido = (string)_lector["SocPrimerApellido"];
                        s.SocSegundoNombre = (string)_lector["SocSegundoNombre"];
                        s.SocSegundoApellido = (string)_lector["SocSegundoApellido"];
                        s.SocDireccion = (string)_lector["SocDireccion"];
                        s.SocFechaIngreso = (DateTime)_lector["SocFechaIngreso"];
                        s.SocDireccion = (string)_lector["SocDireccion"];
                        s.SocEmail = (string)_lector["SocEmail"];
                        s.SocAtivo = (bool)_lector["SocAtivo"];
                        s.SocTel = (string)_lector["SocTel"];
                        s.SocCelular = (string)_lector["SocCelular"];
                        s.SocTipoCuota = (int)_lector["SocTipoCuota"];
                        s.SocObservaciones = (string)_lector["SocObservaciones"];
                        s.SocFechaIngreso = (DateTime)_lector["SocFechaIngreso"];
                        s.SocFechaNacimiento = (DateTime)_lector["SocFechaNacimiento"];

                        _ListaSocios.Add(s);
                    }
                }
                _lector.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
            return _ListaSocios;
        }
        public List<NucleoFamiliar> BuscarNucleoFamiliarPorCI(int socId)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand _comando = new SqlCommand("buscar_nf", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            NucleoFamiliar c = new NucleoFamiliar();
            List<NucleoFamiliar> s = new List<NucleoFamiliar>();

            try
            {
                if (string.IsNullOrEmpty(socId.ToString()))
                    throw new Exception("Ingrese número de documento.");
                else
                    _comando.Parameters.AddWithValue("@Documento", socId);

                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    s = new List<NucleoFamiliar>();
                    while (_lector.Read())
                    {
                        c = new NucleoFamiliar();
                        c.SocId = (int)_lector["SocId"];
                        c.NFCI = (int)_lector["NFCI"];
                        c.NFPrimerNombre = (string)_lector["NFPrimerNombre"];
                        c.NFPrimerApellido = (string)_lector["NFPrimerApellido"];
                        c.NFSegundoNombre = (string)_lector["NFSegundoNombre"];
                        c.NFSegundoApellido = (string)_lector["NFSegundoApellido"]; 
                        c.NfTipoVinculo = (string)_lector["NFTipoVinculo"];
                        c.NFTel = (string)_lector["NFTel"];
                        c.NFCelular = (string)_lector["NFCelular"];
                        c.NFobservaciones = (string)_lector["NFObservaciones"];
                        c.NFFechaNacimiento = (DateTime)_lector["NFFechaNacimiento"];
                        c.NFId = (int)_lector["NFId"];
                        s.Add(c);
                    }
                }

                _lector.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
            return s;
        }
        public bool ModificarNF(NucleoFamiliar s, Usuario _usu)
        {

            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("modificar_nf", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", s.NFId);
            cmd.Parameters.AddWithValue("@NFCI", s.NFCI);
            cmd.Parameters.AddWithValue("@SocId", s.SocId);
            cmd.Parameters.AddWithValue("@NFPrimerApellido", s.NFPrimerApellido);
            cmd.Parameters.AddWithValue("@NFSegundoApellido", s.NFSegundoNombre);
            cmd.Parameters.AddWithValue("@NFPrimerNombre", s.NFPrimerNombre);
            cmd.Parameters.AddWithValue("@NFSegundoNombre", s.NFSegundoApellido);
            cmd.Parameters.AddWithValue("@NFTipoVinculo", s.NfTipoVinculo); 
            cmd.Parameters.AddWithValue("@NFTel", s.NFTel);
            cmd.Parameters.AddWithValue("@NFCelular", s.NFCelular);
            cmd.Parameters.AddWithValue("@NFObservaciones", s.NFobservaciones);
            cmd.Parameters.AddWithValue("@NFFechaNacimiento", s.NFFechaNacimiento);
            cmd.Parameters.AddWithValue("@FecModif", s.FecModif);
            cmd.Parameters.AddWithValue("@UsuIdModif", s.UsuIdModif);
            cmd.Parameters.Add("@NFId", SqlDbType.Int).Direction = ParameterDirection.Output;

            SqlParameter prmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            prmRetorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(prmRetorno);

            int resp = -1;
            int Id;
            bool respuesta = false;

            SqlTransaction tran = null;
            try
            {
                cnn.Open();
                tran = cnn.BeginTransaction();
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();

                resp = (int)cmd.Parameters["@Retorno"].Value;
                if (resp == -1)
                    throw new Exception("No existe un socio con este documento.");
                else if (resp == -2)
                    throw new Exception("Problema al modificar la informacion.");
                else if (resp == -3)
                    throw new Exception("Problema al modificar la informacion .");
                else if (resp == 1)
                {
                    tran.Commit();
                    respuesta = true;
                }

                return respuesta;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }
        public bool BajaNF(int s)
        {
            bool res = false;
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("baja_nf", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NFId", s);
            SqlParameter prmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            prmRetorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(prmRetorno);
            int resp = -1;

            SqlTransaction tran = null;
            try
            {
                cnn.Open();
                tran = cnn.BeginTransaction();
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                resp = (int)cmd.Parameters["@Retorno"].Value;
                if (resp != 1)
                    throw new Exception("Error al dar de baja el/la integrante.");
                else if (resp == 1)
                {
                    tran.Commit();
                    res = true;
                }
                return res;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }
    }
}
