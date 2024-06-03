using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBZ.Data.Models;

namespace DBZ.Data.DataAcces
{
    internal class Conexiondragonball
    {
        private string connectionString = "server=localhost;database=dragonball;user id=root;password=canche12";
        public bool ProbarConexion()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public DataTable LeerPersonajes()
        {
            DataTable personajes = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = "select * from personajes";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(personajes);
                    }
                }
            }

            return personajes;
        }

        public void Insertar(Usuario usr)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))

                try
                {
                string query = "INSERT INTO personajes (nombre, edad, humano, poder, nivel_ki, universo) VALUES (@nombre, @edad, @humano, @poder, @nivel_ki, @universo)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@nombre", usr.Nombre);
                cmd.Parameters.AddWithValue("@edad", usr.Edad);
                cmd.Parameters.AddWithValue("@humano", usr.Humano);
                cmd.Parameters.AddWithValue("@poder", usr.Poder);
                cmd.Parameters.AddWithValue("@nivel_ki", usr.Nivel_Ki);
                cmd.Parameters.AddWithValue("@universo", usr.Universo);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el registro: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void Actualizar(Usuario usr)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))

                try
                {
                    string query = "UPDATE personajes set nombre=@nombre, edad=@edad, humanmo=@humano, poder=@poder, nivel_ki=@nivel_ki, universo=@universo where id=@id";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", usr.ID);
                    cmd.Parameters.AddWithValue("@nombre", usr.Nombre);
                    cmd.Parameters.AddWithValue("@edad", usr.Edad);
                    cmd.Parameters.AddWithValue("@humano", usr.Humano);
                    cmd.Parameters.AddWithValue("@poder", usr.Poder);
                    cmd.Parameters.AddWithValue("@nivel_ki", usr.Nivel_Ki);
                    cmd.Parameters.AddWithValue("@universo", usr.Universo);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al Actualizar el registro: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
        }

        public int Borrar(Usuario usr)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "delete personajes where id =@id";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id",usr.ID);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable BuscarHumano(Usuario usr)
        {
            DataTable humano = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM personajes WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id",usr.ID);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(humano);
                    }
                }
            }

            return humano;
        }

        public Usuario BuscarPorId(int id)
        {
            Usuario BuscarHumano = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))

                try
                {
                string query = "SELECT * FROM personajes WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    BuscarHumano = new Usuario
                    {
                        ID = reader.GetInt32("ID"),
                        Nombre = reader.GetString("nombre"),
                        Edad = reader.GetInt32("edad"),
                        Humano = reader.GetBoolean("humano"),
                        Poder = reader.GetString("poder"),
                        Nivel_Ki = reader.GetString("nivel_ki"),
                        Universo = reader.GetString("universo")
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el libro por ID: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return BuscarHumano;
        }



        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM personajes";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Usuario nuevoUsuario = new Usuario(
                            reader.GetInt32(reader.GetOrdinal("id")),
                            reader.GetString(reader.GetOrdinal("nombre")),
                            reader.GetInt32(reader.GetOrdinal("edad")),
                            reader.GetBoolean(reader.GetOrdinal("mutante")),
                            reader.GetString(reader.GetOrdinal("poder")),
                            reader.GetString(reader.GetOrdinal("nivel_mutacion")),
                            reader.GetString(reader.GetOrdinal("grupo"))
                            );

                        usuarios.Add(nuevoUsuario);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return usuarios;
        }

        public void Eliminar(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))

                try
                {
                string query = "DELETE FROM personajes WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el registro: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


       
    }
}
