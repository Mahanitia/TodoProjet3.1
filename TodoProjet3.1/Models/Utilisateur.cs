using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoProjet3._1.Models
{
    public class Utilisateur
    {
        private int _idname;
        private string _name;
        private string _password;

        public Utilisateur(string name, string password)
        {
            _name = name;
            _password = password;
        }
        public Utilisateur() { }
        public Utilisateur(int idname, string name, string password)
        {
            _idname = idname;
            _name = name;
            _password = password;
        }

        public int Idname { get => _idname; set => _idname = value; }
        public string Name { get => _name; set => _name = value; }
        public string Password { get => _password; set => _password = value; }
    }
}