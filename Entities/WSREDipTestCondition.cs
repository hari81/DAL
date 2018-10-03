﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace DAL
{
    public class WSREDipTestCondition
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Colour { get; set; }
    }
}