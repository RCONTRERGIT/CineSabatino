﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemex.Cartelera.Data
{
    public class DatAbstracta
    {
        public SqlConnection con;
        public DatAbstracta()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Cine"].ConnectionString);
        }
    }
}
