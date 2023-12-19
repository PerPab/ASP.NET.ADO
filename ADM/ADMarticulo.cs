using ADO.MVC.Models;
using System.Data;
using System.Data.SqlClient;

namespace ADO.MVC.ADM
{
    public class ADMarticulo
    {
        private SqlConnection conexion;
        private void Conectar()
        {
            string stringConexion = "Data Source=LAPTOP-URAUHA04\\SQLTEST; User=sa; Password=123456; Initial Catalog=PruebaADM";
            conexion = new SqlConnection(stringConexion);
        }


    public int Alta(Articulo pArticulo)
    {
            Conectar();
            SqlCommand sentencia = new SqlCommand("insert into Articulos(Codigo, Descripcion, Precio) values(@codigo, @descripcion, @precio)", conexion);
            sentencia.Parameters.Add("@codigo", SqlDbType.VarChar);
            sentencia.Parameters.Add("@descripcion", SqlDbType.VarChar);
            sentencia.Parameters.Add("@precio", SqlDbType.Decimal);
            sentencia.Parameters["@codigo"].Value = pArticulo.Codigo;
            sentencia.Parameters["@descripcion"].Value = pArticulo.Descripcion;
            sentencia.Parameters["@precio"].Value = pArticulo.Precio;
            conexion.Open();
            int i = sentencia.ExecuteNonQuery();
            conexion.Close();
            return i;
        }


    public List<Articulo>TraerTodos()
    {
            Conectar();
            List<Articulo> articulos = new List<Articulo>();
            SqlCommand sentencia = new SqlCommand("select Id, codigo, descripcion, precio from articulos",
            conexion);
            conexion.Open();
            SqlDataReader registros = sentencia.ExecuteReader();
            while (registros.Read())
            {
                Articulo articulo = new Articulo
                {
                    Id = int.Parse(registros["Id"].ToString()),
                    Codigo = registros["codigo"].ToString(),
                    Descripcion = registros["descripcion"].ToString(),
                    Precio = decimal.Parse(registros["precio"].ToString())
                };
                articulos.Add(articulo);
            }

        conexion.Close();
            return articulos;
        }
        public Articulo TraerArticulo(int id)
        {
            Conectar();
            SqlCommand sentencia = new SqlCommand("select Id, codigo, descripcion, precio from Articulos where Id = @Id", conexion);
            sentencia.Parameters.Add("@Id", SqlDbType.VarChar);
            sentencia.Parameters["@Id"].Value = id;
            conexion.Open();
            SqlDataReader registros = sentencia.ExecuteReader();
            Articulo articulo = new Articulo();
            if (registros.Read())
            {
                articulo.Codigo = registros["codigo"].ToString();
                articulo.Descripcion = registros["descripcion"].ToString();
                articulo.Precio = decimal.Parse(registros["precio"].ToString());
                articulo.Id = int.Parse(registros["Id"].ToString());

            }

            conexion.Close();
            return articulo;
        }
        public int Modificar(Articulo pArticulo)
        {
            Conectar();
            SqlCommand sentencia = new SqlCommand("update articulos set descripcion = @descripcion, precio = @precio, codigo = @codigo where Id = @Id", conexion);
            sentencia.Parameters.Add("@descripcion", SqlDbType.VarChar);
            sentencia.Parameters["@descripcion"].Value = pArticulo.Descripcion;
            sentencia.Parameters.Add("@precio", SqlDbType.Float);
            sentencia.Parameters["@precio"].Value = pArticulo.Precio;
            sentencia.Parameters.Add("@codigo", SqlDbType.Int);
            sentencia.Parameters["@codigo"].Value = pArticulo.Codigo;
            sentencia.Parameters.Add("@Id", SqlDbType.Int);
            sentencia.Parameters["@Id"].Value = pArticulo.Id;
            conexion.Open();
            int i = sentencia.ExecuteNonQuery();
            conexion.Close();
            return i;
        }

public int Borrar(int id)
 {
            Conectar();
            SqlCommand sentencia = new SqlCommand("delete from articulos where Id=@Id", conexion);
            sentencia.Parameters.Add("@Id", SqlDbType.Int);
            sentencia.Parameters["@Id"].Value = id;
            conexion.Open();
            int i = sentencia.ExecuteNonQuery();
            conexion.Close();
            return i;
        }
    }
}

    

