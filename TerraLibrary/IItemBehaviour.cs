using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraLibrary
{
    public interface IItemBehaviour
    {
        void ItemAction(ITerrariumItem[,] terrariumItems);
    }
}
