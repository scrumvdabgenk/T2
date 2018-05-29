﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public interface IDisaster
    {
        Position Position { get; set; }
        void ActivateAndKillOrganisms(Terrarium terrarium, TimeController timeController);
        
    }
}
