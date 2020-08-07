using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
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
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
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
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
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
        public ResultadoBorrado borrarDetalle(int id)
        {
            throw new Exception("No implementado");
        }
        public ResultadoBorrado borrarNota(int id)
        {
            throw new Exception("No implementado");
        }
        public ResultadoBorrado borrarComentario(int id)
        {
            throw new Exception("No implementado");
        }
        public ResultadoBorrado borrarTicket(int id)
        {
            throw new Exception("No implementado");
        }
        public ResultadoBorrado borrarProducto(int id)
        {
            ResultadoBorrado resultado = new ResultadoBorrado();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "Ventas.borrarProducto",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
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

        public Catalogo guardarCatalogo(Catalogo catalogo)
        {
            Catalogo resultado = new Catalogo();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "Administracion.guardarCatalogo",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
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
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
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
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                })
                {
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Guid,
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
                        resultado.UserName = dr["Usuario"].ToString();
                        resultado.ZonaPaqueteria = (int)dr["ZonaPaqueteria"];
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public void guardarDetalle(DetalleNota detalle)
        {
            throw new Exception("No implementado");
        }
        public void guardarNota(Nota nota)
        {
            throw new Exception("No implementado");
        }
        public void guardarComentario(ComentarioNota comentario)
        {
            throw new Exception("No implementado");
        }
        public void guardarTicket(TicketNota ticket)
        {
            throw new Exception("No implementado");
        }
        public Producto guardarProducto(Producto producto)
        {
            Producto resultado = new Producto();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "Ventas.guardarProducto",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                })
                {
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = producto.Id,
                        ParameterName = "@Id"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.String,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = producto.Nombre,
                        ParameterName = "@Nombre"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.String,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = producto.Descripcion,
                        ParameterName = "@Descripcion"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Decimal,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = producto.PrecioMXN,
                        ParameterName = "@PrecioMXN"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Decimal,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = producto.PrecioUSD,
                        ParameterName = "@PrecioUSD"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = producto.Existencias,
                        ParameterName = "@Existencias"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Boolean,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = producto.AplicaExistencias,
                        ParameterName = "@AplicaExistencias"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Binary,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = producto.Foto,
                        ParameterName = "@Foto"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.String,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = producto.SKU,
                        ParameterName = "@sku"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = producto.IdCatalogo,
                        ParameterName = "@IdCatalogo"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = producto.IdEstatus,
                        ParameterName = "@IdEstatus"
                    });

                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        resultado.Id = (int)dr["Id"];
                        resultado.Nombre = dr["Nombre"].ToString();
                        resultado.Descripcion = dr["Descripcion"].ToString();
                        resultado.Foto = (byte[])dr["Foto"];
                        resultado.AplicaExistencias = (bool)dr["AplicaExistencias"];
                        resultado.Existencias = (int)dr["Existencias"];
                        resultado.IdCatalogo = (int)dr["IdCatalogo"];
                        resultado.PrecioMXN = (decimal)dr["PrecioMXN"];
                        resultado.PrecioUSD = (decimal)dr["PrecioMXN"];
                        resultado.SKU = dr["Sku"].ToString();
                    }
                    conn.Close();
                }
            }
            return resultado;
        }

        public List<Catalogo> listarCatalogo(Catalogo catalogo)
        {
            List<Catalogo> resultado = new List<Catalogo>();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "Administracion.listarCatalogo",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
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
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            resultado.Add(new Catalogo
                            {
                                Id = (int)dr["Id"],
                                IdTipoCatalogo = (int)dr["IdTipoCatalogo"],
                                Nombre = dr["Nombre"].ToString()
                            });
                        }
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public List<Estatus> listarEstatus(Estatus estatus)
        {
            List<Estatus> resultado = new List<Estatus>();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "Administracion.listarEstatus",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                })
                {
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = estatus.IdTipoEstatus,
                        ParameterName = "@IdTipoEstatus"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = estatus.Id,
                        ParameterName = "@IdEstatus"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            resultado.Add(new Estatus
                            {
                                Id = (int)dr["Id"],
                                IdTipoEstatus = (int)dr["IdTipoEstatus"],
                                Nombre = dr["Nombre"].ToString()
                            });
                        }
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public List<Usuario> listarUsuario(Usuario usuario)
        {
            List<Usuario> resultado = new List<Usuario>();
            Usuario usuario1 = new Usuario();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "Seguridad.listarUsuario",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                })
                {
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Guid,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = usuario.Id,
                        ParameterName = "@Id"
                    });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = usuario.IdRol,
                        ParameterName = "@IdRol"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            resultado.Add(new Usuario
                            {
                                Id = new Guid(dr["Id"].ToString()),
                                Nombre = dr["Nombre"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                Foto = (dr["Foto"] == DBNull.Value) ? new byte[0] : (byte[])dr["Foto"],
                                IdEstatus = (int)dr["IdEstatus"],
                                IdRol = (int)dr["IdRol"],
                                Password = (dr["Passwd"] == DBNull.Value) ? new byte[0] : (byte[])dr["Passwd"],
                                Telefono = dr["Telefono"].ToString(),
                                UserName = dr["Usuario"].ToString(),
                                ZonaPaqueteria = (dr["ZonaPaqueteria"] == DBNull.Value) ? 0 : (int)dr["ZonaPaqueteria"],
                            });
                        }
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public void listarDetalle(int idNota)
        {
            throw new Exception("No implementado");
        }
        public List<Nota> listarNota(Nota nota)
        {
            List<Nota> resultado = new List<Nota>();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "Ventas.listarNotas",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                })
                {
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = nota.Folio,
                        ParameterName = "@Folio"
                    });
                    if (nota.Fecha.HasValue)
                        cmd.Parameters.Add(new SqlParameter
                        {
                            DbType = System.Data.DbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = nota.Fecha.Value,
                            ParameterName = "@Fecha"
                        });
                    cmd.Parameters.Add(new SqlParameter
                    {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = nota.IdEstatus,
                        ParameterName = "@IdEstatus"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            resultado.Add(new Nota
                            {
                                Folio = (int)dr["Folio"],
                                Fecha = (DateTime)dr["Fecha"],
                                FechaEnvio = (DateTime)dr["FechaEnvio"],
                                Guia = dr["Guia"].ToString(),
                                IdCliente = new Guid(dr["IdCliente"].ToString()),
                                IdEstatus = (int)dr["IdEstatus"],
                                IdPaqueteria = (int)dr["IdPaqueteria"],
                                IdTipo = (int)dr["IdTipo"],
                                MontoMXN = (decimal)dr["MontoMXN"],
                                MontoUSD = (decimal)dr["MontoUSD"],
                                SaldoMXN = (decimal)dr["SaldoMXN"],
                                SaldoUSD = (decimal)dr["SaldoUSD"]
                            });
                        }
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public void listarComentario(ComentarioNota comentario)
        {
            throw new Exception("No implementado");
        }
        public void listarTicket(TicketNota ticket)
        {
            throw new Exception("No implementado");
        }
        public List<Producto> listarProductos(int id)
        {
            List<Producto> resultado = new List<Producto>();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "Ventas.listarProductos",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
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
                        while (dr.Read())
                        {
                            resultado.Add(new Producto
                            {
                                Id = (int)dr["Id"],
                                Nombre = dr["Nombre"].ToString(),
                                AplicaExistencias = (bool)dr["AplicaExistencias"],
                                Descripcion = dr["Descripcion"].ToString(),
                                Existencias = (int)dr["Existencias"],
                                Foto = (byte[])dr["Foto"],
                                SKU = dr["Sku"].ToString(),
                                PrecioMXN = (decimal)dr["PrecioMXN"],
                                IdCatalogo = (int)dr["IdCatalogo"],
                                PrecioUSD = (decimal)dr["PrecioUSD"]
                            });
                        }
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public List<TipoCatalogo> listarTipoCatalogo(int id)
        {
            List<TipoCatalogo> resultado = new List<TipoCatalogo>();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "Administracion.listarTipoCatalogo",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
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
                        while (dr.Read())
                        {
                            resultado.Add(new TipoCatalogo
                            {
                                Id = (int)dr["Id"],
                                Nombre = dr["Nombre"].ToString()
                            });
                        }
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public List<TipoEstatus> listarTipoEstatus(int id)
        {
            List<TipoEstatus> resultado = new List<TipoEstatus>();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "Administracion.listarTipoEstatus",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
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
                        while (dr.Read())
                        {
                            resultado.Add(new TipoEstatus
                            {
                                Id = (int)dr["Id"],
                                Nombre = dr["Nombre"].ToString()
                            });
                        }
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public List<Rol> listarRol(int id)
        {
            List<Rol> resultado = new List<Rol>();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "Seguridad.listarRol",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
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
                        while (dr.Read())
                        {
                            resultado.Add(new Rol
                            {
                                Id = (int)dr["Id"],
                                Nombre = dr["Nombre"].ToString()
                            });
                        }
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public Usuario iniciarSesion(Usuario usuario)
        {
            Usuario resultado = new Usuario();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "Seguridad.iniciarSesion",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                })
                {
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
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        resultado = new Usuario
                        {
                            Id = (Guid)dr["Id"],
                            Nombre = dr["Nombre"].ToString(),
                            UserName = dr["Usuario"].ToString(),
                            IdRol = (int)dr["IdRol"],
                            ErrorMensaje = dr["Mensaje"].ToString(),
                            ErrorNumero = (int)dr["ErrorNumero"]
                        };
                    }
                }
            }
            return resultado;
        }
    }
}
