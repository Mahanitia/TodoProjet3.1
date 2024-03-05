using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoProjet3._1.Models
{
    public class Utilisateur
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _username;
        private string _password;


        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public Utilisateur(string username, string password)
        {
            _username = username;
            _password = password;
        }
        public Utilisateur() { }

    }
}