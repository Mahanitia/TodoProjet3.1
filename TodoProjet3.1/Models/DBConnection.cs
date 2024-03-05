using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TodoProjet3._1.Models
{
    public class DBConnection
    {
        public static NpgsqlConnection connectionString =
             new NpgsqlConnection(
                 ConfigurationManager.ConnectionStrings["TodoDatabaseConnection"].ConnectionString
                 );

        public static bool VerifierUtilisateur(Utilisateur utilisateur)
        {

            var req = $"SELECT * FROM public.\"user\" WHERE username ='{utilisateur.Username}' AND \"password\"='{utilisateur.Password}'";
            var hasUser = false;

            try
            {
                connectionString.Open();
                var cmd = new NpgsqlCommand(req, connectionString);
                var reader = cmd.ExecuteReader();
                hasUser = reader.HasRows;
                connectionString.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return hasUser;
        }
    }
}