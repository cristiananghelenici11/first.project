﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace Relationships.DAL.Models
{
    public abstract class Mark : Entity
    {
        public double Value { get; set; }
    }
}
