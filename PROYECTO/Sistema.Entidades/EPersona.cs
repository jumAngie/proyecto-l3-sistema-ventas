﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entidades
{
    public class EPersona
    {
        public int idpersona { get; set; }
        public string tipo_persona {  get; set; }
        public string nombre { get; set; }
        public string Tipo_documento { get; set; }
        public string num_documento { get; set; }
        public string direccion     { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
    }
}
