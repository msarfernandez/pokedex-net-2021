using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace presentacion
{
    class PokemonNegocio
    {

        public List<Pokemon> listar()
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "data source=.\\SQLEXPRESS; initial catalog=POKEDEX_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Numero, Nombre, Descripcion, UrlImagen from POKEMONS";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Numero = (int)lector["Numero"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = lector.GetString(2);
                    aux.UrlImagen = (string)lector["UrlImagen"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //select Nombre, P.Descripcion, UrlImagen, T.Descripcion Tipo, D.Descripcion Debilidad from POKEMONS P, ELEMENTOS T, ELEMENTOS D Where P.IdTipo = T.Id and P.IdDebilidad = D.Id
        public List<Pokemon> listar2()
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "data source=.\\SQLEXPRESS; initial catalog=POKEDEX_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Numero, Nombre, P.Descripcion, UrlImagen, T.Descripcion Tipo, D.Descripcion Debilidad from POKEMONS P, ELEMENTOS T, ELEMENTOS D Where P.IdTipo = T.Id and P.IdDebilidad = D.Id";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Numero = (int)lector["Numero"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = lector.GetString(2);
                    aux.UrlImagen = (string)lector["UrlImagen"];

                    
                    //aux.Tipo = new Elemento("");
                    //aux.Tipo.Nombre = (string)lector["Tipo"];

                    aux.Tipo = new Elemento((string)lector["Tipo"]);
                    aux.Debilidad = new Elemento((string)lector["Debilidad"]);

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
