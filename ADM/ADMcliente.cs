using ADO.MVC.Models;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ADO.MVC.ADM
{
    public class ADMcliente
    {
        private SqlConnection conexion;
        private void Conectar()
        {
            string stringConexion = "Data Source=LAPTOP-URAUHA04\\SQLTEST; User=sa; Password=123456; Initial Catalog=PruebaADM";
            conexion = new SqlConnection(stringConexion);
        }

        public int Alta(Cliente pCliente)
        {
            Conectar();
            SqlCommand sentencia = new SqlCommand("insert into Clientes(Nombre, Apellido, Email) values(@nombre, @apellido, @email)", conexion);
            sentencia.Parameters.Add("@nombre", SqlDbType.VarChar);
            sentencia.Parameters.Add("@apellido", SqlDbType.VarChar);
            sentencia.Parameters.Add("@email", SqlDbType.VarChar);
            sentencia.Parameters["@nombre"].Value = pCliente.Nombre;
            sentencia.Parameters["@apellido"].Value = pCliente.Apellido;
            sentencia.Parameters["@email"].Value = pCliente.Email;
            conexion.Open();
            int i = sentencia.ExecuteNonQuery();
            conexion.Close();
            return i;
        }

        public List<Cliente> TraerTodos()
        {
            Conectar();
            List<Cliente> clientes = new List<Cliente>();
            SqlCommand sentencia = new SqlCommand("select Id, nombre, apellido, email from clientes", conexion);
            conexion.Open();
            SqlDataReader registros = sentencia.ExecuteReader();
            while (registros.Read())
            {
                Cliente cliente = new Cliente
                {
                    Id = int.Parse(registros["Id"].ToString()),
                    Nombre = registros["nombre"].ToString(),
                    Apellido = registros["apellido"].ToString(),
                    Email = registros["email"].ToString()
                };
                clientes.Add(cliente);
            }
            conexion.Close();
            return clientes;
        }

        public Cliente TraerCliente(int id)
        {
            Conectar();
            SqlCommand sentencia = new SqlCommand("select Id, nombre, apellido, email from clientes where Id = @Id", conexion);
            sentencia.Parameters.Add("@Id", SqlDbType.Int);
            sentencia.Parameters["@Id"].Value = id;
            conexion.Open();
            SqlDataReader registros = sentencia.ExecuteReader();
            Cliente cliente = new Cliente();
            if (registros.Read())
            {
                cliente.Id = int.Parse(registros["Id"].ToString());
                cliente.Nombre = registros["Nombre"].ToString();
                cliente.Apellido = registros["Apellido"].ToString();
                cliente.Email = registros["Email"].ToString();
            }

            conexion.Close();
            return cliente;
        }

        public int Modificar(Cliente pCliente)
        {
            Conectar();
            SqlCommand sentencia = new SqlCommand("update clientes set nombre=@nombre, apellido = @apellido, email = @email where Id = @Id", conexion);
            sentencia.Parameters.Add("@nombre", SqlDbType.VarChar);
            sentencia.Parameters.Add("@apellido", SqlDbType.VarChar);
            sentencia.Parameters.Add("@email", SqlDbType.VarChar);
            sentencia.Parameters.Add("@Id", SqlDbType.VarChar);
            sentencia.Parameters["@nombre"].Value = pCliente.Nombre;
            sentencia.Parameters["@apellido"].Value = pCliente.Apellido;
            sentencia.Parameters["@email"].Value = pCliente.Email;
            sentencia.Parameters["@Id"].Value = pCliente.Id;
            conexion.Open();
            int i = sentencia.ExecuteNonQuery();
            conexion.Close();
            return i;
        }

        public int Borrar(int id)
        {
            Conectar();
            SqlCommand sentencia = new SqlCommand("delete from clientes where Id=@Id", conexion);
            sentencia.Parameters.Add("@Id", SqlDbType.Int);
            sentencia.Parameters["@Id"].Value = id;
            conexion.Open();
            int i = sentencia.ExecuteNonQuery();
            conexion.Close();
            return i;
        }
    }
}

    

