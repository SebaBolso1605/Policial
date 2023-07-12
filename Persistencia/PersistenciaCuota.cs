using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaCuota : IPersistenciaCuota
    {
        private static PersistenciaCuota _instancia = null;
        private PersistenciaCuota() { }
        public static PersistenciaCuota GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaCuota();
            return _instancia;
        }

        public bool AltaCuota(TipoCuota _c, Usuario _usu)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("alta_TC", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TCDescripcion", _c.TCDescripcion);
            cmd.Parameters.AddWithValue("@TCMonto", _c.TCMonto);
            cmd.Parameters.AddWithValue("@UsuIdAlta", _usu.UsuId);

            SqlParameter prmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            prmRetorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(prmRetorno);
            bool respuesta = false;
            int resp = -1;
            int Id;
            SqlTransaction tran = null;
            try
            {
                cnn.Open();
                tran = cnn.BeginTransaction();
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                resp = (int)cmd.Parameters["@Retorno"].Value;
                if (resp == -1)
                    throw new Exception("Ya existe tipo de cuota.");
                else if (resp == -2)
                    throw new Exception("Ocurrió un problema al insertar tipo de cuota.");

                tran.Commit();
                respuesta = true;

                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }
        public bool ModificarCuota(TipoCuota _c, Usuario _usu)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("modificar_TC", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", _c.TCId);
            cmd.Parameters.AddWithValue("@TCDescripcion", _c.TCDescripcion);
            cmd.Parameters.AddWithValue("@TCMonto", _c.TCMonto);
            cmd.Parameters.AddWithValue("@UsuIdModif", _usu.UsuId);

            SqlParameter prmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            prmRetorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(prmRetorno);
            bool respuesta = false;
            int resp = -1;
            int Id;
            SqlTransaction tran = null;
            try
            {
                cnn.Open();
                tran = cnn.BeginTransaction();
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                resp = (int)cmd.Parameters["@Retorno"].Value;
                if (resp == -1)
                    throw new Exception("Ya existe tipo de cuota.");
                else if (resp == -2)
                    throw new Exception("Ocurrió un problema al insertar tipo de cuota.");

                tran.Commit();
                respuesta = true;

                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }
        public bool BajarCuota(int _c, Usuario _usu)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("baja_TC", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", _c);
            cmd.Parameters.AddWithValue("@UsuIdModif", _usu.UsuId);

            SqlParameter prmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            prmRetorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(prmRetorno);
            bool respuesta = false;
            int resp = -1;
            int Id;
            SqlTransaction tran = null;
            try
            {
                cnn.Open();
                tran = cnn.BeginTransaction();
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                resp = (int)cmd.Parameters["@Retorno"].Value;
                if (resp == -1)
                    throw new Exception("Ya existe tipo de cuota.");
                else if (resp == -2)
                    throw new Exception("Ocurrió un problema al insertar tipo de cuota.");

                tran.Commit();
                respuesta = true;

                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }
        public bool AltaCuentaSocio(Cuota _c, Usuario _usu)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("alta_cuenta_socio", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SocId", _c.SocId);
            cmd.Parameters.AddWithValue("@CuotaFechaDesde", _c.CuotaFechaDesde);
            cmd.Parameters.AddWithValue("@CuotaTipo", _c.CuotaTipo);
            cmd.Parameters.AddWithValue("@CuotaPaga", _c.CuotaPaga);
            if (_c.CuotaPaga)
                cmd.Parameters.AddWithValue("@CuotaFechaPaga", _c.CuotaFechaPaga);
            else
                cmd.Parameters.AddWithValue("@CuotaFechaPaga", DBNull.Value);
            cmd.Parameters.AddWithValue("@CuotaAAAAMM", _c.CuotaAAAAMM);
            
            cmd.Parameters.AddWithValue("@UsuIdAlta", _usu.UsuId);
            cmd.Parameters.Add("@CuotaId", SqlDbType.Int).Direction = ParameterDirection.Output;

            SqlParameter prmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            prmRetorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(prmRetorno);
            bool respuesta = false;
            int resp = -1;
            int Id;
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
                    throw new Exception("Ocurrió un problema al insertar la cuenta.");

                tran.Commit();
                respuesta = true;

                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }
        internal static bool ModificarCuota(int socId, int tipoCuota, Usuario _usu)
        {

            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("modificar_cuota", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SocId", socId); 
            cmd.Parameters.AddWithValue("@CuotaTipo", tipoCuota);
            cmd.Parameters.AddWithValue("@UsuIdModif", _usu);
            cmd.Parameters.Add("@CuotaId", SqlDbType.Int).Direction = ParameterDirection.Output;

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
        public List<Cuota> BuscarCuotasSocio(int socId)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand _comando = new SqlCommand("buscar_cuotaSocio", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            Cuota c = new Cuota();
            List<Cuota> s = null;

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
                    s = new List<Cuota>();
                    while (_lector.Read())
                    {
                        c = new Cuota();
                        c.SocId = (int)_lector["SocId"];
                        c.CuotaId = (int)_lector["CuotaId"];
                        c.CuotaFechaDesde = (DateTime)_lector["CuotaFechaDesde"];
                        //c.CuotaFechaHasta = (DateTime)_lector["CuotaFechaHasta"];
                        c.CuotaAAAAMM = (string)_lector["CuotaAAAAMM"];
                        c.CuotaPaga = (bool)_lector["CuotaPaga"];
                        if (!string.IsNullOrEmpty(_lector["CuotaFechaPaga"].ToString()))
                            c.CuotaFechaPaga = (DateTime)_lector["CuotaFechaPaga"];
                        c.CuotaTipo = (int)_lector["CuotaTipo"];
                        c.FecAlta = (DateTime)_lector["FecAlta"];
                        c.FecModif = (DateTime)_lector["FecModif"];
                        c.UsuIdAlta = (int)_lector["UsuIdAlta"];
                        c.UsuIdModif = (int)_lector["UsuIdModif"];
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
        public bool PagarCuotaSocio(Cuota c, Usuario usu)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("PagoCuotaSocio", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdSocio", c.SocId);
            cmd.Parameters.AddWithValue("@IdCuota", c.CuotaId);
            cmd.Parameters.AddWithValue("@CuotaFechaPaga", c.CuotaFechaPaga);
            cmd.Parameters.AddWithValue("@FechaModifica", c.FecModif);
            cmd.Parameters.AddWithValue("@UsuIdModifica", usu.UsuId);

            SqlParameter prmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            prmRetorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(prmRetorno);
            bool respuesta = false;
            int resp = -1;
            int Id;
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
                    throw new Exception("La cuota ya esta paga.");
                else if (resp == -3)
                    throw new Exception("Ocurrió un problema al modificar el registro.");

                tran.Commit();
                respuesta = true;

                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }
    }
}
