﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaysData
{
    public class Number
    {
        [Key]
        public int ID { get; set;}
        public int Value { get; set; }
    }
}
