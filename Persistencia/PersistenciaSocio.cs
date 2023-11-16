using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PersistenciaSocio : IPersistenciaSocio
    {
        private static PersistenciaSocio _instancia = null;
        private PersistenciaSocio() { }
        public static PersistenciaSocio GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaSocio();
            return _instancia;
        }

        #region SOCIO
        public bool AltaSocio(Socio s, Cuota c, Usuario _usu)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("alta_socio", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SocCI", s.SocCI);
            cmd.Parameters.AddWithValue("@SocPrimerApellido", s.SocPrimerApellido);
            cmd.Parameters.AddWithValue("@SocSegundoApellido", s.SocSegundoApellido);
            cmd.Parameters.AddWithValue("@SocPrimerNombre", s.SocPrimerNombre);
            cmd.Parameters.AddWithValue("@SocSegundoNombre", s.SocSegundoNombre);
            cmd.Parameters.AddWithValue("@SocFechaNacimiento", s.SocFechaNacimiento);
            cmd.Parameters.AddWithValue("@SocDireccion", s.SocDireccion);
            cmd.Parameters.AddWithValue("@SocTel", s.SocTel);
            cmd.Parameters.AddWithValue("@SocCelular", s.SocCelular);
            cmd.Parameters.AddWithValue("@SocEmail", s.SocEmail);
            cmd.Parameters.AddWithValue("@SocObservaciones", s.SocObservaciones);
            cmd.Parameters.AddWithValue("@SocAtivo", s.SocAtivo);
            cmd.Parameters.AddWithValue("@SocFechaIngreso", s.SocFechaIngreso);
            cmd.Parameters.AddWithValue("@SocTipoCuota", s.SocTipoCuota);
            //cmd.Parameters.AddWithValue("@SocFechaEgreso", s.SocFechaEgreso);
            //cmd.Parameters.AddWithValue("@SocMotivoEgreso", s.SocMotivoEgreso);
            cmd.Parameters.AddWithValue("@FecAlta", s.FecAlta);
            cmd.Parameters.AddWithValue("@FecModif", s.FecModif);
            cmd.Parameters.AddWithValue("@UsuIdModif", s.UsuIdModif);
            cmd.Parameters.AddWithValue("@UsuIdAlta", s.UsuIdAlta);
            cmd.Parameters.Add("@SocId", SqlDbType.Int).Direction = ParameterDirection.Output;

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
                else if (resp == 1)
                {
                    Id = (int)cmd.Parameters["@SocId"].Value;
                    c.SocId = Id;
                }

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
        public Socio BuscarSocioPorCI(int _ci)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand _comando = new SqlCommand("buscar_socio_x_cedula", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            Socio s = null;

            try
            {
                if (string.IsNullOrEmpty(_ci.ToString()))
                    throw new Exception("Ingrese número de documento.");
                else
                    _comando.Parameters.AddWithValue("@Documento", _ci);

                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
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
                        //s.ListaMascotas = FabricaPersistencia.getPersistenciaMascota().ListarMascotasPorSocio((int)_lector["Id"]);
                        //s.Cuenta = FabricaPersistencia.getPersistenciaCuentaSocio().BuscarCuentaXSocio((int)_lector["Id"]);
                        //s.ListaCuotas = FabricaPersistencia.getPersistenciaCuotaSocio().ListarCuotaSocio_PorId((int)_lector["Id"]);
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
        public List<Socio> ListarSocios()
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand _comando = new SqlCommand("listar_socios_todos", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            List<Socio> _ListaSocios = new List<Socio>();

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
                        //s.ListaMascotas = FabricaPersistencia.getPersistenciaMascota().ListarMascotasPorSocio((int)_lector["Id"]);
                        //s.Cuenta = FabricaPersistencia.getPersistenciaCuentaSocio().BuscarCuentaXSocio((int)_lector["Id"]);
                        //s.ListaCuotas = FabricaPersistencia.getPersistenciaCuotaSocio().ListarCuotaSocio_PorId((int)_lector["Id"]);

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
        public bool ModificarSocio(Socio s, Usuario _usu)
        {

            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("modificar_socio", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SocCI", s.SocCI);
            cmd.Parameters.AddWithValue("@SocPrimerApellido", s.SocPrimerApellido);
            cmd.Parameters.AddWithValue("@SocSegundoApellido", s.SocSegundoApellido);
            cmd.Parameters.AddWithValue("@SocPrimerNombre", s.SocPrimerNombre);
            cmd.Parameters.AddWithValue("@SocSegundoNombre", s.SocSegundoNombre);
            cmd.Parameters.AddWithValue("@SocDireccion", s.SocDireccion);
            cmd.Parameters.AddWithValue("@SocTel", s.SocTel);
            cmd.Parameters.AddWithValue("@SocCelular", s.SocCelular);
            cmd.Parameters.AddWithValue("@SocEmail", s.SocEmail);
            cmd.Parameters.AddWithValue("@SocObservaciones", s.SocObservaciones);
            cmd.Parameters.AddWithValue("@SocTipoCuota", s.SocTipoCuota);
            cmd.Parameters.AddWithValue("@UsuIdModif", _usu.UsuId);
            cmd.Parameters.Add("@SocId", SqlDbType.Int).Direction = ParameterDirection.Output;

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
                    throw new Exception("El número de socio ingresado no existe.");
                else if (resp == -3)
                    throw new Exception("Problema al guardar la persona.");
                else if (resp == -4)
                    throw new Exception("Problema al guardar el socio.");
                else if (resp == 1)
                {
                    //Id = (int)cmd.Parameters["@SocCI"].Value;
                    //PersistenciaCuota.ModificarCuota(s.SocCI, s.SocTipoCuota, _usu);

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
        public bool ActivarSocio(Socio s, Usuario _usu)
        {

            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("activar_socio", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SocCI", s.SocCI);
            cmd.Parameters.AddWithValue("@UsuIdModif", _usu.UsuId);
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
                    throw new Exception("No existe un socio con este documento.");
                else if (resp == -2)
                    throw new Exception("El número de socio ingresado no existe.");
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
        public bool BajaSocio(Socio s, Usuario _usu)
        {
            bool res = false;
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("baja_socio", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SocCI", s.SocCI);
            cmd.Parameters.AddWithValue("@SocFechaEgreso", s.SocFechaEgreso);
            cmd.Parameters.AddWithValue("@SocMotivoEgreso", s.SocMotivoEgreso);
            cmd.Parameters.AddWithValue("@UsuIdModif", _usu.UsuId);
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
                {
                    throw new Exception("Error al dar de baja el Socio.");
                }
                else
                {
                    tran.Commit();
                    res = true;
                    return res;
                }
            }
            catch (Exception ex)
            {
                //    throw new ApplicationException(ex.Message);
                //}
                tran.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }
        #endregion

        #region TIPOCUOTA
        public List<TipoCuota> ListarTC()
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand _comando = new SqlCommand("listar_tipoCuota", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            List<TipoCuota> _ListaTC = new List<TipoCuota>();

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();

                if (_lector.HasRows)
                {
                    _ListaTC = new List<TipoCuota>();
                    while (_lector.Read())
                    {
                        TipoCuota tc = new TipoCuota();
                        tc.TCId = (int)_lector["TCId"];
                        tc.TCDescripcion = (string)_lector["TCDescripcion"];
                        tc.TCMonto = (int)_lector["TCMonto"];
                        tc.FecAlta = (DateTime)_lector["FecAlta"];
                        tc.FecModif = (DateTime)_lector["FecModif"];
                        tc.UsuIdAlta = (int)_lector["UsuIdAlta"];
                        tc.UsuIdModif = (int)_lector["UsuIdModif"];
                        _ListaTC.Add(tc);
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
            return _ListaTC;
        }
        #endregion
    }
}