using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SuperHeroWeb.Models
{
    public class DataBase
    {

        //TODO: Obtencion de heroes desde la bd
        private List<Heroe> ObtenerHeroes() { 
            List<Heroe> losHeroes = new List<Heroe>();
            String cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(cnnStr)) { 
                cnn.Open();

                SqlCommand cmdSql = new SqlCommand("Select * from Heroes order by Id", cnn);

                SqlDataReader dr = cmdSql.ExecuteReader();


                while (dr.Read()) {
                    //losHeroes.Add(new Heroe(dr.GetInt32(0), dr["Nombre"].ToString(), dr["Superpoder"].ToString(),dr.GetInt32(0),));
                }
            }

                return losHeroes;
        }

        //TODO: Busqueda de heroes segun id
        
        
        //TODO: creacion de metodo create


        //TODO: creacion metodo read


        //TODO: creacion metodo update


        //TODO: creacion metodo delete

    }
}