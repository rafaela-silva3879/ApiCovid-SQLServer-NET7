﻿using ApiCovid.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCovid.Domain.Interfaces.Security
{
    public interface ITokenSecurity
    {
        string CreateToken(Solicitante solicitante);
    }
}
