﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModule.Models
{
    public class Account
    {
        int Id { get; set; }
        public string Name { get; set; }    
        public string Password { get; set; }    
    }
}
