using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraLibrary;

namespace TerraLibrary
{
    [Serializable]
    public class SaveObject
    {
        public TimeController TimeController { get; set; }
        public Terrarium Terrarium { get; set; }
        public TerrariumSettings TerrariumSettings { get; set; }
        public SaveObject(Terrarium terrarium, TimeController timeController, TerrariumSettings terrariumSettings)
        {
            Terrarium = terrarium;
            TimeController = timeController;
            TerrariumSettings = terrariumSettings;
        }
    }
}
