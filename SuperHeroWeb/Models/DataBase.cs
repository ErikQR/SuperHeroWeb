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
                        dr["Fechanac"].ToString().AsDateTime(), dr["Altura"].ToString().AsFloat(), dr["Peso"].ToString().AsFloat()));
                }
                cnn.Close();
                cnn.Dispose();
            }

                return losHeroes;
        }
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
                        dr["Fechanac"].ToString().AsDateTime(), dr["Altura"].ToString().AsFloat(), dr["Peso"].ToString().AsFloat());
                }
                cnn.Close();
                cnn.Dispose();

            }

                return hero;
        }
        //TODO: Busqueda de heroes segun id


        //TODO: creacion de metodo create


        //TODO: creacion metodo read


        //TODO: creacion metodo update


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