using Dojon.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojon.Items
{
    interface IUsable
    {
        void Use(Creature creature);
    }
}
