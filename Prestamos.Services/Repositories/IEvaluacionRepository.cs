﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Services.Repositories
{
    public interface IEvaluacionRepository
    {
        public Task<bool> EvaluarSolicitud(int dni);
    }
}
