﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entites
{
    public class Department:BaseEntity
    {
        public string? Name { get; set; }

        public DateOnly DateOfCreation { get; set; }
    }
}
