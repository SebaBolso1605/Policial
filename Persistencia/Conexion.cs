﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    internal class Conexion
    {

        //Para SQL Sebastián
        //private static string _cnn = "Data Source=SEBABOLSO1605\\SQLEXPRESS; Initial Catalog = Policial; Integrated Security = true";

        //Para SQL Fernando
        private static string _cnn = "Data Source=.; Initial Catalog = Policial; Integrated Security = true";


        public static string Cnn
        {
            get { return _cnn; }
        }

        private static string _servidor = ".";
        public static string Servidor
        {
            get { return _servidor; }
        }
    }
}