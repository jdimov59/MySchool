﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class BaseHoursModel
    {
        public int Id { get; set; }

        public string Hours { get; set; }

        public string Start { get; set; }

        public string End { get; set; }
    }
}