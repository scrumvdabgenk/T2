﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam2
{
    public class Terrarium
    {
        public List<ITerrariumItem> ListTerrariumItems { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
    }
}
