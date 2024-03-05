using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoProjet3._1.Models
{
    public class Utilisateur
    {
        private int _idname;
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _username;
        private string _password;

        public Utilisateur(string name, string password)
        {
            _username = name;
            _password = password;
        }
        public Utilisateur() { }
        public Utilisateur(int idname, string name, string password)
        {
            _idname = idname;
            _username = name;
            _password = password;
        }

        public int Idname { get => _idname; set => _idname = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
    }
}