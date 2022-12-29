using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace SuperHeroWeb.Models
{
    public class DataBase
    {

        //TODO: Obtencion de heroes desde la bd OK
        public List<Heroe> obtenerHeroes() { 
            List<Heroe> losHeroes = new List<Heroe>();
            String cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(cnnStr)) { 
                cnn.Open();

                SqlCommand cmdSql = new SqlCommand("Select * from Heroes order by Id", cnn);
                
                SqlDataReader dr = cmdSql.ExecuteReader();


                while (dr.Read()) {
                    losHeroes.Add(new Heroe(dr["Id"].ToString().AsInt(), dr["Nombre"].ToString(), dr["Superpoder"].ToString(),
                        dr["Nivel"].ToString().AsInt(), dr["Retirado"].ToString().AsBool(), dr["Correo"].ToString(),
                        dr["Fechanac"].ToString().AsDateTime().Date, dr["Altura"].ToString().AsFloat(), dr["Peso"].ToString().AsFloat()));
                }
                cnn.Close();
                cnn.Dispose();
            }

                return losHeroes;
        }

        //TODO: Busqueda de heroes segun id OK
        public Heroe buscarHeroeId(int id) {
            Heroe hero = null;
            String cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(cnnStr)) {
                cnn.Open();

                SqlCommand cmdSql = new SqlCommand("Select * from Heroes where id = @id", cnn);
                cmdSql.Parameters.AddWithValue("@id", id);

                SqlDataReader dr = cmdSql.ExecuteReader();

                if (dr.Read()) {
                    hero = new Heroe(dr["Id"].ToString().AsInt(), dr["Nombre"].ToString(), dr["Superpoder"].ToString(), 
                        dr["Nivel"].ToString().AsInt(), dr["Retirado"].ToString().AsBool(), dr["Correo"].ToString(),
                        dr["Fechanac"].ToString().AsDateTime().Date , dr["Altura"].ToString().AsFloat(), dr["Peso"].ToString().AsFloat());
                }
                cnn.Close();
                cnn.Dispose();

            }
                return hero;
        }
        //TODO: creacion de metodo create
        public int agregarHeroe(Heroe heroe) {
            String cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(cnnStr)) {
                cnn.Open();
                

                SqlCommand cmdSql = new SqlCommand("insert into Heroes (Id,Nombre,Superpoder,Nivel,Retirado,Correo,Fechanac,Altura,Peso) " +
                    "values (@id,@nombre,@superpoder,@nivel,@retirado,@correo,@fechanac,@altura,@peso)",cnn);
                cmdSql.Parameters.AddWithValue("@id",heroe.Id);
                cmdSql.Parameters.AddWithValue("@nombre",heroe.Nombre);
                cmdSql.Parameters.AddWithValue("@superpoder",heroe.Superpoder);
                cmdSql.Parameters.AddWithValue("@nivel",heroe.Nivel);
                cmdSql.Parameters.AddWithValue("@retirado",heroe.Retirado);
                cmdSql.Parameters.AddWithValue("@correo",heroe.Correo);
                cmdSql.Parameters.AddWithValue("@fechanac",heroe.FechaNac);
                cmdSql.Parameters.AddWithValue("@altura",heroe.Altura);
                cmdSql.Parameters.AddWithValue("@peso",heroe.Peso);
                
                
                return cmdSql.ExecuteNonQuery();
            }
        }


        //TODO: creacion metodo update
        public int editarHeroe(Heroe h) {
            String cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(cnnStr)) {
                cnn.Open();

                SqlCommand cmdSql = new SqlCommand("update Heroes " +
                    "set Nombre=@nombre, Superpoder=@superpoder, Nivel=@nivel, Retirado=@retirado, Correo=@correo, Fechanac=@fechanac, Altura=@altura, Peso=@peso " +
                    "where Id = @id",cnn);
                cmdSql.Parameters.AddWithValue("@id", h.Id);
                cmdSql.Parameters.AddWithValue("@nombre", h.Nombre);
                cmdSql.Parameters.AddWithValue("@superpoder", h.Superpoder);
                cmdSql.Parameters.AddWithValue("@nivel", h.Nivel);
                cmdSql.Parameters.AddWithValue("@retirado", h.Retirado);
                cmdSql.Parameters.AddWithValue("@correo", h.Correo);
                cmdSql.Parameters.AddWithValue("@fechanac", h.FechaNac);
                cmdSql.Parameters.AddWithValue("@altura", h.Altura);
                cmdSql.Parameters.AddWithValue("@peso", h.Peso);

                return cmdSql.ExecuteNonQuery();
            }

                
        }

        //TODO: creacion metodo delete
        public int eliminarHeroe(int id) {
            String cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(cnnStr)) {
                cnn.Open();

                SqlCommand cmdSql = new SqlCommand("delete from Heroes where id = @id",cnn);
                cmdSql.Parameters.AddWithValue("@id", id);

                return cmdSql.ExecuteNonQuery();
            }
        }
    }
}