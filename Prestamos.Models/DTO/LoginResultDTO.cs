﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Models.DTO
{
    public class LoginResultDTO
    {
        public bool Result { get; set; }
        public string Mensaje { get; set; }
        public string Rol { get; set; }
    }
}
