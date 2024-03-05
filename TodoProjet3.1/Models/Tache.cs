using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoProjet3._1.Models
{
    public class Tache
    {
        private int _idtache;
        private string _username;
        private string _description;
        private bool _state;

        public bool State
        {
            get { return _state; }
            set { _state = value; }
        }


        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }


        public string Tachename
        {
            get { return _username; }
            set { _username = value; }
        }


        public int id
        {
            get { return _idtache; }
            set { _idtache = value; }
        }

        public Tache() { }

        public Tache(string tachename, string description, bool state)
        {
            _username = tachename;
            _description = description;
            _state = state;
        }

        public Tache(int id, string tachename, string description, bool state)
        {
            _idtache = id;
            _username = tachename;
            _description = description;
            _state = state;
        }
    }
}