﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store2.Domain
{
    public class PropertyStoreModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string value { get; set; }  

        public string imageUrl { get; set; }
    }
}
