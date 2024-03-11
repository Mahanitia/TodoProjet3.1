using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace TodoProjet3._1.Models
{
    public class DBConnection
    {
        public static NpgsqlConnection connectionString =
           new NpgsqlConnection(ConfigurationManager.ConnectionStrings["TodoDBConnection"].ConnectionString);

        public static bool VerifierUtilisateur(Utilisateur utilisateur)
        {

            var req = $"SELECT * FROM public.\"user\" WHERE username ='{utilisateur.Username}' AND \"password\"='{utilisateur.Password}'";
            var hasUser = false ;

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

        public static void AjoutTache(Tache tache)
        {
            var req = "INSERT INTO public.todolist ( description, username , state) VALUES ( '" + tache.Description + "','" + tache.Username + "', '" + tache.State + "')";

            try
            {
                connectionString.Open();
                var cmd = new NpgsqlCommand(req, connectionString);
                cmd.ExecuteNonQuery();
                connectionString.Close();
            }
            catch (Exception ex) { throw ex; }
        }

        public static void AjoutUtilisateur(Utilisateur utilisateur)
        {
            var req = $"INSERT INTO public.user(username, password) VALUES('{utilisateur.Username}','{utilisateur.Password}')";
            try
            {
                connectionString.Open();
                var cmd = new NpgsqlCommand(req, connectionString);
                cmd.ExecuteNonQuery();
                connectionString.Close();

            }
            catch (Exception ex) { throw ex; }
        }

        public static List<Tache> RetrouverTaches(string utilisateur)
        {
            var req = "SELECT * FROM public.todolist WHERE username = '"+utilisateur + "' ORDER BY idtache";
            var hasTask = new List<Tache>();

            try
            {
                connectionString.Open();
                var cmd = new NpgsqlCommand(req, connectionString);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var Task = new Tache(reader.GetInt32(0), reader["username"].ToString(), reader["description"].ToString(), reader.GetBoolean(3));
                    hasTask.Add(Task);
                }
                connectionString.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return hasTask;
        }
        public static void SupprimerTache(int idTache)
        {
            var req = $"DELETE FROM public.todolist WHERE idtache = {idTache}";

            try
            {
                connectionString.Open();
                var cmd = new NpgsqlCommand(req, connectionString);
                cmd.ExecuteNonQuery();
                connectionString.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ModifierTache(int idTache , Tache tache)
        {
            var req = "UPDATE public.todolist SET description= '"+tache.Description+"' , state= '"+tache.State+"'  WHERE idtache = '" + idTache+"'";

            try
            {
                connectionString.Open();
                var cmd = new NpgsqlCommand(req, connectionString);
                cmd.ExecuteNonQuery();
                connectionString.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}