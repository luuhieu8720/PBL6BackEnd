﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBL6BackEnd.Config
{
    public class TokenConfig
    {
        public string Key { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string Subject { get; set; }
    }
}
