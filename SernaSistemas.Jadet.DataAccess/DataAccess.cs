using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SernaSistemas.Jadet.DataAccess
{
    public class DataAccess
    {
        public string CadenaConexion { get; set; }
        public ResultadoBorrado borrarCatalogo(int id)
        {
            ResultadoBorrado resultado = new ResultadoBorrado();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "Administracion.borrarCatalogo",
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                {
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = id,
                        ParameterName = "@Id"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        resultado.ErrorNumero = (int)dr["ErrorNumero"];
                        resultado.ErrorMensaje = dr["Mensaje"].ToString();
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public ResultadoBorrado borrarEstatus(int id)
        {
            ResultadoBorrado resultado = new ResultadoBorrado();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "Administracion.borrarEstatus",
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                {
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = id,
                        ParameterName = "@Id"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        resultado.ErrorNumero = (int)dr["ErrorNumero"];
                        resultado.ErrorMensaje = dr["Mensaje"].ToString();
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public ResultadoBorrado borrarUsuario(Guid id)
        {
            ResultadoBorrado resultado = new ResultadoBorrado();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "Seguridad.borrarUsuario",
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                {
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Guid,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = id,
                        ParameterName = "@Id"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        resultado.ErrorNumero = (int)dr["ErrorNumero"];
                        resultado.ErrorMensaje = dr["Mensaje"].ToString();
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public ResultadoBorrado borrarDetalle()
        {
            throw new Exception("No implementado");
        }
        public ResultadoBorrado borrarNota()
        {
            throw new Exception("No implementado");
        }
        public ResultadoBorrado borrarComentario()
        {
            throw new Exception("No implementado");
        }
        public ResultadoBorrado borrarTicket()
        {
            throw new Exception("No implementado");
        }
        public ResultadoBorrado borrarProducto()
        {
            throw new Exception("No implementado");
        }

        public Catalogo guardarCatalogo(Catalogo catalogo)
        {
            Catalogo resultado = new Catalogo();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "Administracion.guardarCatalogo",
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                {
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = catalogo.Id,
                        ParameterName = "@Id"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.String,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = catalogo.Nombre,
                        ParameterName = "@Nombre"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = catalogo.IdTipoCatalogo,
                        ParameterName = "@IdTipoCatalogo"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        resultado.Id = (int)dr["Id"];
                        resultado.Nombre = dr["Nombre"].ToString();
                        resultado.IdTipoCatalogo = (int)dr["IdTipoCatalogo"];
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public Estatus guardarEstatus(Estatus estatus)
        {
            Estatus resultado = new Estatus();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "Administracion.guardarEstatus",
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                {
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = estatus.Id,
                        ParameterName = "@Id"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.String,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = estatus.Nombre,
                        ParameterName = "@Nombre"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = estatus.IdTipoEstatus,
                        ParameterName = "@IdTipoEstatus"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        resultado.Id = (int)dr["Id"];
                        resultado.Nombre = dr["Nombre"].ToString();
                        resultado.IdTipoEstatus = (int)dr["IdTipoEstatus"];
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public Usuario guardarUsuario(Usuario usuario)
        {
            Usuario resultado = new Usuario();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "Seguridad.guardarUsuario",
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                {
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = usuario.Id,
                        ParameterName = "@Id"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.String,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = usuario.Nombre,
                        ParameterName = "@Nombre"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.String,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = usuario.Direccion,
                        ParameterName = "@Direccion"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.String,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = usuario.Telefono,
                        ParameterName = "@Telefono"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Binary,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = usuario.Foto,
                        ParameterName = "@Foto"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.String,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = usuario.UserName,
                        ParameterName = "@Usuario"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Binary,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = usuario.Password,
                        ParameterName = "@Passwd"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = usuario.IdRol,
                        ParameterName = "@IdRol"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = usuario.ZonaPaqueteria,
                        ParameterName = "@ZonaPaqueteria"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = usuario.IdEstatus,
                        ParameterName = "@IdEstatus"
                    });

                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        resultado.Id = new Guid(dr["Id"].ToString());
                        resultado.Nombre = dr["Nombre"].ToString();
                        resultado.Direccion = dr["Direccion"].ToString();
                        resultado.Foto = (byte[])dr["Foto"];
                        resultado.IdEstatus = (int)dr["IdEstatus"];
                        resultado.IdRol = (int)dr["IdRol"];
                        resultado.Password = (byte[])dr["Passwd"];
                        resultado.Telefono = dr["Telefono"].ToString();
                        resultado.UserName = dr["UserName"].ToString();
                        resultado.ZonaPaqueteria = (int)dr["ZonaPaqueteria"];
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public void guardarDetalle()
        {
            throw new Exception("No implementado");
        }
        public void guardarNota()
        {
            throw new Exception("No implementado");
        }
        public void guardarComentario()
        {
            throw new Exception("No implementado");
        }
        public void guardarTicket()
        {
            throw new Exception("No implementado");
        }
        public void guardarProducto()
        {
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "guardarProducto",
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                {

                }
            }
        }

        public void listarCatalogo(Catalogo catalogo)
        {
            List<Catalogo> resultado = new List<Catalogo>();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "Administracion.listarCatalogo",
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                {
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = catalogo.IdTipoCatalogo,
                        ParameterName = "@IdTipoCatalogo"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = catalogo.Id,
                        ParameterName = "@IdCatalogo"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    
                    conn.Close();

                }
            }
        }
        public void listarEstatus()
        {
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "borrarCatalogo",
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                {

                }
            }
        }
        public void listarUsuario()
        {
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "borrarCatalogo",
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                {

                }
            }
        }
        public void listarDetalle()
        {
            throw new Exception("No implementado");
        }
        public void listarNota()
        {
            throw new Exception("No implementado");
        }
        public void listarComentario()
        {
            throw new Exception("No implementado");
        }
        public void listarTicket()
        {
            throw new Exception("No implementado");
        }
        public void listarProducto()
        {
            throw new Exception("No implementado");
        }
        public void listarTipoCatalogo()
        {
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "listarTipoCatalogo",
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                {

                }
            }
        }
        public void listarTipoEstatus()
        {
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "listarTipoEstatus",
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                {

                }
            }
        }
        public void listarRol(int id)
        {
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "listarRol",
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                {

                }
            }
        }

    }
}
