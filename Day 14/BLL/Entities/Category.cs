﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }

        public required string CategoryName { get; set; }
    }
}
