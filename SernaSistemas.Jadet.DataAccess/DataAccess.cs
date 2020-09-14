using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SernaSistemas.Jadet.DataAccess {
    public class DataAccess {
        public string CadenaConexion { get; set; }
        public ResultadoBorrado borrarCatalogo(int id) {
            ResultadoBorrado resultado = new ResultadoBorrado();
            using (SqlConnection conn = new SqlConnection(CadenaConexion)) {
                using (SqlCommand cmd = new SqlCommand() {
                    CommandText = "Administracion.borrarCatalogo",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                }) {
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = id,
                        ParameterName = "@Id"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
                        dr.Read();
                        resultado.ErrorNumero = (int)dr["ErrorNumero"];
                        resultado.ErrorMensaje = dr["Mensaje"].ToString();
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public ResultadoBorrado borrarEstatus(int id) {
            ResultadoBorrado resultado = new ResultadoBorrado();
            using (SqlConnection conn = new SqlConnection(CadenaConexion)) {
                using (SqlCommand cmd = new SqlCommand() {
                    CommandText = "Administracion.borrarEstatus",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                }) {
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = id,
                        ParameterName = "@Id"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
                        dr.Read();
                        resultado.ErrorNumero = (int)dr["ErrorNumero"];
                        resultado.ErrorMensaje = dr["Mensaje"].ToString();
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public ResultadoBorrado borrarUsuario(Guid id) {
            ResultadoBorrado resultado = new ResultadoBorrado();
            using (SqlConnection conn = new SqlConnection(CadenaConexion)) {
                using (SqlCommand cmd = new SqlCommand() {
                    CommandText = "Seguridad.borrarUsuario",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                }) {
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Guid,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = id,
                        ParameterName = "@Id"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
                        dr.Read();
                        resultado.ErrorNumero = (int)dr["ErrorNumero"];
                        resultado.ErrorMensaje = dr["Mensaje"].ToString();
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        /// <summary>
        /// Retira un producto de un carrito.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResultadoBorrado borrarDetalle(int id) {
            throw new Exception("No implementado");
        }
        /// <summary>
        /// Elimina un carrito (debe estar vacío)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResultadoBorrado borrarNota(int id) {
            throw new Exception("No implementado");
        }
        public ResultadoBorrado borrarComentario(int id) {
            throw new Exception("No implementado");
        }
        public ResultadoBorrado borrarTicket(int id) {
            throw new Exception("No implementado");
        }
        public ResultadoBorrado vaciarCarrito(int id) {
            ResultadoBorrado resultado = new ResultadoBorrado();
            using (SqlConnection conn = new SqlConnection(CadenaConexion)) {
                using (SqlCommand cmd = new SqlCommand() {
                    CommandText = "Ventas.vaciarCarrito",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                }) {
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = id,
                        ParameterName = "@IdCarrito"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
                        dr.Read();
                        resultado.ErrorNumero = (int)dr["ErrorNumero"];
                        resultado.ErrorMensaje = dr["Mensaje"].ToString();
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public ResultadoBorrado borrarProducto(int id) {
            ResultadoBorrado resultado = new ResultadoBorrado();
            using (SqlConnection conn = new SqlConnection(CadenaConexion)) {
                using (SqlCommand cmd = new SqlCommand() {
                    CommandText = "Ventas.borrarProducto",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                }) {
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = id,
                        ParameterName = "@Id"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
                        dr.Read();
                        resultado.ErrorNumero = (int)dr["ErrorNumero"];
                        resultado.ErrorMensaje = dr["Mensaje"].ToString();
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public Catalogo guardarCatalogo(Catalogo catalogo) {
            Catalogo resultado = new Catalogo();
            using (SqlConnection conn = new SqlConnection(CadenaConexion)) {
                using (SqlCommand cmd = new SqlCommand() {
                    CommandText = "Administracion.guardarCatalogo",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                }) {
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = catalogo.Id,
                        ParameterName = "@Id"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.String,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = catalogo.Nombre,
                        ParameterName = "@Nombre"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = catalogo.IdTipoCatalogo,
                        ParameterName = "@IdTipoCatalogo"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
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
        public Estatus guardarEstatus(Estatus estatus) {
            Estatus resultado = new Estatus();
            using (SqlConnection conn = new SqlConnection(CadenaConexion)) {
                using (SqlCommand cmd = new SqlCommand() {
                    CommandText = "Administracion.guardarEstatus",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                }) {
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = estatus.Id,
                        ParameterName = "@Id"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.String,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = estatus.Nombre,
                        ParameterName = "@Nombre"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = estatus.IdTipoEstatus,
                        ParameterName = "@IdTipoEstatus"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
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
        public Usuario guardarUsuario(Usuario usuario) {
            Usuario resultado = new Usuario();
            using (SqlConnection conn = new SqlConnection(CadenaConexion)) {
                using (SqlCommand cmd = new SqlCommand() {
                    CommandText = "Seguridad.guardarUsuario",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                }) {
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Guid,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = usuario.Id,
                        ParameterName = "@Id"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.String,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = usuario.Nombre,
                        ParameterName = "@Nombre"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.String,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = usuario.Direccion,
                        ParameterName = "@Direccion"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.String,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = usuario.Telefono,
                        ParameterName = "@Telefono"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Binary,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = usuario.Foto,
                        ParameterName = "@Foto"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.String,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = usuario.UserName,
                        ParameterName = "@Usuario"
                    });
                    if (!string.IsNullOrEmpty(Encoding.UTF8.GetString(usuario.Password)))
                        cmd.Parameters.Add(new SqlParameter {
                            DbType = System.Data.DbType.Binary,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = usuario.Password,
                            ParameterName = "@Passwd"
                        });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = usuario.IdRol,
                        ParameterName = "@IdRol"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = usuario.ZonaPaqueteria,
                        ParameterName = "@ZonaPaqueteria"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = usuario.IdEstatus,
                        ParameterName = "@IdEstatus"
                    });

                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
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
        public DetalleNota guardarDetalle(DetalleNota detalle) {
            DetalleNota resultado = new DetalleNota();
            using (SqlConnection conn = new SqlConnection(CadenaConexion)) {
                using (SqlCommand cmd = new SqlCommand() {
                    CommandText = "Ventas.guardarDetalle",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                }) {
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = detalle.Id,
                        ParameterName = "@Id"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = detalle.IdNota,
                        ParameterName = "@IdNota"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = detalle.IdProducto,
                        ParameterName = "@IdProducto"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = detalle.Cantidad,
                        ParameterName = "@Cantidad"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Decimal,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = detalle.PrecioMXN,
                        ParameterName = "@PrecioMXN"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Decimal,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = detalle.PrecioUSD,
                        ParameterName = "@PrecioUSD"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
                        dr.Read();
                        resultado.Id = (int)dr["Id"];
                        resultado.IdNota = (int)dr["IdNota"];
                        resultado.IdProducto = (int)dr["IdProducto"];
                        resultado.Cantidad = (int)dr["Cantidad"];
                        resultado.PrecioMXN = (decimal)dr["PrecioMXN"];
                        resultado.PrecioUSD = (decimal)dr["PrecioUSD"];
                    }
                    conn.Close();
                }
            }
            return resultado;

        }
        public Nota guardarNota(Nota nota) {
            Nota resultado = new Nota();
            using (SqlConnection conn = new SqlConnection(CadenaConexion)) {
                using (SqlCommand cmd = new SqlCommand() {
                    CommandText = "Ventas.guardarNota",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                }) {
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = nota.Folio,
                        ParameterName = "@Folio"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Date,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = nota.Fecha,
                        ParameterName = "@Fecha"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = nota.IdTipo,
                        ParameterName = "@IdTipo"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = nota.IdEstatus,
                        ParameterName = "@IdEstatus"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = nota.IdPaqueteria,
                        ParameterName = "@IdPaqueteria"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Guid,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = nota.IdCliente,
                        ParameterName = "@IdCliente"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.String,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = !string.IsNullOrEmpty(nota.Guia) ? nota.Guia : string.Empty,
                        ParameterName = "@Guia"
                    });
                    if (nota.FechaEnvio.HasValue) {
                        cmd.Parameters.Add(new SqlParameter {
                            DbType = System.Data.DbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = nota.FechaEnvio.Value,
                            ParameterName = "@FechaEnvio"
                        });
                    }
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Decimal,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = nota.MontoMXN,
                        ParameterName = "@MontoMXN"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Decimal,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = nota.MontoUSD,
                        ParameterName = "@MontoUSD"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Decimal,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = nota.SaldoMXN,
                        ParameterName = "@SaldoMXN"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Decimal,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = nota.SaldoUSD,
                        ParameterName = "@SaldoUSD"
                    });

                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
                        dr.Read();
                        resultado = new Nota {
                            Fecha = (DateTime)dr["Fecha"],
                            Folio = (int)dr["Folio"],
                            Guia = dr["Guia"].ToString(),
                            IdCliente = new Guid(dr["IdCliente"].ToString()),
                            IdEstatus = (int)dr["IdEstatus"],
                            IdPaqueteria = (int)dr["IdPaqueteria"],
                            IdTipo = (int)dr["IdTipo"],
                            MontoMXN = (decimal)dr["MontoMXN"],
                            MontoUSD = (decimal)dr["MontoUSD"],
                            SaldoMXN = (decimal)dr["SaldoMXN"],
                            SaldoUSD = (decimal)dr["SaldoUSD"]
                        };
                        if (dr["FechaEnvio"] != DBNull.Value)
                            resultado.FechaEnvio = (DateTime)dr["FechaEnvio"];
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public ComentarioNota guardarComentario(ComentarioNota comentario) {
            ComentarioNota resultado = new ComentarioNota();
            using (SqlConnection conn = new SqlConnection(CadenaConexion)) {
                using (SqlCommand cmd = new SqlCommand() {
                    CommandText = "Ventas.guardarComentario",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                }) {
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = comentario.Id,
                        ParameterName = "@Id"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = comentario.IdNota,
                        ParameterName = "@IdNota"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.String,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = comentario.Comentario,
                        ParameterName = "@Comentario"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Date,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = comentario.Fecha,
                        ParameterName = "@Fecha"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
                        dr.Read();
                        resultado.Id = (int)dr["Id"];
                        resultado.IdNota = (int)dr["IdNota"];
                        resultado.Comentario = dr["Comentario"].ToString();
                        resultado.Fecha = (DateTime)dr["Fecha"];
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public void guardarTicket(TicketNota ticket) {
            throw new Exception("No implementado");
        }
        public Producto guardarProducto(Producto producto) {
            Producto resultado = new Producto();
            using (SqlConnection conn = new SqlConnection(CadenaConexion)) {
                using (SqlCommand cmd = new SqlCommand() {
                    CommandText = "Ventas.guardarProducto",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                }) {
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = producto.Id,
                        ParameterName = "@Id"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.String,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = producto.Nombre,
                        ParameterName = "@Nombre"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.String,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = producto.Descripcion,
                        ParameterName = "@Descripcion"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Decimal,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = producto.PrecioMXN,
                        ParameterName = "@PrecioMXN"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Decimal,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = producto.PrecioUSD,
                        ParameterName = "@PrecioUSD"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = producto.Existencias,
                        ParameterName = "@Existencias"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Boolean,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = producto.AplicaExistencias,
                        ParameterName = "@AplicaExistencias"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Binary,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = producto.Foto,
                        ParameterName = "@Foto"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.String,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = producto.SKU,
                        ParameterName = "@sku"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = producto.IdCatalogo,
                        ParameterName = "@IdCatalogo"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = producto.IdEstatus,
                        ParameterName = "@IdEstatus"
                    });

                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
                        dr.Read();
                        resultado.Id = (int)dr["Id"];
                        resultado.Nombre = dr["Nombre"].ToString();
                        resultado.Descripcion = dr["Descripcion"].ToString();
                        resultado.Foto = (byte[])dr["Foto"];
                        resultado.AplicaExistencias = (bool)dr["AplicaExistencias"];
                        resultado.Existencias = (int)dr["Existencias"];
                        resultado.IdCatalogo = (int)dr["IdCatalogo"];
                        resultado.PrecioMXN = (decimal)dr["PrecioMXN"];
                        resultado.PrecioUSD = (decimal)dr["PrecioUSD"];
                        resultado.SKU = dr["Sku"].ToString();
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public List<Catalogo> listarCatalogo(Catalogo catalogo) {
            List<Catalogo> resultado = new List<Catalogo>();
            using (SqlConnection conn = new SqlConnection(CadenaConexion)) {
                using (SqlCommand cmd = new SqlCommand() {
                    CommandText = "Administracion.listarCatalogo",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                }) {
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = catalogo.IdTipoCatalogo,
                        ParameterName = "@IdTipoCatalogo"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = catalogo.Id,
                        ParameterName = "@IdCatalogo"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
                        while (dr.Read()) {
                            resultado.Add(new Catalogo {
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
        public List<Estatus> listarEstatus(Estatus estatus) {
            List<Estatus> resultado = new List<Estatus>();
            using (SqlConnection conn = new SqlConnection(CadenaConexion)) {
                using (SqlCommand cmd = new SqlCommand() {
                    CommandText = "Administracion.listarEstatus",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                }) {
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = estatus.IdTipoEstatus,
                        ParameterName = "@IdTipoEstatus"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = estatus.Id,
                        ParameterName = "@IdEstatus"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
                        while (dr.Read()) {
                            resultado.Add(new Estatus {
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
        public List<Usuario> listarUsuario(Usuario usuario) {
            List<Usuario> resultado = new List<Usuario>();
            Usuario usuario1 = new Usuario();
            using (SqlConnection conn = new SqlConnection(CadenaConexion)) {
                using (SqlCommand cmd = new SqlCommand() {
                    CommandText = "Seguridad.listarUsuario",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                }) {
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Guid,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = usuario.Id,
                        ParameterName = "@Id"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = usuario.IdRol,
                        ParameterName = "@IdRol"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
                        while (dr.Read()) {
                            resultado.Add(new Usuario {
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
        public List<DetalleNota> listarDetalle(int id, int idNota, int IdProducto) {
            List<DetalleNota> resultado = new List<DetalleNota>();

            using (SqlConnection conn = new SqlConnection(CadenaConexion)) {
                using (SqlCommand cmd = new SqlCommand() {
                    CommandText = "Ventas.listarDetalle",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                }) {
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = id,
                        ParameterName = "@Id"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = idNota,
                        ParameterName = "@IdNota"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = IdProducto,
                        ParameterName = "@IdProducto"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
                        while (dr.Read()) {
                            resultado.Add(new DetalleNota {
                                Id = (int)dr["Id"],
                                IdNota = (int)dr["IdNota"],
                                Cantidad = (int)dr["Cantidad"],
                                IdProducto = (int)dr["IdProducto"],
                                PrecioMXN = (decimal)dr["PrecioMXN"],
                                PrecioUSD = (decimal)dr["PrecioUSD"],
                            });
                        }
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public List<Nota> listarNota(Nota nota) {
            List<Nota> resultado = new List<Nota>();
            using (SqlConnection conn = new SqlConnection(CadenaConexion)) {
                using (SqlCommand cmd = new SqlCommand() {
                    CommandText = "Ventas.listarNotas",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                }) {
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = nota.Folio,
                        ParameterName = "@Folio"
                    });
                    if (nota.Fecha.HasValue)
                        cmd.Parameters.Add(new SqlParameter {
                            DbType = System.Data.DbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = nota.Fecha.Value,
                            ParameterName = "@Fecha"
                        });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = nota.IdEstatus,
                        ParameterName = "@IdEstatus"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    Nota _nota;
                    if (dr.HasRows) {
                        while (dr.Read()) {
                            _nota = new Nota {
                                Folio = (int)dr["Folio"],
                                Fecha = (DateTime)dr["Fecha"],
                                Guia = dr["Guia"].ToString(),
                                IdCliente = new Guid(dr["IdCliente"].ToString()),
                                IdEstatus = (int)dr["IdEstatus"],
                                IdPaqueteria = (int)dr["IdPaqueteria"],
                                IdTipo = (int)dr["IdTipo"],
                                MontoMXN = (decimal)dr["MontoMXN"],
                                MontoUSD = (decimal)dr["MontoUSD"],
                                SaldoMXN = (decimal)dr["SaldoMXN"],
                                SaldoUSD = (decimal)dr["SaldoUSD"]
                            };
                            if (dr["FechaEnvio"] != DBNull.Value)
                                _nota.FechaEnvio = (DateTime)dr["FechaEnvio"];
                            resultado.Add(_nota);
                        }
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public List<ComentarioNota> listarComentario(ComentarioNota comentario) {
            List<ComentarioNota> resultado = new List<ComentarioNota>();
            using (SqlConnection conn = new SqlConnection(CadenaConexion)) {
                using (SqlCommand cmd = new SqlCommand() {
                    CommandText = "Ventas.listarComentarios",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                }) {
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = comentario.Id,
                        ParameterName = "@Id"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = comentario.IdNota,
                        ParameterName = "@IdNota"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
                        while (dr.Read()) {
                            resultado.Add(new ComentarioNota {
                                Id = (int)dr["Id"],
                                IdNota = (int)dr["IdNota"],
                                Comentario = dr["Comentario"].ToString(),
                                Fecha = (DateTime)dr["Fecha"]
                            });
                        }
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public List<TicketNota> listarTicket(TicketNota ticket) {
            List<TicketNota> resultado = new List<TicketNota>();

            using (SqlConnection conn = new SqlConnection(CadenaConexion)) {
                using (SqlCommand cmd = new SqlCommand() {
                    CommandText = "Ventas.listarTickets",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                }) {
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = ticket.Id,
                        ParameterName = "@Id"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = ticket.IdNota,
                        ParameterName = "@IdNota"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
                        while (dr.Read()) {
                            resultado.Add(new TicketNota {
                                Id = (int)dr["Id"],
                                IdNota = (int)dr["IdNota"],
                                Fecha = (DateTime)dr["Fecha"],
                                Ticket = (dr["Ticket"] == DBNull.Value) ? new byte[0] : (byte[])dr["Ticket"]
                            });
                        }
                    }
                    conn.Close();
                }
            }
            return resultado;
        }
        public List<Producto> listarProductos(int id) {
            List<Producto> resultado = new List<Producto>();
            using (SqlConnection conn = new SqlConnection(CadenaConexion)) {
                using (SqlCommand cmd = new SqlCommand() {
                    CommandText = "Ventas.listarProductos",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                }) {
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = id,
                        ParameterName = "@Id"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
                        while (dr.Read()) {
                            resultado.Add(new Producto {
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
        public List<TipoCatalogo> listarTipoCatalogo(int id) {
            List<TipoCatalogo> resultado = new List<TipoCatalogo>();
            using (SqlConnection conn = new SqlConnection(CadenaConexion)) {
                using (SqlCommand cmd = new SqlCommand() {
                    CommandText = "Administracion.listarTipoCatalogo",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                }) {
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = id,
                        ParameterName = "@Id"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
                        while (dr.Read()) {
                            resultado.Add(new TipoCatalogo {
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
        public List<TipoEstatus> listarTipoEstatus(int id) {
            List<TipoEstatus> resultado = new List<TipoEstatus>();
            using (SqlConnection conn = new SqlConnection(CadenaConexion)) {
                using (SqlCommand cmd = new SqlCommand() {
                    CommandText = "Administracion.listarTipoEstatus",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                }) {
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = id,
                        ParameterName = "@Id"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
                        while (dr.Read()) {
                            resultado.Add(new TipoEstatus {
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
        public List<Rol> listarRol(int id) {
            List<Rol> resultado = new List<Rol>();
            using (SqlConnection conn = new SqlConnection(CadenaConexion)) {
                using (SqlCommand cmd = new SqlCommand() {
                    CommandText = "Seguridad.listarRol",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                }) {
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = id,
                        ParameterName = "@Id"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
                        while (dr.Read()) {
                            resultado.Add(new Rol {
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
        public Usuario iniciarSesion(Usuario usuario) {
            Usuario resultado = new Usuario();
            using (SqlConnection conn = new SqlConnection(CadenaConexion)) {
                using (SqlCommand cmd = new SqlCommand() {
                    CommandText = "Seguridad.iniciarSesion",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = conn
                }) {
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.String,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = usuario.UserName,
                        ParameterName = "@Usuario"
                    });
                    cmd.Parameters.Add(new SqlParameter {
                        DbType = System.Data.DbType.Binary,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = usuario.Password,
                        ParameterName = "@Passwd"
                    });
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
                        dr.Read();
                        resultado = new Usuario {
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
