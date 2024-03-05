﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TodoProjet3._1.Models
{
    public class DBConnection
    {
        public static NpgsqlConnection connectionString = new NpgsqlConnection(
    ConfigurationManager.ConnectionStrings["TodoDBConnection"].ConnectionString);

        public static void AjoutUtilisateur(Utilisateur utilisateur)
        {
            var req = $"INSERT INTO public.user(username, password) VALUES('{utilisateur.Name}','{utilisateur.Password}')";
            try
            {
                connectionString.Open();
                var cmd = new NpgsqlCommand(req, connectionString);
                cmd.ExecuteNonQuery();
                connectionString.Close();

            }
            catch (Exception ex) { throw ex; }
        }
    }
}