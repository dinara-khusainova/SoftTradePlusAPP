﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTradePlusAPP.Model
{
    public class Manager
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public List<Client> Clients { get; set; } 
    }
}
