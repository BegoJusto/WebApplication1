using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DAL

{
    public class Usuario
    {
        private Guid _codigoUsuario;
        private string _nombre;
        private string _apellidos;
        private DateTime _fNacimiento;
        private string _mail;
        private string _userid;

        public Usuario()
        {
            _codigoUsuario = new Guid("-1");
            _nombre = "";
            _apellidos = "";
            _fNacimiento = new DateTime();
            _mail = "";
        }

        public Guid CodigoUsuario
        {
            get
            {
                return _codigoUsuario;
            }

            set
            {
                _codigoUsuario = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }

        public string Apellidos
        {
            get
            {
                return _apellidos;
            }

            set
            {
                _apellidos = value;
            }
        }

        public DateTime FNacimiento
        {
            get
            {
                return _fNacimiento;
            }

            set
            {
                _fNacimiento = value;
            }
        }
    }
}