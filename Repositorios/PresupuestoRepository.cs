using System.ComponentModel;
using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp6_2024_franleccese11.Models;

namespace tl2_tp6_2024_franleccese11.Repositorios
{
    public class PresupuestoRepository : IPresupuestoRepository
    {
        private readonly string connectionString = @"Data Source=db/Tienda.db;Cache=Shared";
        public void CrearPresupuesto(Presupuesto presupuesto)
        {
            try
            {
                using (SqliteConnection connection = new(connectionString))
                {
                    connection.Open();
                    string queryStr = @" INSERT INTO Presupuestos (NombreDestinatario, FechaCreacion) VALUES (@NombreDestinatario,@FechaCreacion)";
                    SqliteCommand command = new(queryStr, connection);
                    command.Parameters.AddWithValue("@NombreDestinatario", presupuesto.NombreDestinatario);
                    DateTime fechaSinHora = new DateTime(presupuesto.Fecha.Year, presupuesto.Fecha.Month, presupuesto.Fecha.Day);
                    command.Parameters.AddWithValue("@FechaCreacion", fechaSinHora);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqliteException ex)
            {

                throw new Exception("Error al conectar con la base de datos", ex);
            }
        }


        public List<Presupuesto> ListarPresupuestos()
        {
            try
            {
                using (SqliteConnection connection = new(connectionString))
                {
                    connection.Open();
                    string queryStr = "SELECT idPresupuesto,NombreDestinatario,FechaCreacion FROM Presupuestos";
                    var listaPresupuestos = new List<Presupuesto>();
                    SqliteCommand command = new(queryStr, connection);
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Presupuesto presupuesto = new();
                            presupuesto.SetID(Convert.ToInt32(reader["idPresupuesto"]));
                            presupuesto.Fecha = DateTime.Parse(reader["FechaCreacion"].ToString());
                            presupuesto.NombreDestinatario = reader["NombreDestinatario"].ToString();
                            listaPresupuestos.Add(presupuesto);
                        }

                    }
                    connection.Close();
                    return listaPresupuestos;
                }
            }
            catch (SqliteException ex)
            {

                throw new Exception("Error en la conexion con la Base de datos", ex);
            }
        }

        public Presupuesto ObtenerPresupuesto(int id)
        {
            try
            {
                using (SqliteConnection connection = new(connectionString))
                {
                    connection.Open();
                    string queryStr = "SELECT idPresupuesto,NombreDestinatario,FechaCreacion FROM Presupuestos WHERE idPresupuesto =@id";
                    
                    SqliteCommand command = new(queryStr, connection);
                    command.Parameters.AddWithValue("@id",id);
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Presupuesto presupuesto = new();
                            presupuesto.SetID(Convert.ToInt32(reader["idPresupuesto"]));
                            presupuesto.Fecha = DateTime.Parse(reader["FechaCreacion"].ToString());
                            presupuesto.NombreDestinatario = reader["NombreDestinatario"].ToString();
                            connection.Close();
                            return presupuesto;
                        }else
                        {   
                            connection.Close();
                            return null;
                        }
                    }
                }
            }
            catch (SqliteException ex)
            {

                throw new Exception("Error en la conexion con la Base de datos", ex);
            }
        }

        public List<PresupuestoDetalle> ObtenerDetalle(int id)
        {
            try
            {
                using (SqliteConnection connection = new(connectionString))
                {
                    connection.Open();
                    string queryStr = "SELECT idPresupuesto, idProducto, Cantidad FROM PresupuestoDetalle WHERE idPresupuesto= @id";
                    var listaPresupuestoDetalle = new List<PresupuestoDetalle>();
                    SqliteCommand command = new(queryStr, connection);
                    command.Parameters.AddWithValue("@id", id);
                    var listaDetalle = new List<PresupuestoDetalle>();
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var presupuestoDetalle = new PresupuestoDetalle();
                            presupuestoDetalle.AsignarProducto(Convert.ToInt32(reader["idProducto"]));
                            presupuestoDetalle.Cantidad = Convert.ToInt32(reader["Cantidad"]);
                            listaDetalle.Add(presupuestoDetalle);
                        }

                    }
                    connection.Close();
                    return listaDetalle;
                }
            }
            catch (SqliteException ex)
            {

                throw new Exception("Error en la conexion con la Base de datos", ex);
            }
        }

        public void AgregarDetalle(int idPresupuesto, int idProducto, int cantidad)
        {
            try
            {
                using (SqliteConnection connection = new(connectionString))
                {
                    connection.Open();
                    string queryStr = "INSERT INTO PresupuestosDetalle VALUES (@idPresupuesto,@idProducto,@Cantidad)";
                    SqliteCommand command = new(queryStr, connection);
                    command.Parameters.Add(new SqliteParameter("@idPresupuesto", idPresupuesto));
                    command.Parameters.Add(new SqliteParameter("@idProducto", idProducto));
                    command.Parameters.Add(new SqliteParameter("@Cantidad", cantidad));
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqliteException ex)
            {

                throw new("Error al conectar con la base de datos", ex);
            }
        }

        public void EliminarPresupuesto(int id)
        {
            try
            {
                using (SqliteConnection connection = new(connectionString))
                {
                    connection.Open();
                    string queryStr = @"DELETE FROM Presupuesto WHERE idPresupuesto=@id";
                    SqliteCommand command = new(queryStr, connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqliteException ex)
            {

                throw new("Error al conectar con la base de datos", ex);
            }
        }




    }
}